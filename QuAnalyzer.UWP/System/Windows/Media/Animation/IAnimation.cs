namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class IAnimation : Proxy<global::Windows.UI.Xaml.Media.Animation.IAnimation>
    {
        public System.Object GetCurrentValue(System.Object defaultOriginValue, System.Object defaultDestinationValue, System.Windows.Media.Animation.AnimationClock animationClock) => __ProxyValue.GetCurrentValue(@defaultOriginValue, @defaultDestinationValue, @animationClock);
    }
}