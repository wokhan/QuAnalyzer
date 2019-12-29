namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class TaskbarItemInfo : Proxy<global::Windows.UI.Xaml.Shell.TaskbarItemInfo>
    {
        public System.Windows.Shell.TaskbarItemProgressState ProgressState
        {
            get => __ProxyValue.ProgressState;
            set => __ProxyValue.ProgressState = value;
        }

        public System.Double ProgressValue
        {
            get => __ProxyValue.ProgressValue;
            set => __ProxyValue.ProgressValue = value;
        }

        public System.Windows.Media.ImageSource Overlay
        {
            get => __ProxyValue.Overlay;
            set => __ProxyValue.Overlay = value;
        }

        public System.String Description
        {
            get => __ProxyValue.Description;
            set => __ProxyValue.Description = value;
        }

        public System.Windows.Thickness ThumbnailClipMargin
        {
            get => __ProxyValue.ThumbnailClipMargin;
            set => __ProxyValue.ThumbnailClipMargin = value;
        }

        public System.Windows.Shell.ThumbButtonInfoCollection ThumbButtonInfos
        {
            get => __ProxyValue.ThumbButtonInfos;
            set => __ProxyValue.ThumbButtonInfos = value;
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

        public TaskbarItemInfo(): base()
        {
        }

        public System.Windows.Freezable Clone() => __ProxyValue.Clone();
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