namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class WritingPrintTicketRequiredEventArgs : Proxy<global::Windows.UI.Xaml.Documents.Serialization.WritingPrintTicketRequiredEventArgs>
    {
        public System.Windows.Xps.Serialization.PrintTicketLevel CurrentPrintTicketLevel
        {
            get => __ProxyValue.CurrentPrintTicketLevel;
        }

        public System.Int32 Sequence
        {
            get => __ProxyValue.Sequence;
        }

        public System.Printing.PrintTicket CurrentPrintTicket
        {
            get => __ProxyValue.CurrentPrintTicket;
            set => __ProxyValue.CurrentPrintTicket = value;
        }

        public WritingPrintTicketRequiredEventArgs(System.Windows.Xps.Serialization.PrintTicketLevel @printTicketLevel, System.Int32 @sequence): base(@printTicketLevel, @sequence)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}