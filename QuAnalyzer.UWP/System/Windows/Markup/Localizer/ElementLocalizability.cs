namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class ElementLocalizability : Proxy<global::Windows.UI.Xaml.Markup.Localizer.ElementLocalizability>
    {
        public System.String FormattingTag
        {
            get => __ProxyValue.FormattingTag;
            set => __ProxyValue.FormattingTag = value;
        }

        public System.Windows.LocalizabilityAttribute Attribute
        {
            get => __ProxyValue.Attribute;
            set => __ProxyValue.Attribute = value;
        }

        public ElementLocalizability(): base()
        {
        }

        public ElementLocalizability(System.String @formattingTag, System.Windows.LocalizabilityAttribute @attribute): base(@formattingTag, @attribute)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}