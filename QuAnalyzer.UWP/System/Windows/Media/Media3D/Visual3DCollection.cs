namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Visual3DCollection : Proxy<global::Windows.UI.Xaml.Media.Media3D.Visual3DCollection>
    {
        public System.Windows.Media.Media3D.Visual3D Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public void Add(System.Windows.Media.Media3D.Visual3D value) => __ProxyValue.Add(@value);
        public void Insert(System.Int32 index, System.Windows.Media.Media3D.Visual3D value) => __ProxyValue.Insert(@index, @value);
        public System.Boolean Remove(System.Windows.Media.Media3D.Visual3D value) => __ProxyValue.Remove(@value);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.Media.Media3D.Visual3D[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.Media.Media3D.Visual3D value) => __ProxyValue.Contains(@value);
        public System.Int32 IndexOf(System.Windows.Media.Media3D.Visual3D value) => __ProxyValue.IndexOf(@value);
        public System.Windows.Media.Media3D.Enumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}