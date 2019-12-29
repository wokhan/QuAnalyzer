namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class PrintDialog : Proxy<global::Windows.UI.Xaml.Controls.PrintDialog>
    {
        public System.Windows.Controls.PageRangeSelection PageRangeSelection
        {
            get => __ProxyValue.PageRangeSelection;
            set => __ProxyValue.PageRangeSelection = value;
        }

        public System.Windows.Controls.PageRange PageRange
        {
            get => __ProxyValue.PageRange;
            set => __ProxyValue.PageRange = value;
        }

        public System.Boolean UserPageRangeEnabled
        {
            get => __ProxyValue.UserPageRangeEnabled;
            set => __ProxyValue.UserPageRangeEnabled = value;
        }

        public System.Boolean SelectedPagesEnabled
        {
            get => __ProxyValue.SelectedPagesEnabled;
            set => __ProxyValue.SelectedPagesEnabled = value;
        }

        public System.Boolean CurrentPageEnabled
        {
            get => __ProxyValue.CurrentPageEnabled;
            set => __ProxyValue.CurrentPageEnabled = value;
        }

        public System.UInt32 MinPage
        {
            get => __ProxyValue.MinPage;
            set => __ProxyValue.MinPage = value;
        }

        public System.UInt32 MaxPage
        {
            get => __ProxyValue.MaxPage;
            set => __ProxyValue.MaxPage = value;
        }

        public System.Printing.PrintQueue PrintQueue
        {
            get => __ProxyValue.PrintQueue;
            set => __ProxyValue.PrintQueue = value;
        }

        public System.Printing.PrintTicket PrintTicket
        {
            get => __ProxyValue.PrintTicket;
            set => __ProxyValue.PrintTicket = value;
        }

        public System.Double PrintableAreaWidth
        {
            get => __ProxyValue.PrintableAreaWidth;
        }

        public System.Double PrintableAreaHeight
        {
            get => __ProxyValue.PrintableAreaHeight;
        }

        public PrintDialog(): base()
        {
        }

        public System.Nullable<System.Boolean> ShowDialog() => __ProxyValue.ShowDialog();
        public void PrintVisual(System.Windows.Media.Visual visual, System.String description) => __ProxyValue.PrintVisual(@visual, @description);
        public void PrintDocument(System.Windows.Documents.DocumentPaginator documentPaginator, System.String description) => __ProxyValue.PrintDocument(@documentPaginator, @description);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}