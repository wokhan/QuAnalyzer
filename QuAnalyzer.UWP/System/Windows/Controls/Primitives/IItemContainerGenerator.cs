namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class IItemContainerGenerator : Proxy<global::Windows.UI.Xaml.Controls.Primitives.IItemContainerGenerator>
    {
        public System.Windows.Controls.ItemContainerGenerator GetItemContainerGeneratorForPanel(System.Windows.Controls.Panel panel) => __ProxyValue.GetItemContainerGeneratorForPanel(@panel);
        public System.IDisposable StartAt(System.Windows.Controls.Primitives.GeneratorPosition position, System.Windows.Controls.Primitives.GeneratorDirection direction) => __ProxyValue.StartAt(@position, @direction);
        public System.IDisposable StartAt(System.Windows.Controls.Primitives.GeneratorPosition position, System.Windows.Controls.Primitives.GeneratorDirection direction, System.Boolean allowStartAtRealizedItem) => __ProxyValue.StartAt(@position, @direction, @allowStartAtRealizedItem);
        public System.Windows.DependencyObject GenerateNext() => __ProxyValue.GenerateNext();
        public System.Windows.DependencyObject GenerateNext(out System.Boolean isNewlyRealized) => __ProxyValue.GenerateNext(@isNewlyRealized);
        public void PrepareItemContainer(System.Windows.DependencyObject container) => __ProxyValue.PrepareItemContainer(@container);
        public void RemoveAll() => __ProxyValue.RemoveAll();
        public void Remove(System.Windows.Controls.Primitives.GeneratorPosition position, System.Int32 count) => __ProxyValue.Remove(@position, @count);
        public System.Windows.Controls.Primitives.GeneratorPosition GeneratorPositionFromIndex(System.Int32 itemIndex) => __ProxyValue.GeneratorPositionFromIndex(@itemIndex);
        public System.Int32 IndexFromGeneratorPosition(System.Windows.Controls.Primitives.GeneratorPosition position) => __ProxyValue.IndexFromGeneratorPosition(@position);
    }
}