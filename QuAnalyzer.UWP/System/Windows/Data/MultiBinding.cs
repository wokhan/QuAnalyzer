namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class MultiBinding : Proxy<global::Windows.UI.Xaml.Data.MultiBinding>
    {
        public System.Collections.ObjectModel.Collection<System.Windows.Data.BindingBase> Bindings
        {
            get => __ProxyValue.Bindings;
        }

        public System.Windows.Data.BindingMode Mode
        {
            get => __ProxyValue.Mode;
            set => __ProxyValue.Mode = value;
        }

        public System.Windows.Data.UpdateSourceTrigger UpdateSourceTrigger
        {
            get => __ProxyValue.UpdateSourceTrigger;
            set => __ProxyValue.UpdateSourceTrigger = value;
        }

        public System.Boolean NotifyOnSourceUpdated
        {
            get => __ProxyValue.NotifyOnSourceUpdated;
            set => __ProxyValue.NotifyOnSourceUpdated = value;
        }

        public System.Boolean NotifyOnTargetUpdated
        {
            get => __ProxyValue.NotifyOnTargetUpdated;
            set => __ProxyValue.NotifyOnTargetUpdated = value;
        }

        public System.Boolean NotifyOnValidationError
        {
            get => __ProxyValue.NotifyOnValidationError;
            set => __ProxyValue.NotifyOnValidationError = value;
        }

        public System.Windows.Data.IMultiValueConverter Converter
        {
            get => __ProxyValue.Converter;
            set => __ProxyValue.Converter = value;
        }

        public System.Object ConverterParameter
        {
            get => __ProxyValue.ConverterParameter;
            set => __ProxyValue.ConverterParameter = value;
        }

        public System.Globalization.CultureInfo ConverterCulture
        {
            get => __ProxyValue.ConverterCulture;
            set => __ProxyValue.ConverterCulture = value;
        }

        public System.Collections.ObjectModel.Collection<System.Windows.Controls.ValidationRule> ValidationRules
        {
            get => __ProxyValue.ValidationRules;
        }

        public System.Windows.Data.UpdateSourceExceptionFilterCallback UpdateSourceExceptionFilter
        {
            get => __ProxyValue.UpdateSourceExceptionFilter;
            set => __ProxyValue.UpdateSourceExceptionFilter = value;
        }

        public System.Boolean ValidatesOnExceptions
        {
            get => __ProxyValue.ValidatesOnExceptions;
            set => __ProxyValue.ValidatesOnExceptions = value;
        }

        public System.Boolean ValidatesOnDataErrors
        {
            get => __ProxyValue.ValidatesOnDataErrors;
            set => __ProxyValue.ValidatesOnDataErrors = value;
        }

        public System.Boolean ValidatesOnNotifyDataErrors
        {
            get => __ProxyValue.ValidatesOnNotifyDataErrors;
            set => __ProxyValue.ValidatesOnNotifyDataErrors = value;
        }

        public System.Object FallbackValue
        {
            get => __ProxyValue.FallbackValue;
            set => __ProxyValue.FallbackValue = value;
        }

        public System.String StringFormat
        {
            get => __ProxyValue.StringFormat;
            set => __ProxyValue.StringFormat = value;
        }

        public System.Object TargetNullValue
        {
            get => __ProxyValue.TargetNullValue;
            set => __ProxyValue.TargetNullValue = value;
        }

        public System.String BindingGroupName
        {
            get => __ProxyValue.BindingGroupName;
            set => __ProxyValue.BindingGroupName = value;
        }

        public System.Int32 Delay
        {
            get => __ProxyValue.Delay;
            set => __ProxyValue.Delay = value;
        }

        public MultiBinding(): base()
        {
        }

        public System.Boolean ShouldSerializeBindings() => __ProxyValue.ShouldSerializeBindings();
        public System.Boolean ShouldSerializeValidationRules() => __ProxyValue.ShouldSerializeValidationRules();
        public System.Boolean ShouldSerializeFallbackValue() => __ProxyValue.ShouldSerializeFallbackValue();
        public System.Boolean ShouldSerializeTargetNullValue() => __ProxyValue.ShouldSerializeTargetNullValue();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}