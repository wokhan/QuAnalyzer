using Microsoft.Extensions.Logging;

using QuAnalyzer.Core.Helpers;
using QuAnalyzer.Core.Project;
using QuAnalyzer.UI.Pages;

using System.Globalization;

using Windows.ApplicationModel;

using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer;

[ObservableObject]
public sealed partial class App : Application
{
    public Window MainWindow { get; private set; }

    public static App Instance => (App)Current;

    [ObservableProperty]
    private ProjectSettings currentProject;

    [ObservableProperty]
    private (IDataProvider, string) _currentSelection;

    [ObservableProperty]
    private bool _currentSelectionLinked;
    
    public string ApplicationInfo { get; init; }

    //public string Copyright { get { return _appBase.Info.Copyright; } }
    public string Copyright { get; } = "";

    public string HelpLink { get; } = "https://www.wokhan.com";

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeLogging();

        InitializeComponent();

#if HAS_UNO || NETFX_CORE
        this.Suspending += OnSuspending;
#endif

        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        var assemblyName = Assembly.GetExecutingAssembly().GetName();
        ApplicationInfo = $"{assemblyName.Name} - v{assemblyName.Version} ({assemblyName.ProcessorArchitecture})";

        // Always start with a fresh project
        CurrentProject = new ProjectSettings();
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
        MainWindow = new Window() { Title = "QuAnalyzer" };
        MainWindow.Activate();
#else
        MainWindow = Microsoft.UI.Xaml.Window.Current;
#endif

#if !(NET6_0_OR_GREATER && WINDOWS)
        if (args.UWPLaunchActivatedEventArgs.PrelaunchActivated == false)
#endif
        {
            if (MainWindow.Content is null)
            {
                MainWindow.Content = new MainPage();
                MicaBackground.TrySetBackdrop(MainWindow, MicaBackground.BackgroundMode.Mica);
            }

            // Ensure the current window is active
            MainWindow.Activate();
        }
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

   
}
