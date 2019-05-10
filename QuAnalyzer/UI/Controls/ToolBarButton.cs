using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuAnalyzer.UI.Controls
{
    public class ToolBarButton : Button
    {
        [Bindable(true)]
        public string Text { get; set; }
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ToolBarButton), new PropertyMetadata());

        [Bindable(true)]
        public Geometry Image { get; set; }
        public static DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(Geometry), typeof(ToolBarButton), new PropertyMetadata());

        [Bindable(true)]
        public Orientation Orientation { get; set; }

        static ToolBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarButton), new FrameworkPropertyMetadata(typeof(ToolBarButton)));
        }
    }
}
