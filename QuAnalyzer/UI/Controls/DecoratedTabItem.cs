using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuAnalyzer.UI.Controls
{
    public class DecoratedTabItem : TabItem
    {
        [Bindable(true)]
        public Geometry Image { get; set; }
        public static DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(Geometry), typeof(DecoratedTabItem), new PropertyMetadata());

        static DecoratedTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DecoratedTabItem), new FrameworkPropertyMetadata(typeof(DecoratedTabItem)));
        }

    }
}
