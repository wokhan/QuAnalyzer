namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class GetPageRootCompletedEventArgs : Proxy<global::Windows.UI.Xaml.Documents.GetPageRootCompletedEventArgs>
    {
        public System.Windows.Documents.FixedPage Result
        {
            get => __ProxyValue.Result;
        }

        public System.Boolean Cancelled
        {
            get => __ProxyValue.Cancelled;
        }

        public System.Exception Error
        {
            get => __ProxyValue.Error;
        }

        public System.Object UserState
        {
            get => __ProxyValue.UserState;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}