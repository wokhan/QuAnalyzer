namespace System.Windows
{
    using Uno.UI.Generic;

    public class IDataObject : Proxy<global::Windows.UI.Xaml.IDataObject>
    {
        public System.Object GetData(System.String format) => __ProxyValue.GetData(@format);
        public System.Object GetData(System.Type format) => __ProxyValue.GetData(@format);
        public System.Object GetData(System.String format, System.Boolean autoConvert) => __ProxyValue.GetData(@format, @autoConvert);
        public System.Boolean GetDataPresent(System.String format) => __ProxyValue.GetDataPresent(@format);
        public System.Boolean GetDataPresent(System.Type format) => __ProxyValue.GetDataPresent(@format);
        public System.Boolean GetDataPresent(System.String format, System.Boolean autoConvert) => __ProxyValue.GetDataPresent(@format, @autoConvert);
        public System.String[] GetFormats() => __ProxyValue.GetFormats();
        public System.String[] GetFormats(System.Boolean autoConvert) => __ProxyValue.GetFormats(@autoConvert);
        public void SetData(System.Object data) => __ProxyValue.SetData(@data);
        public void SetData(System.String format, System.Object data) => __ProxyValue.SetData(@format, @data);
        public void SetData(System.Type format, System.Object data) => __ProxyValue.SetData(@format, @data);
        public void SetData(System.String format, System.Object data, System.Boolean autoConvert) => __ProxyValue.SetData(@format, @data, @autoConvert);
    }
}