namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CollectionViewGroup : Proxy<global::Windows.UI.Xaml.Data.CollectionViewGroup>
    {
        public System.Object Name
        {
            get => __ProxyValue.Name;
        }

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<System.Object> Items
        {
            get => __ProxyValue.Items;
        }

        public System.Int32 ItemCount
        {
            get => __ProxyValue.ItemCount;
        }

        public System.Boolean IsBottomLevel
        {
            get => __ProxyValue.IsBottomLevel;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}