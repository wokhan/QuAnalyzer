namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class TextElementEditingBehaviorAttribute : Proxy<global::Windows.UI.Xaml.Documents.TextElementEditingBehaviorAttribute>
    {
        public System.Boolean IsMergeable
        {
            get => __ProxyValue.IsMergeable;
            set => __ProxyValue.IsMergeable = value;
        }

        public System.Boolean IsTypographicOnly
        {
            get => __ProxyValue.IsTypographicOnly;
            set => __ProxyValue.IsTypographicOnly = value;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public TextElementEditingBehaviorAttribute(): base()
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}