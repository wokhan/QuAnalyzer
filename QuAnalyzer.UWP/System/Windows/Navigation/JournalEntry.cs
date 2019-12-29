namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class JournalEntry : Proxy<global::Windows.UI.Xaml.Navigation.JournalEntry>
    {
        public System.Uri Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Windows.Navigation.CustomContentState CustomContentState
        {
            get => __ProxyValue.CustomContentState;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
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

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public static System.String GetName(System.Windows.DependencyObject dependencyObject) => Windows.UI.Xaml.Navigation.JournalEntry.GetName(@dependencyObject);
        public static void SetName(System.Windows.DependencyObject dependencyObject, System.String name) => Windows.UI.Xaml.Navigation.JournalEntry.SetName(@dependencyObject, @name);
        public static System.Boolean GetKeepAlive(System.Windows.DependencyObject dependencyObject) => Windows.UI.Xaml.Navigation.JournalEntry.GetKeepAlive(@dependencyObject);
        public static void SetKeepAlive(System.Windows.DependencyObject dependencyObject, System.Boolean keepAlive) => Windows.UI.Xaml.Navigation.JournalEntry.SetKeepAlive(@dependencyObject, @keepAlive);
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