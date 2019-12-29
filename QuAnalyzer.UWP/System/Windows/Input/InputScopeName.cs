namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputScopeName : Proxy<global::Windows.UI.Xaml.Input.InputScopeName>
    {
        public System.Windows.Input.InputScopeNameValue NameValue
        {
            get => __ProxyValue.NameValue;
            set => __ProxyValue.NameValue = value;
        }

        public InputScopeName(): base()
        {
        }

        public InputScopeName(System.Windows.Input.InputScopeNameValue @nameValue): base(@nameValue)
        {
        }

        public void AddChild(System.Object value) => __ProxyValue.AddChild(@value);
        public void AddText(System.String name) => __ProxyValue.AddText(@name);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}