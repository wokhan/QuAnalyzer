namespace System.Windows
{
    using Uno.UI.Generic;

    public class Localization : Proxy<global::Windows.UI.Xaml.Localization>
    {
        public static System.String GetComments(System.Object element) => Windows.UI.Xaml.Localization.GetComments(@element);
        public static void SetComments(System.Object element, System.String comments) => Windows.UI.Xaml.Localization.SetComments(@element, @comments);
        public static System.String GetAttributes(System.Object element) => Windows.UI.Xaml.Localization.GetAttributes(@element);
        public static void SetAttributes(System.Object element, System.String attributes) => Windows.UI.Xaml.Localization.SetAttributes(@element, @attributes);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}