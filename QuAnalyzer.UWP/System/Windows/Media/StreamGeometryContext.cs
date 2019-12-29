namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class StreamGeometryContext : Proxy<global::Windows.UI.Xaml.Media.StreamGeometryContext>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void Close() => __ProxyValue.Close();
        public void BeginFigure(System.Windows.Point startPoint, System.Boolean isFilled, System.Boolean isClosed) => __ProxyValue.BeginFigure(@startPoint, @isFilled, @isClosed);
        public void LineTo(System.Windows.Point point, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.LineTo(@point, @isStroked, @isSmoothJoin);
        public void QuadraticBezierTo(System.Windows.Point point1, System.Windows.Point point2, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.QuadraticBezierTo(@point1, @point2, @isStroked, @isSmoothJoin);
        public void BezierTo(System.Windows.Point point1, System.Windows.Point point2, System.Windows.Point point3, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.BezierTo(@point1, @point2, @point3, @isStroked, @isSmoothJoin);
        public void PolyLineTo(System.Collections.Generic.IList<System.Windows.Point> points, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.PolyLineTo(@points, @isStroked, @isSmoothJoin);
        public void PolyQuadraticBezierTo(System.Collections.Generic.IList<System.Windows.Point> points, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.PolyQuadraticBezierTo(@points, @isStroked, @isSmoothJoin);
        public void PolyBezierTo(System.Collections.Generic.IList<System.Windows.Point> points, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.PolyBezierTo(@points, @isStroked, @isSmoothJoin);
        public void ArcTo(System.Windows.Point point, System.Windows.Size size, System.Double rotationAngle, System.Boolean isLargeArc, System.Windows.Media.SweepDirection sweepDirection, System.Boolean isStroked, System.Boolean isSmoothJoin) => __ProxyValue.ArcTo(@point, @size, @rotationAngle, @isLargeArc, @sweepDirection, @isStroked, @isSmoothJoin);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}