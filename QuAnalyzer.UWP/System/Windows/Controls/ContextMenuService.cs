namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ContextMenuService : Proxy<global::Windows.UI.Xaml.Controls.ContextMenuService>
    {
        public static System.Windows.Controls.ContextMenu GetContextMenu(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetContextMenu(@element);
        public static void SetContextMenu(System.Windows.DependencyObject element, System.Windows.Controls.ContextMenu value) => Windows.UI.Xaml.Controls.ContextMenuService.SetContextMenu(@element, @value);
        public static System.Double GetHorizontalOffset(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetHorizontalOffset(@element);
        public static void SetHorizontalOffset(System.Windows.DependencyObject element, System.Double value) => Windows.UI.Xaml.Controls.ContextMenuService.SetHorizontalOffset(@element, @value);
        public static System.Double GetVerticalOffset(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetVerticalOffset(@element);
        public static void SetVerticalOffset(System.Windows.DependencyObject element, System.Double value) => Windows.UI.Xaml.Controls.ContextMenuService.SetVerticalOffset(@element, @value);
        public static System.Boolean GetHasDropShadow(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetHasDropShadow(@element);
        public static void SetHasDropShadow(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Controls.ContextMenuService.SetHasDropShadow(@element, @value);
        public static System.Windows.UIElement GetPlacementTarget(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetPlacementTarget(@element);
        public static void SetPlacementTarget(System.Windows.DependencyObject element, System.Windows.UIElement value) => Windows.UI.Xaml.Controls.ContextMenuService.SetPlacementTarget(@element, @value);
        public static System.Windows.Rect GetPlacementRectangle(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetPlacementRectangle(@element);
        public static void SetPlacementRectangle(System.Windows.DependencyObject element, System.Windows.Rect value) => Windows.UI.Xaml.Controls.ContextMenuService.SetPlacementRectangle(@element, @value);
        public static System.Windows.Controls.Primitives.PlacementMode GetPlacement(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetPlacement(@element);
        public static void SetPlacement(System.Windows.DependencyObject element, System.Windows.Controls.Primitives.PlacementMode value) => Windows.UI.Xaml.Controls.ContextMenuService.SetPlacement(@element, @value);
        public static System.Boolean GetShowOnDisabled(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetShowOnDisabled(@element);
        public static void SetShowOnDisabled(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Controls.ContextMenuService.SetShowOnDisabled(@element, @value);
        public static System.Boolean GetIsEnabled(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ContextMenuService.GetIsEnabled(@element);
        public static void SetIsEnabled(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Controls.ContextMenuService.SetIsEnabled(@element, @value);
        public static void AddContextMenuOpeningHandler(System.Windows.DependencyObject element, System.Windows.Controls.ContextMenuEventHandler handler) => Windows.UI.Xaml.Controls.ContextMenuService.AddContextMenuOpeningHandler(@element, @handler);
        public static void RemoveContextMenuOpeningHandler(System.Windows.DependencyObject element, System.Windows.Controls.ContextMenuEventHandler handler) => Windows.UI.Xaml.Controls.ContextMenuService.RemoveContextMenuOpeningHandler(@element, @handler);
        public static void AddContextMenuClosingHandler(System.Windows.DependencyObject element, System.Windows.Controls.ContextMenuEventHandler handler) => Windows.UI.Xaml.Controls.ContextMenuService.AddContextMenuClosingHandler(@element, @handler);
        public static void RemoveContextMenuClosingHandler(System.Windows.DependencyObject element, System.Windows.Controls.ContextMenuEventHandler handler) => Windows.UI.Xaml.Controls.ContextMenuService.RemoveContextMenuClosingHandler(@element, @handler);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}