namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class GetPageNumberCompletedEventArgs : Proxy<global::Windows.UI.Xaml.Documents.GetPageNumberCompletedEventArgs>
    {
        public System.Windows.Documents.ContentPosition ContentPosition
        {
            get => __ProxyValue.ContentPosition;
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

        public GetPageNumberCompletedEventArgs(System.Windows.Documents.ContentPosition @contentPosition, System.Int32 @pageNumber, System.Exception @error, System.Boolean @cancelled, System.Object @userState): base(@contentPosition, @pageNumber, @error, @cancelled, @userState)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}