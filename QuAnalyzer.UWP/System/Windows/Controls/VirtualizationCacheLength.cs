namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class VirtualizationCacheLength : Proxy<global::Windows.UI.Xaml.Controls.VirtualizationCacheLength>
    {
        public System.Double CacheBeforeViewport
        {
            get => __ProxyValue.CacheBeforeViewport;
        }

        public System.Double CacheAfterViewport
        {
            get => __ProxyValue.CacheAfterViewport;
        }

        public VirtualizationCacheLength(System.Double @cacheBeforeAndAfterViewport): base(@cacheBeforeAndAfterViewport)
        {
        }

        public VirtualizationCacheLength(System.Double @cacheBeforeViewport, System.Double @cacheAfterViewport): base(@cacheBeforeViewport, @cacheAfterViewport)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.VirtualizationCacheLength cl1, System.Windows.Controls.VirtualizationCacheLength cl2) => Windows.UI.Xaml.Controls.VirtualizationCacheLength.op_Equality(@cl1, @cl2);
        public static System.Boolean op_Inequality(System.Windows.Controls.VirtualizationCacheLength cl1, System.Windows.Controls.VirtualizationCacheLength cl2) => Windows.UI.Xaml.Controls.VirtualizationCacheLength.op_Inequality(@cl1, @cl2);
        public override System.Boolean Equals(System.Object oCompare) => __ProxyValue.Equals(@oCompare);
        public System.Boolean Equals(System.Windows.Controls.VirtualizationCacheLength cacheLength) => __ProxyValue.Equals(@cacheLength);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}