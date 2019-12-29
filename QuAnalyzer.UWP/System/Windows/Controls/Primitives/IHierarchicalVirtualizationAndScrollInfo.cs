namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class IHierarchicalVirtualizationAndScrollInfo : Proxy<global::Windows.UI.Xaml.Controls.Primitives.IHierarchicalVirtualizationAndScrollInfo>
    {
        public System.Windows.Controls.HierarchicalVirtualizationConstraints Constraints
        {
            get => __ProxyValue.Constraints;
            set => __ProxyValue.Constraints = value;
        }

        public System.Windows.Controls.HierarchicalVirtualizationHeaderDesiredSizes HeaderDesiredSizes
        {
            get => __ProxyValue.HeaderDesiredSizes;
        }

        public System.Windows.Controls.HierarchicalVirtualizationItemDesiredSizes ItemDesiredSizes
        {
            get => __ProxyValue.ItemDesiredSizes;
            set => __ProxyValue.ItemDesiredSizes = value;
        }

        public System.Windows.Controls.Panel ItemsHost
        {
            get => __ProxyValue.ItemsHost;
        }

        public System.Boolean MustDisableVirtualization
        {
            get => __ProxyValue.MustDisableVirtualization;
            set => __ProxyValue.MustDisableVirtualization = value;
        }

        public System.Boolean InBackgroundLayout
        {
            get => __ProxyValue.InBackgroundLayout;
            set => __ProxyValue.InBackgroundLayout = value;
        }
    }
}