namespace System.Windows
{
    using Uno.UI.Generic;

    public class ResourceDictionary : Proxy<global::Windows.UI.Xaml.ResourceDictionary>
    {
        public System.Collections.ObjectModel.Collection<System.Windows.ResourceDictionary> MergedDictionaries
        {
            get => __ProxyValue.MergedDictionaries;
        }

        public System.Uri Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Boolean InvalidatesImplicitDataTemplateResources
        {
            get => __ProxyValue.InvalidatesImplicitDataTemplateResources;
            set => __ProxyValue.InvalidatesImplicitDataTemplateResources = value;
        }

        public System.Object Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Windows.DeferrableContent DeferrableContent
        {
            get => __ProxyValue.DeferrableContent;
            set => __ProxyValue.DeferrableContent = value;
        }

        public System.Collections.ICollection Keys
        {
            get => __ProxyValue.Keys;
        }

        public System.Collections.ICollection Values
        {
            get => __ProxyValue.Values;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public ResourceDictionary(): base()
        {
        }

        public void CopyTo(System.Collections.DictionaryEntry[] array, System.Int32 arrayIndex) => __ProxyValue.CopyTo(@array, @arrayIndex);
        public void RegisterName(System.String name, System.Object scopedElement) => __ProxyValue.RegisterName(@name, @scopedElement);
        public void UnregisterName(System.String name) => __ProxyValue.UnregisterName(@name);
        public System.Object FindName(System.String name) => __ProxyValue.FindName(@name);
        public void Add(System.Object key, System.Object value) => __ProxyValue.Add(@key, @value);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Object key) => __ProxyValue.Contains(@key);
        public System.Collections.IDictionaryEnumerator GetEnumerator() => __ProxyValue.GetEnumerator();
        public void Remove(System.Object key) => __ProxyValue.Remove(@key);
        public void BeginInit() => __ProxyValue.BeginInit();
        public void EndInit() => __ProxyValue.EndInit();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}