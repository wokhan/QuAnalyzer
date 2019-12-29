namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class IScrollInfo : Proxy<global::Windows.UI.Xaml.Controls.Primitives.IScrollInfo>
    {
        public System.Boolean CanVerticallyScroll
        {
            get => __ProxyValue.CanVerticallyScroll;
            set => __ProxyValue.CanVerticallyScroll = value;
        }

        public System.Boolean CanHorizontallyScroll
        {
            get => __ProxyValue.CanHorizontallyScroll;
            set => __ProxyValue.CanHorizontallyScroll = value;
        }

        public System.Double ExtentWidth
        {
            get => __ProxyValue.ExtentWidth;
        }

        public System.Double ExtentHeight
        {
            get => __ProxyValue.ExtentHeight;
        }

        public System.Double ViewportWidth
        {
            get => __ProxyValue.ViewportWidth;
        }

        public System.Double ViewportHeight
        {
            get => __ProxyValue.ViewportHeight;
        }

        public System.Double HorizontalOffset
        {
            get => __ProxyValue.HorizontalOffset;
        }

        public System.Double VerticalOffset
        {
            get => __ProxyValue.VerticalOffset;
        }

        public System.Windows.Controls.ScrollViewer ScrollOwner
        {
            get => __ProxyValue.ScrollOwner;
            set => __ProxyValue.ScrollOwner = value;
        }

        public void LineUp() => __ProxyValue.LineUp();
        public void LineDown() => __ProxyValue.LineDown();
        public void LineLeft() => __ProxyValue.LineLeft();
        public void LineRight() => __ProxyValue.LineRight();
        public void PageUp() => __ProxyValue.PageUp();
        public void PageDown() => __ProxyValue.PageDown();
        public void PageLeft() => __ProxyValue.PageLeft();
        public void PageRight() => __ProxyValue.PageRight();
        public void MouseWheelUp() => __ProxyValue.MouseWheelUp();
        public void MouseWheelDown() => __ProxyValue.MouseWheelDown();
        public void MouseWheelLeft() => __ProxyValue.MouseWheelLeft();
        public void MouseWheelRight() => __ProxyValue.MouseWheelRight();
        public void SetHorizontalOffset(System.Double offset) => __ProxyValue.SetHorizontalOffset(@offset);
        public void SetVerticalOffset(System.Double offset) => __ProxyValue.SetVerticalOffset(@offset);
        public System.Windows.Rect MakeVisible(System.Windows.Media.Visual visual, System.Windows.Rect rectangle) => __ProxyValue.MakeVisible(@visual, @rectangle);
    }
}