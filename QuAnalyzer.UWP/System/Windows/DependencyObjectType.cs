namespace System.Windows
{
    using Uno.UI.Generic;

    public class DependencyObjectType : Proxy<global::Windows.UI.Xaml.DependencyObjectType>
    {
        public System.Int32 Id
        {
            get => __ProxyValue.Id;
        }

        public System.Type SystemType
        {
            get => __ProxyValue.SystemType;
        }

        public System.Windows.DependencyObjectType BaseType
        {
            get => __ProxyValue.BaseType;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public static System.Windows.DependencyObjectType FromSystemType(System.Type systemType) => Windows.UI.Xaml.DependencyObjectType.FromSystemType(@systemType);
        public System.Boolean IsInstanceOfType(System.Windows.DependencyObject dependencyObject) => __ProxyValue.IsInstanceOfType(@dependencyObject);
        public System.Boolean IsSubclassOf(System.Windows.DependencyObjectType dependencyObjectType) => __ProxyValue.IsSubclassOf(@dependencyObjectType);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
    }
}