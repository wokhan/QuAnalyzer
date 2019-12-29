namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class RelativeSource : Proxy<global::Windows.UI.Xaml.Data.RelativeSource>
    {
        public static System.Windows.Data.RelativeSource PreviousData
        {
            get => __ProxyValue.PreviousData;
        }

        public static System.Windows.Data.RelativeSource TemplatedParent
        {
            get => __ProxyValue.TemplatedParent;
        }

        public static System.Windows.Data.RelativeSource Self
        {
            get => __ProxyValue.Self;
        }

        public System.Windows.Data.RelativeSourceMode Mode
        {
            get => __ProxyValue.Mode;
            set => __ProxyValue.Mode = value;
        }

        public System.Type AncestorType
        {
            get => __ProxyValue.AncestorType;
            set => __ProxyValue.AncestorType = value;
        }

        public System.Int32 AncestorLevel
        {
            get => __ProxyValue.AncestorLevel;
            set => __ProxyValue.AncestorLevel = value;
        }

        public RelativeSource(): base()
        {
        }

        public RelativeSource(System.Windows.Data.RelativeSourceMode @mode): base(@mode)
        {
        }

        public RelativeSource(System.Windows.Data.RelativeSourceMode @mode, System.Type @ancestorType, System.Int32 @ancestorLevel): base(@mode, @ancestorType, @ancestorLevel)
        {
        }

        public System.Boolean ShouldSerializeAncestorType() => __ProxyValue.ShouldSerializeAncestorType();
        public System.Boolean ShouldSerializeAncestorLevel() => __ProxyValue.ShouldSerializeAncestorLevel();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}