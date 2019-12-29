namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class BindingListCollectionView : Proxy<global::Windows.UI.Xaml.Data.BindingListCollectionView>
    {
        public System.ComponentModel.SortDescriptionCollection SortDescriptions
        {
            get => __ProxyValue.SortDescriptions;
        }

        public System.Boolean CanSort
        {
            get => __ProxyValue.CanSort;
        }

        public System.Boolean CanFilter
        {
            get => __ProxyValue.CanFilter;
        }

        public System.String CustomFilter
        {
            get => __ProxyValue.CustomFilter;
            set => __ProxyValue.CustomFilter = value;
        }

        public System.Boolean CanCustomFilter
        {
            get => __ProxyValue.CanCustomFilter;
        }

        public System.Boolean CanGroup
        {
            get => __ProxyValue.CanGroup;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.ComponentModel.GroupDescription> GroupDescriptions
        {
            get => __ProxyValue.GroupDescriptions;
        }

        public System.Collections.ObjectModel.ReadOnlyObservableCollection<System.Object> Groups
        {
            get => __ProxyValue.Groups;
        }

        public System.Windows.Data.GroupDescriptionSelectorCallback GroupBySelector
        {
            get => __ProxyValue.GroupBySelector;
            set => __ProxyValue.GroupBySelector = value;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
        }

        public System.Boolean IsDataInGroupOrder
        {
            get => __ProxyValue.IsDataInGroupOrder;
            set => __ProxyValue.IsDataInGroupOrder = value;
        }

        public System.ComponentModel.NewItemPlaceholderPosition NewItemPlaceholderPosition
        {
            get => __ProxyValue.NewItemPlaceholderPosition;
            set => __ProxyValue.NewItemPlaceholderPosition = value;
        }

        public System.Boolean CanAddNew
        {
            get => __ProxyValue.CanAddNew;
        }

        public System.Boolean IsAddingNew
        {
            get => __ProxyValue.IsAddingNew;
        }

        public System.Object CurrentAddItem
        {
            get => __ProxyValue.CurrentAddItem;
        }

        public System.Boolean CanRemove
        {
            get => __ProxyValue.CanRemove;
        }

        public System.Boolean CanCancelEdit
        {
            get => __ProxyValue.CanCancelEdit;
        }

        public System.Boolean IsEditingItem
        {
            get => __ProxyValue.IsEditingItem;
        }

        public System.Object CurrentEditItem
        {
            get => __ProxyValue.CurrentEditItem;
        }

        public System.Boolean CanChangeLiveSorting
        {
            get => __ProxyValue.CanChangeLiveSorting;
        }

        public System.Boolean CanChangeLiveFiltering
        {
            get => __ProxyValue.CanChangeLiveFiltering;
        }

        public System.Boolean CanChangeLiveGrouping
        {
            get => __ProxyValue.CanChangeLiveGrouping;
        }

        public System.Nullable<System.Boolean> IsLiveSorting
        {
            get => __ProxyValue.IsLiveSorting;
            set => __ProxyValue.IsLiveSorting = value;
        }

        public System.Nullable<System.Boolean> IsLiveFiltering
        {
            get => __ProxyValue.IsLiveFiltering;
            set => __ProxyValue.IsLiveFiltering = value;
        }

        public System.Nullable<System.Boolean> IsLiveGrouping
        {
            get => __ProxyValue.IsLiveGrouping;
            set => __ProxyValue.IsLiveGrouping = value;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.String> LiveSortingProperties
        {
            get => __ProxyValue.LiveSortingProperties;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.String> LiveFilteringProperties
        {
            get => __ProxyValue.LiveFilteringProperties;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.String> LiveGroupingProperties
        {
            get => __ProxyValue.LiveGroupingProperties;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.ComponentModel.ItemPropertyInfo> ItemProperties
        {
            get => __ProxyValue.ItemProperties;
        }

        public System.Globalization.CultureInfo Culture
        {
            get => __ProxyValue.Culture;
            set => __ProxyValue.Culture = value;
        }

        public System.Collections.IEnumerable SourceCollection
        {
            get => __ProxyValue.SourceCollection;
        }

        public System.Predicate<System.Object> Filter
        {
            get => __ProxyValue.Filter;
            set => __ProxyValue.Filter = value;
        }

        public System.Object CurrentItem
        {
            get => __ProxyValue.CurrentItem;
        }

        public System.Int32 CurrentPosition
        {
            get => __ProxyValue.CurrentPosition;
        }

        public System.Boolean IsCurrentAfterLast
        {
            get => __ProxyValue.IsCurrentAfterLast;
        }

        public System.Boolean IsCurrentBeforeFirst
        {
            get => __ProxyValue.IsCurrentBeforeFirst;
        }

        public System.Collections.IComparer Comparer
        {
            get => __ProxyValue.Comparer;
        }

        public System.Boolean NeedsRefresh
        {
            get => __ProxyValue.NeedsRefresh;
        }

        public System.Boolean IsInUse
        {
            get => __ProxyValue.IsInUse;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public BindingListCollectionView(System.ComponentModel.IBindingList @list): base(@list)
        {
        }

        public System.Boolean PassesFilter(System.Object item) => __ProxyValue.PassesFilter(@item);
        public System.Boolean Contains(System.Object item) => __ProxyValue.Contains(@item);
        public System.Boolean MoveCurrentToPosition(System.Int32 position) => __ProxyValue.MoveCurrentToPosition(@position);
        public System.Int32 IndexOf(System.Object item) => __ProxyValue.IndexOf(@item);
        public System.Object GetItemAt(System.Int32 index) => __ProxyValue.GetItemAt(@index);
        public void DetachFromSourceCollection() => __ProxyValue.DetachFromSourceCollection();
        public System.Object AddNew() => __ProxyValue.AddNew();
        public void CommitNew() => __ProxyValue.CommitNew();
        public void CancelNew() => __ProxyValue.CancelNew();
        public void RemoveAt(System.Int32 index) => __ProxyValue.RemoveAt(@index);
        public void Remove(System.Object item) => __ProxyValue.Remove(@item);
        public void EditItem(System.Object item) => __ProxyValue.EditItem(@item);
        public void CommitEdit() => __ProxyValue.CommitEdit();
        public void CancelEdit() => __ProxyValue.CancelEdit();
        public void Refresh() => __ProxyValue.Refresh();
        public System.IDisposable DeferRefresh() => __ProxyValue.DeferRefresh();
        public System.Boolean MoveCurrentToFirst() => __ProxyValue.MoveCurrentToFirst();
        public System.Boolean MoveCurrentToLast() => __ProxyValue.MoveCurrentToLast();
        public System.Boolean MoveCurrentToNext() => __ProxyValue.MoveCurrentToNext();
        public System.Boolean MoveCurrentToPrevious() => __ProxyValue.MoveCurrentToPrevious();
        public System.Boolean MoveCurrentTo(System.Object item) => __ProxyValue.MoveCurrentTo(@item);
        public void add_CurrentChanging(System.ComponentModel.CurrentChangingEventHandler value) => __ProxyValue.add_CurrentChanging(@value);
        public void remove_CurrentChanging(System.ComponentModel.CurrentChangingEventHandler value) => __ProxyValue.remove_CurrentChanging(@value);
        public void add_CurrentChanged(System.EventHandler value) => __ProxyValue.add_CurrentChanged(@value);
        public void remove_CurrentChanged(System.EventHandler value) => __ProxyValue.remove_CurrentChanged(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}