namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class RepeatBehavior : Proxy<global::Windows.UI.Xaml.Media.Animation.RepeatBehavior>
    {
        public static System.Windows.Media.Animation.RepeatBehavior Forever
        {
            get => __ProxyValue.Forever;
        }

        public System.Boolean HasCount
        {
            get => __ProxyValue.HasCount;
        }

        public System.Boolean HasDuration
        {
            get => __ProxyValue.HasDuration;
        }

        public System.Double Count
        {
            get => __ProxyValue.Count;
        }

        public System.TimeSpan Duration
        {
            get => __ProxyValue.Duration;
        }

        public RepeatBehavior(System.Double @count): base(@count)
        {
        }

        public RepeatBehavior(System.TimeSpan @duration): base(@duration)
        {
        }

        public override System.Boolean Equals(System.Object value) => __ProxyValue.Equals(@value);
        public System.Boolean Equals(System.Windows.Media.Animation.RepeatBehavior repeatBehavior) => __ProxyValue.Equals(@repeatBehavior);
        public static System.Boolean Equals(System.Windows.Media.Animation.RepeatBehavior repeatBehavior1, System.Windows.Media.Animation.RepeatBehavior repeatBehavior2) => Windows.UI.Xaml.Media.Animation.RepeatBehavior.Equals(@repeatBehavior1, @repeatBehavior2);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider formatProvider) => __ProxyValue.ToString(@formatProvider);
        public static System.Boolean op_Equality(System.Windows.Media.Animation.RepeatBehavior repeatBehavior1, System.Windows.Media.Animation.RepeatBehavior repeatBehavior2) => Windows.UI.Xaml.Media.Animation.RepeatBehavior.op_Equality(@repeatBehavior1, @repeatBehavior2);
        public static System.Boolean op_Inequality(System.Windows.Media.Animation.RepeatBehavior repeatBehavior1, System.Windows.Media.Animation.RepeatBehavior repeatBehavior2) => Windows.UI.Xaml.Media.Animation.RepeatBehavior.op_Inequality(@repeatBehavior1, @repeatBehavior2);
    }
}