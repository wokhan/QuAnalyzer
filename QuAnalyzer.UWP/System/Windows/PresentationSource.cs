namespace System.Windows
{
    using Uno.UI.Generic;

    public class PresentationSource : Proxy<global::Windows.UI.Xaml.PresentationSource>
    {
        public System.Windows.Media.CompositionTarget CompositionTarget
        {
            get => __ProxyValue.CompositionTarget;
        }

        public System.Windows.Media.Visual RootVisual
        {
            get => __ProxyValue.RootVisual;
            set => __ProxyValue.RootVisual = value;
        }

        public System.Boolean IsDisposed
        {
            get => __ProxyValue.IsDisposed;
        }

        public static System.Collections.IEnumerable CurrentSources
        {
            get => __ProxyValue.CurrentSources;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static System.Windows.PresentationSource FromVisual(System.Windows.Media.Visual visual) => Windows.UI.Xaml.PresentationSource.FromVisual(@visual);
        public static System.Windows.PresentationSource FromDependencyObject(System.Windows.DependencyObject dependencyObject) => Windows.UI.Xaml.PresentationSource.FromDependencyObject(@dependencyObject);
        public static void AddSourceChangedHandler(System.Windows.IInputElement element, System.Windows.SourceChangedEventHandler handler) => Windows.UI.Xaml.PresentationSource.AddSourceChangedHandler(@element, @handler);
        public static void RemoveSourceChangedHandler(System.Windows.IInputElement e, System.Windows.SourceChangedEventHandler handler) => Windows.UI.Xaml.PresentationSource.RemoveSourceChangedHandler(@e, @handler);
        public void add_ContentRendered(System.EventHandler value) => __ProxyValue.add_ContentRendered(@value);
        public void remove_ContentRendered(System.EventHandler value) => __ProxyValue.remove_ContentRendered(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}