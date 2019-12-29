namespace System.Windows
{
    using Uno.UI.Generic;

    public class Trigger : Proxy<global::Windows.UI.Xaml.Trigger>
    {
        public System.Windows.DependencyProperty Property
        {
            get => __ProxyValue.Property;
            set => __ProxyValue.Property = value;
        }

        public System.Object Value
        {
            get => __ProxyValue.Value;
            set => __ProxyValue.Value = value;
        }

        public System.String SourceName
        {
            get => __ProxyValue.SourceName;
            set => __ProxyValue.SourceName = value;
        }

        public System.Windows.SetterBaseCollection Setters
        {
            get => __ProxyValue.Setters;
        }

        public System.Windows.TriggerActionCollection EnterActions
        {
            get => __ProxyValue.EnterActions;
        }

        public System.Windows.TriggerActionCollection ExitActions
        {
            get => __ProxyValue.ExitActions;
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

        public Trigger(): base()
        {
        }

        public static void ReceiveTypeConverter(System.Object targetObject, System.Windows.Markup.XamlSetTypeConverterEventArgs eventArgs) => Windows.UI.Xaml.Trigger.ReceiveTypeConverter(@targetObject, @eventArgs);
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