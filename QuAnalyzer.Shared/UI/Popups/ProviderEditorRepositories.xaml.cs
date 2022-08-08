
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.UI.Windows;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class ProviderEditorRepositories : Page
{
    public string MessageTitle { get; set; }
    public string MessageContent { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CurrentType))]
    private IDataProvider _currentProvider;

    public DataProviderDefinition CurrentType => CurrentProvider.Definition;

    public class RepositoryView
    {
        public bool Selected { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public ObservableCollection<RepositoryView> Repositories { get; } = new ObservableCollection<RepositoryView>();

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        CurrentProvider = (IDataProvider)e.Parameter;

        fillProvider();
    }

    private void ProviderEditor_Loaded(object sender, RoutedEventArgs e)
    {
        GenericPopup.UpdateCurrent(this, nextButtonCommand: SaveCommand, isLastStep: true);
    }

    public ProviderEditorRepositories()
    {
        Repositories.CollectionChanged += Repositories_CollectionChanged;

        this.Loaded += ProviderEditor_Loaded;

        InitializeComponent();

    }

    private void Repositories_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ClearCommand.NotifyCanExecuteChanged();
        SelectAllCommand.NotifyCanExecuteChanged();
        ClearSelectionCommand.NotifyCanExecuteChanged();

        if (e.NewItems is not null)
        {
            foreach (RepositoryView repo in e.NewItems)
            {
                CurrentProvider.InvalidateColumnsCache(repo.Key);
            }
        }

        if (e.OldItems is not null)
        {
            foreach (RepositoryView repo in e.OldItems)
            {
                CurrentProvider.InvalidateColumnsCache(repo.Key);
            }
        }
    }

    private void fillProvider()
    {
        if (CurrentProvider.Repositories is not null)
        {
            foreach (var r in CurrentProvider.Repositories)
            {
                Repositories.Add(new RepositoryView() { Key = r.Key, Value = r.Value, Selected = true });
            }
        }
    }

    bool stopAction;

    [RelayCommand(AllowConcurrentExecutions = false)]
    private async Task Retrieve()
    {
        MessageTitle = "Please wait";
        MessageContent = "Retrieving repositories...";

        string res = null;
        try
        {
            await Task.Run(() =>
            {
                var reps = CurrentProvider.GetDefaultRepositories().OrderBy(r => r.Key).Select(r => new RepositoryView() { Key = r.Key, Value = r.Value, Selected = true });
                foreach (var r in reps)
                {
                    DispatcherQueue.TryEnqueue(() => Repositories.Add(r));

                    if (stopAction)
                    {
                        break;
                    }
                }
            });

            MessageTitle = null;
        }
        catch (Exception exc)
        {
            res = exc.Message;
            /*msg.SetMessage(exc.Message);
            msg.SetProgress(0);
            msg.SetTitle("Unexpected error");*/
        }

        if (res is not null)
        {
            MessageTitle = "Unexpected error";
        }
        /*catch (Exception exc)
        {
            ForceDialog("Something went wrong (and this message will get better later). Press OK to continue.", "Unexpected error");
        }*/
    }

    public bool CanExecuteRepositoriesCommands => Repositories.Any();

    [RelayCommand(CanExecute = nameof(CanExecuteRepositoriesCommands))]
    private void Clear()
    {
        Repositories.Clear();
    }


    [RelayCommand(CanExecute = nameof(CanExecuteRepositoriesCommands))]
    private void SelectAll()
    {
        foreach (var r in Repositories)
        {
            r.Selected = true;
        }
    }


    [RelayCommand(CanExecute = nameof(CanExecuteRepositoriesCommands))]
    private void ClearSelection()
    {
        foreach (var r in Repositories)
        {
            r.Selected = false;
        }
    }

    [RelayCommand]
    private void RepositoryAdd()
    {
        Repositories.Add(new RepositoryView() { Key = "Repository #" + (Repositories.Count + 1), Selected = true });
    }

    [RelayCommand]
    private void ProviderDelete(IDataProvider provider)
    {
        App.Instance.CurrentProject.CurrentProviders.Remove(provider);
    }

    [RelayCommand]
    private void RepositoryDelete(RepositoryView item)
    {
        Repositories.Remove(item);
    }


    [RelayCommand]
    private void Save()
    {
        CurrentProvider.Repositories = Repositories.Where(r => r.Selected).ToDictionary(r => r.Key, r => r.Value);

        if (!App.Instance.CurrentProject.CurrentProviders.Contains(CurrentProvider))
        {
            App.Instance.CurrentProject.CurrentProviders.Add(CurrentProvider);
        }
    }
}
