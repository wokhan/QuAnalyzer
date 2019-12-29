namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusPointPropertyInfo : Proxy<global::Windows.UI.Xaml.Input.StylusPointPropertyInfo>
    {
        public System.Int32 Minimum
        {
            get => __ProxyValue.Minimum;
        }

        public System.Int32 Maximum
        {
            get => __ProxyValue.Maximum;
        }

        public System.Single Resolution
        {
            get => __ProxyValue.Resolution;
        }

        public System.Windows.Input.StylusPointPropertyUnit Unit
        {
            get => __ProxyValue.Unit;
        }

        public System.Guid Id
        {
            get => __ProxyValue.Id;
        }

        public System.Boolean IsButton
        {
            get => __ProxyValue.IsButton;
        }

        public StylusPointPropertyInfo(System.Windows.Input.StylusPointProperty @stylusPointProperty): base(@stylusPointProperty)
        {
        }

        public StylusPointPropertyInfo(System.Windows.Input.StylusPointProperty @stylusPointProperty, System.Int32 @minimum, System.Int32 @maximum, System.Windows.Input.StylusPointPropertyUnit @unit, System.Single @resolution): base(@stylusPointProperty, @minimum, @maximum, @unit, @resolution)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}