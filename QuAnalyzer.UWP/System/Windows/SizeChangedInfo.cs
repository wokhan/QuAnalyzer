namespace System.Windows
{
    using Uno.UI.Generic;

    public class SizeChangedInfo : Proxy<global::Windows.UI.Xaml.SizeChangedInfo>
    {
        public System.Windows.Size PreviousSize
        {
            get => __ProxyValue.PreviousSize;
        }

        public System.Windows.Size NewSize
        {
            get => __ProxyValue.NewSize;
        }

        public System.Boolean WidthChanged
        {
            get => __ProxyValue.WidthChanged;
        }

        public System.Boolean HeightChanged
        {
            get => __ProxyValue.HeightChanged;
        }

        public SizeChangedInfo(System.Windows.UIElement @element, System.Windows.Size @previousSize, System.Boolean @widthChanged, System.Boolean @heightChanged): base(@element, @previousSize, @widthChanged, @heightChanged)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}