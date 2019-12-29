namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class IKeyFrameAnimation : Proxy<global::Windows.UI.Xaml.Media.Animation.IKeyFrameAnimation>
    {
        public System.Collections.IList KeyFrames
        {
            get => __ProxyValue.KeyFrames;
            set => __ProxyValue.KeyFrames = value;
        }
    }
}