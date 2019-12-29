namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class ValueConversionAttribute : Proxy<global::Windows.UI.Xaml.Data.ValueConversionAttribute>
    {
        public System.Type SourceType
        {
            get => __ProxyValue.SourceType;
        }

        public System.Type TargetType
        {
            get => __ProxyValue.TargetType;
        }

        public System.Type ParameterType
        {
            get => __ProxyValue.ParameterType;
            set => __ProxyValue.ParameterType = value;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public ValueConversionAttribute(System.Type @sourceType, System.Type @targetType): base(@sourceType, @targetType)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}