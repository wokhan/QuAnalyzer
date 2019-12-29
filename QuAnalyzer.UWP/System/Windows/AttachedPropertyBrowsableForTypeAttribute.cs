namespace System.Windows
{
    using Uno.UI.Generic;

    public class AttachedPropertyBrowsableForTypeAttribute : Proxy<global::Windows.UI.Xaml.AttachedPropertyBrowsableForTypeAttribute>
    {
        public System.Type TargetType
        {
            get => __ProxyValue.TargetType;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public AttachedPropertyBrowsableForTypeAttribute(System.Type @targetType): base(@targetType)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}