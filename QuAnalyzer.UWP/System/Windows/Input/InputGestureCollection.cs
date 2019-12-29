namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputGestureCollection : Proxy<global::Windows.UI.Xaml.Input.InputGestureCollection>
    {
        public System.Windows.Input.InputGesture Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Boolean IsSynchronized
        {
            get => __ProxyValue.IsSynchronized;
        }

        public System.Object SyncRoot
        {
            get => __ProxyValue.SyncRoot;
        }

        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public InputGestureCollection(): base()
        {
        }

        public InputGestureCollection(System.Collections.IList @inputGestures): base(@inputGestures)
        {
        }

        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Input.InputGesture value) => __ProxyValue.IndexOf(@value);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public System.Int32 Add(System.Windows.Input.InputGesture inputGesture) => __ProxyValue.Add(@inputGesture);
        public void AddRange(System.Collections.ICollection collection) => __ProxyValue.AddRange(@collection);
        public void Insert(System.Int32 index, System.Windows.Input.InputGesture inputGesture) => __ProxyValue.Insert(@index, @inputGesture);
        public void Remove(System.Windows.Input.InputGesture inputGesture) => __ProxyValue.Remove(@inputGesture);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Input.InputGesture key) => __ProxyValue.Contains(@key);
        public void CopyTo(System.Windows.Input.InputGesture[] inputGestures, System.Int32 index) => __ProxyValue.CopyTo(@inputGestures, @index);
        public void Seal() => __ProxyValue.Seal();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}