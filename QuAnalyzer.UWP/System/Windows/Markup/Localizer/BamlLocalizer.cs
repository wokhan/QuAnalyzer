namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizer : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizer>
    {
        public BamlLocalizer(System.IO.Stream @source): base(@source)
        {
        }

        public BamlLocalizer(System.IO.Stream @source, System.Windows.Markup.Localizer.BamlLocalizabilityResolver @resolver): base(@source, @resolver)
        {
        }

        public BamlLocalizer(System.IO.Stream @source, System.Windows.Markup.Localizer.BamlLocalizabilityResolver @resolver, System.IO.TextReader @comments): base(@source, @resolver, @comments)
        {
        }

        public System.Windows.Markup.Localizer.BamlLocalizationDictionary ExtractResources() => __ProxyValue.ExtractResources();
        public void UpdateBaml(System.IO.Stream target, System.Windows.Markup.Localizer.BamlLocalizationDictionary updates) => __ProxyValue.UpdateBaml(@target, @updates);
        public void add_ErrorNotify(System.Windows.Markup.Localizer.BamlLocalizerErrorNotifyEventHandler value) => __ProxyValue.add_ErrorNotify(@value);
        public void remove_ErrorNotify(System.Windows.Markup.Localizer.BamlLocalizerErrorNotifyEventHandler value) => __ProxyValue.remove_ErrorNotify(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}