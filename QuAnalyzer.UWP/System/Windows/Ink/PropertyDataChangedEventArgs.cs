namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class PropertyDataChangedEventArgs : Proxy<global::Windows.UI.Xaml.Ink.PropertyDataChangedEventArgs>
    {
        public System.Guid PropertyGuid
        {
            get => __ProxyValue.PropertyGuid;
        }

        public System.Object NewValue
        {
            get => __ProxyValue.NewValue;
        }

        public System.Object PreviousValue
        {
            get => __ProxyValue.PreviousValue;
        }

        public PropertyDataChangedEventArgs(System.Guid @propertyGuid, System.Object @newValue, System.Object @previousValue): base(@propertyGuid, @newValue, @previousValue)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}