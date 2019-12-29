namespace System.Windows
{
    using Uno.UI.Generic;

    public class LocalValueEntry : Proxy<global::Windows.UI.Xaml.LocalValueEntry>
    {
        public System.Windows.DependencyProperty Property
        {
            get => __ProxyValue.Property;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public static System.Boolean op_Equality(System.Windows.LocalValueEntry obj1, System.Windows.LocalValueEntry obj2) => Windows.UI.Xaml.LocalValueEntry.op_Equality(@obj1, @obj2);
        public static System.Boolean op_Inequality(System.Windows.LocalValueEntry obj1, System.Windows.LocalValueEntry obj2) => Windows.UI.Xaml.LocalValueEntry.op_Inequality(@obj1, @obj2);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}