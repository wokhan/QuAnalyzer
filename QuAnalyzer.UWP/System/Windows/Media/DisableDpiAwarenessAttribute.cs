namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class DisableDpiAwarenessAttribute : Proxy<global::Windows.UI.Xaml.Media.DisableDpiAwarenessAttribute>
    {
        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public DisableDpiAwarenessAttribute(): base()
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}