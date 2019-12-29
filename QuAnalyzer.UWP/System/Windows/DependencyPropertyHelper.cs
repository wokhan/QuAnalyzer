namespace System.Windows
{
    using Uno.UI.Generic;

    public class DependencyPropertyHelper : Proxy<global::Windows.UI.Xaml.DependencyPropertyHelper>
    {
        public static System.Windows.ValueSource GetValueSource(System.Windows.DependencyObject dependencyObject, System.Windows.DependencyProperty dependencyProperty) => Windows.UI.Xaml.DependencyPropertyHelper.GetValueSource(@dependencyObject, @dependencyProperty);
        public static System.Boolean IsTemplatedValueDynamic(System.Windows.DependencyObject elementInTemplate, System.Windows.DependencyProperty dependencyProperty) => Windows.UI.Xaml.DependencyPropertyHelper.IsTemplatedValueDynamic(@elementInTemplate, @dependencyProperty);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}