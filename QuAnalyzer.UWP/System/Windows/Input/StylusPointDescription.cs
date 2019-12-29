namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusPointDescription : Proxy<global::Windows.UI.Xaml.Input.StylusPointDescription>
    {
        public System.Int32 PropertyCount
        {
            get => __ProxyValue.PropertyCount;
        }

        public StylusPointDescription(): base()
        {
        }

        public StylusPointDescription(System.Collections.Generic.IEnumerable<System.Windows.Input.StylusPointPropertyInfo> @stylusPointPropertyInfos): base(@stylusPointPropertyInfos)
        {
        }

        public System.Boolean HasProperty(System.Windows.Input.StylusPointProperty stylusPointProperty) => __ProxyValue.HasProperty(@stylusPointProperty);
        public System.Windows.Input.StylusPointPropertyInfo GetPropertyInfo(System.Windows.Input.StylusPointProperty stylusPointProperty) => __ProxyValue.GetPropertyInfo(@stylusPointProperty);
        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Input.StylusPointPropertyInfo> GetStylusPointProperties() => __ProxyValue.GetStylusPointProperties();
        public static System.Boolean AreCompatible(System.Windows.Input.StylusPointDescription stylusPointDescription1, System.Windows.Input.StylusPointDescription stylusPointDescription2) => Windows.UI.Xaml.Input.StylusPointDescription.AreCompatible(@stylusPointDescription1, @stylusPointDescription2);
        public static System.Windows.Input.StylusPointDescription GetCommonDescription(System.Windows.Input.StylusPointDescription stylusPointDescription, System.Windows.Input.StylusPointDescription stylusPointDescriptionPreserveInfo) => Windows.UI.Xaml.Input.StylusPointDescription.GetCommonDescription(@stylusPointDescription, @stylusPointDescriptionPreserveInfo);
        public System.Boolean IsSubsetOf(System.Windows.Input.StylusPointDescription stylusPointDescriptionSuperset) => __ProxyValue.IsSubsetOf(@stylusPointDescriptionSuperset);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}