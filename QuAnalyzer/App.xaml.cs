using Microsoft.Win32;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.UI.Windows;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Wokhan.Data.Providers.Contracts;
using Wokhan.UI.Diagnostics;

namespace QuAnalyzer;

/// <summary>
/// 
/// </summary>
public partial class App : INotifyPropertyChanged
{
    public static App Instance => (App)Current;

    public List<SolidColorBrush> AvailableColors { get; } = new List<SolidColorBrush> {
            new SolidColorBrush(Color.FromRgb(0x41, 0xB1, 0xE1)),
            new SolidColorBrush(Colors.LightCoral),
            new SolidColorBrush(Colors.LightSeaGreen),
            new SolidColorBrush(Colors.LightSlateGray),
            new SolidColorBrush(Colors.MediumPurple),
            new SolidColorBrush(Colors.PaleVioletRed)
        };

    public ProjectSettings CurrentProject { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;

    private (IDataProvider, string) _currentSelection;
    public (IDataProvider, string) CurrentSelection
    {
        get => _currentSelection;
        set { _currentSelection = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSelection))); }
    }

    private bool _currentSelectionLinked;
    public bool CurrentSelectionLinked
    {
        get => _currentSelectionLinked;
        set { _currentSelectionLinked = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSelectionLinked))); }
    }

    public ResourcesWatcher Performance { get; private set; }
    public ProvidersManager ProvidersMan { get; private set; }

    //public string ApplicationInfo { get { return String.Format("{0} {1} v{2}", _appBase.Info.CompanyName, _appBase.Info.ProductName, _appBase.Info.Version); } }
    public string ApplicationInfo { get; } = $"{Assembly.GetExecutingAssembly().GetName().Name} - v{Assembly.GetExecutingAssembly().GetName().Version}";

    //public string Copyright { get { return _appBase.Info.Copyright; } }
    public string Copyright { get; } = "";

    public string HelpLink { get; } = "https://www.wokhan.com";
    public ObservableCollection<GlobalTask> Tasks { get; private set; } = new();

    public App()
    {
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        CurrentProject = new ProjectSettings() { Name = "Unamed project" };
        Performance = new ResourcesWatcher();
        ProvidersMan = new ProvidersManager();

        //TODO: change to a static initializer
        MonitorItem.Providers = Instance.CurrentProject.CurrentProviders;
        SourcesMapper.Providers = Instance.CurrentProject.CurrentProviders;

        RegisterCommands();

        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

        this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        this.Exit += App_Exit;
    }

    private void RegisterCommands()
    {
        CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(ApplicationCommands.Save, ProjectSave));
        CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(ApplicationCommands.SaveAs, ProjectSaveAs));
        CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(ApplicationCommands.Open, ProjectOpen));
        CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(ApplicationCommands.New, ProjectNew));
    }

    private void ProjectNew(object sender, ExecutedRoutedEventArgs e)
    {
        CurrentProject.CreateNew();
    }

    private void ProjectOpen(object sender, ExecutedRoutedEventArgs e)
    {
        var dial = new OpenFileDialog()
        {
            CheckFileExists = true,
            ValidateNames = true,
            AddExtension = true,
            Filter = "QuAnalyzer project file|*.qap"
        };

        if (dial.ShowDialog().Value)
        {
            CurrentProject.Open(dial.FileName);
        }
    }

    private void ProjectSaveAs(object sender, ExecutedRoutedEventArgs e)
    {
        CurrentProject.SaveAs();
    }

    private void ProjectSave(object sender, ExecutedRoutedEventArgs e)
    {
        CurrentProject.Save();
    }

    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "providers", args.Name.Split(',')[0] + ".dll");

        if (File.Exists(path))
        {
            return Assembly.LoadFrom(path);
        }

        return null;
    }

    private void App_Exit(object sender, ExitEventArgs e)
    {
        // Ensures all threads are killed as well.
        Environment.Exit(0);
    }

    /// <summary>
    /// Temporary method (the callback handling is not good, and the "host" retrieval ain't better)
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    internal (Panel host, Action<double>, CancellationTokenSource) AddTaskAndGetCallback(string title)
    {
        var window = ((MainWindow)this.MainWindow);

        var task = new GlobalTask() { Title = title };

        return (window.stackExports,
                i =>
                {
                    if (task.Progress is null)
                    {
                        Tasks.Add(task);
                    }
                    task.Progress = i;
                },
                task.CancellationTokenSource
        );
    }
}
