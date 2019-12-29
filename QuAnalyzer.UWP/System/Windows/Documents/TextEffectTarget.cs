namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class TextEffectTarget : Proxy<global::Windows.UI.Xaml.Documents.TextEffectTarget>
    {
        public System.Windows.DependencyObject Element
        {
            get => __ProxyValue.Element;
        }

        public System.Windows.Media.TextEffect TextEffect
        {
            get => __ProxyValue.TextEffect;
        }

        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
        }

        public void Enable() => __ProxyValue.Enable();
        public void Disable() => __ProxyValue.Disable();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}