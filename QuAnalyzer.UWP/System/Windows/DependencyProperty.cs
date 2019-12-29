namespace System.Windows
{
    using Uno.UI.Generic;

    public class DependencyProperty : Proxy<global::Windows.UI.Xaml.DependencyProperty>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Type PropertyType
        {
            get => __ProxyValue.PropertyType;
        }

        public System.Type OwnerType
        {
            get => __ProxyValue.OwnerType;
        }

        public System.Windows.PropertyMetadata DefaultMetadata
        {
            get => __ProxyValue.DefaultMetadata;
        }

        public System.Windows.ValidateValueCallback ValidateValueCallback
        {
            get => __ProxyValue.ValidateValueCallback;
        }

        public System.Int32 GlobalIndex
        {
            get => __ProxyValue.GlobalIndex;
        }

        public System.Boolean ReadOnly
        {
            get => __ProxyValue.ReadOnly;
        }

        public static System.Windows.DependencyProperty Register(System.String name, System.Type propertyType, System.Type ownerType) => Windows.UI.Xaml.DependencyProperty.Register(@name, @propertyType, @ownerType);
        public static System.Windows.DependencyProperty Register(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata typeMetadata) => Windows.UI.Xaml.DependencyProperty.Register(@name, @propertyType, @ownerType, @typeMetadata);
        public static System.Windows.DependencyProperty Register(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata typeMetadata, System.Windows.ValidateValueCallback validateValueCallback) => Windows.UI.Xaml.DependencyProperty.Register(@name, @propertyType, @ownerType, @typeMetadata, @validateValueCallback);
        public static System.Windows.DependencyPropertyKey RegisterReadOnly(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata typeMetadata) => Windows.UI.Xaml.DependencyProperty.RegisterReadOnly(@name, @propertyType, @ownerType, @typeMetadata);
        public static System.Windows.DependencyPropertyKey RegisterReadOnly(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata typeMetadata, System.Windows.ValidateValueCallback validateValueCallback) => Windows.UI.Xaml.DependencyProperty.RegisterReadOnly(@name, @propertyType, @ownerType, @typeMetadata, @validateValueCallback);
        public static System.Windows.DependencyPropertyKey RegisterAttachedReadOnly(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata defaultMetadata) => Windows.UI.Xaml.DependencyProperty.RegisterAttachedReadOnly(@name, @propertyType, @ownerType, @defaultMetadata);
        public static System.Windows.DependencyPropertyKey RegisterAttachedReadOnly(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata defaultMetadata, System.Windows.ValidateValueCallback validateValueCallback) => Windows.UI.Xaml.DependencyProperty.RegisterAttachedReadOnly(@name, @propertyType, @ownerType, @defaultMetadata, @validateValueCallback);
        public static System.Windows.DependencyProperty RegisterAttached(System.String name, System.Type propertyType, System.Type ownerType) => Windows.UI.Xaml.DependencyProperty.RegisterAttached(@name, @propertyType, @ownerType);
        public static System.Windows.DependencyProperty RegisterAttached(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata defaultMetadata) => Windows.UI.Xaml.DependencyProperty.RegisterAttached(@name, @propertyType, @ownerType, @defaultMetadata);
        public static System.Windows.DependencyProperty RegisterAttached(System.String name, System.Type propertyType, System.Type ownerType, System.Windows.PropertyMetadata defaultMetadata, System.Windows.ValidateValueCallback validateValueCallback) => Windows.UI.Xaml.DependencyProperty.RegisterAttached(@name, @propertyType, @ownerType, @defaultMetadata, @validateValueCallback);
        public void OverrideMetadata(System.Type forType, System.Windows.PropertyMetadata typeMetadata) => __ProxyValue.OverrideMetadata(@forType, @typeMetadata);
        public void OverrideMetadata(System.Type forType, System.Windows.PropertyMetadata typeMetadata, System.Windows.DependencyPropertyKey key) => __ProxyValue.OverrideMetadata(@forType, @typeMetadata, @key);
        public System.Windows.PropertyMetadata GetMetadata(System.Type forType) => __ProxyValue.GetMetadata(@forType);
        public System.Windows.PropertyMetadata GetMetadata(System.Windows.DependencyObject dependencyObject) => __ProxyValue.GetMetadata(@dependencyObject);
        public System.Windows.PropertyMetadata GetMetadata(System.Windows.DependencyObjectType dependencyObjectType) => __ProxyValue.GetMetadata(@dependencyObjectType);
        public System.Windows.DependencyProperty AddOwner(System.Type ownerType) => __ProxyValue.AddOwner(@ownerType);
        public System.Windows.DependencyProperty AddOwner(System.Type ownerType, System.Windows.PropertyMetadata typeMetadata) => __ProxyValue.AddOwner(@ownerType, @typeMetadata);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean IsValidType(System.Object value) => __ProxyValue.IsValidType(@value);
        public System.Boolean IsValidValue(System.Object value) => __ProxyValue.IsValidValue(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
    }
}