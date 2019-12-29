namespace System.Windows
{
    using Uno.UI.Generic;

    public class VisualStateGroup : Proxy<global::Windows.UI.Xaml.VisualStateGroup>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Collections.IList States
        {
            get => __ProxyValue.States;
        }

        public System.Collections.IList Transitions
        {
            get => __ProxyValue.Transitions;
        }

        public System.Windows.VisualState CurrentState
        {
            get => __ProxyValue.CurrentState;
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

        public VisualStateGroup(): base()
        {
        }

        public void add_CurrentStateChanged(System.EventHandler<System.Windows.VisualStateChangedEventArgs> value) => __ProxyValue.add_CurrentStateChanged(@value);
        public void remove_CurrentStateChanged(System.EventHandler<System.Windows.VisualStateChangedEventArgs> value) => __ProxyValue.remove_CurrentStateChanged(@value);
        public void add_CurrentStateChanging(System.EventHandler<System.Windows.VisualStateChangedEventArgs> value) => __ProxyValue.add_CurrentStateChanging(@value);
        public void remove_CurrentStateChanging(System.EventHandler<System.Windows.VisualStateChangedEventArgs> value) => __ProxyValue.remove_CurrentStateChanging(@value);
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