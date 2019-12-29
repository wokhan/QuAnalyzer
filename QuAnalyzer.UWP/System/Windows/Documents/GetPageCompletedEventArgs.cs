namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class GetPageCompletedEventArgs : Proxy<global::Windows.UI.Xaml.Documents.GetPageCompletedEventArgs>
    {
        public System.Windows.Documents.DocumentPage DocumentPage
        {
            get => __ProxyValue.DocumentPage;
        }

        public System.Int32 PageNumber
        {
            get => __ProxyValue.PageNumber;
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

        public GetPageCompletedEventArgs(System.Windows.Documents.DocumentPage @page, System.Int32 @pageNumber, System.Exception @error, System.Boolean @cancelled, System.Object @userState): base(@page, @pageNumber, @error, @cancelled, @userState)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}