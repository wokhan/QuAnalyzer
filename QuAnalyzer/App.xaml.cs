﻿using Microsoft.Extensions.Logging;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project;
using QuAnalyzer.Features.Comparison;
using QuAnalyzer.Features.Monitoring;
using QuAnalyzer.UI.Pages;

using System.Globalization;
using System.Threading;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;

using Wokhan.Data.Providers.Contracts;
using Wokhan.UI.Diagnostics;

namespace QuAnalyzer;

[ObservableObject]
public sealed partial class App : Application
{
    public Window MainWindow { get; private set; }

    public MainPage MainPage { get; private set; }

    public static App Instance => (App)Current;

    public List<SolidColorBrush> AvailableColors { get; } = new List<SolidColorBrush> {
            //new SolidColorBrush(Color.FromArgb(0xff, 0x41, 0xB1, 0xE1)),
            new SolidColorBrush(Colors.LightCoral),
            new SolidColorBrush(Colors.LightSeaGreen),
            new SolidColorBrush(Colors.LightSlateGray),
            new SolidColorBrush(Colors.MediumPurple),
            new SolidColorBrush(Colors.PaleVioletRed)
        };

    public ProjectSettings CurrentProject { get; private set; }

    [ObservableProperty]
    private (IDataProvider, string) _currentSelection;

    [ObservableProperty]
    private bool _currentSelectionLinked;
    
    public ResourcesWatcher Performance { get; private set; }
    public ProvidersManager ProvidersMan { get; private set; }

    //public string ApplicationInfo { get { return String.Format("{0} {1} v{2}", _appBase.Info.CompanyName, _appBase.Info.ProductName, _appBase.Info.Version); } }
    public string ApplicationInfo { get; } = $"{Assembly.GetExecutingAssembly().GetName().Name} - v{Assembly.GetExecutingAssembly().GetName().Version}";

    //public string Copyright { get { return _appBase.Info.Copyright; } }
    public string Copyright { get; } = "";

    public string HelpLink { get; } = "https://www.wokhan.com";
    public ObservableCollection<GlobalTask> Tasks { get; private set; } = new();

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeLogging();

        this.InitializeComponent();

#if HAS_UNO || NETFX_CORE
        this.Suspending += OnSuspending;
#endif


        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        CurrentProject = new ProjectSettings() { Name = "Unamed project" };
        //Performance = new ResourcesWatcher();
        ProvidersMan = new ProvidersManager();

        //TODO: change to a static initializer
        TestDefinition.Providers = Instance.CurrentProject.CurrentProviders;
        SourcesMapper.Providers = Instance.CurrentProject.CurrentProviders;

        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

        UnhandledException += App_UnhandledException;
        //this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //this.Exit += App_Exit;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        MainPage?.ShowError("An unexpected error occured and has not been handled. Program might be unstable.");
        e.Handled = true;
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
#if DEBUG
        if (System.Diagnostics.Debugger.IsAttached)
        {
            // this.DebugSettings.EnableFrameRateCounter = true;
        }
#endif

#if NET6_0_OR_GREATER && WINDOWS
        MainWindow = new Window();
        MainWindow.Activate();
#else
        MainWindow = Microsoft.UI.Xaml.Window.Current;
#endif

        var rootFrame = MainWindow.Content as Frame;

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (rootFrame == null)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            rootFrame.NavigationFailed += OnNavigationFailed;

            if (args.UWPLaunchActivatedEventArgs.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                // TODO: Load state from previously suspended application
            }

            // Place the frame in the current Window
            MainWindow.Content = rootFrame;
        }

#if !(NET6_0_OR_GREATER && WINDOWS)
        if (args.UWPLaunchActivatedEventArgs.PrelaunchActivated == false)
#endif
        {
            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), args.Arguments);
            }
            // Ensure the current window is active
            MainWindow.Activate();
        }
    }

    /// <summary>
    /// Invoked when Navigation to a certain page fails
    /// </summary>
    /// <param name="sender">The Frame which failed navigation</param>
    /// <param name="e">Details about the navigation failure</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new InvalidOperationException($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
    }

    /// <summary>
    /// Invoked when application execution is being suspended.  Application state is saved
    /// without knowing whether the application will be terminated or resumed with the contents
    /// of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
        var deferral = e.SuspendingOperation.GetDeferral();
        //TODO: Save application state and stop any background activity
        deferral.Complete();
    }

    /// <summary>
    /// Configures global Uno Platform logging
    /// </summary>
    private static void InitializeLogging()
    {
#if DEBUG
			// Logging is disabled by default for release builds, as it incurs a significant
			// initialization cost from Microsoft.Extensions.Logging setup. If startup performance
			// is a concern for your application, keep this disabled. If you're running on web or 
			// desktop targets, you can use url or command line parameters to enable it.
			//
			// For more performance documentation: https://platform.uno/docs/articles/Uno-UI-Performance.html

			var factory = LoggerFactory.Create(builder =>
        {
#if __WASM__
            builder.AddProvider(new global::Uno.Extensions.Logging.WebAssembly.WebAssemblyConsoleLoggerProvider());
#elif __IOS__
            builder.AddProvider(new global::Uno.Extensions.Logging.OSLogLoggerProvider());
#elif NETFX_CORE
            builder.AddDebug();
#else
            builder.AddConsole();
#endif

            // Exclude logs below this level
            builder.SetMinimumLevel(LogLevel.Information);

            // Default filters for Uno Platform namespaces
            builder.AddFilter("Uno", LogLevel.Warning);
            builder.AddFilter("Windows", LogLevel.Warning);
            builder.AddFilter("Microsoft", LogLevel.Warning);

            // Generic Xaml events
            // builder.AddFilter("Windows.UI.Xaml", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.VisualStateGroup", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.StateTriggerBase", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.UIElement", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.FrameworkElement", LogLevel.Trace );

            // Layouter specific messages
            // builder.AddFilter("Windows.UI.Xaml.Controls", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.Controls.Layouter", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.Controls.Panel", LogLevel.Debug );

            // builder.AddFilter("Windows.Storage", LogLevel.Debug );

            // Binding related messages
            // builder.AddFilter("Windows.UI.Xaml.Data", LogLevel.Debug );
            // builder.AddFilter("Windows.UI.Xaml.Data", LogLevel.Debug );

            // Binder memory references tracking
            // builder.AddFilter("Uno.UI.DataBinding.BinderReferenceHolder", LogLevel.Debug );

            // RemoteControl and HotReload related
            // builder.AddFilter("Uno.UI.RemoteControl", LogLevel.Information);

            // Debug JS interop
            // builder.AddFilter("Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug );
        });

        global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory = factory;

#if HAS_UNO
			global::Uno.UI.Adapter.Microsoft.Extensions.Logging.LoggingAdapter.Initialize();
#endif
#endif
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


    /// <summary>
    /// Temporary method (the callback handling is not good, and the "host" retrieval ain't better)
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    internal (Panel host, IProgress<double> progress, CancellationTokenSource cancelationToken) AddTaskAndGetCallback(string title)
    {
        var task = new GlobalTask() { Title = title };

        return (null,
                new Progress<double>(i =>
                {
                    if (task.Progress == -1)
                    {
                        Tasks.Add(task);
                    }
                    task.Progress = i;
                }),
                task.CancellationTokenSource
        );
    }
}
