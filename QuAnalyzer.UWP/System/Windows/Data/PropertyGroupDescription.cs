namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class PropertyGroupDescription : Proxy<global::Windows.UI.Xaml.Data.PropertyGroupDescription>
    {
        public System.String PropertyName
        {
            get => __ProxyValue.PropertyName;
            set => __ProxyValue.PropertyName = value;
        }

        public System.Windows.Data.IValueConverter Converter
        {
            get => __ProxyValue.Converter;
            set => __ProxyValue.Converter = value;
        }

        public System.StringComparison StringComparison
        {
            get => __ProxyValue.StringComparison;
            set => __ProxyValue.StringComparison = value;
        }

        public static System.Collections.IComparer CompareNameAscending
        {
            get => __ProxyValue.CompareNameAscending;
        }

        public static System.Collections.IComparer CompareNameDescending
        {
            get => __ProxyValue.CompareNameDescending;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.Object> GroupNames
        {
            get => __ProxyValue.GroupNames;
        }

        public System.ComponentModel.SortDescriptionCollection SortDescriptions
        {
            get => __ProxyValue.SortDescriptions;
        }

        public System.Collections.IComparer CustomSort
        {
            get => __ProxyValue.CustomSort;
            set => __ProxyValue.CustomSort = value;
        }

        public PropertyGroupDescription(): base()
        {
        }

        public PropertyGroupDescription(System.String @propertyName): base(@propertyName)
        {
        }

        public PropertyGroupDescription(System.String @propertyName, System.Windows.Data.IValueConverter @converter): base(@propertyName, @converter)
        {
        }

        public PropertyGroupDescription(System.String @propertyName, System.Windows.Data.IValueConverter @converter, System.StringComparison @stringComparison): base(@propertyName, @converter, @stringComparison)
        {
        }

        public System.Object GroupNameFromItem(System.Object item, System.Int32 level, System.Globalization.CultureInfo culture) => __ProxyValue.GroupNameFromItem(@item, @level, @culture);
        public System.Boolean NamesMatch(System.Object groupName, System.Object itemName) => __ProxyValue.NamesMatch(@groupName, @itemName);
        public System.Boolean ShouldSerializeGroupNames() => __ProxyValue.ShouldSerializeGroupNames();
        public System.Boolean ShouldSerializeSortDescriptions() => __ProxyValue.ShouldSerializeSortDescriptions();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}