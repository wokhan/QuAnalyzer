namespace System.Windows
{
    using Uno.UI.Generic;

    public class UIPropertyMetadata : Proxy<global::Windows.UI.Xaml.UIPropertyMetadata>
    {
        public System.Boolean IsAnimationProhibited
        {
            get => __ProxyValue.IsAnimationProhibited;
            set => __ProxyValue.IsAnimationProhibited = value;
        }

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

        public UIPropertyMetadata(): base()
        {
        }

        public UIPropertyMetadata(System.Object @defaultValue): base(@defaultValue)
        {
        }

        public UIPropertyMetadata(System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@propertyChangedCallback)
        {
        }

        public UIPropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@defaultValue, @propertyChangedCallback)
        {
        }

        public UIPropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback): base(@defaultValue, @propertyChangedCallback, @coerceValueCallback)
        {
        }

        public UIPropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback, System.Boolean @isAnimationProhibited): base(@defaultValue, @propertyChangedCallback, @coerceValueCallback, @isAnimationProhibited)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}