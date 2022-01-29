using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Comparison.Comparers;

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Threading;

using Wokhan.Data.Providers.Bases;

using LExpr = System.Linq.Expressions;

namespace QuAnalyzer.UI.Pages;

/// <summary>
/// Logique d'interaction pour DataViewer.xaml
/// </summary>
public partial class Duplicates : Page, INotifyPropertyChanged
{

    private bool _keepDuplicates;
    public bool KeepDuplicates
    {
        get { return _keepDuplicates; }
        set { _keepDuplicates = value; NotifyPropertyChanged(); }
    }

    private bool _keepColumns = true;
    public bool KeepColumns
    {
        get { return _keepColumns; }
        set { _keepColumns = value; NotifyPropertyChanged(); }
    }

    public Duplicates()
    {
        InitializeComponent();

        ((App)App.Instance).PropertyChanged += App_PropertyChanged;
    }

    private void App_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(App.CurrentSelection))
        {
            var (prov, repo) = ((App)App.Instance).CurrentSelection;
            if (prov is not null)
            {
                lstColumns.ItemsSource = prov.GetColumns(repo);
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Turns a generic <see cref="IEnumerable"/> into an object[] enumeration (each property being mapped into the array)
    /// </summary>
    /// <param name="src">Source enumeration</param>
    /// <param name="properties">Name of the properties to use to populate the array</param>
    /// <returns></returns>
    public static IEnumerable<object[]> AsObjectCollection(IEnumerable src, params string[] properties)
    {
        return AsObjectCollection(src.Cast<object>(), properties);
    }

    /// <summary>
    /// Turns a generic <see cref="IEnumerable{T}"/> into an object[] enumeration (each property being mapped into the array)
    /// </summary>
    /// <param name="src">Source enumeration</param>
    /// <param name="properties">Name of the properties to use to populate the array</param>
    /// <returns></returns>
    public static IEnumerable<object[]> AsObjectCollection<T>(IEnumerable<T> src, params string[] properties)
    {
        Contract.Requires(src is not null);

        var innertype = src.GetInnerType();
        if (innertype.IsArray)
        {
            return ((IEnumerable<object[]>)src);
        }
        else
        {

            if (properties is null)
            {
                properties = innertype.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(a => a.Name).ToArray();
            }

            var param = LExpr.Expression.Parameter(typeof(object));
            var expa = LExpr.Expression.Parameter(typeof(Exception));
            var ide_cstr = typeof(InvalidDataException).GetConstructor(new[] { typeof(string), typeof(Exception) });

            var casted = LExpr.Expression.Convert(param, innertype);

            Func<string, LExpr.Expression> propertyGet = a => LExpr.Expression.Property(casted, a);
            // Assuming dynamic...
            /*if (innertype == typeof(object))
            {

                propertyGet = a =>
                {
                    var binder = Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, a, innertype, new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
                    return Expression.Dynamic(binder, innertype, casted);
                };
            }
            else
            {
                propertyGet = a => Expression.Property(casted, a);
            }*/
            var atrs = properties.Select(a =>
                LExpr.Expression.TryCatch(
                    LExpr.Expression.Block(
                        LExpr.Expression.Convert(propertyGet(a), typeof(object))
                    ),
                LExpr.Expression.Catch(expa,
                    LExpr.Expression.Block(
                        LExpr.Expression.Throw(LExpr.Expression.New(ide_cstr, LExpr.Expression.Constant(a), expa)),
                        LExpr.Expression.Constant(null))))
            ).ToList();

            var attrExpr = LExpr.Expression.Lambda<Func<T, object[]>>(LExpr.Expression.NewArrayInit(typeof(object), atrs), param).Compile();

            //return src.Select(x => { if (x is null) { throw new Exception("Should never get there."); } return attrExpr(x); });
            return src.Select(x => attrExpr(x));
        }
    }

    private async void btnRun_Click(object sender, RoutedEventArgs e)
    {
        var (prov, repository) = ((App)App.Instance).CurrentSelection;

        var allHeadersFu = prov.GetColumns(repository);
        string[] keys;
        string[] headers;
        if (lstColumns.SelectedItems.Count > 0)
        {
            keys = lstColumns.SelectedItems.Cast<ColumnDescription>().Select(c => c.Name).ToArray();
            headers = allHeadersFu.OrderBy(h => keys.Contains(h.Name) ? 0 : 1).Select(h => h.Name).ToArray();
        }
        else
        {
            headers = allHeadersFu.Select(h => h.Name).ToArray();
            keys = headers;
        }

        await Task.Run(() =>
        {
            gridData.LoadingProgress = -1;
            gridData.Status = "Loading data...";

            var data = prov.GetQueryable(repository);//.Select<dynamic>(headers);

            gridData.LoadingProgress = -1;

            //TODO: move
            //TODO: performance is now awful?! Use proxy object instead?
            void updateStatusLoad(double i) => Dispatcher.InvokeAsync(() => gridData.Status = $"Parsed {i} entries");


            //var dataObjectArray = ComparerDefinition<object[]>.ToObjectArrays(data)
            IEnumerable<object> dataObjectArray = AsObjectCollection(data, KeepDuplicates ? headers : keys)
                                      .OrderByAll()
                                      .WithProgress(updateStatusLoad);

            gridData.LoadingProgress = -1;

            var ret = Comparison.GetDuplicates(dataObjectArray, keys, (IComparer<object>)SequenceEqualityComparer<IEnumerable<object>, object>.Default, true).Duplicates;

            var keyComparer = new SequenceEqualityComparer<IEnumerable<object>, object>(0, keys.Length);
            if (!KeepDuplicates)
            {
                ret = ret.Distinct((IEqualityComparer<object>)keyComparer).ToList();
            }

            Dispatcher.InvokeAsync(() =>
            {
                displayData(ret, headers, keys.Length);
                //gridData.ItemsSource = ret.Duplicates;
                //gridData.Columns.Single(c => c.SortMemberPath == SortOrder).SortDirection = (currentSortDirectionAsc ? ListSortDirection.Ascending : ListSortDirection.Descending);
            });

            gridData.LoadingProgress = 100;
        }).ConfigureAwait(false);
    }


    private void displayData(IEnumerable<object> data, string[] headers, int keysCount)
    {
        gridData.Columns.Clear();

        gridData.AutoGenerateColumns = false;

        var count = (KeepColumns && KeepDuplicates ? headers.Length : keysCount);
        gridData.CustomHeaders = headers.Take(count).Select(h => new ColumnDescription { Name = h, DisplayName = h }).ToList();

        if (data is not null && data.Any())
        {
            gridData.Columns.AddAll(headers.Take(count).Select((h, i) => new DataGridTextColumn() { Header = h, Binding = new Binding("[" + i + "]") }));
            gridData.Source = data.AsQueryable();
        }
        else
        {
            gridData.Source = null;
        }
    }
}
