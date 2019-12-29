namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class DrawingAttributesReplacedEventArgs : Proxy<global::Windows.UI.Xaml.Ink.DrawingAttributesReplacedEventArgs>
    {
        public System.Windows.Ink.DrawingAttributes NewDrawingAttributes
        {
            get => __ProxyValue.NewDrawingAttributes;
        }

        public System.Windows.Ink.DrawingAttributes PreviousDrawingAttributes
        {
            get => __ProxyValue.PreviousDrawingAttributes;
        }

        public DrawingAttributesReplacedEventArgs(System.Windows.Ink.DrawingAttributes @newDrawingAttributes, System.Windows.Ink.DrawingAttributes @previousDrawingAttributes): base(@newDrawingAttributes, @previousDrawingAttributes)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}