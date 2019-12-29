namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class MediaPlayer : Proxy<global::Windows.UI.Xaml.Media.MediaPlayer>
    {
        public System.Boolean IsBuffering
        {
            get => __ProxyValue.IsBuffering;
        }

        public System.Boolean CanPause
        {
            get => __ProxyValue.CanPause;
        }

        public System.Double DownloadProgress
        {
            get => __ProxyValue.DownloadProgress;
        }

        public System.Double BufferingProgress
        {
            get => __ProxyValue.BufferingProgress;
        }

        public System.Int32 NaturalVideoHeight
        {
            get => __ProxyValue.NaturalVideoHeight;
        }

        public System.Int32 NaturalVideoWidth
        {
            get => __ProxyValue.NaturalVideoWidth;
        }

        public System.Boolean HasAudio
        {
            get => __ProxyValue.HasAudio;
        }

        public System.Boolean HasVideo
        {
            get => __ProxyValue.HasVideo;
        }

        public System.Uri Source
        {
            get => __ProxyValue.Source;
        }

        public System.Double Volume
        {
            get => __ProxyValue.Volume;
            set => __ProxyValue.Volume = value;
        }

        public System.Double Balance
        {
            get => __ProxyValue.Balance;
            set => __ProxyValue.Balance = value;
        }

        public System.Boolean ScrubbingEnabled
        {
            get => __ProxyValue.ScrubbingEnabled;
            set => __ProxyValue.ScrubbingEnabled = value;
        }

        public System.Boolean IsMuted
        {
            get => __ProxyValue.IsMuted;
            set => __ProxyValue.IsMuted = value;
        }

        public System.Windows.Duration NaturalDuration
        {
            get => __ProxyValue.NaturalDuration;
        }

        public System.TimeSpan Position
        {
            get => __ProxyValue.Position;
            set => __ProxyValue.Position = value;
        }

        public System.Double SpeedRatio
        {
            get => __ProxyValue.SpeedRatio;
            set => __ProxyValue.SpeedRatio = value;
        }

        public System.Windows.Media.MediaClock Clock
        {
            get => __ProxyValue.Clock;
            set => __ProxyValue.Clock = value;
        }

        public System.Boolean HasAnimatedProperties
        {
            get => __ProxyValue.HasAnimatedProperties;
        }

        public System.Boolean CanFreeze
        {
            get => __ProxyValue.CanFreeze;
        }

        public System.Boolean IsFrozen
        {
            get => __ProxyValue.IsFrozen;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public MediaPlayer(): base()
        {
        }

        public void add_MediaFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.add_MediaFailed(@value);
        public void remove_MediaFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.remove_MediaFailed(@value);
        public void add_MediaOpened(System.EventHandler value) => __ProxyValue.add_MediaOpened(@value);
        public void remove_MediaOpened(System.EventHandler value) => __ProxyValue.remove_MediaOpened(@value);
        public void add_MediaEnded(System.EventHandler value) => __ProxyValue.add_MediaEnded(@value);
        public void remove_MediaEnded(System.EventHandler value) => __ProxyValue.remove_MediaEnded(@value);
        public void add_BufferingStarted(System.EventHandler value) => __ProxyValue.add_BufferingStarted(@value);
        public void remove_BufferingStarted(System.EventHandler value) => __ProxyValue.remove_BufferingStarted(@value);
        public void add_BufferingEnded(System.EventHandler value) => __ProxyValue.add_BufferingEnded(@value);
        public void remove_BufferingEnded(System.EventHandler value) => __ProxyValue.remove_BufferingEnded(@value);
        public void add_ScriptCommand(System.EventHandler<System.Windows.Media.MediaScriptCommandEventArgs> value) => __ProxyValue.add_ScriptCommand(@value);
        public void remove_ScriptCommand(System.EventHandler<System.Windows.Media.MediaScriptCommandEventArgs> value) => __ProxyValue.remove_ScriptCommand(@value);
        public void Open(System.Uri source) => __ProxyValue.Open(@source);
        public void Play() => __ProxyValue.Play();
        public void Pause() => __ProxyValue.Pause();
        public void Stop() => __ProxyValue.Stop();
        public void Close() => __ProxyValue.Close();
        public System.Windows.Media.Animation.Animatable Clone() => __ProxyValue.Clone();
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock) => __ProxyValue.ApplyAnimationClock(@dp, @clock);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.ApplyAnimationClock(@dp, @clock, @handoffBehavior);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation) => __ProxyValue.BeginAnimation(@dp, @animation);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.BeginAnimation(@dp, @animation, @handoffBehavior);
        public System.Object GetAnimationBaseValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetAnimationBaseValue(@dp);
        public System.Windows.Freezable CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Windows.Freezable GetAsFrozen() => __ProxyValue.GetAsFrozen();
        public System.Windows.Freezable GetCurrentValueAsFrozen() => __ProxyValue.GetCurrentValueAsFrozen();
        public void Freeze() => __ProxyValue.Freeze();
        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}