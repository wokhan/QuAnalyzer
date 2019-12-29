namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Vector3DCollection : Proxy<global::Windows.UI.Xaml.Media.Media3D.Vector3DCollection>
    {
        public System.Windows.Media.Media3D.Vector3D Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean CanFreeze
        {
            get => __ProxyValue.CanFreeze;
        }

        public System.Boolean IsFrozen
        {
            get => __ProxyValue.IsFrozen;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public Vector3DCollection(): base()
        {
        }

        public Vector3DCollection(System.Int32 @capacity): base(@capacity)
        {
        }

        public Vector3DCollection(System.Collections.Generic.IEnumerable<System.Windows.Media.Media3D.Vector3D> @collection): base(@collection)
        {
        }

        public System.Windows.Media.Media3D.Vector3DCollection Clone() => __ProxyValue.Clone();
        public System.Windows.Media.Media3D.Vector3DCollection CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public void Add(System.Windows.Media.Media3D.Vector3D value) => __ProxyValue.Add(@value);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Media.Media3D.Vector3D value) => __ProxyValue.Contains(@value);
        public System.Int32 IndexOf(System.Windows.Media.Media3D.Vector3D value) => __ProxyValue.IndexOf(@value);
        public void Insert(System.Int32 index, System.Windows.Media.Media3D.Vector3D value) => __ProxyValue.Insert(@index, @value);
        public System.Boolean Remove(System.Windows.Media.Media3D.Vector3D value) => __ProxyValue.Remove(@value);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void CopyTo(System.Windows.Media.Media3D.Vector3D[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Windows.Media.Media3D.Enumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public static System.Windows.Media.Media3D.Vector3DCollection Parse(System.String source) => Windows.UI.Xaml.Media.Media3D.Vector3DCollection.Parse(@source);
        public System.Windows.Freezable GetAsFrozen() => __ProxyValue.GetAsFrozen();
        public System.Windows.Freezable GetCurrentValueAsFrozen() => __ProxyValue.GetCurrentValueAsFrozen();
        public void Freeze() => __ProxyValue.Freeze();
        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
    }
}