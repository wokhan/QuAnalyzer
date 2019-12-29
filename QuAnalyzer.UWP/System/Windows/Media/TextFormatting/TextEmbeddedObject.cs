namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextEmbeddedObject : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextEmbeddedObject>
    {
        public System.Windows.LineBreakCondition BreakBefore
        {
            get => __ProxyValue.BreakBefore;
        }

        public System.Windows.LineBreakCondition BreakAfter
        {
            get => __ProxyValue.BreakAfter;
        }

        public System.Boolean HasFixedSize
        {
            get => __ProxyValue.HasFixedSize;
        }

        public System.Windows.Media.TextFormatting.CharacterBufferReference CharacterBufferReference
        {
            get => __ProxyValue.CharacterBufferReference;
        }

        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public System.Windows.Media.TextFormatting.TextRunProperties Properties
        {
            get => __ProxyValue.Properties;
        }

        public System.Windows.Media.TextFormatting.TextEmbeddedObjectMetrics Format(System.Double remainingParagraphWidth) => __ProxyValue.Format(@remainingParagraphWidth);
        public System.Windows.Rect ComputeBoundingBox(System.Boolean rightToLeft, System.Boolean sideways) => __ProxyValue.ComputeBoundingBox(@rightToLeft, @sideways);
        public void Draw(System.Windows.Media.DrawingContext drawingContext, System.Windows.Point origin, System.Boolean rightToLeft, System.Boolean sideways) => __ProxyValue.Draw(@drawingContext, @origin, @rightToLeft, @sideways);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}