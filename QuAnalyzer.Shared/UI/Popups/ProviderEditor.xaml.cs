﻿
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;
using Microsoft.Win32;

using QuAnalyzer.UI.Windows;

using System.Diagnostics.Contracts;

using Wokhan.Data.Providers;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Pages;

[ObservableObject]
public partial class ProviderEditor : Page
{
    public class CustomDataTemplateSelector : DataTemplateSelector
    {
        private DataTemplate defaultTemplate;
        private DataTemplate fileTemplate;
        private DataTemplate listTemplate;
        private DataTemplate booleanTemplate;

        public CustomDataTemplateSelector(DataTemplate defaultTemplate, DataTemplate fileTemplate, DataTemplate listTemplate, DataTemplate booleanTemplate)
        {
            this.defaultTemplate = defaultTemplate;
            this.fileTemplate = fileTemplate;
            this.listTemplate = listTemplate;
            this.booleanTemplate = booleanTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var definition = item as DataProviderMemberDefinition;
            if (definition.IsFile)
            {
                return fileTemplate;
            }

            if (definition.MemberType == typeof(bool))
            {
                return booleanTemplate;
            }

            if (definition.HasValuesGetter)
            {
                return listTemplate;
            }

            return defaultTemplate;
        }
    }

    private CustomDataTemplateSelector TemplateSelector;

    [ObservableProperty]
    private IDataProvider _currentProvider;

    private IList<IGrouping<string, DataProviderMemberDefinition>> expParameters = null;

    public IList<IGrouping<string, DataProviderMemberDefinition>> ExpParameters
    {
        get
        {
            if (expParameters is null)
            {
                expParameters = DataProviders.GetParameters(CurrentProvider);
                NotifyPropertyChanged(nameof(HasMultipleItems));
            }
            return expParameters;
        }
    }

    private bool isNewProvider;

    public bool HasMultipleItems => (expParameters?.Count > 1);

    protected void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

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

        if (e.Parameter is string)
        {
            isNewProvider = true;
            CurrentProvider = DataProviders.CreateInstance((string)e.Parameter, new Dictionary<string, object>());
        }
        else
        {
            CurrentProvider = (IDataProvider)e.Parameter;
        }
    }

    private void ProviderEditor_Loaded(object sender, RoutedEventArgs e)
    {
        GenericPopup.UpdateCurrent(this, nextButtonCommand: ShowRepositoryPickerCommand);

        if (!isNewProvider)
        {
            GenericPopup.UpdateCurrent(this, title: CurrentProvider.Name);
        }
    }

    [RelayCommand]
    private void ShowRepositoryPicker()
    {
        Frame.Navigate(typeof(ProviderEditorRepositories), CurrentProvider);
    }

    public ProviderEditor()
    {
        this.Loaded += ProviderEditor_Loaded;

        InitializeComponent();

        TemplateSelector = new(DefaultTemplate, FileTemplate, ListTemplate, BooleanTemplate);
    }

    public void rdb_Checked(object sender, RoutedEventArgs e)
    {
        Contract.Requires(sender is not null);

        if (((RadioButton)sender).IsChecked is true)
        {
            CurrentProvider.SelectedGroups.Add(((RadioButton)sender).Name);
        }
        else
        {
            CurrentProvider.SelectedGroups.Remove(((RadioButton)sender).Name);
        }
    }

    /*private void btnNewPrv_Click(object sender, RoutedEventArgs e)
    {
        CurrentProvider = (IDataProvider)Activator.CreateInstance(DataProvider.AllProviders.First().Type);
        CurrentProvider.Name = "Provider #" + (lstProviders.Items.Count + 1);

        App.Current.CurrentProject.CurrentProviders.Add(CurrentProvider);

        fillProvider();
    }*/


    [RelayCommand]
    private void Test()
    {
        string res;
        txtTestResult.Text = "Testing...";
        CurrentProvider.Test(out res);
        //TODO: check if TestCommand has a Result property to return this instead.
        txtTestResult.Text = res;
    }

    [RelayCommand]
    private void ShowFileDialog(DataProviderMemberDefinition definition)
    {
        var dial = new OpenFileDialog() { CheckFileExists = true, ValidateNames = true, AddExtension = true, Filter = definition.FileFilter };
        if (dial.ShowDialog().Value)
        {
            definition.ValueWrapper = dial.FileName;
        }
    }
}
