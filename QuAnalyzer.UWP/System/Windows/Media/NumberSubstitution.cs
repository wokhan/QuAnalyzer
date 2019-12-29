namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class NumberSubstitution : Proxy<global::Windows.UI.Xaml.Media.NumberSubstitution>
    {
        public System.Windows.Media.NumberCultureSource CultureSource
        {
            get => __ProxyValue.CultureSource;
            set => __ProxyValue.CultureSource = value;
        }

        public System.Globalization.CultureInfo CultureOverride
        {
            get => __ProxyValue.CultureOverride;
            set => __ProxyValue.CultureOverride = value;
        }

        public System.Windows.Media.NumberSubstitutionMethod Substitution
        {
            get => __ProxyValue.Substitution;
            set => __ProxyValue.Substitution = value;
        }

        public NumberSubstitution(): base()
        {
        }

        public NumberSubstitution(System.Windows.Media.NumberCultureSource @source, System.Globalization.CultureInfo @cultureOverride, System.Windows.Media.NumberSubstitutionMethod @substitution): base(@source, @cultureOverride, @substitution)
        {
        }

        public static void SetCultureSource(System.Windows.DependencyObject target, System.Windows.Media.NumberCultureSource value) => Windows.UI.Xaml.Media.NumberSubstitution.SetCultureSource(@target, @value);
        public static System.Windows.Media.NumberCultureSource GetCultureSource(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.NumberSubstitution.GetCultureSource(@target);
        public static void SetCultureOverride(System.Windows.DependencyObject target, System.Globalization.CultureInfo value) => Windows.UI.Xaml.Media.NumberSubstitution.SetCultureOverride(@target, @value);
        public static System.Globalization.CultureInfo GetCultureOverride(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.NumberSubstitution.GetCultureOverride(@target);
        public static void SetSubstitution(System.Windows.DependencyObject target, System.Windows.Media.NumberSubstitutionMethod value) => Windows.UI.Xaml.Media.NumberSubstitution.SetSubstitution(@target, @value);
        public static System.Windows.Media.NumberSubstitutionMethod GetSubstitution(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.NumberSubstitution.GetSubstitution(@target);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}