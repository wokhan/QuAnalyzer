namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StylusPointProperty : Proxy<global::Windows.UI.Xaml.Input.StylusPointProperty>
    {
        public System.Guid Id
        {
            get => __ProxyValue.Id;
        }

        public System.Boolean IsButton
        {
            get => __ProxyValue.IsButton;
        }

        public StylusPointProperty(System.Guid @identifier, System.Boolean @isButton): base(@identifier, @isButton)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}