namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class SerializerWriterCollator : Proxy<global::Windows.UI.Xaml.Documents.Serialization.SerializerWriterCollator>
    {
        public void BeginBatchWrite() => __ProxyValue.BeginBatchWrite();
        public void EndBatchWrite() => __ProxyValue.EndBatchWrite();
        public void Write(System.Windows.Media.Visual visual) => __ProxyValue.Write(@visual);
        public void Write(System.Windows.Media.Visual visual, System.Printing.PrintTicket printTicket) => __ProxyValue.Write(@visual, @printTicket);
        public void WriteAsync(System.Windows.Media.Visual visual) => __ProxyValue.WriteAsync(@visual);
        public void WriteAsync(System.Windows.Media.Visual visual, System.Object userState) => __ProxyValue.WriteAsync(@visual, @userState);
        public void WriteAsync(System.Windows.Media.Visual visual, System.Printing.PrintTicket printTicket) => __ProxyValue.WriteAsync(@visual, @printTicket);
        public void WriteAsync(System.Windows.Media.Visual visual, System.Printing.PrintTicket printTicket, System.Object userState) => __ProxyValue.WriteAsync(@visual, @printTicket, @userState);
        public void CancelAsync() => __ProxyValue.CancelAsync();
        public void Cancel() => __ProxyValue.Cancel();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}