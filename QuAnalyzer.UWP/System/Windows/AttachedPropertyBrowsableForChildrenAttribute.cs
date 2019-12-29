namespace System.Windows
{
    using Uno.UI.Generic;

    public class AttachedPropertyBrowsableForChildrenAttribute : Proxy<global::Windows.UI.Xaml.AttachedPropertyBrowsableForChildrenAttribute>
    {
        public System.Boolean IncludeDescendants
        {
            get => __ProxyValue.IncludeDescendants;
            set => __ProxyValue.IncludeDescendants = value;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public AttachedPropertyBrowsableForChildrenAttribute(): base()
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}