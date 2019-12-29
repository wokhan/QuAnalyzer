namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class Stroke : Proxy<global::Windows.UI.Xaml.Ink.Stroke>
    {
        public System.Windows.Ink.DrawingAttributes DrawingAttributes
        {
            get => __ProxyValue.DrawingAttributes;
            set => __ProxyValue.DrawingAttributes = value;
        }

        public System.Windows.Input.StylusPointCollection StylusPoints
        {
            get => __ProxyValue.StylusPoints;
            set => __ProxyValue.StylusPoints = value;
        }

        public Stroke(System.Windows.Input.StylusPointCollection @stylusPoints): base(@stylusPoints)
        {
        }

        public Stroke(System.Windows.Input.StylusPointCollection @stylusPoints, System.Windows.Ink.DrawingAttributes @drawingAttributes): base(@stylusPoints, @drawingAttributes)
        {
        }

        public System.Windows.Ink.Stroke Clone() => __ProxyValue.Clone();
        public void Transform(System.Windows.Media.Matrix transformMatrix, System.Boolean applyToStylusTip) => __ProxyValue.Transform(@transformMatrix, @applyToStylusTip);
        public System.Windows.Input.StylusPointCollection GetBezierStylusPoints() => __ProxyValue.GetBezierStylusPoints();
        public void AddPropertyData(System.Guid propertyDataId, System.Object propertyData) => __ProxyValue.AddPropertyData(@propertyDataId, @propertyData);
        public void RemovePropertyData(System.Guid propertyDataId) => __ProxyValue.RemovePropertyData(@propertyDataId);
        public System.Object GetPropertyData(System.Guid propertyDataId) => __ProxyValue.GetPropertyData(@propertyDataId);
        public System.Guid[] GetPropertyDataIds() => __ProxyValue.GetPropertyDataIds();
        public System.Boolean ContainsPropertyData(System.Guid propertyDataId) => __ProxyValue.ContainsPropertyData(@propertyDataId);
        public void add_DrawingAttributesChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.add_DrawingAttributesChanged(@value);
        public void remove_DrawingAttributesChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.remove_DrawingAttributesChanged(@value);
        public void add_DrawingAttributesReplaced(System.Windows.Ink.DrawingAttributesReplacedEventHandler value) => __ProxyValue.add_DrawingAttributesReplaced(@value);
        public void remove_DrawingAttributesReplaced(System.Windows.Ink.DrawingAttributesReplacedEventHandler value) => __ProxyValue.remove_DrawingAttributesReplaced(@value);
        public void add_StylusPointsReplaced(System.Windows.Ink.StylusPointsReplacedEventHandler value) => __ProxyValue.add_StylusPointsReplaced(@value);
        public void remove_StylusPointsReplaced(System.Windows.Ink.StylusPointsReplacedEventHandler value) => __ProxyValue.remove_StylusPointsReplaced(@value);
        public void add_StylusPointsChanged(System.EventHandler value) => __ProxyValue.add_StylusPointsChanged(@value);
        public void remove_StylusPointsChanged(System.EventHandler value) => __ProxyValue.remove_StylusPointsChanged(@value);
        public void add_PropertyDataChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.add_PropertyDataChanged(@value);
        public void remove_PropertyDataChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.remove_PropertyDataChanged(@value);
        public void add_Invalidated(System.EventHandler value) => __ProxyValue.add_Invalidated(@value);
        public void remove_Invalidated(System.EventHandler value) => __ProxyValue.remove_Invalidated(@value);
        public System.Windows.Rect GetBounds() => __ProxyValue.GetBounds();
        public void Draw(System.Windows.Media.DrawingContext context) => __ProxyValue.Draw(@context);
        public void Draw(System.Windows.Media.DrawingContext drawingContext, System.Windows.Ink.DrawingAttributes drawingAttributes) => __ProxyValue.Draw(@drawingContext, @drawingAttributes);
        public System.Windows.Ink.StrokeCollection GetClipResult(System.Windows.Rect bounds) => __ProxyValue.GetClipResult(@bounds);
        public System.Windows.Ink.StrokeCollection GetClipResult(System.Collections.Generic.IEnumerable<System.Windows.Point> lassoPoints) => __ProxyValue.GetClipResult(@lassoPoints);
        public System.Windows.Ink.StrokeCollection GetEraseResult(System.Windows.Rect bounds) => __ProxyValue.GetEraseResult(@bounds);
        public System.Windows.Ink.StrokeCollection GetEraseResult(System.Collections.Generic.IEnumerable<System.Windows.Point> lassoPoints) => __ProxyValue.GetEraseResult(@lassoPoints);
        public System.Windows.Ink.StrokeCollection GetEraseResult(System.Collections.Generic.IEnumerable<System.Windows.Point> eraserPath, System.Windows.Ink.StylusShape eraserShape) => __ProxyValue.GetEraseResult(@eraserPath, @eraserShape);
        public System.Boolean HitTest(System.Windows.Point point) => __ProxyValue.HitTest(@point);
        public System.Boolean HitTest(System.Windows.Point point, System.Double diameter) => __ProxyValue.HitTest(@point, @diameter);
        public System.Boolean HitTest(System.Windows.Rect bounds, System.Int32 percentageWithinBounds) => __ProxyValue.HitTest(@bounds, @percentageWithinBounds);
        public System.Boolean HitTest(System.Collections.Generic.IEnumerable<System.Windows.Point> lassoPoints, System.Int32 percentageWithinLasso) => __ProxyValue.HitTest(@lassoPoints, @percentageWithinLasso);
        public System.Boolean HitTest(System.Collections.Generic.IEnumerable<System.Windows.Point> path, System.Windows.Ink.StylusShape stylusShape) => __ProxyValue.HitTest(@path, @stylusShape);
        public System.Windows.Media.Geometry GetGeometry() => __ProxyValue.GetGeometry();
        public System.Windows.Media.Geometry GetGeometry(System.Windows.Ink.DrawingAttributes drawingAttributes) => __ProxyValue.GetGeometry(@drawingAttributes);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}