namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class DynamicDocumentPaginator : Proxy<global::Windows.UI.Xaml.Documents.DynamicDocumentPaginator>
    {
        public System.Boolean IsBackgroundPaginationEnabled
        {
            get => __ProxyValue.IsBackgroundPaginationEnabled;
            set => __ProxyValue.IsBackgroundPaginationEnabled = value;
        }

        public System.Boolean IsPageCountValid
        {
            get => __ProxyValue.IsPageCountValid;
        }

        public System.Int32 PageCount
        {
            get => __ProxyValue.PageCount;
        }

        public System.Windows.Size PageSize
        {
            get => __ProxyValue.PageSize;
            set => __ProxyValue.PageSize = value;
        }

        public System.Windows.Documents.IDocumentPaginatorSource Source
        {
            get => __ProxyValue.Source;
        }

        public System.Int32 GetPageNumber(System.Windows.Documents.ContentPosition contentPosition) => __ProxyValue.GetPageNumber(@contentPosition);
        public void GetPageNumberAsync(System.Windows.Documents.ContentPosition contentPosition) => __ProxyValue.GetPageNumberAsync(@contentPosition);
        public void GetPageNumberAsync(System.Windows.Documents.ContentPosition contentPosition, System.Object userState) => __ProxyValue.GetPageNumberAsync(@contentPosition, @userState);
        public System.Windows.Documents.ContentPosition GetPagePosition(System.Windows.Documents.DocumentPage page) => __ProxyValue.GetPagePosition(@page);
        public System.Windows.Documents.ContentPosition GetObjectPosition(System.Object value) => __ProxyValue.GetObjectPosition(@value);
        public void add_GetPageNumberCompleted(System.Windows.Documents.GetPageNumberCompletedEventHandler value) => __ProxyValue.add_GetPageNumberCompleted(@value);
        public void remove_GetPageNumberCompleted(System.Windows.Documents.GetPageNumberCompletedEventHandler value) => __ProxyValue.remove_GetPageNumberCompleted(@value);
        public void add_PaginationCompleted(System.EventHandler value) => __ProxyValue.add_PaginationCompleted(@value);
        public void remove_PaginationCompleted(System.EventHandler value) => __ProxyValue.remove_PaginationCompleted(@value);
        public void add_PaginationProgress(System.Windows.Documents.PaginationProgressEventHandler value) => __ProxyValue.add_PaginationProgress(@value);
        public void remove_PaginationProgress(System.Windows.Documents.PaginationProgressEventHandler value) => __ProxyValue.remove_PaginationProgress(@value);
        public System.Windows.Documents.DocumentPage GetPage(System.Int32 pageNumber) => __ProxyValue.GetPage(@pageNumber);
        public void GetPageAsync(System.Int32 pageNumber) => __ProxyValue.GetPageAsync(@pageNumber);
        public void GetPageAsync(System.Int32 pageNumber, System.Object userState) => __ProxyValue.GetPageAsync(@pageNumber, @userState);
        public void ComputePageCount() => __ProxyValue.ComputePageCount();
        public void ComputePageCountAsync() => __ProxyValue.ComputePageCountAsync();
        public void ComputePageCountAsync(System.Object userState) => __ProxyValue.ComputePageCountAsync(@userState);
        public void CancelAsync(System.Object userState) => __ProxyValue.CancelAsync(@userState);
        public void add_GetPageCompleted(System.Windows.Documents.GetPageCompletedEventHandler value) => __ProxyValue.add_GetPageCompleted(@value);
        public void remove_GetPageCompleted(System.Windows.Documents.GetPageCompletedEventHandler value) => __ProxyValue.remove_GetPageCompleted(@value);
        public void add_ComputePageCountCompleted(System.ComponentModel.AsyncCompletedEventHandler value) => __ProxyValue.add_ComputePageCountCompleted(@value);
        public void remove_ComputePageCountCompleted(System.ComponentModel.AsyncCompletedEventHandler value) => __ProxyValue.remove_ComputePageCountCompleted(@value);
        public void add_PagesChanged(System.Windows.Documents.PagesChangedEventHandler value) => __ProxyValue.add_PagesChanged(@value);
        public void remove_PagesChanged(System.Windows.Documents.PagesChangedEventHandler value) => __ProxyValue.remove_PagesChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}