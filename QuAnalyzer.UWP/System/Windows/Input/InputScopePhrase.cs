namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputScopePhrase : Proxy<global::Windows.UI.Xaml.Input.InputScopePhrase>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public InputScopePhrase(): base()
        {
        }

        public InputScopePhrase(System.String @name): base(@name)
        {
        }

        public void AddChild(System.Object value) => __ProxyValue.AddChild(@value);
        public void AddText(System.String name) => __ProxyValue.AddText(@name);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}