namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ToolTipService : Proxy<global::Windows.UI.Xaml.Controls.ToolTipService>
    {
        public static System.Object GetToolTip(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetToolTip(@element);
        public static void SetToolTip(System.Windows.DependencyObject element, System.Object value) => Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(@element, @value);
        public static System.Double GetHorizontalOffset(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetHorizontalOffset(@element);
        public static void SetHorizontalOffset(System.Windows.DependencyObject element, System.Double value) => Windows.UI.Xaml.Controls.ToolTipService.SetHorizontalOffset(@element, @value);
        public static System.Double GetVerticalOffset(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetVerticalOffset(@element);
        public static void SetVerticalOffset(System.Windows.DependencyObject element, System.Double value) => Windows.UI.Xaml.Controls.ToolTipService.SetVerticalOffset(@element, @value);
        public static System.Boolean GetHasDropShadow(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetHasDropShadow(@element);
        public static void SetHasDropShadow(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Controls.ToolTipService.SetHasDropShadow(@element, @value);
        public static System.Windows.UIElement GetPlacementTarget(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetPlacementTarget(@element);
        public static void SetPlacementTarget(System.Windows.DependencyObject element, System.Windows.UIElement value) => Windows.UI.Xaml.Controls.ToolTipService.SetPlacementTarget(@element, @value);
        public static System.Windows.Rect GetPlacementRectangle(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetPlacementRectangle(@element);
        public static void SetPlacementRectangle(System.Windows.DependencyObject element, System.Windows.Rect value) => Windows.UI.Xaml.Controls.ToolTipService.SetPlacementRectangle(@element, @value);
        public static System.Windows.Controls.Primitives.PlacementMode GetPlacement(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetPlacement(@element);
        public static void SetPlacement(System.Windows.DependencyObject element, System.Windows.Controls.Primitives.PlacementMode value) => Windows.UI.Xaml.Controls.ToolTipService.SetPlacement(@element, @value);
        public static System.Boolean GetShowOnDisabled(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetShowOnDisabled(@element);
        public static void SetShowOnDisabled(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Controls.ToolTipService.SetShowOnDisabled(@element, @value);
        public static System.Boolean GetIsOpen(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetIsOpen(@element);
        public static System.Boolean GetIsEnabled(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetIsEnabled(@element);
        public static void SetIsEnabled(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Controls.ToolTipService.SetIsEnabled(@element, @value);
        public static System.Int32 GetShowDuration(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetShowDuration(@element);
        public static void SetShowDuration(System.Windows.DependencyObject element, System.Int32 value) => Windows.UI.Xaml.Controls.ToolTipService.SetShowDuration(@element, @value);
        public static System.Int32 GetInitialShowDelay(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetInitialShowDelay(@element);
        public static void SetInitialShowDelay(System.Windows.DependencyObject element, System.Int32 value) => Windows.UI.Xaml.Controls.ToolTipService.SetInitialShowDelay(@element, @value);
        public static System.Int32 GetBetweenShowDelay(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.ToolTipService.GetBetweenShowDelay(@element);
        public static void SetBetweenShowDelay(System.Windows.DependencyObject element, System.Int32 value) => Windows.UI.Xaml.Controls.ToolTipService.SetBetweenShowDelay(@element, @value);
        public static void AddToolTipOpeningHandler(System.Windows.DependencyObject element, System.Windows.Controls.ToolTipEventHandler handler) => Windows.UI.Xaml.Controls.ToolTipService.AddToolTipOpeningHandler(@element, @handler);
        public static void RemoveToolTipOpeningHandler(System.Windows.DependencyObject element, System.Windows.Controls.ToolTipEventHandler handler) => Windows.UI.Xaml.Controls.ToolTipService.RemoveToolTipOpeningHandler(@element, @handler);
        public static void AddToolTipClosingHandler(System.Windows.DependencyObject element, System.Windows.Controls.ToolTipEventHandler handler) => Windows.UI.Xaml.Controls.ToolTipService.AddToolTipClosingHandler(@element, @handler);
        public static void RemoveToolTipClosingHandler(System.Windows.DependencyObject element, System.Windows.Controls.ToolTipEventHandler handler) => Windows.UI.Xaml.Controls.ToolTipService.RemoveToolTipClosingHandler(@element, @handler);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}