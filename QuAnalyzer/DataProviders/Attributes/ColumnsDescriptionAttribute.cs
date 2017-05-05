using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QuAnalyzer.DataProviders.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class ColumnsDescriptionAttribute : Attribute
    {
        public string[] Headers;
        
        public ColumnsDescriptionAttribute(params string[] headers) { }
    }
}
