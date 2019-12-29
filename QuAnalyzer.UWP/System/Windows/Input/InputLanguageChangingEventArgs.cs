namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputLanguageChangingEventArgs : Proxy<global::Windows.UI.Xaml.Input.InputLanguageChangingEventArgs>
    {
        public System.Boolean Rejected
        {
            get => __ProxyValue.Rejected;
            set => __ProxyValue.Rejected = value;
        }

        public System.Globalization.CultureInfo NewLanguage
        {
            get => __ProxyValue.NewLanguage;
        }

        public System.Globalization.CultureInfo PreviousLanguage
        {
            get => __ProxyValue.PreviousLanguage;
        }

        public InputLanguageChangingEventArgs(System.Globalization.CultureInfo @newLanguageId, System.Globalization.CultureInfo @previousLanguageId): base(@newLanguageId, @previousLanguageId)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}