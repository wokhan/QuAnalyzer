namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class StrokeCollection : Proxy<global::Windows.UI.Xaml.Ink.StrokeCollection>
    {
        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Windows.Ink.Stroke Item
        {
            get => __ProxyValue.Item;
            set => __ProxyValue.Item = value;
        }

        public StrokeCollection(): base()
        {
        }

        public StrokeCollection(System.Collections.Generic.IEnumerable<System.Windows.Ink.Stroke> @strokes): base(@strokes)
        {
        }

        public StrokeCollection(System.IO.Stream @stream): base(@stream)
        {
        }

        public void Save(System.IO.Stream stream, System.Boolean compress) => __ProxyValue.Save(@stream, @compress);
        public void Save(System.IO.Stream stream) => __ProxyValue.Save(@stream);
        public void AddPropertyData(System.Guid propertyDataId, System.Object propertyData) => __ProxyValue.AddPropertyData(@propertyDataId, @propertyData);
        public void RemovePropertyData(System.Guid propertyDataId) => __ProxyValue.RemovePropertyData(@propertyDataId);
        public System.Object GetPropertyData(System.Guid propertyDataId) => __ProxyValue.GetPropertyData(@propertyDataId);
        public System.Guid[] GetPropertyDataIds() => __ProxyValue.GetPropertyDataIds();
        public System.Boolean ContainsPropertyData(System.Guid propertyDataId) => __ProxyValue.ContainsPropertyData(@propertyDataId);
        public void Transform(System.Windows.Media.Matrix transformMatrix, System.Boolean applyToStylusTip) => __ProxyValue.Transform(@transformMatrix, @applyToStylusTip);
        public System.Windows.Ink.StrokeCollection Clone() => __ProxyValue.Clone();
        public System.Int32 IndexOf(System.Windows.Ink.Stroke stroke) => __ProxyValue.IndexOf(@stroke);
        public void Remove(System.Windows.Ink.StrokeCollection strokes) => __ProxyValue.Remove(@strokes);
        public void Add(System.Windows.Ink.StrokeCollection strokes) => __ProxyValue.Add(@strokes);
        public void Replace(System.Windows.Ink.Stroke strokeToReplace, System.Windows.Ink.StrokeCollection strokesToReplaceWith) => __ProxyValue.Replace(@strokeToReplace, @strokesToReplaceWith);
        public void Replace(System.Windows.Ink.StrokeCollection strokesToReplace, System.Windows.Ink.StrokeCollection strokesToReplaceWith) => __ProxyValue.Replace(@strokesToReplace, @strokesToReplaceWith);
        public void add_StrokesChanged(System.Windows.Ink.StrokeCollectionChangedEventHandler value) => __ProxyValue.add_StrokesChanged(@value);
        public void remove_StrokesChanged(System.Windows.Ink.StrokeCollectionChangedEventHandler value) => __ProxyValue.remove_StrokesChanged(@value);
        public void add_PropertyDataChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.add_PropertyDataChanged(@value);
        public void remove_PropertyDataChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.remove_PropertyDataChanged(@value);
        public System.Windows.Rect GetBounds() => __ProxyValue.GetBounds();
        public System.Windows.Ink.StrokeCollection HitTest(System.Windows.Point point) => __ProxyValue.HitTest(@point);
        public System.Windows.Ink.StrokeCollection HitTest(System.Windows.Point point, System.Double diameter) => __ProxyValue.HitTest(@point, @diameter);
        public System.Windows.Ink.StrokeCollection HitTest(System.Collections.Generic.IEnumerable<System.Windows.Point> lassoPoints, System.Int32 percentageWithinLasso) => __ProxyValue.HitTest(@lassoPoints, @percentageWithinLasso);
        public System.Windows.Ink.StrokeCollection HitTest(System.Windows.Rect bounds, System.Int32 percentageWithinBounds) => __ProxyValue.HitTest(@bounds, @percentageWithinBounds);
        public System.Windows.Ink.StrokeCollection HitTest(System.Collections.Generic.IEnumerable<System.Windows.Point> path, System.Windows.Ink.StylusShape stylusShape) => __ProxyValue.HitTest(@path, @stylusShape);
        public void Clip(System.Collections.Generic.IEnumerable<System.Windows.Point> lassoPoints) => __ProxyValue.Clip(@lassoPoints);
        public void Clip(System.Windows.Rect bounds) => __ProxyValue.Clip(@bounds);
        public void Erase(System.Collections.Generic.IEnumerable<System.Windows.Point> lassoPoints) => __ProxyValue.Erase(@lassoPoints);
        public void Erase(System.Windows.Rect bounds) => __ProxyValue.Erase(@bounds);
        public void Erase(System.Collections.Generic.IEnumerable<System.Windows.Point> eraserPath, System.Windows.Ink.StylusShape eraserShape) => __ProxyValue.Erase(@eraserPath, @eraserShape);
        public void Draw(System.Windows.Media.DrawingContext context) => __ProxyValue.Draw(@context);
        public System.Windows.Ink.IncrementalStrokeHitTester GetIncrementalStrokeHitTester(System.Windows.Ink.StylusShape eraserShape) => __ProxyValue.GetIncrementalStrokeHitTester(@eraserShape);
        public System.Windows.Ink.IncrementalLassoHitTester GetIncrementalLassoHitTester(System.Int32 percentageWithinLasso) => __ProxyValue.GetIncrementalLassoHitTester(@percentageWithinLasso);
        public void Add(System.Windows.Ink.Stroke item) => __ProxyValue.Add(@item);
        public void Clear() => __ProxyValue.Clear();
        public void CopyTo(System.Windows.Ink.Stroke[] array, System.Int32 index) => __ProxyValue.CopyTo(@array, @index);
        public System.Boolean Contains(System.Windows.Ink.Stroke item) => __ProxyValue.Contains(@item);
        public System.Collections.Generic.IEnumerator<System.Windows.Ink.Stroke> GetEnumerator() => __ProxyValue.GetEnumerator();
        public System.Int32 IndexOf(System.Windows.Ink.Stroke item) => __ProxyValue.IndexOf(@item);
        public void Insert(System.Int32 index, System.Windows.Ink.Stroke item) => __ProxyValue.Insert(@index, @item);
        public System.Boolean Remove(System.Windows.Ink.Stroke item) => __ProxyValue.Remove(@item);
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}