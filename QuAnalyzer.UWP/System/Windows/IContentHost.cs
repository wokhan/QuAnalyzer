namespace System.Windows
{
    using Uno.UI.Generic;

    public class IContentHost : Proxy<global::Windows.UI.Xaml.IContentHost>
    {
        public System.Collections.Generic.IEnumerator<System.Windows.IInputElement> HostedElements
        {
            get => __ProxyValue.HostedElements;
        }

        public System.Windows.IInputElement InputHitTest(System.Windows.Point point) => __ProxyValue.InputHitTest(@point);
        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Rect> GetRectangles(System.Windows.ContentElement child) => __ProxyValue.GetRectangles(@child);
        public void OnChildDesiredSizeChanged(System.Windows.UIElement child) => __ProxyValue.OnChildDesiredSizeChanged(@child);
    }
}