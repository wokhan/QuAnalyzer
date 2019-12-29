namespace System.Windows
{
    using Uno.UI.Generic;

    public class LogicalTreeHelper : Proxy<global::Windows.UI.Xaml.LogicalTreeHelper>
    {
        public static System.Windows.DependencyObject FindLogicalNode(System.Windows.DependencyObject logicalTreeNode, System.String elementName) => Windows.UI.Xaml.LogicalTreeHelper.FindLogicalNode(@logicalTreeNode, @elementName);
        public static System.Windows.DependencyObject GetParent(System.Windows.DependencyObject current) => Windows.UI.Xaml.LogicalTreeHelper.GetParent(@current);
        public static System.Collections.IEnumerable GetChildren(System.Windows.DependencyObject current) => Windows.UI.Xaml.LogicalTreeHelper.GetChildren(@current);
        public static System.Collections.IEnumerable GetChildren(System.Windows.FrameworkElement current) => Windows.UI.Xaml.LogicalTreeHelper.GetChildren(@current);
        public static System.Collections.IEnumerable GetChildren(System.Windows.FrameworkContentElement current) => Windows.UI.Xaml.LogicalTreeHelper.GetChildren(@current);
        public static void BringIntoView(System.Windows.DependencyObject current) => Windows.UI.Xaml.LogicalTreeHelper.BringIntoView(@current);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}