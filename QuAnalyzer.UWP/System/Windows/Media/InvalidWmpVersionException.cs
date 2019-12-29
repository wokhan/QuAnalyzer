namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class InvalidWmpVersionException : Proxy<global::Windows.UI.Xaml.Media.InvalidWmpVersionException>
    {
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

        public InvalidWmpVersionException(): base()
        {
        }

        public InvalidWmpVersionException(System.String @message): base(@message)
        {
        }

        public InvalidWmpVersionException(System.String @message, System.Exception @innerException): base(@message, @innerException)
        {
        }

        public System.Exception GetBaseException() => __ProxyValue.GetBaseException();
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}