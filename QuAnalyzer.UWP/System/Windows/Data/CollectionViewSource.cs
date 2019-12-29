namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CollectionViewSource : Proxy<global::Windows.UI.Xaml.Data.CollectionViewSource>
    {
        public System.ComponentModel.ICollectionView View
        {
            get => __ProxyValue.View;
        }

        public System.Object Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Type CollectionViewType
        {
            get => __ProxyValue.CollectionViewType;
            set => __ProxyValue.CollectionViewType = value;
        }

        public System.Globalization.CultureInfo Culture
        {
            get => __ProxyValue.Culture;
            set => __ProxyValue.Culture = value;
        }

        public System.ComponentModel.SortDescriptionCollection SortDescriptions
        {
            get => __ProxyValue.SortDescriptions;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.ComponentModel.GroupDescription> GroupDescriptions
        {
            get => __ProxyValue.GroupDescriptions;
        }

        public System.Boolean CanChangeLiveSorting
        {
            get => __ProxyValue.CanChangeLiveSorting;
        }

        public System.Boolean IsLiveSortingRequested
        {
            get => __ProxyValue.IsLiveSortingRequested;
            set => __ProxyValue.IsLiveSortingRequested = value;
        }

        public System.Nullable<System.Boolean> IsLiveSorting
        {
            get => __ProxyValue.IsLiveSorting;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.String> LiveSortingProperties
        {
            get => __ProxyValue.LiveSortingProperties;
        }

        public System.Boolean CanChangeLiveFiltering
        {
            get => __ProxyValue.CanChangeLiveFiltering;
        }

        public System.Boolean IsLiveFilteringRequested
        {
            get => __ProxyValue.IsLiveFilteringRequested;
            set => __ProxyValue.IsLiveFilteringRequested = value;
        }

        public System.Nullable<System.Boolean> IsLiveFiltering
        {
            get => __ProxyValue.IsLiveFiltering;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.String> LiveFilteringProperties
        {
            get => __ProxyValue.LiveFilteringProperties;
        }

        public System.Boolean CanChangeLiveGrouping
        {
            get => __ProxyValue.CanChangeLiveGrouping;
        }

        public System.Boolean IsLiveGroupingRequested
        {
            get => __ProxyValue.IsLiveGroupingRequested;
            set => __ProxyValue.IsLiveGroupingRequested = value;
        }

        public System.Nullable<System.Boolean> IsLiveGrouping
        {
            get => __ProxyValue.IsLiveGrouping;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.String> LiveGroupingProperties
        {
            get => __ProxyValue.LiveGroupingProperties;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public CollectionViewSource(): base()
        {
        }

        public void add_Filter(System.Windows.Data.FilterEventHandler value) => __ProxyValue.add_Filter(@value);
        public void remove_Filter(System.Windows.Data.FilterEventHandler value) => __ProxyValue.remove_Filter(@value);
        public static System.ComponentModel.ICollectionView GetDefaultView(System.Object source) => Windows.UI.Xaml.Data.CollectionViewSource.GetDefaultView(@source);
        public static System.Boolean IsDefaultView(System.ComponentModel.ICollectionView view) => Windows.UI.Xaml.Data.CollectionViewSource.IsDefaultView(@view);
        public System.IDisposable DeferRefresh() => __ProxyValue.DeferRefresh();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}