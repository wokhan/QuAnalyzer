using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Controls.Primitives;

using System.Linq.Dynamic.Core;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class PatternsPage : Page
{
    private List<string> stringAttributes;

    public int SimThreshold { get; set; }
    public bool AutoUpdate { get; set; }

    [ObservableProperty]
    private string status;

    public PatternsPage()
    {
        InitializeComponent();

        App.Instance.PropertyChanged += (s, e) => { if (e.PropertyName == nameof(App.CurrentSelection)) { UpdateSelection(); } };

        UpdateSelection();
    }

    private async void UpdateSelection()
    {
        RunCommand.NotifyCanExecuteChanged();

        var (prov, repo) = App.Instance.CurrentSelection;
        var attr = (string)lstAttributes.SelectedValue;

        if (repo is not null && attr is null)
        {
            stringAttributes = prov.GetColumns(repo).Where(h => h.Type == typeof(string)).Select(h => h.Name).ToList();
            lstAttributes.ItemsSource = stringAttributes;
        }
        else if (AutoUpdate)
        {
            await RunCommand.ExecuteAsync(null);
            //await Run().ConfigureAwait(false);
        }
    }

    [RelayCommand(AllowConcurrentExecutions = false, CanExecute = nameof(CanExecuteRun))]
    private async Task Run()
    {
        var (prov, repo) = App.Instance.CurrentSelection;
        var attr = (string)lstAttributes.SelectedValue;

        prg.IsIndeterminate = true;

        var res = await Task.Run(() =>
        {
            var data = prov.GetQueryable(repo)
                           .Select(attr)
                           .AsEnumerable()
                           .WithProgress(i => { Status = $"Loaded {i} entries..."; })
                           .Select(a => a.ToString())
                           .ToList();

            DispatcherQueue.TryEnqueue(() =>
            {
                prg.IsIndeterminate = false;
                prg.Maximum = data.Count;
            });

            return data.WithProgress(i => DispatcherQueue.TryEnqueue(() => prg.Value = i))
                       .Select(d => new { val = d, reg = Features.Patterns.Patterns.GetRegEx(d, SimThreshold) })
                       .ToList()
                       .GroupBy(s => s.reg)
                       .Select(g => new { Pattern = g.Key, Count = g.Count(), Sample = g.First().val })
                       .OrderByDescending(g => g.Count);
        }).ConfigureAwait(true);

        //gridPatterns.CustomHeaders = prov.GetColumns(repo).Join(stringAttributes, a => a.Name, b => b, (a, b) => a).ToList();
        DispatcherQueue.TryEnqueue(() => gridPatterns.ItemsSource = res);
        /*}
        else
        {
            //gridPatterns.CustomHeaders = null;
            gridPatterns.Source = null;
        }*/
    }

    private bool CanExecuteRun => lstAttributes?.SelectedItems.Count > 0;

    private void lstDataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSelection();
    }

    private void slideSim_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        SimThreshold = (int)e.NewValue;
        if (gridPatterns is not null)
        {
            UpdateSelection();
        }
    }
}
