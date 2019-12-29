namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class HierarchicalVirtualizationConstraints : Proxy<global::Windows.UI.Xaml.Controls.HierarchicalVirtualizationConstraints>
    {
        public System.Windows.Controls.VirtualizationCacheLength CacheLength
        {
            get => __ProxyValue.CacheLength;
        }

        public System.Windows.Controls.VirtualizationCacheLengthUnit CacheLengthUnit
        {
            get => __ProxyValue.CacheLengthUnit;
        }

        public System.Windows.Rect Viewport
        {
            get => __ProxyValue.Viewport;
        }

        public HierarchicalVirtualizationConstraints(System.Windows.Controls.VirtualizationCacheLength @cacheLength, System.Windows.Controls.VirtualizationCacheLengthUnit @cacheLengthUnit, System.Windows.Rect @viewport): base(@cacheLength, @cacheLengthUnit, @viewport)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.HierarchicalVirtualizationConstraints constraints1, System.Windows.Controls.HierarchicalVirtualizationConstraints constraints2) => Windows.UI.Xaml.Controls.HierarchicalVirtualizationConstraints.op_Equality(@constraints1, @constraints2);
        public static System.Boolean op_Inequality(System.Windows.Controls.HierarchicalVirtualizationConstraints constraints1, System.Windows.Controls.HierarchicalVirtualizationConstraints constraints2) => Windows.UI.Xaml.Controls.HierarchicalVirtualizationConstraints.op_Inequality(@constraints1, @constraints2);
        public override System.Boolean Equals(System.Object oCompare) => __ProxyValue.Equals(@oCompare);
        public System.Boolean Equals(System.Windows.Controls.HierarchicalVirtualizationConstraints comparisonConstraints) => __ProxyValue.Equals(@comparisonConstraints);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}