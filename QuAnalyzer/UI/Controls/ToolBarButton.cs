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
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(ToolBarButton), new PropertyMetadata(null));

        [Bindable(true)]
        public object Image { get; set; }
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(nameof(Image), typeof(object), typeof(ToolBarButton), new PropertyMetadata(null));

        [Bindable(true)]
        public Orientation Orientation { get; set; }

        static ToolBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarButton), new FrameworkPropertyMetadata(typeof(ToolBarButton)));
        }
    }
}
