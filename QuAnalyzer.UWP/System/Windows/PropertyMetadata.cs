namespace System.Windows
{
    using Uno.UI.Generic;

    public class PropertyMetadata : Proxy<global::Windows.UI.Xaml.PropertyMetadata>
    {
        public System.Object DefaultValue
        {
            get => __ProxyValue.DefaultValue;
            set => __ProxyValue.DefaultValue = value;
        }

        public System.Windows.PropertyChangedCallback PropertyChangedCallback
        {
            get => __ProxyValue.PropertyChangedCallback;
            set => __ProxyValue.PropertyChangedCallback = value;
        }

        public System.Windows.CoerceValueCallback CoerceValueCallback
        {
            get => __ProxyValue.CoerceValueCallback;
            set => __ProxyValue.CoerceValueCallback = value;
        }

        public PropertyMetadata(): base()
        {
        }

        public PropertyMetadata(System.Object @defaultValue): base(@defaultValue)
        {
        }

        public PropertyMetadata(System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@propertyChangedCallback)
        {
        }

        public PropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@defaultValue, @propertyChangedCallback)
        {
        }

        public PropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback): base(@defaultValue, @propertyChangedCallback, @coerceValueCallback)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}