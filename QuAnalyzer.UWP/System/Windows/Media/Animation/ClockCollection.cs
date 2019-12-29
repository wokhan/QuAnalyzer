namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class ClockCollection : Proxy<global::Windows.UI.Xaml.Media.Animation.ClockCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Windows.Media.Animation.Clock Item
        {
            get => __ProxyValue.Item;
        }

        public void Clear() => __ProxyValue.Clear();
        public void Add(System.Windows.Media.Animation.Clock item) => __ProxyValue.Add(@item);
        public System.Boolean Remove(System.Windows.Media.Animation.Clock item) => __ProxyValue.Remove(@item);
        public System.Boolean Contains(System.Windows.Media.Animation.Clock item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Windows.Media.Animation.Clock[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public static System.Boolean Equals(System.Windows.Media.Animation.ClockCollection objA, System.Windows.Media.Animation.ClockCollection objB) => Windows.UI.Xaml.Media.Animation.ClockCollection.Equals(@objA, @objB);
        public static System.Boolean op_Equality(System.Windows.Media.Animation.ClockCollection objA, System.Windows.Media.Animation.ClockCollection objB) => Windows.UI.Xaml.Media.Animation.ClockCollection.op_Equality(@objA, @objB);
        public static System.Boolean op_Inequality(System.Windows.Media.Animation.ClockCollection objA, System.Windows.Media.Animation.ClockCollection objB) => Windows.UI.Xaml.Media.Animation.ClockCollection.op_Inequality(@objA, @objB);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}