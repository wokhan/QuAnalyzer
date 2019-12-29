namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class CompositionTarget : Proxy<global::Windows.UI.Xaml.Media.CompositionTarget>
    {
        public System.Windows.Media.Visual RootVisual
        {
            get => __ProxyValue.RootVisual;
            set => __ProxyValue.RootVisual = value;
        }

        public System.Windows.Media.Matrix TransformToDevice
        {
            get => __ProxyValue.TransformToDevice;
        }

        public System.Windows.Media.Matrix TransformFromDevice
        {
            get => __ProxyValue.TransformFromDevice;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void Dispose() => __ProxyValue.Dispose();
        public static void add_Rendering(System.EventHandler value) => Windows.UI.Xaml.Media.CompositionTarget.add_Rendering(@value);
        public static void remove_Rendering(System.EventHandler value) => Windows.UI.Xaml.Media.CompositionTarget.remove_Rendering(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}