namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class VectorKeyFrameCollection : Proxy<global::Windows.UI.Xaml.Media.Animation.VectorKeyFrameCollection>
    {
        public static System.Windows.Media.Animation.VectorKeyFrameCollection Empty
        {
            get => __ProxyValue.Empty;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
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

        public System.Windows.Media.Animation.VectorKeyFrame Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
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

        public VectorKeyFrameCollection(): base()
        {
        }

        public System.Windows.Media.Animation.VectorKeyFrameCollection Clone() => __ProxyValue.Clone();
        public System.Collections.IEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public void CopyTo(System.Windows.Media.Animation.VectorKeyFrame[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Int32 Add(System.Windows.Media.Animation.VectorKeyFrame keyFrame) => __ProxyValue.Add(@keyFrame);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Media.Animation.VectorKeyFrame keyFrame) => __ProxyValue.Contains(@keyFrame);
        public System.Int32 IndexOf(System.Windows.Media.Animation.VectorKeyFrame keyFrame) => __ProxyValue.IndexOf(@keyFrame);
        public void Insert(System.Int32 index, System.Windows.Media.Animation.VectorKeyFrame keyFrame) => __ProxyValue.Insert(@index, @keyFrame);
        public void Remove(System.Windows.Media.Animation.VectorKeyFrame keyFrame) => __ProxyValue.Remove(@keyFrame);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public System.Windows.Freezable CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
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
        public override System.String ToString() => __ProxyValue.ToString();
    }
}