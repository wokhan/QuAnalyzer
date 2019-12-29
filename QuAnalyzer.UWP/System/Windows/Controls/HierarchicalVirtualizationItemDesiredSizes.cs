namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class HierarchicalVirtualizationItemDesiredSizes : Proxy<global::Windows.UI.Xaml.Controls.HierarchicalVirtualizationItemDesiredSizes>
    {
        public System.Windows.Size LogicalSize
        {
            get => __ProxyValue.LogicalSize;
        }

        public System.Windows.Size LogicalSizeInViewport
        {
            get => __ProxyValue.LogicalSizeInViewport;
        }

        public System.Windows.Size LogicalSizeBeforeViewport
        {
            get => __ProxyValue.LogicalSizeBeforeViewport;
        }

        public System.Windows.Size LogicalSizeAfterViewport
        {
            get => __ProxyValue.LogicalSizeAfterViewport;
        }

        public System.Windows.Size PixelSize
        {
            get => __ProxyValue.PixelSize;
        }

        public System.Windows.Size PixelSizeInViewport
        {
            get => __ProxyValue.PixelSizeInViewport;
        }

        public System.Windows.Size PixelSizeBeforeViewport
        {
            get => __ProxyValue.PixelSizeBeforeViewport;
        }

        public System.Windows.Size PixelSizeAfterViewport
        {
            get => __ProxyValue.PixelSizeAfterViewport;
        }

        public HierarchicalVirtualizationItemDesiredSizes(System.Windows.Size @logicalSize, System.Windows.Size @logicalSizeInViewport, System.Windows.Size @logicalSizeBeforeViewport, System.Windows.Size @logicalSizeAfterViewport, System.Windows.Size @pixelSize, System.Windows.Size @pixelSizeInViewport, System.Windows.Size @pixelSizeBeforeViewport, System.Windows.Size @pixelSizeAfterViewport): base(@logicalSize, @logicalSizeInViewport, @logicalSizeBeforeViewport, @logicalSizeAfterViewport, @pixelSize, @pixelSizeInViewport, @pixelSizeBeforeViewport, @pixelSizeAfterViewport)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.HierarchicalVirtualizationItemDesiredSizes itemDesiredSizes1, System.Windows.Controls.HierarchicalVirtualizationItemDesiredSizes itemDesiredSizes2) => Windows.UI.Xaml.Controls.HierarchicalVirtualizationItemDesiredSizes.op_Equality(@itemDesiredSizes1, @itemDesiredSizes2);
        public static System.Boolean op_Inequality(System.Windows.Controls.HierarchicalVirtualizationItemDesiredSizes itemDesiredSizes1, System.Windows.Controls.HierarchicalVirtualizationItemDesiredSizes itemDesiredSizes2) => Windows.UI.Xaml.Controls.HierarchicalVirtualizationItemDesiredSizes.op_Inequality(@itemDesiredSizes1, @itemDesiredSizes2);
        public override System.Boolean Equals(System.Object oCompare) => __ProxyValue.Equals(@oCompare);
        public System.Boolean Equals(System.Windows.Controls.HierarchicalVirtualizationItemDesiredSizes comparisonItemSizes) => __ProxyValue.Equals(@comparisonItemSizes);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}