namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class HierarchicalVirtualizationHeaderDesiredSizes : Proxy<global::Windows.UI.Xaml.Controls.HierarchicalVirtualizationHeaderDesiredSizes>
    {
        public System.Windows.Size LogicalSize
        {
            get => __ProxyValue.LogicalSize;
        }

        public System.Windows.Size PixelSize
        {
            get => __ProxyValue.PixelSize;
        }

        public HierarchicalVirtualizationHeaderDesiredSizes(System.Windows.Size @logicalSize, System.Windows.Size @pixelSize): base(@logicalSize, @pixelSize)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.HierarchicalVirtualizationHeaderDesiredSizes headerDesiredSizes1, System.Windows.Controls.HierarchicalVirtualizationHeaderDesiredSizes headerDesiredSizes2) => Windows.UI.Xaml.Controls.HierarchicalVirtualizationHeaderDesiredSizes.op_Equality(@headerDesiredSizes1, @headerDesiredSizes2);
        public static System.Boolean op_Inequality(System.Windows.Controls.HierarchicalVirtualizationHeaderDesiredSizes headerDesiredSizes1, System.Windows.Controls.HierarchicalVirtualizationHeaderDesiredSizes headerDesiredSizes2) => Windows.UI.Xaml.Controls.HierarchicalVirtualizationHeaderDesiredSizes.op_Inequality(@headerDesiredSizes1, @headerDesiredSizes2);
        public override System.Boolean Equals(System.Object oCompare) => __ProxyValue.Equals(@oCompare);
        public System.Boolean Equals(System.Windows.Controls.HierarchicalVirtualizationHeaderDesiredSizes comparisonHeaderSizes) => __ProxyValue.Equals(@comparisonHeaderSizes);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}