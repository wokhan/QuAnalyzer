namespace System.Windows.Automation
{
    using Uno.UI.Generic;

    public class AutomationProperties : Proxy<global::Windows.UI.Xaml.Automation.AutomationProperties>
    {
        public static void SetAutomationId(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetAutomationId(@element, @value);
        public static System.String GetAutomationId(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetAutomationId(@element);
        public static void SetName(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetName(@element, @value);
        public static System.String GetName(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetName(@element);
        public static void SetHelpText(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetHelpText(@element, @value);
        public static System.String GetHelpText(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetHelpText(@element);
        public static void SetAcceleratorKey(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetAcceleratorKey(@element, @value);
        public static System.String GetAcceleratorKey(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetAcceleratorKey(@element);
        public static void SetAccessKey(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetAccessKey(@element, @value);
        public static System.String GetAccessKey(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetAccessKey(@element);
        public static void SetItemStatus(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetItemStatus(@element, @value);
        public static System.String GetItemStatus(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetItemStatus(@element);
        public static void SetItemType(System.Windows.DependencyObject element, System.String value) => Windows.UI.Xaml.Automation.AutomationProperties.SetItemType(@element, @value);
        public static System.String GetItemType(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetItemType(@element);
        public static void SetIsColumnHeader(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Automation.AutomationProperties.SetIsColumnHeader(@element, @value);
        public static System.Boolean GetIsColumnHeader(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetIsColumnHeader(@element);
        public static void SetIsRowHeader(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Automation.AutomationProperties.SetIsRowHeader(@element, @value);
        public static System.Boolean GetIsRowHeader(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetIsRowHeader(@element);
        public static void SetIsRequiredForForm(System.Windows.DependencyObject element, System.Boolean value) => Windows.UI.Xaml.Automation.AutomationProperties.SetIsRequiredForForm(@element, @value);
        public static System.Boolean GetIsRequiredForForm(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetIsRequiredForForm(@element);
        public static void SetLabeledBy(System.Windows.DependencyObject element, System.Windows.UIElement value) => Windows.UI.Xaml.Automation.AutomationProperties.SetLabeledBy(@element, @value);
        public static System.Windows.UIElement GetLabeledBy(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetLabeledBy(@element);
        public static void SetIsOffscreenBehavior(System.Windows.DependencyObject element, System.Windows.Automation.IsOffscreenBehavior value) => Windows.UI.Xaml.Automation.AutomationProperties.SetIsOffscreenBehavior(@element, @value);
        public static System.Windows.Automation.IsOffscreenBehavior GetIsOffscreenBehavior(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetIsOffscreenBehavior(@element);
        public static void SetLiveSetting(System.Windows.DependencyObject element, System.Windows.Automation.AutomationLiveSetting value) => Windows.UI.Xaml.Automation.AutomationProperties.SetLiveSetting(@element, @value);
        public static System.Windows.Automation.AutomationLiveSetting GetLiveSetting(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetLiveSetting(@element);
        public static void SetPositionInSet(System.Windows.DependencyObject element, System.Int32 value) => Windows.UI.Xaml.Automation.AutomationProperties.SetPositionInSet(@element, @value);
        public static System.Int32 GetPositionInSet(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetPositionInSet(@element);
        public static void SetSizeOfSet(System.Windows.DependencyObject element, System.Int32 value) => Windows.UI.Xaml.Automation.AutomationProperties.SetSizeOfSet(@element, @value);
        public static System.Int32 GetSizeOfSet(System.Windows.DependencyObject element) => Windows.UI.Xaml.Automation.AutomationProperties.GetSizeOfSet(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}