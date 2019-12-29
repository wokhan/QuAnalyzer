namespace System.Windows
{
    using Uno.UI.Generic;

    public class DependencyPropertyChangedEventArgs : Proxy<global::Windows.UI.Xaml.DependencyPropertyChangedEventArgs>
    {
        public System.Windows.DependencyProperty Property
        {
            get => __ProxyValue.Property;
        }

        public System.Object OldValue
        {
            get => __ProxyValue.OldValue;
        }

        public System.Object NewValue
        {
            get => __ProxyValue.NewValue;
        }

        public DependencyPropertyChangedEventArgs(System.Windows.DependencyProperty @property, System.Object @oldValue, System.Object @newValue): base(@property, @oldValue, @newValue)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.DependencyPropertyChangedEventArgs args) => __ProxyValue.Equals(@args);
        public static System.Boolean op_Equality(System.Windows.DependencyPropertyChangedEventArgs left, System.Windows.DependencyPropertyChangedEventArgs right) => Windows.UI.Xaml.DependencyPropertyChangedEventArgs.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.DependencyPropertyChangedEventArgs left, System.Windows.DependencyPropertyChangedEventArgs right) => Windows.UI.Xaml.DependencyPropertyChangedEventArgs.op_Inequality(@left, @right);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}