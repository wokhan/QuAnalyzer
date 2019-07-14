using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace QuAnalyzer.UI.Controls
{
    public class ToolBarToggleButton : ToggleButton
    {
        [Bindable(true)]
        public string Text { get; set; }
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ToolBarToggleButton), new PropertyMetadata());

        [Bindable(true)]
        public Geometry Image { get; set; }
        public static DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(Geometry), typeof(ToolBarToggleButton), new PropertyMetadata());

        [Bindable(true)]
        public Orientation Orientation { get; set; }

        static ToolBarToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarToggleButton), new FrameworkPropertyMetadata(typeof(ToolBarToggleButton)));
        }
    }
}
