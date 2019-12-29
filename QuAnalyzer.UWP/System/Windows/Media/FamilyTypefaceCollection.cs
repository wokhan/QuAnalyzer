﻿namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class FamilyTypefaceCollection : Proxy<global::Windows.UI.Xaml.Media.FamilyTypefaceCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Windows.Media.FamilyTypeface Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public System.Collections.Generic.IEnumerator<System.Windows.Media.FamilyTypeface> GetEnumerator() => __ProxyValue.GetEnumerator();
        public void Add(System.Windows.Media.FamilyTypeface item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public System.Boolean Contains(System.Windows.Media.FamilyTypeface item) => __ProxyValue.Contains(@item);
        public void CopyTo(System.Windows.Media.FamilyTypeface[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Remove(System.Windows.Media.FamilyTypeface item) => __ProxyValue.Remove(@item);
        public System.Int32 IndexOf(System.Windows.Media.FamilyTypeface item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.Media.FamilyTypeface item) => __ProxyValue.Insert(@index, @item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}