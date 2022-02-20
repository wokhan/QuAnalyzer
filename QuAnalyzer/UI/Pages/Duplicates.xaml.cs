using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;

using System.Diagnostics.Contracts;
using System.Windows.Data;
using System.Windows.Threading;

using Wokhan.Data.Providers.Bases;
using CommunityToolkit.Mvvm.Input;
using System.Linq.Dynamic.Core;

using LinqExpression = System.Linq.Expressions.Expression;
using System.Reflection;
using QuAnalyzer.Core.Helpers;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class Duplicates : Page
{

    [ObservableProperty]
    private bool _keepDuplicates;


    [ObservableProperty]
    private bool _keepColumns = true;

    public Duplicates()
    {
        InitializeComponent();

        App.Instance.PropertyChanged += App_PropertyChanged;
        lstColumns.SelectionChanged += LstColumns_SelectionChanged;
    }

    private void LstColumns_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        RunCommand.NotifyCanExecuteChanged();
    }

    private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(App.CurrentSelection))
        {
            var (prov, repo) = App.Instance.CurrentSelection;
            if (prov is not null)
            {
                lstColumns.ItemsSource = prov.GetColumns(repo);
            }
        }
    }

    /// <summary>
    /// Turns a generic <see cref="IEnumerable"/> into an object[] enumeration (each property being mapped into the array)
    /// </summary>
    /// <param name="src">Source enumeration</param>
    /// <param name="properties">Name of the properties to use to populate the array</param>
    /// <returns></returns>
    public static IEnumerable<object[]> AsObjectCollection(IQueryable src, params string[] properties)
    {
        var innertype = src.ElementType;

        //TODO: rename the other method to get the right one directly
        var m = typeof(Duplicates).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(method => method.IsGenericMethod && method.Name == nameof(AsObjectCollection)).First().MakeGenericMethod(innertype);
        return (IEnumerable<object[]>)m.Invoke(null, new object[] { src, properties });
    }

    /// <summary>
    /// Turns a generic <see cref="IEnumerable{T}"/> into an object[] enumeration (each property being mapped into the array)
    /// </summary>
    /// <param name="src">Source enumeration</param>
    /// <param name="properties">Name of the properties to use to populate the array</param>
    /// <returns></returns>
    public static IEnumerable<object[]> AsObjectCollection<T>(IQueryable<T> src, params string[] properties)
    {
        ArgumentNullException.ThrowIfNull(src);

        //if (typeof(T).IsArray)
        //{
        //    return ((IEnumerable<object[]>)src);
        //}
        //else
        {
            if (properties is null)
            {
                properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToArray();
            }

            var map = GetExpression<T>(properties);

            //TODO: Test with actual IQueryable implementation like LinqToSQL...
            return src.Select(x => map(x));

            //var param = LExpr.Expression.Parameter(typeof(object));
            //var expa = LExpr.Expression.Parameter(typeof(Exception));
            //var ide_cstr = typeof(InvalidDataException).GetConstructor(new[] { typeof(string), typeof(Exception) });

            //var casted = LExpr.Expression.Convert(param, innertype);

            //Func<string, LExpr.Expression> propertyGet = a => LExpr.Expression.Property(casted, a);
            //var atrs = properties.Select(a =>
            //    LExpr.Expression.TryCatch(
            //        LExpr.Expression.Block(
            //            LExpr.Expression.Convert(propertyGet(a), typeof(object))
            //        ),
            //    LExpr.Expression.Catch(expa,
            //        LExpr.Expression.Block(
            //            LExpr.Expression.Throw(LExpr.Expression.New(ide_cstr, LExpr.Expression.Constant(a), expa)),
            //            LExpr.Expression.Constant(null))))
            //).ToList();

            //var attrExpr = LExpr.Expression.Lambda<Func<T, object[]>>(LExpr.Expression.NewArrayInit(typeof(object), atrs), param).Compile();

            ////return src.Select(x => { if (x is null) { throw new Exception("Should never get there."); } return attrExpr(x); });
            //return src.Select(x => attrExpr(x));
        }
    }

    private static Func<T, object[]> GetExpression<T>(params string[] properties)
    {
        var param = LinqExpression.Parameter(typeof(T));
        var propertyGetExpression = properties.Select(property => LinqExpression.Convert(LinqExpression.Property(param, property), typeof(object))).ToArray();
        return LinqExpression.Lambda<Func<T, object[]>>(LinqExpression.NewArrayInit(typeof(object), propertyGetExpression), param).Compile();
    }

    [ICommand(AllowConcurrentExecutions = false, CanExecute = nameof(CanExecuteRun))]
    private async Task Run()
    {
        var (prov, repository) = App.Instance.CurrentSelection;

        var columns = prov.GetColumns(repository);
        string[] keys;
        string[] headers;
        if (lstColumns.SelectedItems.Count > 0)
        {
            keys = lstColumns.SelectedItems.Cast<ColumnDescription>().Select(c => c.Name).ToArray();
            headers = columns.OrderBy(h => keys.Contains(h.Name) ? 0 : 1).Select(h => h.Name).ToArray();
        }
        else
        {
            headers = columns.Select(h => h.Name).ToArray();
            keys = headers;
        }
            
        var progressCallback = new Progress<int>((i) => gridData.Status = $"Checked {i} entries");
            
        gridData.LoadingProgress = -1;

        await Task.Run(() =>
        {
            
            var data = prov.GetQueryable(repository);

            var keysAsString = String.Join(",", keys);

            if (!KeepDuplicates)
            {
                data = data.Select($"new({keysAsString})");
            }

            // Ordering by selected columns is required for comparison as items need to be sorted first.
            data = data.OrderBy(keysAsString);

            var comparer = DynamicComparer.Create(data.ElementType, keys);

            var duplicates = GenericMethodHelper.InvokeGenericStatic<IEnumerable>(typeof(Comparison), nameof(Comparison.GetDuplicates), new[] { data.ElementType }, data, keys, comparer, progressCallback);

            gridData.Source = duplicates.AsQueryable();

            gridData.LoadingProgress = 100;
        }).ConfigureAwait(false);
    }

    private bool CanExecuteRun => lstColumns?.SelectedItems.Count > 0;
}
