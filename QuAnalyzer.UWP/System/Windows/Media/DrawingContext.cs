namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class DrawingContext : Proxy<global::Windows.UI.Xaml.Media.DrawingContext>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void DrawText(System.Windows.Media.FormattedText formattedText, System.Windows.Point origin) => __ProxyValue.DrawText(@formattedText, @origin);
        public void Close() => __ProxyValue.Close();
        public void DrawLine(System.Windows.Media.Pen pen, System.Windows.Point point0, System.Windows.Point point1) => __ProxyValue.DrawLine(@pen, @point0, @point1);
        public void DrawLine(System.Windows.Media.Pen pen, System.Windows.Point point0, System.Windows.Media.Animation.AnimationClock point0Animations, System.Windows.Point point1, System.Windows.Media.Animation.AnimationClock point1Animations) => __ProxyValue.DrawLine(@pen, @point0, @point0Animations, @point1, @point1Animations);
        public void DrawRectangle(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Rect rectangle) => __ProxyValue.DrawRectangle(@brush, @pen, @rectangle);
        public void DrawRectangle(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Rect rectangle, System.Windows.Media.Animation.AnimationClock rectangleAnimations) => __ProxyValue.DrawRectangle(@brush, @pen, @rectangle, @rectangleAnimations);
        public void DrawRoundedRectangle(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Rect rectangle, System.Double radiusX, System.Double radiusY) => __ProxyValue.DrawRoundedRectangle(@brush, @pen, @rectangle, @radiusX, @radiusY);
        public void DrawRoundedRectangle(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Rect rectangle, System.Windows.Media.Animation.AnimationClock rectangleAnimations, System.Double radiusX, System.Windows.Media.Animation.AnimationClock radiusXAnimations, System.Double radiusY, System.Windows.Media.Animation.AnimationClock radiusYAnimations) => __ProxyValue.DrawRoundedRectangle(@brush, @pen, @rectangle, @rectangleAnimations, @radiusX, @radiusXAnimations, @radiusY, @radiusYAnimations);
        public void DrawEllipse(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Point center, System.Double radiusX, System.Double radiusY) => __ProxyValue.DrawEllipse(@brush, @pen, @center, @radiusX, @radiusY);
        public void DrawEllipse(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Point center, System.Windows.Media.Animation.AnimationClock centerAnimations, System.Double radiusX, System.Windows.Media.Animation.AnimationClock radiusXAnimations, System.Double radiusY, System.Windows.Media.Animation.AnimationClock radiusYAnimations) => __ProxyValue.DrawEllipse(@brush, @pen, @center, @centerAnimations, @radiusX, @radiusXAnimations, @radiusY, @radiusYAnimations);
        public void DrawGeometry(System.Windows.Media.Brush brush, System.Windows.Media.Pen pen, System.Windows.Media.Geometry geometry) => __ProxyValue.DrawGeometry(@brush, @pen, @geometry);
        public void DrawImage(System.Windows.Media.ImageSource imageSource, System.Windows.Rect rectangle) => __ProxyValue.DrawImage(@imageSource, @rectangle);
        public void DrawImage(System.Windows.Media.ImageSource imageSource, System.Windows.Rect rectangle, System.Windows.Media.Animation.AnimationClock rectangleAnimations) => __ProxyValue.DrawImage(@imageSource, @rectangle, @rectangleAnimations);
        public void DrawGlyphRun(System.Windows.Media.Brush foregroundBrush, System.Windows.Media.GlyphRun glyphRun) => __ProxyValue.DrawGlyphRun(@foregroundBrush, @glyphRun);
        public void DrawDrawing(System.Windows.Media.Drawing drawing) => __ProxyValue.DrawDrawing(@drawing);
        public void DrawVideo(System.Windows.Media.MediaPlayer player, System.Windows.Rect rectangle) => __ProxyValue.DrawVideo(@player, @rectangle);
        public void DrawVideo(System.Windows.Media.MediaPlayer player, System.Windows.Rect rectangle, System.Windows.Media.Animation.AnimationClock rectangleAnimations) => __ProxyValue.DrawVideo(@player, @rectangle, @rectangleAnimations);
        public void PushClip(System.Windows.Media.Geometry clipGeometry) => __ProxyValue.PushClip(@clipGeometry);
        public void PushOpacityMask(System.Windows.Media.Brush opacityMask) => __ProxyValue.PushOpacityMask(@opacityMask);
        public void PushOpacity(System.Double opacity) => __ProxyValue.PushOpacity(@opacity);
        public void PushOpacity(System.Double opacity, System.Windows.Media.Animation.AnimationClock opacityAnimations) => __ProxyValue.PushOpacity(@opacity, @opacityAnimations);
        public void PushTransform(System.Windows.Media.Transform transform) => __ProxyValue.PushTransform(@transform);
        public void PushGuidelineSet(System.Windows.Media.GuidelineSet guidelines) => __ProxyValue.PushGuidelineSet(@guidelines);
        public void PushEffect(System.Windows.Media.Effects.BitmapEffect effect, System.Windows.Media.Effects.BitmapEffectInput effectInput) => __ProxyValue.PushEffect(@effect, @effectInput);
        public void Pop() => __ProxyValue.Pop();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}