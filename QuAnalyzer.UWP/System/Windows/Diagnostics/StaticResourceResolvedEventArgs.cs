namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class StaticResourceResolvedEventArgs : Proxy<global::Windows.UI.Xaml.Diagnostics.StaticResourceResolvedEventArgs>
    {
        public System.Object TargetObject
        {
            get => __ProxyValue.TargetObject;
        }

        public System.Object TargetProperty
        {
            get => __ProxyValue.TargetProperty;
        }

        public System.Windows.ResourceDictionary ResourceDictionary
        {
            get => __ProxyValue.ResourceDictionary;
        }

        public System.Object ResourceKey
        {
            get => __ProxyValue.ResourceKey;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}