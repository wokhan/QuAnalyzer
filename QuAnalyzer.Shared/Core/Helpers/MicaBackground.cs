#if !HAS_UNO
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

using System.Runtime.InteropServices;

using WinRT;

namespace QuAnalyzer.Core.Helpers;

public class MicaBackground
{
    /// <summary>
    /// Defines the backdrop mode to use for the Background
    /// Mica: the brand new one in Windows 11
    /// Acrylic: the Windows 10 translucent effect
    /// None: fallbacks to whatever background is set on the corresponding window content.
    /// </summary>
    public enum BackgroundMode
    {
        None,
        Acrylic,
        Mica
    }

    public static BackgroundMode CurrentMode { get; private set; } = BackgroundMode.None;

    private static bool initDone;


    private static Brush previousBackground;

    private static BindingExpression previousBackgroundBinding;

    static WindowsSystemDispatcherQueueHelper dispatcherQueueHelper;
    static MicaController micaController;
    static DesktopAcrylicController acrylicController;

    static SystemBackdropConfiguration configurationSource;

    public static bool TrySetBackdrop(Window window, BackgroundMode mode)
    {
        if (CurrentMode != mode)
        {
            CurrentMode = mode;
            disposeCurrentResources(window);

            switch (mode)
            {
                case BackgroundMode.Acrylic:
                    return TrySetAcrylicBackdrop(window);

                case BackgroundMode.Mica:
                    return TrySetMicaBackdrop(window);

                default:
                    return RestoreBackground(window);
            }
        }

        return true;
    }

    private static bool TrySetAcrylicBackdrop(Window window)
    {
        if (DesktopAcrylicController.IsSupported())
        {
            if (!initDone)
            {
                init(window);
            }

            window.Content.ClearValue(Control.BackgroundProperty);

            acrylicController = new DesktopAcrylicController();

            acrylicController.AddSystemBackdropTarget(window.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
            acrylicController.SetSystemBackdropConfiguration(configurationSource);

            return true; // succeeded
        }

        return false; // Acrylic is not supported on this system
    }


    private static bool TrySetMicaBackdrop(Window window)
    {
        if (MicaController.IsSupported())
        {
            if (!initDone)
            {
                init(window);
            }

            window.Content.ClearValue(Control.BackgroundProperty);

            micaController = new MicaController();

            micaController.AddSystemBackdropTarget(window.As<Microsoft.UI.Composition.ICompositionSupportsSystemBackdrop>());
            micaController.SetSystemBackdropConfiguration(configurationSource);

            return true; // succeeded
        }

        return false; // Mica is not supported on this system
    }

    private static bool RestoreBackground(Window window)
    {
        var contentControl = (Control)window.Content;

        if (previousBackgroundBinding is not null)
        {
            contentControl.SetBinding(Control.BackgroundProperty, previousBackgroundBinding.ParentBinding);
        }
        else if (previousBackground is not null)
        {
            contentControl.Background = previousBackground;
        }

        return true;
    }
    private static void init(Window window)
    {
        initDone = true;

        var contentControl = (Control)window.Content;
        if ((previousBackgroundBinding = contentControl.GetBindingExpression(Control.BackgroundProperty)) is null
            && contentControl.Background is Brush)
        {
            previousBackground = contentControl.Background;
        }

        dispatcherQueueHelper = new WindowsSystemDispatcherQueueHelper();
        dispatcherQueueHelper.EnsureWindowsSystemDispatcherQueueController();

        // Hooking up the policy object
        configurationSource = new SystemBackdropConfiguration();
        window.Activated += Window_Activated;

        window.Closed += Window_Closed;

        ((FrameworkElement)window.Content).ActualThemeChanged += (_, _) =>
        {
            if (configurationSource is not null)
            {
                SetConfigurationSourceTheme(window);
            }
        };

        // Initial configuration state.
        configurationSource.IsInputActive = true;
        SetConfigurationSourceTheme(window);
    }

    private static void Window_Activated(object sender, WindowActivatedEventArgs args)
    {
        configurationSource.IsInputActive = args.WindowActivationState != WindowActivationState.Deactivated;
    }

    private static void Window_Closed(object sender, WindowEventArgs args)
    {
        disposeCurrentResources((Window)sender);

        ((Window)sender).Activated -= Window_Activated;
        configurationSource = null;
    }

    private static void disposeCurrentResources(Window window)
    {
        if (micaController is not null)
        {
            micaController.Dispose();
            micaController = null;
        }

        if (acrylicController is not null)
        {
            acrylicController.Dispose();
            acrylicController = null;
        }
    }

    private static void SetConfigurationSourceTheme(Window host)
    {
        switch (((FrameworkElement)host.Content).ActualTheme)
        {
            case ElementTheme.Dark:
                configurationSource.Theme = SystemBackdropTheme.Dark;
                break;

            case ElementTheme.Light:
                configurationSource.Theme = SystemBackdropTheme.Light;
                break;

            case ElementTheme.Default:
                configurationSource.Theme = SystemBackdropTheme.Default;
                break;
        }
    }

    /// <summary>
    /// Source: Sample from WinUI 3 Gallery by Microsoft
    /// </summary>
    private class WindowsSystemDispatcherQueueHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        struct DispatcherQueueOptions
        {
            internal int dwSize;
            internal int threadType;
            internal int apartmentType;
        }

        [DllImport("CoreMessaging.dll")]
        private static extern int CreateDispatcherQueueController([In] DispatcherQueueOptions options, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object dispatcherQueueController);

        object m_dispatcherQueueController = null;
        public void EnsureWindowsSystemDispatcherQueueController()
        {
            if (Windows.System.DispatcherQueue.GetForCurrentThread() is not null)
            {
                // one already exists, so we'll just use it.
                return;
            }

            if (m_dispatcherQueueController is null)
            {
                DispatcherQueueOptions options;
                options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));
                options.threadType = 2;    // DQTYPE_THREAD_CURRENT
                options.apartmentType = 2; // DQTAT_COM_STA

                CreateDispatcherQueueController(options, ref m_dispatcherQueueController);
            }
        }
    }
}

#endif