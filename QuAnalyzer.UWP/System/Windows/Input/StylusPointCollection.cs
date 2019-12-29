namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusPointCollection : Proxy<global::Windows.UI.Xaml.Input.StylusPointCollection>
    {
        public System.Windows.Input.StylusPointDescription Description
        {
            get => __ProxyValue.Description;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Input.StylusPoint Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public StylusPointCollection(): base()
        {
        }

        public StylusPointCollection(System.Int32 @initialCapacity): base(@initialCapacity)
        {
        }

        public StylusPointCollection(System.Windows.Input.StylusPointDescription @stylusPointDescription): base(@stylusPointDescription)
        {
        }

        public StylusPointCollection(System.Windows.Input.StylusPointDescription @stylusPointDescription, System.Int32 @initialCapacity): base(@stylusPointDescription, @initialCapacity)
        {
        }

        public StylusPointCollection(System.Collections.Generic.IEnumerable<System.Windows.Input.StylusPoint> @stylusPoints): base(@stylusPoints)
        {
        }

        public StylusPointCollection(System.Collections.Generic.IEnumerable<System.Windows.Point> @points): base(@points)
        {
        }

        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
        public void Add(System.Windows.Input.StylusPointCollection stylusPoints) => __ProxyValue.Add(@stylusPoints);
        public System.Windows.Input.StylusPointCollection Clone() => __ProxyValue.Clone();
        public static System.Windows.Point[] op_Explicit(System.Windows.Input.StylusPointCollection stylusPoints) => Windows.UI.Xaml.Input.StylusPointCollection.op_Explicit(@stylusPoints);
        public System.Windows.Input.StylusPointCollection Reformat(System.Windows.Input.StylusPointDescription subsetToReformatTo) => __ProxyValue.Reformat(@subsetToReformatTo);
        public System.Int32[] ToHiMetricArray() => __ProxyValue.ToHiMetricArray();
        public void Add(System.Windows.Input.StylusPoint item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.Input.StylusPoint[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.Input.StylusPoint item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.Windows.Input.StylusPoint> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Input.StylusPoint item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.Input.StylusPoint item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.Windows.Input.StylusPoint item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}