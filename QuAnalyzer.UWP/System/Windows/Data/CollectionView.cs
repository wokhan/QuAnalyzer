namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CollectionView : Proxy<global::Windows.UI.Xaml.Data.CollectionView>
    {
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

        public System.Boolean CanFilter
        {
            get => __ProxyValue.CanFilter;
        }

        public System.ComponentModel.SortDescriptionCollection SortDescriptions
        {
            get => __ProxyValue.SortDescriptions;
        }

        public System.Boolean CanSort
        {
            get => __ProxyValue.CanSort;
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

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
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

        public static System.Object NewItemPlaceholder
        {
            get => __ProxyValue.NewItemPlaceholder;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public CollectionView(System.Collections.IEnumerable @collection): base(@collection)
        {
        }

        public System.Boolean PassesFilter(System.Object item) => __ProxyValue.PassesFilter(@item);
        public System.Boolean Contains(System.Object item) => __ProxyValue.Contains(@item);
        public System.Boolean MoveCurrentToPosition(System.Int32 position) => __ProxyValue.MoveCurrentToPosition(@position);
        public System.Int32 IndexOf(System.Object item) => __ProxyValue.IndexOf(@item);
        public System.Object GetItemAt(System.Int32 index) => __ProxyValue.GetItemAt(@index);
        public void DetachFromSourceCollection() => __ProxyValue.DetachFromSourceCollection();
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