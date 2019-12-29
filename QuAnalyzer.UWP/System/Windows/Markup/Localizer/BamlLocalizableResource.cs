namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizableResource : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizableResource>
    {
        public System.String Content
        {
            get => __ProxyValue.Content;
            set => __ProxyValue.Content = value;
        }

        public System.String Comments
        {
            get => __ProxyValue.Comments;
            set => __ProxyValue.Comments = value;
        }

        public System.Boolean Modifiable
        {
            get => __ProxyValue.Modifiable;
            set => __ProxyValue.Modifiable = value;
        }

        public System.Boolean Readable
        {
            get => __ProxyValue.Readable;
            set => __ProxyValue.Readable = value;
        }

        public System.Windows.LocalizationCategory Category
        {
            get => __ProxyValue.Category;
            set => __ProxyValue.Category = value;
        }

        public BamlLocalizableResource(): base()
        {
        }

        public BamlLocalizableResource(System.String @content, System.String @comments, System.Windows.LocalizationCategory @category, System.Boolean @modifiable, System.Boolean @readable): base(@content, @comments, @category, @modifiable, @readable)
        {
        }

        public override System.Boolean Equals(System.Object other) => __ProxyValue.Equals(@other);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}