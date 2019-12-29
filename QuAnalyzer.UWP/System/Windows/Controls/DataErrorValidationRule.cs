namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataErrorValidationRule : Proxy<global::Windows.UI.Xaml.Controls.DataErrorValidationRule>
    {
        public System.Windows.Controls.ValidationStep ValidationStep
        {
            get => __ProxyValue.ValidationStep;
            set => __ProxyValue.ValidationStep = value;
        }

        public System.Boolean ValidatesOnTargetUpdated
        {
            get => __ProxyValue.ValidatesOnTargetUpdated;
            set => __ProxyValue.ValidatesOnTargetUpdated = value;
        }

        public DataErrorValidationRule(): base()
        {
        }

        public System.Windows.Controls.ValidationResult Validate(System.Object value, System.Globalization.CultureInfo cultureInfo) => __ProxyValue.Validate(@value, @cultureInfo);
        public System.Windows.Controls.ValidationResult Validate(System.Object value, System.Globalization.CultureInfo cultureInfo, System.Windows.Data.BindingExpressionBase owner) => __ProxyValue.Validate(@value, @cultureInfo, @owner);
        public System.Windows.Controls.ValidationResult Validate(System.Object value, System.Globalization.CultureInfo cultureInfo, System.Windows.Data.BindingGroup owner) => __ProxyValue.Validate(@value, @cultureInfo, @owner);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}