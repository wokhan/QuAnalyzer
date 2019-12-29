namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class Binding : Proxy<global::Windows.UI.Xaml.Data.Binding>
    {
        public System.Collections.ObjectModel.Collection<System.Windows.Controls.ValidationRule> ValidationRules
        {
            get => __ProxyValue.ValidationRules;
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

        public System.Windows.PropertyPath Path
        {
            get => __ProxyValue.Path;
            set => __ProxyValue.Path = value;
        }

        public System.String XPath
        {
            get => __ProxyValue.XPath;
            set => __ProxyValue.XPath = value;
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

        public System.Windows.Data.IValueConverter Converter
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

        public System.Object Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Windows.Data.RelativeSource RelativeSource
        {
            get => __ProxyValue.RelativeSource;
            set => __ProxyValue.RelativeSource = value;
        }

        public System.String ElementName
        {
            get => __ProxyValue.ElementName;
            set => __ProxyValue.ElementName = value;
        }

        public System.Boolean IsAsync
        {
            get => __ProxyValue.IsAsync;
            set => __ProxyValue.IsAsync = value;
        }

        public System.Object AsyncState
        {
            get => __ProxyValue.AsyncState;
            set => __ProxyValue.AsyncState = value;
        }

        public System.Boolean BindsDirectlyToSource
        {
            get => __ProxyValue.BindsDirectlyToSource;
            set => __ProxyValue.BindsDirectlyToSource = value;
        }

        public System.Windows.Data.UpdateSourceExceptionFilterCallback UpdateSourceExceptionFilter
        {
            get => __ProxyValue.UpdateSourceExceptionFilter;
            set => __ProxyValue.UpdateSourceExceptionFilter = value;
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

        public Binding(): base()
        {
        }

        public Binding(System.String @path): base(@path)
        {
        }

        public static void AddSourceUpdatedHandler(System.Windows.DependencyObject element, System.EventHandler<System.Windows.Data.DataTransferEventArgs> handler) => Windows.UI.Xaml.Data.Binding.AddSourceUpdatedHandler(@element, @handler);
        public static void RemoveSourceUpdatedHandler(System.Windows.DependencyObject element, System.EventHandler<System.Windows.Data.DataTransferEventArgs> handler) => Windows.UI.Xaml.Data.Binding.RemoveSourceUpdatedHandler(@element, @handler);
        public static void AddTargetUpdatedHandler(System.Windows.DependencyObject element, System.EventHandler<System.Windows.Data.DataTransferEventArgs> handler) => Windows.UI.Xaml.Data.Binding.AddTargetUpdatedHandler(@element, @handler);
        public static void RemoveTargetUpdatedHandler(System.Windows.DependencyObject element, System.EventHandler<System.Windows.Data.DataTransferEventArgs> handler) => Windows.UI.Xaml.Data.Binding.RemoveTargetUpdatedHandler(@element, @handler);
        public static System.Xml.XmlNamespaceManager GetXmlNamespaceManager(System.Windows.DependencyObject target) => Windows.UI.Xaml.Data.Binding.GetXmlNamespaceManager(@target);
        public static void SetXmlNamespaceManager(System.Windows.DependencyObject target, System.Xml.XmlNamespaceManager value) => Windows.UI.Xaml.Data.Binding.SetXmlNamespaceManager(@target, @value);
        public System.Boolean ShouldSerializeValidationRules() => __ProxyValue.ShouldSerializeValidationRules();
        public System.Boolean ShouldSerializePath() => __ProxyValue.ShouldSerializePath();
        public System.Boolean ShouldSerializeSource() => __ProxyValue.ShouldSerializeSource();
        public System.Boolean ShouldSerializeFallbackValue() => __ProxyValue.ShouldSerializeFallbackValue();
        public System.Boolean ShouldSerializeTargetNullValue() => __ProxyValue.ShouldSerializeTargetNullValue();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}