namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class XamlParseException : Proxy<global::Windows.UI.Xaml.Markup.XamlParseException>
    {
        public System.Int32 LineNumber
        {
            get => __ProxyValue.LineNumber;
        }

        public System.Int32 LinePosition
        {
            get => __ProxyValue.LinePosition;
        }

        public System.Object KeyContext
        {
            get => __ProxyValue.KeyContext;
        }

        public System.String UidContext
        {
            get => __ProxyValue.UidContext;
        }

        public System.String NameContext
        {
            get => __ProxyValue.NameContext;
        }

        public System.Uri BaseUri
        {
            get => __ProxyValue.BaseUri;
        }

        public System.Reflection.MethodBase TargetSite
        {
            get => __ProxyValue.TargetSite;
        }

        public System.String StackTrace
        {
            get => __ProxyValue.StackTrace;
        }

        public System.String Message
        {
            get => __ProxyValue.Message;
        }

        public System.Collections.IDictionary Data
        {
            get => __ProxyValue.Data;
        }

        public System.Exception InnerException
        {
            get => __ProxyValue.InnerException;
        }

        public System.String HelpLink
        {
            get => __ProxyValue.HelpLink;
            set => __ProxyValue.HelpLink = value;
        }

        public System.String Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Int32 HResult
        {
            get => __ProxyValue.HResult;
            set => __ProxyValue.HResult = value;
        }

        public XamlParseException(): base()
        {
        }

        public XamlParseException(System.String @message): base(@message)
        {
        }

        public XamlParseException(System.String @message, System.Exception @innerException): base(@message, @innerException)
        {
        }

        public XamlParseException(System.String @message, System.Int32 @lineNumber, System.Int32 @linePosition): base(@message, @lineNumber, @linePosition)
        {
        }

        public XamlParseException(System.String @message, System.Int32 @lineNumber, System.Int32 @linePosition, System.Exception @innerException): base(@message, @lineNumber, @linePosition, @innerException)
        {
        }

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public System.Exception GetBaseException() => __ProxyValue.GetBaseException();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}