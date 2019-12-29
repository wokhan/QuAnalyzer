namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class SpellingError : Proxy<global::Windows.UI.Xaml.Controls.SpellingError>
    {
        public System.Collections.Generic.IEnumerable<System.String> Suggestions
        {
            get => __ProxyValue.Suggestions;
        }

        public void Correct(System.String correctedText) => __ProxyValue.Correct(@correctedText);
        public void IgnoreAll() => __ProxyValue.IgnoreAll();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}