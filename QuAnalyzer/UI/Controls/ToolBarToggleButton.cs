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
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ToolBarToggleButton), new PropertyMetadata(null));

        [Bindable(true)]
        public object Image { get; set; }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(object), typeof(ToolBarToggleButton), new PropertyMetadata(null));

        [Bindable(true)]
        public Orientation Orientation { get; set; }

        static ToolBarToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarToggleButton), new FrameworkPropertyMetadata(typeof(ToolBarToggleButton)));
        }
    }
}
