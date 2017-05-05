using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;

namespace QuAnalyzer.DataProviders.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DataProviderAttribute : Attribute
    {
        public string Category;
        public string Name;
        public string Icon = "/Resources/ICON_PROVIDER_DEFAULT.png";
        public string Copyright;
        public string Description;

        public DataProviderAttribute() { }
    }
}
