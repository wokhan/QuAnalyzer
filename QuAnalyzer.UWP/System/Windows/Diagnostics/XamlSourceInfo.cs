namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class XamlSourceInfo : Proxy<global::Windows.UI.Xaml.Diagnostics.XamlSourceInfo>
    {
        public System.Uri SourceUri
        {
            get => __ProxyValue.SourceUri;
        }

        public System.Int32 LineNumber
        {
            get => __ProxyValue.LineNumber;
        }

        public System.Int32 LinePosition
        {
            get => __ProxyValue.LinePosition;
        }

        public XamlSourceInfo(System.Uri @sourceUri, System.Int32 @lineNumber, System.Int32 @linePosition): base(@sourceUri, @lineNumber, @linePosition)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}