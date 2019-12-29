namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class Manipulation : Proxy<global::Windows.UI.Xaml.Input.Manipulation>
    {
        public static System.Boolean IsManipulationActive(System.Windows.UIElement element) => Windows.UI.Xaml.Input.Manipulation.IsManipulationActive(@element);
        public static void StartInertia(System.Windows.UIElement element) => Windows.UI.Xaml.Input.Manipulation.StartInertia(@element);
        public static void CompleteManipulation(System.Windows.UIElement element) => Windows.UI.Xaml.Input.Manipulation.CompleteManipulation(@element);
        public static void SetManipulationMode(System.Windows.UIElement element, System.Windows.Input.ManipulationModes mode) => Windows.UI.Xaml.Input.Manipulation.SetManipulationMode(@element, @mode);
        public static System.Windows.Input.ManipulationModes GetManipulationMode(System.Windows.UIElement element) => Windows.UI.Xaml.Input.Manipulation.GetManipulationMode(@element);
        public static void SetManipulationContainer(System.Windows.UIElement element, System.Windows.IInputElement container) => Windows.UI.Xaml.Input.Manipulation.SetManipulationContainer(@element, @container);
        public static System.Windows.IInputElement GetManipulationContainer(System.Windows.UIElement element) => Windows.UI.Xaml.Input.Manipulation.GetManipulationContainer(@element);
        public static void SetManipulationPivot(System.Windows.UIElement element, System.Windows.Input.ManipulationPivot pivot) => Windows.UI.Xaml.Input.Manipulation.SetManipulationPivot(@element, @pivot);
        public static System.Windows.Input.ManipulationPivot GetManipulationPivot(System.Windows.UIElement element) => Windows.UI.Xaml.Input.Manipulation.GetManipulationPivot(@element);
        public static void AddManipulator(System.Windows.UIElement element, System.Windows.Input.IManipulator manipulator) => Windows.UI.Xaml.Input.Manipulation.AddManipulator(@element, @manipulator);
        public static void RemoveManipulator(System.Windows.UIElement element, System.Windows.Input.IManipulator manipulator) => Windows.UI.Xaml.Input.Manipulation.RemoveManipulator(@element, @manipulator);
        public static void SetManipulationParameter(System.Windows.UIElement element, System.Windows.Input.Manipulations.ManipulationParameters2D parameter) => Windows.UI.Xaml.Input.Manipulation.SetManipulationParameter(@element, @parameter);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}