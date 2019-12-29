namespace System.Windows
{
    using Uno.UI.Generic;

    public class ContentOperations : Proxy<global::Windows.UI.Xaml.ContentOperations>
    {
        public static System.Windows.DependencyObject GetParent(System.Windows.ContentElement reference) => Windows.UI.Xaml.ContentOperations.GetParent(@reference);
        public static void SetParent(System.Windows.ContentElement reference, System.Windows.DependencyObject parent) => Windows.UI.Xaml.ContentOperations.SetParent(@reference, @parent);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}