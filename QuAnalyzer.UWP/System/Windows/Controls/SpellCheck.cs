namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class SpellCheck : Proxy<global::Windows.UI.Xaml.Controls.SpellCheck>
    {
        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
            set => __ProxyValue.IsEnabled = value;
        }

        public System.Windows.Controls.SpellingReform SpellingReform
        {
            get => __ProxyValue.SpellingReform;
            set => __ProxyValue.SpellingReform = value;
        }

        public System.Collections.IList CustomDictionaries
        {
            get => __ProxyValue.CustomDictionaries;
        }

        public static void SetIsEnabled(System.Windows.Controls.Primitives.TextBoxBase textBoxBase, System.Boolean value) => Windows.UI.Xaml.Controls.SpellCheck.SetIsEnabled(@textBoxBase, @value);
        public static System.Boolean GetIsEnabled(System.Windows.Controls.Primitives.TextBoxBase textBoxBase) => Windows.UI.Xaml.Controls.SpellCheck.GetIsEnabled(@textBoxBase);
        public static void SetSpellingReform(System.Windows.Controls.Primitives.TextBoxBase textBoxBase, System.Windows.Controls.SpellingReform value) => Windows.UI.Xaml.Controls.SpellCheck.SetSpellingReform(@textBoxBase, @value);
        public static System.Collections.IList GetCustomDictionaries(System.Windows.Controls.Primitives.TextBoxBase textBoxBase) => Windows.UI.Xaml.Controls.SpellCheck.GetCustomDictionaries(@textBoxBase);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}