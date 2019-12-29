namespace System.Windows
{
    using Uno.UI.Generic;

    public class Duration : Proxy<global::Windows.UI.Xaml.Duration>
    {
        public System.Boolean HasTimeSpan
        {
            get => __ProxyValue.HasTimeSpan;
        }

        public static System.Windows.Duration Automatic
        {
            get => __ProxyValue.Automatic;
        }

        public static System.Windows.Duration Forever
        {
            get => __ProxyValue.Forever;
        }

        public System.TimeSpan TimeSpan
        {
            get => __ProxyValue.TimeSpan;
        }

        public Duration(System.TimeSpan @timeSpan): base(@timeSpan)
        {
        }

        public static System.Windows.Duration op_Implicit(System.TimeSpan timeSpan) => Windows.UI.Xaml.Duration.op_Implicit(@timeSpan);
        public static System.Windows.Duration op_Addition(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_Addition(@t1, @t2);
        public static System.Windows.Duration op_Subtraction(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_Subtraction(@t1, @t2);
        public static System.Boolean op_Equality(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_Equality(@t1, @t2);
        public static System.Boolean op_Inequality(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_Inequality(@t1, @t2);
        public static System.Boolean op_GreaterThan(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_GreaterThan(@t1, @t2);
        public static System.Boolean op_GreaterThanOrEqual(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_GreaterThanOrEqual(@t1, @t2);
        public static System.Boolean op_LessThan(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_LessThan(@t1, @t2);
        public static System.Boolean op_LessThanOrEqual(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.op_LessThanOrEqual(@t1, @t2);
        public static System.Int32 Compare(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.Compare(@t1, @t2);
        public static System.Windows.Duration Plus(System.Windows.Duration duration) => Windows.UI.Xaml.Duration.Plus(@duration);
        public static System.Windows.Duration op_UnaryPlus(System.Windows.Duration duration) => Windows.UI.Xaml.Duration.op_UnaryPlus(@duration);
        public System.Windows.Duration Add(System.Windows.Duration duration) => __ProxyValue.Add(@duration);
        public override System.Boolean Equals(System.Object value) => __ProxyValue.Equals(@value);
        public System.Boolean Equals(System.Windows.Duration duration) => __ProxyValue.Equals(@duration);
        public static System.Boolean Equals(System.Windows.Duration t1, System.Windows.Duration t2) => Windows.UI.Xaml.Duration.Equals(@t1, @t2);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Windows.Duration Subtract(System.Windows.Duration duration) => __ProxyValue.Subtract(@duration);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}