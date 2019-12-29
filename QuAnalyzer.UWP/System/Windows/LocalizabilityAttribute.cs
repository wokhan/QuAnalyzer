namespace System.Windows
{
    using Uno.UI.Generic;

    public class LocalizabilityAttribute : Proxy<global::Windows.UI.Xaml.LocalizabilityAttribute>
    {
        public System.Windows.LocalizationCategory Category
        {
            get => __ProxyValue.Category;
        }

        public System.Windows.Readability Readability
        {
            get => __ProxyValue.Readability;
            set => __ProxyValue.Readability = value;
        }

        public System.Windows.Modifiability Modifiability
        {
            get => __ProxyValue.Modifiability;
            set => __ProxyValue.Modifiability = value;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public LocalizabilityAttribute(System.Windows.LocalizationCategory @category): base(@category)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}