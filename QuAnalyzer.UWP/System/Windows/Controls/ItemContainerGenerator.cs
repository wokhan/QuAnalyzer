namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ItemContainerGenerator : Proxy<global::Windows.UI.Xaml.Controls.ItemContainerGenerator>
    {
        public System.Windows.Controls.Primitives.GeneratorStatus Status
        {
            get => __ProxyValue.Status;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Object> Items
        {
            get => __ProxyValue.Items;
        }

        public System.IDisposable GenerateBatches() => __ProxyValue.GenerateBatches();
        public System.Object ItemFromContainer(System.Windows.DependencyObject container) => __ProxyValue.ItemFromContainer(@container);
        public System.Windows.DependencyObject ContainerFromItem(System.Object item) => __ProxyValue.ContainerFromItem(@item);
        public System.Int32 IndexFromContainer(System.Windows.DependencyObject container) => __ProxyValue.IndexFromContainer(@container);
        public System.Int32 IndexFromContainer(System.Windows.DependencyObject container, System.Boolean returnLocalIndex) => __ProxyValue.IndexFromContainer(@container, @returnLocalIndex);
        public System.Windows.DependencyObject ContainerFromIndex(System.Int32 index) => __ProxyValue.ContainerFromIndex(@index);
        public void add_ItemsChanged(System.Windows.Controls.Primitives.ItemsChangedEventHandler value) => __ProxyValue.add_ItemsChanged(@value);
        public void remove_ItemsChanged(System.Windows.Controls.Primitives.ItemsChangedEventHandler value) => __ProxyValue.remove_ItemsChanged(@value);
        public void add_StatusChanged(System.EventHandler value) => __ProxyValue.add_StatusChanged(@value);
        public void remove_StatusChanged(System.EventHandler value) => __ProxyValue.remove_StatusChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}