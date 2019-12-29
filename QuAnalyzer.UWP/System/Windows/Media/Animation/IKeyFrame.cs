namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class IKeyFrame : Proxy<global::Windows.UI.Xaml.Media.Animation.IKeyFrame>
    {
        public System.Windows.Media.Animation.KeyTime KeyTime
        {
            get => __ProxyValue.KeyTime;
            set => __ProxyValue.KeyTime = value;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
            set => __ProxyValue.Value = value;
        }
    }
}