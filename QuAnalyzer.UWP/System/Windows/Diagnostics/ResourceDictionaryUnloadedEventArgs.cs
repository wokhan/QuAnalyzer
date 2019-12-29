namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class ResourceDictionaryUnloadedEventArgs : Proxy<global::Windows.UI.Xaml.Diagnostics.ResourceDictionaryUnloadedEventArgs>
    {
        public System.Windows.Diagnostics.ResourceDictionaryInfo ResourceDictionaryInfo
        {
            get => __ProxyValue.ResourceDictionaryInfo;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}