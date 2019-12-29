namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class SerializerWriter : Proxy<global::Windows.UI.Xaml.Documents.Serialization.SerializerWriter>
    {
        public void Write(System.Windows.Media.Visual visual) => __ProxyValue.Write(@visual);
        public void Write(System.Windows.Media.Visual visual, System.Printing.PrintTicket printTicket) => __ProxyValue.Write(@visual, @printTicket);
        public void WriteAsync(System.Windows.Media.Visual visual) => __ProxyValue.WriteAsync(@visual);
        public void WriteAsync(System.Windows.Media.Visual visual, System.Object userState) => __ProxyValue.WriteAsync(@visual, @userState);
        public void WriteAsync(System.Windows.Media.Visual visual, System.Printing.PrintTicket printTicket) => __ProxyValue.WriteAsync(@visual, @printTicket);
        public void WriteAsync(System.Windows.Media.Visual visual, System.Printing.PrintTicket printTicket, System.Object userState) => __ProxyValue.WriteAsync(@visual, @printTicket, @userState);
        public void Write(System.Windows.Documents.DocumentPaginator documentPaginator) => __ProxyValue.Write(@documentPaginator);
        public void Write(System.Windows.Documents.DocumentPaginator documentPaginator, System.Printing.PrintTicket printTicket) => __ProxyValue.Write(@documentPaginator, @printTicket);
        public void WriteAsync(System.Windows.Documents.DocumentPaginator documentPaginator) => __ProxyValue.WriteAsync(@documentPaginator);
        public void WriteAsync(System.Windows.Documents.DocumentPaginator documentPaginator, System.Printing.PrintTicket printTicket) => __ProxyValue.WriteAsync(@documentPaginator, @printTicket);
        public void WriteAsync(System.Windows.Documents.DocumentPaginator documentPaginator, System.Object userState) => __ProxyValue.WriteAsync(@documentPaginator, @userState);
        public void WriteAsync(System.Windows.Documents.DocumentPaginator documentPaginator, System.Printing.PrintTicket printTicket, System.Object userState) => __ProxyValue.WriteAsync(@documentPaginator, @printTicket, @userState);
        public void Write(System.Windows.Documents.FixedPage fixedPage) => __ProxyValue.Write(@fixedPage);
        public void Write(System.Windows.Documents.FixedPage fixedPage, System.Printing.PrintTicket printTicket) => __ProxyValue.Write(@fixedPage, @printTicket);
        public void WriteAsync(System.Windows.Documents.FixedPage fixedPage) => __ProxyValue.WriteAsync(@fixedPage);
        public void WriteAsync(System.Windows.Documents.FixedPage fixedPage, System.Printing.PrintTicket printTicket) => __ProxyValue.WriteAsync(@fixedPage, @printTicket);
        public void WriteAsync(System.Windows.Documents.FixedPage fixedPage, System.Object userState) => __ProxyValue.WriteAsync(@fixedPage, @userState);
        public void WriteAsync(System.Windows.Documents.FixedPage fixedPage, System.Printing.PrintTicket printTicket, System.Object userState) => __ProxyValue.WriteAsync(@fixedPage, @printTicket, @userState);
        public void Write(System.Windows.Documents.FixedDocument fixedDocument) => __ProxyValue.Write(@fixedDocument);
        public void Write(System.Windows.Documents.FixedDocument fixedDocument, System.Printing.PrintTicket printTicket) => __ProxyValue.Write(@fixedDocument, @printTicket);
        public void WriteAsync(System.Windows.Documents.FixedDocument fixedDocument) => __ProxyValue.WriteAsync(@fixedDocument);
        public void WriteAsync(System.Windows.Documents.FixedDocument fixedDocument, System.Printing.PrintTicket printTicket) => __ProxyValue.WriteAsync(@fixedDocument, @printTicket);
        public void WriteAsync(System.Windows.Documents.FixedDocument fixedDocument, System.Object userState) => __ProxyValue.WriteAsync(@fixedDocument, @userState);
        public void WriteAsync(System.Windows.Documents.FixedDocument fixedDocument, System.Printing.PrintTicket printTicket, System.Object userState) => __ProxyValue.WriteAsync(@fixedDocument, @printTicket, @userState);
        public void Write(System.Windows.Documents.FixedDocumentSequence fixedDocumentSequence) => __ProxyValue.Write(@fixedDocumentSequence);
        public void Write(System.Windows.Documents.FixedDocumentSequence fixedDocumentSequence, System.Printing.PrintTicket printTicket) => __ProxyValue.Write(@fixedDocumentSequence, @printTicket);
        public void WriteAsync(System.Windows.Documents.FixedDocumentSequence fixedDocumentSequence) => __ProxyValue.WriteAsync(@fixedDocumentSequence);
        public void WriteAsync(System.Windows.Documents.FixedDocumentSequence fixedDocumentSequence, System.Printing.PrintTicket printTicket) => __ProxyValue.WriteAsync(@fixedDocumentSequence, @printTicket);
        public void WriteAsync(System.Windows.Documents.FixedDocumentSequence fixedDocumentSequence, System.Object userState) => __ProxyValue.WriteAsync(@fixedDocumentSequence, @userState);
        public void WriteAsync(System.Windows.Documents.FixedDocumentSequence fixedDocumentSequence, System.Printing.PrintTicket printTicket, System.Object userState) => __ProxyValue.WriteAsync(@fixedDocumentSequence, @printTicket, @userState);
        public void CancelAsync() => __ProxyValue.CancelAsync();
        public System.Windows.Documents.Serialization.SerializerWriterCollator CreateVisualsCollator() => __ProxyValue.CreateVisualsCollator();
        public System.Windows.Documents.Serialization.SerializerWriterCollator CreateVisualsCollator(System.Printing.PrintTicket documentSequencePT, System.Printing.PrintTicket documentPT) => __ProxyValue.CreateVisualsCollator(@documentSequencePT, @documentPT);
        public void add_WritingPrintTicketRequired(System.Windows.Documents.Serialization.WritingPrintTicketRequiredEventHandler value) => __ProxyValue.add_WritingPrintTicketRequired(@value);
        public void remove_WritingPrintTicketRequired(System.Windows.Documents.Serialization.WritingPrintTicketRequiredEventHandler value) => __ProxyValue.remove_WritingPrintTicketRequired(@value);
        public void add_WritingProgressChanged(System.Windows.Documents.Serialization.WritingProgressChangedEventHandler value) => __ProxyValue.add_WritingProgressChanged(@value);
        public void remove_WritingProgressChanged(System.Windows.Documents.Serialization.WritingProgressChangedEventHandler value) => __ProxyValue.remove_WritingProgressChanged(@value);
        public void add_WritingCompleted(System.Windows.Documents.Serialization.WritingCompletedEventHandler value) => __ProxyValue.add_WritingCompleted(@value);
        public void remove_WritingCompleted(System.Windows.Documents.Serialization.WritingCompletedEventHandler value) => __ProxyValue.remove_WritingCompleted(@value);
        public void add_WritingCancelled(System.Windows.Documents.Serialization.WritingCancelledEventHandler value) => __ProxyValue.add_WritingCancelled(@value);
        public void remove_WritingCancelled(System.Windows.Documents.Serialization.WritingCancelledEventHandler value) => __ProxyValue.remove_WritingCancelled(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}