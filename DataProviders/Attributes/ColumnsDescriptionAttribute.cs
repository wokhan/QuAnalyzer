using System;

namespace Wokhan.Data.Providers.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class ColumnsDescriptionAttribute : Attribute
    {
        public string[] Headers;
        
        public ColumnsDescriptionAttribute(params string[] headers) { }
    }
}
