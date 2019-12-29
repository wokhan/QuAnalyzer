namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class KeyTime : Proxy<global::Windows.UI.Xaml.Media.Animation.KeyTime>
    {
        public static System.Windows.Media.Animation.KeyTime Uniform
        {
            get => __ProxyValue.Uniform;
        }

        public static System.Windows.Media.Animation.KeyTime Paced
        {
            get => __ProxyValue.Paced;
        }

        public System.TimeSpan TimeSpan
        {
            get => __ProxyValue.TimeSpan;
        }

        public System.Double Percent
        {
            get => __ProxyValue.Percent;
        }

        public System.Windows.Media.Animation.KeyTimeType Type
        {
            get => __ProxyValue.Type;
        }

        public static System.Windows.Media.Animation.KeyTime FromPercent(System.Double percent) => Windows.UI.Xaml.Media.Animation.KeyTime.FromPercent(@percent);
        public static System.Windows.Media.Animation.KeyTime FromTimeSpan(System.TimeSpan timeSpan) => Windows.UI.Xaml.Media.Animation.KeyTime.FromTimeSpan(@timeSpan);
        public static System.Boolean Equals(System.Windows.Media.Animation.KeyTime keyTime1, System.Windows.Media.Animation.KeyTime keyTime2) => Windows.UI.Xaml.Media.Animation.KeyTime.Equals(@keyTime1, @keyTime2);
        public static System.Boolean op_Equality(System.Windows.Media.Animation.KeyTime keyTime1, System.Windows.Media.Animation.KeyTime keyTime2) => Windows.UI.Xaml.Media.Animation.KeyTime.op_Equality(@keyTime1, @keyTime2);
        public static System.Boolean op_Inequality(System.Windows.Media.Animation.KeyTime keyTime1, System.Windows.Media.Animation.KeyTime keyTime2) => Windows.UI.Xaml.Media.Animation.KeyTime.op_Inequality(@keyTime1, @keyTime2);
        public System.Boolean Equals(System.Windows.Media.Animation.KeyTime value) => __ProxyValue.Equals(@value);
        public override System.Boolean Equals(System.Object value) => __ProxyValue.Equals(@value);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public static System.Windows.Media.Animation.KeyTime op_Implicit(System.TimeSpan timeSpan) => Windows.UI.Xaml.Media.Animation.KeyTime.op_Implicit(@timeSpan);
    }
}