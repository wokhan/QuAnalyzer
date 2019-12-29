namespace System.Windows.Media.Media3D.Converters
{
    using Uno.UI.Generic;

    public class Matrix3DValueSerializer : Proxy<global::Windows.UI.Xaml.Media.Media3D.Converters.Matrix3DValueSerializer>
    {
        public Matrix3DValueSerializer(): base()
        {
        }

        public System.Boolean CanConvertFromString(System.String value, System.Windows.Markup.IValueSerializerContext context) => __ProxyValue.CanConvertFromString(@value, @context);
        public System.Boolean CanConvertToString(System.Object value, System.Windows.Markup.IValueSerializerContext context) => __ProxyValue.CanConvertToString(@value, @context);
        public System.Object ConvertFromString(System.String value, System.Windows.Markup.IValueSerializerContext context) => __ProxyValue.ConvertFromString(@value, @context);
        public System.String ConvertToString(System.Object value, System.Windows.Markup.IValueSerializerContext context) => __ProxyValue.ConvertToString(@value, @context);
        public System.Collections.Generic.IEnumerable<System.Type> TypeReferences(System.Object value, System.Windows.Markup.IValueSerializerContext context) => __ProxyValue.TypeReferences(@value, @context);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}