namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizerErrorNotifyEventArgs : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizerErrorNotifyEventArgs>
    {
        public System.Windows.Markup.Localizer.BamlLocalizableResourceKey Key
        {
            get => __ProxyValue.Key;
        }

        public System.Windows.Markup.Localizer.BamlLocalizerError Error
        {
            get => __ProxyValue.Error;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}