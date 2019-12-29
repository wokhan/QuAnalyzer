namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class AnnotationDocumentPaginator : Proxy<global::Windows.UI.Xaml.Annotations.AnnotationDocumentPaginator>
    {
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

        public AnnotationDocumentPaginator(System.Windows.Documents.DocumentPaginator @originalPaginator, System.IO.Stream @annotationStore): base(@originalPaginator, @annotationStore)
        {
        }

        public AnnotationDocumentPaginator(System.Windows.Documents.DocumentPaginator @originalPaginator, System.IO.Stream @annotationStore, System.Windows.FlowDirection @flowDirection): base(@originalPaginator, @annotationStore, @flowDirection)
        {
        }

        public AnnotationDocumentPaginator(System.Windows.Documents.DocumentPaginator @originalPaginator, System.Windows.Annotations.Storage.AnnotationStore @annotationStore): base(@originalPaginator, @annotationStore)
        {
        }

        public AnnotationDocumentPaginator(System.Windows.Documents.DocumentPaginator @originalPaginator, System.Windows.Annotations.Storage.AnnotationStore @annotationStore, System.Windows.FlowDirection @flowDirection): base(@originalPaginator, @annotationStore, @flowDirection)
        {
        }

        public System.Windows.Documents.DocumentPage GetPage(System.Int32 pageNumber) => __ProxyValue.GetPage(@pageNumber);
        public void GetPageAsync(System.Int32 pageNumber, System.Object userState) => __ProxyValue.GetPageAsync(@pageNumber, @userState);
        public void ComputePageCount() => __ProxyValue.ComputePageCount();
        public void ComputePageCountAsync(System.Object userState) => __ProxyValue.ComputePageCountAsync(@userState);
        public void CancelAsync(System.Object userState) => __ProxyValue.CancelAsync(@userState);
        public void GetPageAsync(System.Int32 pageNumber) => __ProxyValue.GetPageAsync(@pageNumber);
        public void ComputePageCountAsync() => __ProxyValue.ComputePageCountAsync();
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