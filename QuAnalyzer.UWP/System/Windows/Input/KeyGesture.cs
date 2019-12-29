namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class KeyGesture : Proxy<global::Windows.UI.Xaml.Input.KeyGesture>
    {
        public System.Windows.Input.ModifierKeys Modifiers
        {
            get => __ProxyValue.Modifiers;
        }

        public System.Windows.Input.Key Key
        {
            get => __ProxyValue.Key;
        }

        public System.String DisplayString
        {
            get => __ProxyValue.DisplayString;
        }

        public KeyGesture(System.Windows.Input.Key @key): base(@key)
        {
        }

        public KeyGesture(System.Windows.Input.Key @key, System.Windows.Input.ModifierKeys @modifiers): base(@key, @modifiers)
        {
        }

        public KeyGesture(System.Windows.Input.Key @key, System.Windows.Input.ModifierKeys @modifiers, System.String @displayString): base(@key, @modifiers, @displayString)
        {
        }

        public System.String GetDisplayStringForCulture(System.Globalization.CultureInfo culture) => __ProxyValue.GetDisplayStringForCulture(@culture);
        public System.Boolean Matches(System.Object targetElement, System.Windows.Input.InputEventArgs inputEventArgs) => __ProxyValue.Matches(@targetElement, @inputEventArgs);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}