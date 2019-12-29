namespace System.Windows
{
    using Uno.UI.Generic;

    public class ValueSource : Proxy<global::Windows.UI.Xaml.ValueSource>
    {
        public System.Windows.BaseValueSource BaseValueSource
        {
            get => __ProxyValue.BaseValueSource;
        }

        public System.Boolean IsExpression
        {
            get => __ProxyValue.IsExpression;
        }

        public System.Boolean IsAnimated
        {
            get => __ProxyValue.IsAnimated;
        }

        public System.Boolean IsCoerced
        {
            get => __ProxyValue.IsCoerced;
        }

        public System.Boolean IsCurrent
        {
            get => __ProxyValue.IsCurrent;
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public static System.Boolean op_Equality(System.Windows.ValueSource vs1, System.Windows.ValueSource vs2) => Windows.UI.Xaml.ValueSource.op_Equality(@vs1, @vs2);
        public static System.Boolean op_Inequality(System.Windows.ValueSource vs1, System.Windows.ValueSource vs2) => Windows.UI.Xaml.ValueSource.op_Inequality(@vs1, @vs2);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}