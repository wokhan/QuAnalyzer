namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class WritingCancelledEventArgs : Proxy<global::Windows.UI.Xaml.Documents.Serialization.WritingCancelledEventArgs>
    {
        public System.Exception Error
        {
            get => __ProxyValue.Error;
        }

        public WritingCancelledEventArgs(System.Exception @exception): base(@exception)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}