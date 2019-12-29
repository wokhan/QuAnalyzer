namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class XmlDataProvider : Proxy<global::Windows.UI.Xaml.Data.XmlDataProvider>
    {
        public System.Uri Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Xml.XmlDocument Document
        {
            get => __ProxyValue.Document;
            set => __ProxyValue.Document = value;
        }

        public System.String XPath
        {
            get => __ProxyValue.XPath;
            set => __ProxyValue.XPath = value;
        }

        public System.Xml.XmlNamespaceManager XmlNamespaceManager
        {
            get => __ProxyValue.XmlNamespaceManager;
            set => __ProxyValue.XmlNamespaceManager = value;
        }

        public System.Boolean IsAsynchronous
        {
            get => __ProxyValue.IsAsynchronous;
            set => __ProxyValue.IsAsynchronous = value;
        }

        public System.Xml.Serialization.IXmlSerializable XmlSerializer
        {
            get => __ProxyValue.XmlSerializer;
        }

        public System.Boolean IsInitialLoadEnabled
        {
            get => __ProxyValue.IsInitialLoadEnabled;
            set => __ProxyValue.IsInitialLoadEnabled = value;
        }

        public System.Object Data
        {
            get => __ProxyValue.Data;
        }

        public System.Exception Error
        {
            get => __ProxyValue.Error;
        }

        public XmlDataProvider(): base()
        {
        }

        public System.Boolean ShouldSerializeSource() => __ProxyValue.ShouldSerializeSource();
        public System.Boolean ShouldSerializeXPath() => __ProxyValue.ShouldSerializeXPath();
        public System.Boolean ShouldSerializeXmlSerializer() => __ProxyValue.ShouldSerializeXmlSerializer();
        public void InitialLoad() => __ProxyValue.InitialLoad();
        public void Refresh() => __ProxyValue.Refresh();
        public void add_DataChanged(System.EventHandler value) => __ProxyValue.add_DataChanged(@value);
        public void remove_DataChanged(System.EventHandler value) => __ProxyValue.remove_DataChanged(@value);
        public System.IDisposable DeferRefresh() => __ProxyValue.DeferRefresh();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}