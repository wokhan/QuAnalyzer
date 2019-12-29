namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputScope : Proxy<global::Windows.UI.Xaml.Input.InputScope>
    {
        public System.Collections.IList Names
        {
            get => __ProxyValue.Names;
        }

        public System.String SrgsMarkup
        {
            get => __ProxyValue.SrgsMarkup;
            set => __ProxyValue.SrgsMarkup = value;
        }

        public System.String RegularExpression
        {
            get => __ProxyValue.RegularExpression;
            set => __ProxyValue.RegularExpression = value;
        }

        public System.Collections.IList PhraseList
        {
            get => __ProxyValue.PhraseList;
        }

        public InputScope(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}