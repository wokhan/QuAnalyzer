namespace System.Windows
{
    using Uno.UI.Generic;

    public class FrameworkPropertyMetadata : Proxy<global::Windows.UI.Xaml.FrameworkPropertyMetadata>
    {
        public System.Boolean AffectsMeasure
        {
            get => __ProxyValue.AffectsMeasure;
            set => __ProxyValue.AffectsMeasure = value;
        }

        public System.Boolean AffectsArrange
        {
            get => __ProxyValue.AffectsArrange;
            set => __ProxyValue.AffectsArrange = value;
        }

        public System.Boolean AffectsParentMeasure
        {
            get => __ProxyValue.AffectsParentMeasure;
            set => __ProxyValue.AffectsParentMeasure = value;
        }

        public System.Boolean AffectsParentArrange
        {
            get => __ProxyValue.AffectsParentArrange;
            set => __ProxyValue.AffectsParentArrange = value;
        }

        public System.Boolean AffectsRender
        {
            get => __ProxyValue.AffectsRender;
            set => __ProxyValue.AffectsRender = value;
        }

        public System.Boolean Inherits
        {
            get => __ProxyValue.Inherits;
            set => __ProxyValue.Inherits = value;
        }

        public System.Boolean OverridesInheritanceBehavior
        {
            get => __ProxyValue.OverridesInheritanceBehavior;
            set => __ProxyValue.OverridesInheritanceBehavior = value;
        }

        public System.Boolean IsNotDataBindable
        {
            get => __ProxyValue.IsNotDataBindable;
            set => __ProxyValue.IsNotDataBindable = value;
        }

        public System.Boolean BindsTwoWayByDefault
        {
            get => __ProxyValue.BindsTwoWayByDefault;
            set => __ProxyValue.BindsTwoWayByDefault = value;
        }

        public System.Windows.Data.UpdateSourceTrigger DefaultUpdateSourceTrigger
        {
            get => __ProxyValue.DefaultUpdateSourceTrigger;
            set => __ProxyValue.DefaultUpdateSourceTrigger = value;
        }

        public System.Boolean Journal
        {
            get => __ProxyValue.Journal;
            set => __ProxyValue.Journal = value;
        }

        public System.Boolean SubPropertiesDoNotAffectRender
        {
            get => __ProxyValue.SubPropertiesDoNotAffectRender;
            set => __ProxyValue.SubPropertiesDoNotAffectRender = value;
        }

        public System.Boolean IsDataBindingAllowed
        {
            get => __ProxyValue.IsDataBindingAllowed;
        }

        public System.Boolean IsAnimationProhibited
        {
            get => __ProxyValue.IsAnimationProhibited;
            set => __ProxyValue.IsAnimationProhibited = value;
        }

        public System.Object DefaultValue
        {
            get => __ProxyValue.DefaultValue;
            set => __ProxyValue.DefaultValue = value;
        }

        public System.Windows.PropertyChangedCallback PropertyChangedCallback
        {
            get => __ProxyValue.PropertyChangedCallback;
            set => __ProxyValue.PropertyChangedCallback = value;
        }

        public System.Windows.CoerceValueCallback CoerceValueCallback
        {
            get => __ProxyValue.CoerceValueCallback;
            set => __ProxyValue.CoerceValueCallback = value;
        }

        public FrameworkPropertyMetadata(): base()
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue): base(@defaultValue)
        {
        }

        public FrameworkPropertyMetadata(System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@propertyChangedCallback)
        {
        }

        public FrameworkPropertyMetadata(System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback): base(@propertyChangedCallback, @coerceValueCallback)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@defaultValue, @propertyChangedCallback)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback): base(@defaultValue, @propertyChangedCallback, @coerceValueCallback)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.FrameworkPropertyMetadataOptions @flags): base(@defaultValue, @flags)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.FrameworkPropertyMetadataOptions @flags, System.Windows.PropertyChangedCallback @propertyChangedCallback): base(@defaultValue, @flags, @propertyChangedCallback)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.FrameworkPropertyMetadataOptions @flags, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback): base(@defaultValue, @flags, @propertyChangedCallback, @coerceValueCallback)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.FrameworkPropertyMetadataOptions @flags, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback, System.Boolean @isAnimationProhibited): base(@defaultValue, @flags, @propertyChangedCallback, @coerceValueCallback, @isAnimationProhibited)
        {
        }

        public FrameworkPropertyMetadata(System.Object @defaultValue, System.Windows.FrameworkPropertyMetadataOptions @flags, System.Windows.PropertyChangedCallback @propertyChangedCallback, System.Windows.CoerceValueCallback @coerceValueCallback, System.Boolean @isAnimationProhibited, System.Windows.Data.UpdateSourceTrigger @defaultUpdateSourceTrigger): base(@defaultValue, @flags, @propertyChangedCallback, @coerceValueCallback, @isAnimationProhibited, @defaultUpdateSourceTrigger)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}