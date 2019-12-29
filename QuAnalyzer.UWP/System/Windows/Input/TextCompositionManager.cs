namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TextCompositionManager : Proxy<global::Windows.UI.Xaml.Input.TextCompositionManager>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void AddPreviewTextInputStartHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.AddPreviewTextInputStartHandler(@element, @handler);
        public static void RemovePreviewTextInputStartHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.RemovePreviewTextInputStartHandler(@element, @handler);
        public static void AddTextInputStartHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.AddTextInputStartHandler(@element, @handler);
        public static void RemoveTextInputStartHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.RemoveTextInputStartHandler(@element, @handler);
        public static void AddPreviewTextInputUpdateHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.AddPreviewTextInputUpdateHandler(@element, @handler);
        public static void RemovePreviewTextInputUpdateHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.RemovePreviewTextInputUpdateHandler(@element, @handler);
        public static void AddTextInputUpdateHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.AddTextInputUpdateHandler(@element, @handler);
        public static void RemoveTextInputUpdateHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.RemoveTextInputUpdateHandler(@element, @handler);
        public static void AddPreviewTextInputHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.AddPreviewTextInputHandler(@element, @handler);
        public static void RemovePreviewTextInputHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.RemovePreviewTextInputHandler(@element, @handler);
        public static void AddTextInputHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.AddTextInputHandler(@element, @handler);
        public static void RemoveTextInputHandler(System.Windows.DependencyObject element, System.Windows.Input.TextCompositionEventHandler handler) => Windows.UI.Xaml.Input.TextCompositionManager.RemoveTextInputHandler(@element, @handler);
        public static System.Boolean StartComposition(System.Windows.Input.TextComposition composition) => Windows.UI.Xaml.Input.TextCompositionManager.StartComposition(@composition);
        public static System.Boolean UpdateComposition(System.Windows.Input.TextComposition composition) => Windows.UI.Xaml.Input.TextCompositionManager.UpdateComposition(@composition);
        public static System.Boolean CompleteComposition(System.Windows.Input.TextComposition composition) => Windows.UI.Xaml.Input.TextCompositionManager.CompleteComposition(@composition);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}