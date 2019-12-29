namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DataGrid : Proxy<global::Windows.UI.Xaml.Controls.DataGrid>
    {
        public System.Collections.ObjectModel.ObservableCollection<System.Windows.Controls.DataGridColumn> Columns
        {
            get => __ProxyValue.Columns;
        }

        public System.Boolean CanUserResizeColumns
        {
            get => __ProxyValue.CanUserResizeColumns;
            set => __ProxyValue.CanUserResizeColumns = value;
        }

        public System.Windows.Controls.DataGridLength ColumnWidth
        {
            get => __ProxyValue.ColumnWidth;
            set => __ProxyValue.ColumnWidth = value;
        }

        public System.Double MinColumnWidth
        {
            get => __ProxyValue.MinColumnWidth;
            set => __ProxyValue.MinColumnWidth = value;
        }

        public System.Double MaxColumnWidth
        {
            get => __ProxyValue.MaxColumnWidth;
            set => __ProxyValue.MaxColumnWidth = value;
        }

        public System.Windows.Controls.DataGridGridLinesVisibility GridLinesVisibility
        {
            get => __ProxyValue.GridLinesVisibility;
            set => __ProxyValue.GridLinesVisibility = value;
        }

        public System.Windows.Media.Brush HorizontalGridLinesBrush
        {
            get => __ProxyValue.HorizontalGridLinesBrush;
            set => __ProxyValue.HorizontalGridLinesBrush = value;
        }

        public System.Windows.Media.Brush VerticalGridLinesBrush
        {
            get => __ProxyValue.VerticalGridLinesBrush;
            set => __ProxyValue.VerticalGridLinesBrush = value;
        }

        public System.Windows.Style RowStyle
        {
            get => __ProxyValue.RowStyle;
            set => __ProxyValue.RowStyle = value;
        }

        public System.Windows.Controls.ControlTemplate RowValidationErrorTemplate
        {
            get => __ProxyValue.RowValidationErrorTemplate;
            set => __ProxyValue.RowValidationErrorTemplate = value;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.Windows.Controls.ValidationRule> RowValidationRules
        {
            get => __ProxyValue.RowValidationRules;
        }

        public System.Windows.Controls.StyleSelector RowStyleSelector
        {
            get => __ProxyValue.RowStyleSelector;
            set => __ProxyValue.RowStyleSelector = value;
        }

        public System.Windows.Media.Brush RowBackground
        {
            get => __ProxyValue.RowBackground;
            set => __ProxyValue.RowBackground = value;
        }

        public System.Windows.Media.Brush AlternatingRowBackground
        {
            get => __ProxyValue.AlternatingRowBackground;
            set => __ProxyValue.AlternatingRowBackground = value;
        }

        public System.Double RowHeight
        {
            get => __ProxyValue.RowHeight;
            set => __ProxyValue.RowHeight = value;
        }

        public System.Double MinRowHeight
        {
            get => __ProxyValue.MinRowHeight;
            set => __ProxyValue.MinRowHeight = value;
        }

        public System.Double RowHeaderWidth
        {
            get => __ProxyValue.RowHeaderWidth;
            set => __ProxyValue.RowHeaderWidth = value;
        }

        public System.Double RowHeaderActualWidth
        {
            get => __ProxyValue.RowHeaderActualWidth;
        }

        public System.Double ColumnHeaderHeight
        {
            get => __ProxyValue.ColumnHeaderHeight;
            set => __ProxyValue.ColumnHeaderHeight = value;
        }

        public System.Windows.Controls.DataGridHeadersVisibility HeadersVisibility
        {
            get => __ProxyValue.HeadersVisibility;
            set => __ProxyValue.HeadersVisibility = value;
        }

        public System.Windows.Style CellStyle
        {
            get => __ProxyValue.CellStyle;
            set => __ProxyValue.CellStyle = value;
        }

        public System.Windows.Style ColumnHeaderStyle
        {
            get => __ProxyValue.ColumnHeaderStyle;
            set => __ProxyValue.ColumnHeaderStyle = value;
        }

        public System.Windows.Style RowHeaderStyle
        {
            get => __ProxyValue.RowHeaderStyle;
            set => __ProxyValue.RowHeaderStyle = value;
        }

        public System.Windows.DataTemplate RowHeaderTemplate
        {
            get => __ProxyValue.RowHeaderTemplate;
            set => __ProxyValue.RowHeaderTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector RowHeaderTemplateSelector
        {
            get => __ProxyValue.RowHeaderTemplateSelector;
            set => __ProxyValue.RowHeaderTemplateSelector = value;
        }

        public static System.Windows.ComponentResourceKey FocusBorderBrushKey
        {
            get => __ProxyValue.FocusBorderBrushKey;
        }

        public static System.Windows.Data.IValueConverter HeadersVisibilityConverter
        {
            get => __ProxyValue.HeadersVisibilityConverter;
        }

        public static System.Windows.Data.IValueConverter RowDetailsScrollingConverter
        {
            get => __ProxyValue.RowDetailsScrollingConverter;
        }

        public System.Windows.Controls.ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get => __ProxyValue.HorizontalScrollBarVisibility;
            set => __ProxyValue.HorizontalScrollBarVisibility = value;
        }

        public System.Windows.Controls.ScrollBarVisibility VerticalScrollBarVisibility
        {
            get => __ProxyValue.VerticalScrollBarVisibility;
            set => __ProxyValue.VerticalScrollBarVisibility = value;
        }

        public static System.Windows.Input.RoutedUICommand DeleteCommand
        {
            get => __ProxyValue.DeleteCommand;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
            set => __ProxyValue.IsReadOnly = value;
        }

        public System.Object CurrentItem
        {
            get => __ProxyValue.CurrentItem;
            set => __ProxyValue.CurrentItem = value;
        }

        public System.Windows.Controls.DataGridColumn CurrentColumn
        {
            get => __ProxyValue.CurrentColumn;
            set => __ProxyValue.CurrentColumn = value;
        }

        public System.Windows.Controls.DataGridCellInfo CurrentCell
        {
            get => __ProxyValue.CurrentCell;
            set => __ProxyValue.CurrentCell = value;
        }

        public System.Boolean CanUserAddRows
        {
            get => __ProxyValue.CanUserAddRows;
            set => __ProxyValue.CanUserAddRows = value;
        }

        public System.Boolean CanUserDeleteRows
        {
            get => __ProxyValue.CanUserDeleteRows;
            set => __ProxyValue.CanUserDeleteRows = value;
        }

        public System.Windows.Controls.DataGridRowDetailsVisibilityMode RowDetailsVisibilityMode
        {
            get => __ProxyValue.RowDetailsVisibilityMode;
            set => __ProxyValue.RowDetailsVisibilityMode = value;
        }

        public System.Boolean AreRowDetailsFrozen
        {
            get => __ProxyValue.AreRowDetailsFrozen;
            set => __ProxyValue.AreRowDetailsFrozen = value;
        }

        public System.Windows.DataTemplate RowDetailsTemplate
        {
            get => __ProxyValue.RowDetailsTemplate;
            set => __ProxyValue.RowDetailsTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector RowDetailsTemplateSelector
        {
            get => __ProxyValue.RowDetailsTemplateSelector;
            set => __ProxyValue.RowDetailsTemplateSelector = value;
        }

        public System.Boolean CanUserResizeRows
        {
            get => __ProxyValue.CanUserResizeRows;
            set => __ProxyValue.CanUserResizeRows = value;
        }

        public System.Windows.Thickness NewItemMargin
        {
            get => __ProxyValue.NewItemMargin;
        }

        public System.Collections.Generic.IList<System.Windows.Controls.DataGridCellInfo> SelectedCells
        {
            get => __ProxyValue.SelectedCells;
        }

        public static System.Windows.Input.RoutedUICommand SelectAllCommand
        {
            get => __ProxyValue.SelectAllCommand;
        }

        public System.Windows.Controls.DataGridSelectionMode SelectionMode
        {
            get => __ProxyValue.SelectionMode;
            set => __ProxyValue.SelectionMode = value;
        }

        public System.Windows.Controls.DataGridSelectionUnit SelectionUnit
        {
            get => __ProxyValue.SelectionUnit;
            set => __ProxyValue.SelectionUnit = value;
        }

        public System.Boolean CanUserSortColumns
        {
            get => __ProxyValue.CanUserSortColumns;
            set => __ProxyValue.CanUserSortColumns = value;
        }

        public System.Boolean AutoGenerateColumns
        {
            get => __ProxyValue.AutoGenerateColumns;
            set => __ProxyValue.AutoGenerateColumns = value;
        }

        public System.Int32 FrozenColumnCount
        {
            get => __ProxyValue.FrozenColumnCount;
            set => __ProxyValue.FrozenColumnCount = value;
        }

        public System.Double NonFrozenColumnsViewportHorizontalOffset
        {
            get => __ProxyValue.NonFrozenColumnsViewportHorizontalOffset;
        }

        public System.Boolean EnableRowVirtualization
        {
            get => __ProxyValue.EnableRowVirtualization;
            set => __ProxyValue.EnableRowVirtualization = value;
        }

        public System.Boolean EnableColumnVirtualization
        {
            get => __ProxyValue.EnableColumnVirtualization;
            set => __ProxyValue.EnableColumnVirtualization = value;
        }

        public System.Boolean CanUserReorderColumns
        {
            get => __ProxyValue.CanUserReorderColumns;
            set => __ProxyValue.CanUserReorderColumns = value;
        }

        public System.Windows.Style DragIndicatorStyle
        {
            get => __ProxyValue.DragIndicatorStyle;
            set => __ProxyValue.DragIndicatorStyle = value;
        }

        public System.Windows.Style DropLocationIndicatorStyle
        {
            get => __ProxyValue.DropLocationIndicatorStyle;
            set => __ProxyValue.DropLocationIndicatorStyle = value;
        }

        public System.Windows.Controls.DataGridClipboardCopyMode ClipboardCopyMode
        {
            get => __ProxyValue.ClipboardCopyMode;
            set => __ProxyValue.ClipboardCopyMode = value;
        }

        public System.Double CellsPanelHorizontalOffset
        {
            get => __ProxyValue.CellsPanelHorizontalOffset;
        }

        public System.Collections.IList SelectedItems
        {
            get => __ProxyValue.SelectedItems;
        }

        public System.Nullable<System.Boolean> IsSynchronizedWithCurrentItem
        {
            get => __ProxyValue.IsSynchronizedWithCurrentItem;
            set => __ProxyValue.IsSynchronizedWithCurrentItem = value;
        }

        public System.Int32 SelectedIndex
        {
            get => __ProxyValue.SelectedIndex;
            set => __ProxyValue.SelectedIndex = value;
        }

        public System.Object SelectedItem
        {
            get => __ProxyValue.SelectedItem;
            set => __ProxyValue.SelectedItem = value;
        }

        public System.Object SelectedValue
        {
            get => __ProxyValue.SelectedValue;
            set => __ProxyValue.SelectedValue = value;
        }

        public System.String SelectedValuePath
        {
            get => __ProxyValue.SelectedValuePath;
            set => __ProxyValue.SelectedValuePath = value;
        }

        public System.Windows.Controls.ItemCollection Items
        {
            get => __ProxyValue.Items;
        }

        public System.Collections.IEnumerable ItemsSource
        {
            get => __ProxyValue.ItemsSource;
            set => __ProxyValue.ItemsSource = value;
        }

        public System.Windows.Controls.ItemContainerGenerator ItemContainerGenerator
        {
            get => __ProxyValue.ItemContainerGenerator;
        }

        public System.Boolean HasItems
        {
            get => __ProxyValue.HasItems;
        }

        public System.String DisplayMemberPath
        {
            get => __ProxyValue.DisplayMemberPath;
            set => __ProxyValue.DisplayMemberPath = value;
        }

        public System.Windows.DataTemplate ItemTemplate
        {
            get => __ProxyValue.ItemTemplate;
            set => __ProxyValue.ItemTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector ItemTemplateSelector
        {
            get => __ProxyValue.ItemTemplateSelector;
            set => __ProxyValue.ItemTemplateSelector = value;
        }

        public System.String ItemStringFormat
        {
            get => __ProxyValue.ItemStringFormat;
            set => __ProxyValue.ItemStringFormat = value;
        }

        public System.Windows.Data.BindingGroup ItemBindingGroup
        {
            get => __ProxyValue.ItemBindingGroup;
            set => __ProxyValue.ItemBindingGroup = value;
        }

        public System.Windows.Style ItemContainerStyle
        {
            get => __ProxyValue.ItemContainerStyle;
            set => __ProxyValue.ItemContainerStyle = value;
        }

        public System.Windows.Controls.StyleSelector ItemContainerStyleSelector
        {
            get => __ProxyValue.ItemContainerStyleSelector;
            set => __ProxyValue.ItemContainerStyleSelector = value;
        }

        public System.Windows.Controls.ItemsPanelTemplate ItemsPanel
        {
            get => __ProxyValue.ItemsPanel;
            set => __ProxyValue.ItemsPanel = value;
        }

        public System.Boolean IsGrouping
        {
            get => __ProxyValue.IsGrouping;
        }

        public System.Collections.ObjectModel.ObservableCollection<System.Windows.Controls.GroupStyle> GroupStyle
        {
            get => __ProxyValue.GroupStyle;
        }

        public System.Windows.Controls.GroupStyleSelector GroupStyleSelector
        {
            get => __ProxyValue.GroupStyleSelector;
            set => __ProxyValue.GroupStyleSelector = value;
        }

        public System.Int32 AlternationCount
        {
            get => __ProxyValue.AlternationCount;
            set => __ProxyValue.AlternationCount = value;
        }

        public System.Boolean IsTextSearchEnabled
        {
            get => __ProxyValue.IsTextSearchEnabled;
            set => __ProxyValue.IsTextSearchEnabled = value;
        }

        public System.Boolean IsTextSearchCaseSensitive
        {
            get => __ProxyValue.IsTextSearchCaseSensitive;
            set => __ProxyValue.IsTextSearchCaseSensitive = value;
        }

        public System.Windows.Media.Brush BorderBrush
        {
            get => __ProxyValue.BorderBrush;
            set => __ProxyValue.BorderBrush = value;
        }

        public System.Windows.Thickness BorderThickness
        {
            get => __ProxyValue.BorderThickness;
            set => __ProxyValue.BorderThickness = value;
        }

        public System.Windows.Media.Brush Background
        {
            get => __ProxyValue.Background;
            set => __ProxyValue.Background = value;
        }

        public System.Windows.Media.Brush Foreground
        {
            get => __ProxyValue.Foreground;
            set => __ProxyValue.Foreground = value;
        }

        public System.Windows.Media.FontFamily FontFamily
        {
            get => __ProxyValue.FontFamily;
            set => __ProxyValue.FontFamily = value;
        }

        public System.Double FontSize
        {
            get => __ProxyValue.FontSize;
            set => __ProxyValue.FontSize = value;
        }

        public System.Windows.FontStretch FontStretch
        {
            get => __ProxyValue.FontStretch;
            set => __ProxyValue.FontStretch = value;
        }

        public System.Windows.FontStyle FontStyle
        {
            get => __ProxyValue.FontStyle;
            set => __ProxyValue.FontStyle = value;
        }

        public System.Windows.FontWeight FontWeight
        {
            get => __ProxyValue.FontWeight;
            set => __ProxyValue.FontWeight = value;
        }

        public System.Windows.HorizontalAlignment HorizontalContentAlignment
        {
            get => __ProxyValue.HorizontalContentAlignment;
            set => __ProxyValue.HorizontalContentAlignment = value;
        }

        public System.Windows.VerticalAlignment VerticalContentAlignment
        {
            get => __ProxyValue.VerticalContentAlignment;
            set => __ProxyValue.VerticalContentAlignment = value;
        }

        public System.Int32 TabIndex
        {
            get => __ProxyValue.TabIndex;
            set => __ProxyValue.TabIndex = value;
        }

        public System.Boolean IsTabStop
        {
            get => __ProxyValue.IsTabStop;
            set => __ProxyValue.IsTabStop = value;
        }

        public System.Windows.Thickness Padding
        {
            get => __ProxyValue.Padding;
            set => __ProxyValue.Padding = value;
        }

        public System.Windows.Controls.ControlTemplate Template
        {
            get => __ProxyValue.Template;
            set => __ProxyValue.Template = value;
        }

        public System.Windows.Style Style
        {
            get => __ProxyValue.Style;
            set => __ProxyValue.Style = value;
        }

        public System.Boolean OverridesDefaultStyle
        {
            get => __ProxyValue.OverridesDefaultStyle;
            set => __ProxyValue.OverridesDefaultStyle = value;
        }

        public System.Boolean UseLayoutRounding
        {
            get => __ProxyValue.UseLayoutRounding;
            set => __ProxyValue.UseLayoutRounding = value;
        }

        public System.Windows.TriggerCollection Triggers
        {
            get => __ProxyValue.Triggers;
        }

        public System.Windows.DependencyObject TemplatedParent
        {
            get => __ProxyValue.TemplatedParent;
        }

        public System.Windows.ResourceDictionary Resources
        {
            get => __ProxyValue.Resources;
            set => __ProxyValue.Resources = value;
        }

        public System.Object DataContext
        {
            get => __ProxyValue.DataContext;
            set => __ProxyValue.DataContext = value;
        }

        public System.Windows.Data.BindingGroup BindingGroup
        {
            get => __ProxyValue.BindingGroup;
            set => __ProxyValue.BindingGroup = value;
        }

        public System.Windows.Markup.XmlLanguage Language
        {
            get => __ProxyValue.Language;
            set => __ProxyValue.Language = value;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Object Tag
        {
            get => __ProxyValue.Tag;
            set => __ProxyValue.Tag = value;
        }

        public System.Windows.Input.InputScope InputScope
        {
            get => __ProxyValue.InputScope;
            set => __ProxyValue.InputScope = value;
        }

        public System.Double ActualWidth
        {
            get => __ProxyValue.ActualWidth;
        }

        public System.Double ActualHeight
        {
            get => __ProxyValue.ActualHeight;
        }

        public System.Windows.Media.Transform LayoutTransform
        {
            get => __ProxyValue.LayoutTransform;
            set => __ProxyValue.LayoutTransform = value;
        }

        public System.Double Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Double MinWidth
        {
            get => __ProxyValue.MinWidth;
            set => __ProxyValue.MinWidth = value;
        }

        public System.Double MaxWidth
        {
            get => __ProxyValue.MaxWidth;
            set => __ProxyValue.MaxWidth = value;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
            set => __ProxyValue.Height = value;
        }

        public System.Double MinHeight
        {
            get => __ProxyValue.MinHeight;
            set => __ProxyValue.MinHeight = value;
        }

        public System.Double MaxHeight
        {
            get => __ProxyValue.MaxHeight;
            set => __ProxyValue.MaxHeight = value;
        }

        public System.Windows.FlowDirection FlowDirection
        {
            get => __ProxyValue.FlowDirection;
            set => __ProxyValue.FlowDirection = value;
        }

        public System.Windows.Thickness Margin
        {
            get => __ProxyValue.Margin;
            set => __ProxyValue.Margin = value;
        }

        public System.Windows.HorizontalAlignment HorizontalAlignment
        {
            get => __ProxyValue.HorizontalAlignment;
            set => __ProxyValue.HorizontalAlignment = value;
        }

        public System.Windows.VerticalAlignment VerticalAlignment
        {
            get => __ProxyValue.VerticalAlignment;
            set => __ProxyValue.VerticalAlignment = value;
        }

        public System.Windows.Style FocusVisualStyle
        {
            get => __ProxyValue.FocusVisualStyle;
            set => __ProxyValue.FocusVisualStyle = value;
        }

        public System.Windows.Input.Cursor Cursor
        {
            get => __ProxyValue.Cursor;
            set => __ProxyValue.Cursor = value;
        }

        public System.Boolean ForceCursor
        {
            get => __ProxyValue.ForceCursor;
            set => __ProxyValue.ForceCursor = value;
        }

        public System.Boolean IsInitialized
        {
            get => __ProxyValue.IsInitialized;
        }

        public System.Boolean IsLoaded
        {
            get => __ProxyValue.IsLoaded;
        }

        public System.Object ToolTip
        {
            get => __ProxyValue.ToolTip;
            set => __ProxyValue.ToolTip = value;
        }

        public System.Windows.Controls.ContextMenu ContextMenu
        {
            get => __ProxyValue.ContextMenu;
            set => __ProxyValue.ContextMenu = value;
        }

        public System.Windows.DependencyObject Parent
        {
            get => __ProxyValue.Parent;
        }

        public System.Boolean HasAnimatedProperties
        {
            get => __ProxyValue.HasAnimatedProperties;
        }

        public System.Windows.Input.InputBindingCollection InputBindings
        {
            get => __ProxyValue.InputBindings;
        }

        public System.Windows.Input.CommandBindingCollection CommandBindings
        {
            get => __ProxyValue.CommandBindings;
        }

        public System.Boolean AllowDrop
        {
            get => __ProxyValue.AllowDrop;
            set => __ProxyValue.AllowDrop = value;
        }

        public System.Windows.Size DesiredSize
        {
            get => __ProxyValue.DesiredSize;
        }

        public System.Boolean IsMeasureValid
        {
            get => __ProxyValue.IsMeasureValid;
        }

        public System.Boolean IsArrangeValid
        {
            get => __ProxyValue.IsArrangeValid;
        }

        public System.Windows.Size RenderSize
        {
            get => __ProxyValue.RenderSize;
            set => __ProxyValue.RenderSize = value;
        }

        public System.Windows.Media.Transform RenderTransform
        {
            get => __ProxyValue.RenderTransform;
            set => __ProxyValue.RenderTransform = value;
        }

        public System.Windows.Point RenderTransformOrigin
        {
            get => __ProxyValue.RenderTransformOrigin;
            set => __ProxyValue.RenderTransformOrigin = value;
        }

        public System.Boolean IsMouseDirectlyOver
        {
            get => __ProxyValue.IsMouseDirectlyOver;
        }

        public System.Boolean IsMouseOver
        {
            get => __ProxyValue.IsMouseOver;
        }

        public System.Boolean IsStylusOver
        {
            get => __ProxyValue.IsStylusOver;
        }

        public System.Boolean IsKeyboardFocusWithin
        {
            get => __ProxyValue.IsKeyboardFocusWithin;
        }

        public System.Boolean IsMouseCaptured
        {
            get => __ProxyValue.IsMouseCaptured;
        }

        public System.Boolean IsMouseCaptureWithin
        {
            get => __ProxyValue.IsMouseCaptureWithin;
        }

        public System.Boolean IsStylusDirectlyOver
        {
            get => __ProxyValue.IsStylusDirectlyOver;
        }

        public System.Boolean IsStylusCaptured
        {
            get => __ProxyValue.IsStylusCaptured;
        }

        public System.Boolean IsStylusCaptureWithin
        {
            get => __ProxyValue.IsStylusCaptureWithin;
        }

        public System.Boolean IsKeyboardFocused
        {
            get => __ProxyValue.IsKeyboardFocused;
        }

        public System.Boolean IsInputMethodEnabled
        {
            get => __ProxyValue.IsInputMethodEnabled;
        }

        public System.Double Opacity
        {
            get => __ProxyValue.Opacity;
            set => __ProxyValue.Opacity = value;
        }

        public System.Windows.Media.Brush OpacityMask
        {
            get => __ProxyValue.OpacityMask;
            set => __ProxyValue.OpacityMask = value;
        }

        public System.Windows.Media.Effects.BitmapEffect BitmapEffect
        {
            get => __ProxyValue.BitmapEffect;
            set => __ProxyValue.BitmapEffect = value;
        }

        public System.Windows.Media.Effects.Effect Effect
        {
            get => __ProxyValue.Effect;
            set => __ProxyValue.Effect = value;
        }

        public System.Windows.Media.Effects.BitmapEffectInput BitmapEffectInput
        {
            get => __ProxyValue.BitmapEffectInput;
            set => __ProxyValue.BitmapEffectInput = value;
        }

        public System.Windows.Media.CacheMode CacheMode
        {
            get => __ProxyValue.CacheMode;
            set => __ProxyValue.CacheMode = value;
        }

        public System.String Uid
        {
            get => __ProxyValue.Uid;
            set => __ProxyValue.Uid = value;
        }

        public System.Windows.Visibility Visibility
        {
            get => __ProxyValue.Visibility;
            set => __ProxyValue.Visibility = value;
        }

        public System.Boolean ClipToBounds
        {
            get => __ProxyValue.ClipToBounds;
            set => __ProxyValue.ClipToBounds = value;
        }

        public System.Windows.Media.Geometry Clip
        {
            get => __ProxyValue.Clip;
            set => __ProxyValue.Clip = value;
        }

        public System.Boolean SnapsToDevicePixels
        {
            get => __ProxyValue.SnapsToDevicePixels;
            set => __ProxyValue.SnapsToDevicePixels = value;
        }

        public System.Boolean IsFocused
        {
            get => __ProxyValue.IsFocused;
        }

        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
            set => __ProxyValue.IsEnabled = value;
        }

        public System.Boolean IsHitTestVisible
        {
            get => __ProxyValue.IsHitTestVisible;
            set => __ProxyValue.IsHitTestVisible = value;
        }

        public System.Boolean IsVisible
        {
            get => __ProxyValue.IsVisible;
        }

        public System.Boolean Focusable
        {
            get => __ProxyValue.Focusable;
            set => __ProxyValue.Focusable = value;
        }

        public System.Int32 PersistId
        {
            get => __ProxyValue.PersistId;
        }

        public System.Boolean IsManipulationEnabled
        {
            get => __ProxyValue.IsManipulationEnabled;
            set => __ProxyValue.IsManipulationEnabled = value;
        }

        public System.Boolean AreAnyTouchesOver
        {
            get => __ProxyValue.AreAnyTouchesOver;
        }

        public System.Boolean AreAnyTouchesDirectlyOver
        {
            get => __ProxyValue.AreAnyTouchesDirectlyOver;
        }

        public System.Boolean AreAnyTouchesCapturedWithin
        {
            get => __ProxyValue.AreAnyTouchesCapturedWithin;
        }

        public System.Boolean AreAnyTouchesCaptured
        {
            get => __ProxyValue.AreAnyTouchesCaptured;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesCaptured
        {
            get => __ProxyValue.TouchesCaptured;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesCapturedWithin
        {
            get => __ProxyValue.TouchesCapturedWithin;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesOver
        {
            get => __ProxyValue.TouchesOver;
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Input.TouchDevice> TouchesDirectlyOver
        {
            get => __ProxyValue.TouchesDirectlyOver;
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

        public DataGrid(): base()
        {
        }

        public void add_CopyingRowClipboardContent(System.EventHandler<System.Windows.Controls.DataGridRowClipboardEventArgs> value) => __ProxyValue.add_CopyingRowClipboardContent(@value);
        public void remove_CopyingRowClipboardContent(System.EventHandler<System.Windows.Controls.DataGridRowClipboardEventArgs> value) => __ProxyValue.remove_CopyingRowClipboardContent(@value);
        public void add_Sorting(System.Windows.Controls.DataGridSortingEventHandler value) => __ProxyValue.add_Sorting(@value);
        public void remove_Sorting(System.Windows.Controls.DataGridSortingEventHandler value) => __ProxyValue.remove_Sorting(@value);
        public void add_AutoGeneratedColumns(System.EventHandler value) => __ProxyValue.add_AutoGeneratedColumns(@value);
        public void remove_AutoGeneratedColumns(System.EventHandler value) => __ProxyValue.remove_AutoGeneratedColumns(@value);
        public void add_AutoGeneratingColumn(System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs> value) => __ProxyValue.add_AutoGeneratingColumn(@value);
        public void remove_AutoGeneratingColumn(System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs> value) => __ProxyValue.remove_AutoGeneratingColumn(@value);
        public static System.Collections.ObjectModel.Collection<System.Windows.Controls.DataGridColumn> GenerateColumns(System.ComponentModel.IItemProperties itemProperties) => Windows.UI.Xaml.Controls.DataGrid.GenerateColumns(@itemProperties);
        public void OnApplyTemplate() => __ProxyValue.OnApplyTemplate();
        public void add_ColumnReordering(System.EventHandler<System.Windows.Controls.DataGridColumnReorderingEventArgs> value) => __ProxyValue.add_ColumnReordering(@value);
        public void remove_ColumnReordering(System.EventHandler<System.Windows.Controls.DataGridColumnReorderingEventArgs> value) => __ProxyValue.remove_ColumnReordering(@value);
        public void add_ColumnHeaderDragStarted(System.EventHandler<System.Windows.Controls.Primitives.DragStartedEventArgs> value) => __ProxyValue.add_ColumnHeaderDragStarted(@value);
        public void remove_ColumnHeaderDragStarted(System.EventHandler<System.Windows.Controls.Primitives.DragStartedEventArgs> value) => __ProxyValue.remove_ColumnHeaderDragStarted(@value);
        public void add_ColumnHeaderDragDelta(System.EventHandler<System.Windows.Controls.Primitives.DragDeltaEventArgs> value) => __ProxyValue.add_ColumnHeaderDragDelta(@value);
        public void remove_ColumnHeaderDragDelta(System.EventHandler<System.Windows.Controls.Primitives.DragDeltaEventArgs> value) => __ProxyValue.remove_ColumnHeaderDragDelta(@value);
        public void add_ColumnHeaderDragCompleted(System.EventHandler<System.Windows.Controls.Primitives.DragCompletedEventArgs> value) => __ProxyValue.add_ColumnHeaderDragCompleted(@value);
        public void remove_ColumnHeaderDragCompleted(System.EventHandler<System.Windows.Controls.Primitives.DragCompletedEventArgs> value) => __ProxyValue.remove_ColumnHeaderDragCompleted(@value);
        public void add_ColumnReordered(System.EventHandler<System.Windows.Controls.DataGridColumnEventArgs> value) => __ProxyValue.add_ColumnReordered(@value);
        public void remove_ColumnReordered(System.EventHandler<System.Windows.Controls.DataGridColumnEventArgs> value) => __ProxyValue.remove_ColumnReordered(@value);
        public void add_RowDetailsVisibilityChanged(System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs> value) => __ProxyValue.add_RowDetailsVisibilityChanged(@value);
        public void remove_RowDetailsVisibilityChanged(System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs> value) => __ProxyValue.remove_RowDetailsVisibilityChanged(@value);
        public void add_SelectedCellsChanged(System.Windows.Controls.SelectedCellsChangedEventHandler value) => __ProxyValue.add_SelectedCellsChanged(@value);
        public void remove_SelectedCellsChanged(System.Windows.Controls.SelectedCellsChangedEventHandler value) => __ProxyValue.remove_SelectedCellsChanged(@value);
        public void SelectAllCells() => __ProxyValue.SelectAllCells();
        public void UnselectAllCells() => __ProxyValue.UnselectAllCells();
        public void add_CurrentCellChanged(System.EventHandler<System.EventArgs> value) => __ProxyValue.add_CurrentCellChanged(@value);
        public void remove_CurrentCellChanged(System.EventHandler<System.EventArgs> value) => __ProxyValue.remove_CurrentCellChanged(@value);
        public void add_BeginningEdit(System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs> value) => __ProxyValue.add_BeginningEdit(@value);
        public void remove_BeginningEdit(System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs> value) => __ProxyValue.remove_BeginningEdit(@value);
        public void add_PreparingCellForEdit(System.EventHandler<System.Windows.Controls.DataGridPreparingCellForEditEventArgs> value) => __ProxyValue.add_PreparingCellForEdit(@value);
        public void remove_PreparingCellForEdit(System.EventHandler<System.Windows.Controls.DataGridPreparingCellForEditEventArgs> value) => __ProxyValue.remove_PreparingCellForEdit(@value);
        public System.Boolean BeginEdit() => __ProxyValue.BeginEdit();
        public System.Boolean BeginEdit(System.Windows.RoutedEventArgs editingEventArgs) => __ProxyValue.BeginEdit(@editingEventArgs);
        public System.Boolean CancelEdit() => __ProxyValue.CancelEdit();
        public System.Boolean CancelEdit(System.Windows.Controls.DataGridEditingUnit editingUnit) => __ProxyValue.CancelEdit(@editingUnit);
        public System.Boolean CommitEdit() => __ProxyValue.CommitEdit();
        public System.Boolean CommitEdit(System.Windows.Controls.DataGridEditingUnit editingUnit, System.Boolean exitEditingMode) => __ProxyValue.CommitEdit(@editingUnit, @exitEditingMode);
        public void add_AddingNewItem(System.EventHandler<System.Windows.Controls.AddingNewItemEventArgs> value) => __ProxyValue.add_AddingNewItem(@value);
        public void remove_AddingNewItem(System.EventHandler<System.Windows.Controls.AddingNewItemEventArgs> value) => __ProxyValue.remove_AddingNewItem(@value);
        public void add_InitializingNewItem(System.Windows.Controls.InitializingNewItemEventHandler value) => __ProxyValue.add_InitializingNewItem(@value);
        public void remove_InitializingNewItem(System.Windows.Controls.InitializingNewItemEventHandler value) => __ProxyValue.remove_InitializingNewItem(@value);
        public void add_LoadingRowDetails(System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs> value) => __ProxyValue.add_LoadingRowDetails(@value);
        public void remove_LoadingRowDetails(System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs> value) => __ProxyValue.remove_LoadingRowDetails(@value);
        public void add_UnloadingRowDetails(System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs> value) => __ProxyValue.add_UnloadingRowDetails(@value);
        public void remove_UnloadingRowDetails(System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs> value) => __ProxyValue.remove_UnloadingRowDetails(@value);
        public void SetDetailsVisibilityForItem(System.Object item, System.Windows.Visibility detailsVisibility) => __ProxyValue.SetDetailsVisibilityForItem(@item, @detailsVisibility);
        public System.Windows.Visibility GetDetailsVisibilityForItem(System.Object item) => __ProxyValue.GetDetailsVisibilityForItem(@item);
        public void ClearDetailsVisibilityForItem(System.Object item) => __ProxyValue.ClearDetailsVisibilityForItem(@item);
        public void ScrollIntoView(System.Object item) => __ProxyValue.ScrollIntoView(@item);
        public void ScrollIntoView(System.Object item, System.Windows.Controls.DataGridColumn column) => __ProxyValue.ScrollIntoView(@item, @column);
        public void add_RowEditEnding(System.EventHandler<System.Windows.Controls.DataGridRowEditEndingEventArgs> value) => __ProxyValue.add_RowEditEnding(@value);
        public void remove_RowEditEnding(System.EventHandler<System.Windows.Controls.DataGridRowEditEndingEventArgs> value) => __ProxyValue.remove_RowEditEnding(@value);
        public void add_CellEditEnding(System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs> value) => __ProxyValue.add_CellEditEnding(@value);
        public void remove_CellEditEnding(System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs> value) => __ProxyValue.remove_CellEditEnding(@value);
        public System.Windows.Controls.DataGridColumn ColumnFromDisplayIndex(System.Int32 displayIndex) => __ProxyValue.ColumnFromDisplayIndex(@displayIndex);
        public void add_ColumnDisplayIndexChanged(System.EventHandler<System.Windows.Controls.DataGridColumnEventArgs> value) => __ProxyValue.add_ColumnDisplayIndexChanged(@value);
        public void remove_ColumnDisplayIndexChanged(System.EventHandler<System.Windows.Controls.DataGridColumnEventArgs> value) => __ProxyValue.remove_ColumnDisplayIndexChanged(@value);
        public void add_LoadingRow(System.EventHandler<System.Windows.Controls.DataGridRowEventArgs> value) => __ProxyValue.add_LoadingRow(@value);
        public void remove_LoadingRow(System.EventHandler<System.Windows.Controls.DataGridRowEventArgs> value) => __ProxyValue.remove_LoadingRow(@value);
        public void add_UnloadingRow(System.EventHandler<System.Windows.Controls.DataGridRowEventArgs> value) => __ProxyValue.add_UnloadingRow(@value);
        public void remove_UnloadingRow(System.EventHandler<System.Windows.Controls.DataGridRowEventArgs> value) => __ProxyValue.remove_UnloadingRow(@value);
        public void SelectAll() => __ProxyValue.SelectAll();
        public void UnselectAll() => __ProxyValue.UnselectAll();
        public void add_SelectionChanged(System.Windows.Controls.SelectionChangedEventHandler value) => __ProxyValue.add_SelectionChanged(@value);
        public void remove_SelectionChanged(System.Windows.Controls.SelectionChangedEventHandler value) => __ProxyValue.remove_SelectionChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public void BeginInit() => __ProxyValue.BeginInit();
        public void EndInit() => __ProxyValue.EndInit();
        public System.Boolean IsItemItsOwnContainer(System.Object item) => __ProxyValue.IsItemItsOwnContainer(@item);
        public System.Boolean ShouldSerializeItems() => __ProxyValue.ShouldSerializeItems();
        public System.Boolean ShouldSerializeGroupStyle() => __ProxyValue.ShouldSerializeGroupStyle();
        public System.Windows.DependencyObject ContainerFromElement(System.Windows.DependencyObject element) => __ProxyValue.ContainerFromElement(@element);
        public void add_PreviewMouseDoubleClick(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseDoubleClick(@value);
        public void remove_PreviewMouseDoubleClick(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseDoubleClick(@value);
        public void add_MouseDoubleClick(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseDoubleClick(@value);
        public void remove_MouseDoubleClick(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseDoubleClick(@value);
        public void RegisterName(System.String name, System.Object scopedElement) => __ProxyValue.RegisterName(@name, @scopedElement);
        public void UnregisterName(System.String name) => __ProxyValue.UnregisterName(@name);
        public System.Object FindName(System.String name) => __ProxyValue.FindName(@name);
        public void UpdateDefaultStyle() => __ProxyValue.UpdateDefaultStyle();
        public System.Boolean MoveFocus(System.Windows.Input.TraversalRequest request) => __ProxyValue.MoveFocus(@request);
        public System.Windows.DependencyObject PredictFocus(System.Windows.Input.FocusNavigationDirection direction) => __ProxyValue.PredictFocus(@direction);
        public void add_Initialized(System.EventHandler value) => __ProxyValue.add_Initialized(@value);
        public void remove_Initialized(System.EventHandler value) => __ProxyValue.remove_Initialized(@value);
        public void add_Loaded(System.Windows.RoutedEventHandler value) => __ProxyValue.add_Loaded(@value);
        public void remove_Loaded(System.Windows.RoutedEventHandler value) => __ProxyValue.remove_Loaded(@value);
        public void add_Unloaded(System.Windows.RoutedEventHandler value) => __ProxyValue.add_Unloaded(@value);
        public void remove_Unloaded(System.Windows.RoutedEventHandler value) => __ProxyValue.remove_Unloaded(@value);
        public void add_ToolTipOpening(System.Windows.Controls.ToolTipEventHandler value) => __ProxyValue.add_ToolTipOpening(@value);
        public void remove_ToolTipOpening(System.Windows.Controls.ToolTipEventHandler value) => __ProxyValue.remove_ToolTipOpening(@value);
        public void add_ToolTipClosing(System.Windows.Controls.ToolTipEventHandler value) => __ProxyValue.add_ToolTipClosing(@value);
        public void remove_ToolTipClosing(System.Windows.Controls.ToolTipEventHandler value) => __ProxyValue.remove_ToolTipClosing(@value);
        public void add_ContextMenuOpening(System.Windows.Controls.ContextMenuEventHandler value) => __ProxyValue.add_ContextMenuOpening(@value);
        public void remove_ContextMenuOpening(System.Windows.Controls.ContextMenuEventHandler value) => __ProxyValue.remove_ContextMenuOpening(@value);
        public void add_ContextMenuClosing(System.Windows.Controls.ContextMenuEventHandler value) => __ProxyValue.add_ContextMenuClosing(@value);
        public void remove_ContextMenuClosing(System.Windows.Controls.ContextMenuEventHandler value) => __ProxyValue.remove_ContextMenuClosing(@value);
        public void remove_DataContextChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_DataContextChanged(@value);
        public System.Windows.Data.BindingExpression GetBindingExpression(System.Windows.DependencyProperty dp) => __ProxyValue.GetBindingExpression(@dp);
        public System.Windows.Data.BindingExpressionBase SetBinding(System.Windows.DependencyProperty dp, System.Windows.Data.BindingBase binding) => __ProxyValue.SetBinding(@dp, @binding);
        public System.Windows.Data.BindingExpression SetBinding(System.Windows.DependencyProperty dp, System.String path) => __ProxyValue.SetBinding(@dp, @path);
        public void add_RequestBringIntoView(System.Windows.RequestBringIntoViewEventHandler value) => __ProxyValue.add_RequestBringIntoView(@value);
        public void remove_RequestBringIntoView(System.Windows.RequestBringIntoViewEventHandler value) => __ProxyValue.remove_RequestBringIntoView(@value);
        public void BringIntoView() => __ProxyValue.BringIntoView();
        public void BringIntoView(System.Windows.Rect targetRectangle) => __ProxyValue.BringIntoView(@targetRectangle);
        public void add_SizeChanged(System.Windows.SizeChangedEventHandler value) => __ProxyValue.add_SizeChanged(@value);
        public void remove_SizeChanged(System.Windows.SizeChangedEventHandler value) => __ProxyValue.remove_SizeChanged(@value);
        public System.Boolean ShouldSerializeStyle() => __ProxyValue.ShouldSerializeStyle();
        public System.Boolean ApplyTemplate() => __ProxyValue.ApplyTemplate();
        public void BeginStoryboard(System.Windows.Media.Animation.Storyboard storyboard) => __ProxyValue.BeginStoryboard(@storyboard);
        public void BeginStoryboard(System.Windows.Media.Animation.Storyboard storyboard, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.BeginStoryboard(@storyboard, @handoffBehavior);
        public void BeginStoryboard(System.Windows.Media.Animation.Storyboard storyboard, System.Windows.Media.Animation.HandoffBehavior handoffBehavior, System.Boolean isControllable) => __ProxyValue.BeginStoryboard(@storyboard, @handoffBehavior, @isControllable);
        public System.Boolean ShouldSerializeTriggers() => __ProxyValue.ShouldSerializeTriggers();
        public System.Boolean ShouldSerializeResources() => __ProxyValue.ShouldSerializeResources();
        public System.Object FindResource(System.Object resourceKey) => __ProxyValue.FindResource(@resourceKey);
        public System.Object TryFindResource(System.Object resourceKey) => __ProxyValue.TryFindResource(@resourceKey);
        public void SetResourceReference(System.Windows.DependencyProperty dp, System.Object name) => __ProxyValue.SetResourceReference(@dp, @name);
        public void add_TargetUpdated(System.EventHandler<System.Windows.Data.DataTransferEventArgs> value) => __ProxyValue.add_TargetUpdated(@value);
        public void remove_TargetUpdated(System.EventHandler<System.Windows.Data.DataTransferEventArgs> value) => __ProxyValue.remove_TargetUpdated(@value);
        public void add_SourceUpdated(System.EventHandler<System.Windows.Data.DataTransferEventArgs> value) => __ProxyValue.add_SourceUpdated(@value);
        public void remove_SourceUpdated(System.EventHandler<System.Windows.Data.DataTransferEventArgs> value) => __ProxyValue.remove_SourceUpdated(@value);
        public void add_DataContextChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_DataContextChanged(@value);
        public void add_ManipulationStarting(System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs> value) => __ProxyValue.add_ManipulationStarting(@value);
        public void remove_ManipulationStarting(System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs> value) => __ProxyValue.remove_ManipulationStarting(@value);
        public void add_ManipulationStarted(System.EventHandler<System.Windows.Input.ManipulationStartedEventArgs> value) => __ProxyValue.add_ManipulationStarted(@value);
        public void remove_ManipulationStarted(System.EventHandler<System.Windows.Input.ManipulationStartedEventArgs> value) => __ProxyValue.remove_ManipulationStarted(@value);
        public void add_ManipulationDelta(System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs> value) => __ProxyValue.add_ManipulationDelta(@value);
        public void remove_ManipulationDelta(System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs> value) => __ProxyValue.remove_ManipulationDelta(@value);
        public void add_ManipulationInertiaStarting(System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs> value) => __ProxyValue.add_ManipulationInertiaStarting(@value);
        public void remove_ManipulationInertiaStarting(System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs> value) => __ProxyValue.remove_ManipulationInertiaStarting(@value);
        public void add_ManipulationBoundaryFeedback(System.EventHandler<System.Windows.Input.ManipulationBoundaryFeedbackEventArgs> value) => __ProxyValue.add_ManipulationBoundaryFeedback(@value);
        public void remove_ManipulationBoundaryFeedback(System.EventHandler<System.Windows.Input.ManipulationBoundaryFeedbackEventArgs> value) => __ProxyValue.remove_ManipulationBoundaryFeedback(@value);
        public void add_ManipulationCompleted(System.EventHandler<System.Windows.Input.ManipulationCompletedEventArgs> value) => __ProxyValue.add_ManipulationCompleted(@value);
        public void remove_ManipulationCompleted(System.EventHandler<System.Windows.Input.ManipulationCompletedEventArgs> value) => __ProxyValue.remove_ManipulationCompleted(@value);
        public System.Boolean CaptureTouch(System.Windows.Input.TouchDevice touchDevice) => __ProxyValue.CaptureTouch(@touchDevice);
        public System.Boolean ReleaseTouchCapture(System.Windows.Input.TouchDevice touchDevice) => __ProxyValue.ReleaseTouchCapture(@touchDevice);
        public void ReleaseAllTouchCaptures() => __ProxyValue.ReleaseAllTouchCaptures();
        public void add_GotFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.add_GotFocus(@value);
        public void remove_GotFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.remove_GotFocus(@value);
        public void add_LostFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.add_LostFocus(@value);
        public void remove_LostFocus(System.Windows.RoutedEventHandler value) => __ProxyValue.remove_LostFocus(@value);
        public void add_IsEnabledChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsEnabledChanged(@value);
        public void remove_IsEnabledChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsEnabledChanged(@value);
        public void add_IsHitTestVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsHitTestVisibleChanged(@value);
        public void remove_IsHitTestVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsHitTestVisibleChanged(@value);
        public void add_IsVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsVisibleChanged(@value);
        public void remove_IsVisibleChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsVisibleChanged(@value);
        public void add_FocusableChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_FocusableChanged(@value);
        public void remove_FocusableChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_FocusableChanged(@value);
        public void UpdateLayout() => __ProxyValue.UpdateLayout();
        public System.Windows.Point TranslatePoint(System.Windows.Point point, System.Windows.UIElement relativeTo) => __ProxyValue.TranslatePoint(@point, @relativeTo);
        public System.Windows.IInputElement InputHitTest(System.Windows.Point point) => __ProxyValue.InputHitTest(@point);
        public System.Boolean CaptureMouse() => __ProxyValue.CaptureMouse();
        public void ReleaseMouseCapture() => __ProxyValue.ReleaseMouseCapture();
        public System.Boolean CaptureStylus() => __ProxyValue.CaptureStylus();
        public void ReleaseStylusCapture() => __ProxyValue.ReleaseStylusCapture();
        public System.Boolean Focus() => __ProxyValue.Focus();
        public void add_TouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchMove(@value);
        public void remove_TouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchMove(@value);
        public void add_PreviewTouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_PreviewTouchUp(@value);
        public void remove_PreviewTouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_PreviewTouchUp(@value);
        public void add_TouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchUp(@value);
        public void remove_TouchUp(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchUp(@value);
        public void add_GotTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_GotTouchCapture(@value);
        public void remove_GotTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_GotTouchCapture(@value);
        public void add_LostTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_LostTouchCapture(@value);
        public void remove_LostTouchCapture(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_LostTouchCapture(@value);
        public void add_TouchEnter(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchEnter(@value);
        public void remove_TouchEnter(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchEnter(@value);
        public void add_TouchLeave(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchLeave(@value);
        public void remove_TouchLeave(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchLeave(@value);
        public void add_IsMouseDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsMouseDirectlyOverChanged(@value);
        public void remove_IsMouseDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsMouseDirectlyOverChanged(@value);
        public void add_IsKeyboardFocusWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsKeyboardFocusWithinChanged(@value);
        public void remove_IsKeyboardFocusWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsKeyboardFocusWithinChanged(@value);
        public void add_IsMouseCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsMouseCapturedChanged(@value);
        public void remove_IsMouseCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsMouseCapturedChanged(@value);
        public void add_IsMouseCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsMouseCaptureWithinChanged(@value);
        public void remove_IsMouseCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsMouseCaptureWithinChanged(@value);
        public void add_IsStylusDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsStylusDirectlyOverChanged(@value);
        public void remove_IsStylusDirectlyOverChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsStylusDirectlyOverChanged(@value);
        public void add_IsStylusCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsStylusCapturedChanged(@value);
        public void remove_IsStylusCapturedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsStylusCapturedChanged(@value);
        public void add_IsStylusCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsStylusCaptureWithinChanged(@value);
        public void remove_IsStylusCaptureWithinChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsStylusCaptureWithinChanged(@value);
        public void add_IsKeyboardFocusedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.add_IsKeyboardFocusedChanged(@value);
        public void remove_IsKeyboardFocusedChanged(System.Windows.DependencyPropertyChangedEventHandler value) => __ProxyValue.remove_IsKeyboardFocusedChanged(@value);
        public void InvalidateMeasure() => __ProxyValue.InvalidateMeasure();
        public void InvalidateArrange() => __ProxyValue.InvalidateArrange();
        public void InvalidateVisual() => __ProxyValue.InvalidateVisual();
        public void add_LayoutUpdated(System.EventHandler value) => __ProxyValue.add_LayoutUpdated(@value);
        public void remove_LayoutUpdated(System.EventHandler value) => __ProxyValue.remove_LayoutUpdated(@value);
        public void Measure(System.Windows.Size availableSize) => __ProxyValue.Measure(@availableSize);
        public void Arrange(System.Windows.Rect finalRect) => __ProxyValue.Arrange(@finalRect);
        public void add_StylusLeave(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusLeave(@value);
        public void remove_StylusLeave(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusLeave(@value);
        public void add_PreviewStylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusInRange(@value);
        public void remove_PreviewStylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusInRange(@value);
        public void add_StylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusInRange(@value);
        public void remove_StylusInRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusInRange(@value);
        public void add_PreviewStylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusOutOfRange(@value);
        public void remove_PreviewStylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusOutOfRange(@value);
        public void add_StylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusOutOfRange(@value);
        public void remove_StylusOutOfRange(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusOutOfRange(@value);
        public void add_PreviewStylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.add_PreviewStylusSystemGesture(@value);
        public void remove_PreviewStylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.remove_PreviewStylusSystemGesture(@value);
        public void add_StylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.add_StylusSystemGesture(@value);
        public void remove_StylusSystemGesture(System.Windows.Input.StylusSystemGestureEventHandler value) => __ProxyValue.remove_StylusSystemGesture(@value);
        public void add_GotStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_GotStylusCapture(@value);
        public void remove_GotStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_GotStylusCapture(@value);
        public void add_LostStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_LostStylusCapture(@value);
        public void remove_LostStylusCapture(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_LostStylusCapture(@value);
        public void add_StylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_StylusButtonDown(@value);
        public void remove_StylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_StylusButtonDown(@value);
        public void add_StylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_StylusButtonUp(@value);
        public void remove_StylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_StylusButtonUp(@value);
        public void add_PreviewStylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_PreviewStylusButtonDown(@value);
        public void remove_PreviewStylusButtonDown(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_PreviewStylusButtonDown(@value);
        public void add_PreviewStylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.add_PreviewStylusButtonUp(@value);
        public void remove_PreviewStylusButtonUp(System.Windows.Input.StylusButtonEventHandler value) => __ProxyValue.remove_PreviewStylusButtonUp(@value);
        public void add_PreviewKeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_PreviewKeyDown(@value);
        public void remove_PreviewKeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_PreviewKeyDown(@value);
        public void add_KeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_KeyDown(@value);
        public void remove_KeyDown(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_KeyDown(@value);
        public void add_PreviewKeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_PreviewKeyUp(@value);
        public void remove_PreviewKeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_PreviewKeyUp(@value);
        public void add_KeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.add_KeyUp(@value);
        public void remove_KeyUp(System.Windows.Input.KeyEventHandler value) => __ProxyValue.remove_KeyUp(@value);
        public void add_PreviewGotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_PreviewGotKeyboardFocus(@value);
        public void remove_PreviewGotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_PreviewGotKeyboardFocus(@value);
        public void add_GotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_GotKeyboardFocus(@value);
        public void remove_GotKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_GotKeyboardFocus(@value);
        public void add_PreviewLostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_PreviewLostKeyboardFocus(@value);
        public void remove_PreviewLostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_PreviewLostKeyboardFocus(@value);
        public void add_LostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.add_LostKeyboardFocus(@value);
        public void remove_LostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventHandler value) => __ProxyValue.remove_LostKeyboardFocus(@value);
        public void add_PreviewTextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.add_PreviewTextInput(@value);
        public void remove_PreviewTextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.remove_PreviewTextInput(@value);
        public void add_TextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.add_TextInput(@value);
        public void remove_TextInput(System.Windows.Input.TextCompositionEventHandler value) => __ProxyValue.remove_TextInput(@value);
        public void add_PreviewQueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.add_PreviewQueryContinueDrag(@value);
        public void remove_PreviewQueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.remove_PreviewQueryContinueDrag(@value);
        public void add_QueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.add_QueryContinueDrag(@value);
        public void remove_QueryContinueDrag(System.Windows.QueryContinueDragEventHandler value) => __ProxyValue.remove_QueryContinueDrag(@value);
        public void add_PreviewGiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.add_PreviewGiveFeedback(@value);
        public void remove_PreviewGiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.remove_PreviewGiveFeedback(@value);
        public void add_GiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.add_GiveFeedback(@value);
        public void remove_GiveFeedback(System.Windows.GiveFeedbackEventHandler value) => __ProxyValue.remove_GiveFeedback(@value);
        public void add_PreviewDragEnter(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDragEnter(@value);
        public void remove_PreviewDragEnter(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDragEnter(@value);
        public void add_DragEnter(System.Windows.DragEventHandler value) => __ProxyValue.add_DragEnter(@value);
        public void remove_DragEnter(System.Windows.DragEventHandler value) => __ProxyValue.remove_DragEnter(@value);
        public void add_PreviewDragOver(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDragOver(@value);
        public void remove_PreviewDragOver(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDragOver(@value);
        public void add_DragOver(System.Windows.DragEventHandler value) => __ProxyValue.add_DragOver(@value);
        public void remove_DragOver(System.Windows.DragEventHandler value) => __ProxyValue.remove_DragOver(@value);
        public void add_PreviewDragLeave(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDragLeave(@value);
        public void remove_PreviewDragLeave(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDragLeave(@value);
        public void add_DragLeave(System.Windows.DragEventHandler value) => __ProxyValue.add_DragLeave(@value);
        public void remove_DragLeave(System.Windows.DragEventHandler value) => __ProxyValue.remove_DragLeave(@value);
        public void add_PreviewDrop(System.Windows.DragEventHandler value) => __ProxyValue.add_PreviewDrop(@value);
        public void remove_PreviewDrop(System.Windows.DragEventHandler value) => __ProxyValue.remove_PreviewDrop(@value);
        public void add_Drop(System.Windows.DragEventHandler value) => __ProxyValue.add_Drop(@value);
        public void remove_Drop(System.Windows.DragEventHandler value) => __ProxyValue.remove_Drop(@value);
        public void add_PreviewTouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_PreviewTouchDown(@value);
        public void remove_PreviewTouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_PreviewTouchDown(@value);
        public void add_TouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_TouchDown(@value);
        public void remove_TouchDown(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_TouchDown(@value);
        public void add_PreviewTouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.add_PreviewTouchMove(@value);
        public void remove_PreviewTouchMove(System.EventHandler<System.Windows.Input.TouchEventArgs> value) => __ProxyValue.remove_PreviewTouchMove(@value);
        public void add_PreviewMouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseDown(@value);
        public void remove_PreviewMouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseDown(@value);
        public void add_MouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseDown(@value);
        public void remove_MouseDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseDown(@value);
        public void add_PreviewMouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseUp(@value);
        public void remove_PreviewMouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseUp(@value);
        public void add_MouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseUp(@value);
        public void remove_MouseUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseUp(@value);
        public void add_PreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseLeftButtonDown(@value);
        public void remove_PreviewMouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseLeftButtonDown(@value);
        public void add_MouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseLeftButtonDown(@value);
        public void remove_MouseLeftButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseLeftButtonDown(@value);
        public void add_PreviewMouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseLeftButtonUp(@value);
        public void remove_PreviewMouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseLeftButtonUp(@value);
        public void add_MouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseLeftButtonUp(@value);
        public void remove_MouseLeftButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseLeftButtonUp(@value);
        public void add_PreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseRightButtonDown(@value);
        public void remove_PreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseRightButtonDown(@value);
        public void add_MouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseRightButtonDown(@value);
        public void remove_MouseRightButtonDown(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseRightButtonDown(@value);
        public void add_PreviewMouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_PreviewMouseRightButtonUp(@value);
        public void remove_PreviewMouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_PreviewMouseRightButtonUp(@value);
        public void add_MouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.add_MouseRightButtonUp(@value);
        public void remove_MouseRightButtonUp(System.Windows.Input.MouseButtonEventHandler value) => __ProxyValue.remove_MouseRightButtonUp(@value);
        public void add_PreviewMouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_PreviewMouseMove(@value);
        public void remove_PreviewMouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_PreviewMouseMove(@value);
        public void add_MouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_MouseMove(@value);
        public void remove_MouseMove(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_MouseMove(@value);
        public void add_PreviewMouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.add_PreviewMouseWheel(@value);
        public void remove_PreviewMouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.remove_PreviewMouseWheel(@value);
        public void add_MouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.add_MouseWheel(@value);
        public void remove_MouseWheel(System.Windows.Input.MouseWheelEventHandler value) => __ProxyValue.remove_MouseWheel(@value);
        public void add_MouseEnter(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_MouseEnter(@value);
        public void remove_MouseEnter(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_MouseEnter(@value);
        public void add_MouseLeave(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_MouseLeave(@value);
        public void remove_MouseLeave(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_MouseLeave(@value);
        public void add_GotMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_GotMouseCapture(@value);
        public void remove_GotMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_GotMouseCapture(@value);
        public void add_LostMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.add_LostMouseCapture(@value);
        public void remove_LostMouseCapture(System.Windows.Input.MouseEventHandler value) => __ProxyValue.remove_LostMouseCapture(@value);
        public void add_QueryCursor(System.Windows.Input.QueryCursorEventHandler value) => __ProxyValue.add_QueryCursor(@value);
        public void remove_QueryCursor(System.Windows.Input.QueryCursorEventHandler value) => __ProxyValue.remove_QueryCursor(@value);
        public void add_PreviewStylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.add_PreviewStylusDown(@value);
        public void remove_PreviewStylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.remove_PreviewStylusDown(@value);
        public void add_StylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.add_StylusDown(@value);
        public void remove_StylusDown(System.Windows.Input.StylusDownEventHandler value) => __ProxyValue.remove_StylusDown(@value);
        public void add_PreviewStylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusUp(@value);
        public void remove_PreviewStylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusUp(@value);
        public void add_StylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusUp(@value);
        public void remove_StylusUp(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusUp(@value);
        public void add_PreviewStylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusMove(@value);
        public void remove_PreviewStylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusMove(@value);
        public void add_StylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusMove(@value);
        public void remove_StylusMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusMove(@value);
        public void add_PreviewStylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_PreviewStylusInAirMove(@value);
        public void remove_PreviewStylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_PreviewStylusInAirMove(@value);
        public void add_StylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusInAirMove(@value);
        public void remove_StylusInAirMove(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusInAirMove(@value);
        public void add_StylusEnter(System.Windows.Input.StylusEventHandler value) => __ProxyValue.add_StylusEnter(@value);
        public void remove_StylusEnter(System.Windows.Input.StylusEventHandler value) => __ProxyValue.remove_StylusEnter(@value);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock) => __ProxyValue.ApplyAnimationClock(@dp, @clock);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.ApplyAnimationClock(@dp, @clock, @handoffBehavior);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation) => __ProxyValue.BeginAnimation(@dp, @animation);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.BeginAnimation(@dp, @animation, @handoffBehavior);
        public System.Object GetAnimationBaseValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetAnimationBaseValue(@dp);
        public System.Boolean ShouldSerializeInputBindings() => __ProxyValue.ShouldSerializeInputBindings();
        public System.Boolean ShouldSerializeCommandBindings() => __ProxyValue.ShouldSerializeCommandBindings();
        public void RaiseEvent(System.Windows.RoutedEventArgs e) => __ProxyValue.RaiseEvent(@e);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.AddHandler(@routedEvent, @handler);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler, System.Boolean handledEventsToo) => __ProxyValue.AddHandler(@routedEvent, @handler, @handledEventsToo);
        public void RemoveHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.RemoveHandler(@routedEvent, @handler);
        public void AddToEventRoute(System.Windows.EventRoute route, System.Windows.RoutedEventArgs e) => __ProxyValue.AddToEventRoute(@route, @e);
        public System.Boolean IsAncestorOf(System.Windows.DependencyObject descendant) => __ProxyValue.IsAncestorOf(@descendant);
        public System.Boolean IsDescendantOf(System.Windows.DependencyObject ancestor) => __ProxyValue.IsDescendantOf(@ancestor);
        public System.Windows.DependencyObject FindCommonVisualAncestor(System.Windows.DependencyObject otherVisual) => __ProxyValue.FindCommonVisualAncestor(@otherVisual);
        public System.Windows.Media.GeneralTransform TransformToAncestor(System.Windows.Media.Visual ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public System.Windows.Media.Media3D.GeneralTransform2DTo3D TransformToAncestor(System.Windows.Media.Media3D.Visual3D ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public System.Windows.Media.GeneralTransform TransformToDescendant(System.Windows.Media.Visual descendant) => __ProxyValue.TransformToDescendant(@descendant);
        public System.Windows.Media.GeneralTransform TransformToVisual(System.Windows.Media.Visual visual) => __ProxyValue.TransformToVisual(@visual);
        public System.Windows.Point PointToScreen(System.Windows.Point point) => __ProxyValue.PointToScreen(@point);
        public System.Windows.Point PointFromScreen(System.Windows.Point point) => __ProxyValue.PointFromScreen(@point);
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
    }
}