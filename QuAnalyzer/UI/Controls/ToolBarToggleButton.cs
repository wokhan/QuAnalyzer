using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
