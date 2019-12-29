namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class DrawingAttributes : Proxy<global::Windows.UI.Xaml.Ink.DrawingAttributes>
    {
        public System.Windows.Media.Color Color
        {
            get => __ProxyValue.Color;
            set => __ProxyValue.Color = value;
        }

        public System.Windows.Ink.StylusTip StylusTip
        {
            get => __ProxyValue.StylusTip;
            set => __ProxyValue.StylusTip = value;
        }

        public System.Windows.Media.Matrix StylusTipTransform
        {
            get => __ProxyValue.StylusTipTransform;
            set => __ProxyValue.StylusTipTransform = value;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
            set => __ProxyValue.Height = value;
        }

        public System.Double Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Boolean FitToCurve
        {
            get => __ProxyValue.FitToCurve;
            set => __ProxyValue.FitToCurve = value;
        }

        public System.Boolean IgnorePressure
        {
            get => __ProxyValue.IgnorePressure;
            set => __ProxyValue.IgnorePressure = value;
        }

        public System.Boolean IsHighlighter
        {
            get => __ProxyValue.IsHighlighter;
            set => __ProxyValue.IsHighlighter = value;
        }

        public DrawingAttributes(): base()
        {
        }

        public void AddPropertyData(System.Guid propertyDataId, System.Object propertyData) => __ProxyValue.AddPropertyData(@propertyDataId, @propertyData);
        public void RemovePropertyData(System.Guid propertyDataId) => __ProxyValue.RemovePropertyData(@propertyDataId);
        public System.Object GetPropertyData(System.Guid propertyDataId) => __ProxyValue.GetPropertyData(@propertyDataId);
        public System.Guid[] GetPropertyDataIds() => __ProxyValue.GetPropertyDataIds();
        public System.Boolean ContainsPropertyData(System.Guid propertyDataId) => __ProxyValue.ContainsPropertyData(@propertyDataId);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public static System.Boolean op_Equality(System.Windows.Ink.DrawingAttributes first, System.Windows.Ink.DrawingAttributes second) => Windows.UI.Xaml.Ink.DrawingAttributes.op_Equality(@first, @second);
        public static System.Boolean op_Inequality(System.Windows.Ink.DrawingAttributes first, System.Windows.Ink.DrawingAttributes second) => Windows.UI.Xaml.Ink.DrawingAttributes.op_Inequality(@first, @second);
        public System.Windows.Ink.DrawingAttributes Clone() => __ProxyValue.Clone();
        public void add_AttributeChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.add_AttributeChanged(@value);
        public void remove_AttributeChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.remove_AttributeChanged(@value);
        public void add_PropertyDataChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.add_PropertyDataChanged(@value);
        public void remove_PropertyDataChanged(System.Windows.Ink.PropertyDataChangedEventHandler value) => __ProxyValue.remove_PropertyDataChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}