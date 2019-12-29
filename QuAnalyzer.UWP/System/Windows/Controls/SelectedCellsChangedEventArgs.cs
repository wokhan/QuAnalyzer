namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class SelectedCellsChangedEventArgs : Proxy<global::Windows.UI.Xaml.Controls.SelectedCellsChangedEventArgs>
    {
        public System.Collections.Generic.IList<System.Windows.Controls.DataGridCellInfo> AddedCells
        {
            get => __ProxyValue.AddedCells;
        }

        public System.Collections.Generic.IList<System.Windows.Controls.DataGridCellInfo> RemovedCells
        {
            get => __ProxyValue.RemovedCells;
        }

        public SelectedCellsChangedEventArgs(System.Collections.Generic.List<System.Windows.Controls.DataGridCellInfo> @addedCells, System.Collections.Generic.List<System.Windows.Controls.DataGridCellInfo> @removedCells): base(@addedCells, @removedCells)
        {
        }

        public SelectedCellsChangedEventArgs(System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Controls.DataGridCellInfo> @addedCells, System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Controls.DataGridCellInfo> @removedCells): base(@addedCells, @removedCells)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}