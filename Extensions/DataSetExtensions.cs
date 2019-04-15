using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CoreView.Extensions
{
    /// <summary>
    /// Summary description for DataSetExtensions
    /// </summary>
    public static class DataSetExtensions
    {
        public static IEnumerable<DataRow> GetParentRows(this DataRow drow)
        {
            return drow.Table.ParentRelations.Cast<DataRelation>().SelectMany(r => drow.GetParentRows(r));
        }

        public static void AddIfValued(this PropertyCollection propertyCollection, string propertyName, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                propertyCollection[propertyName] = value;
            }
        }

        public static void AddIfValued(this PropertyCollection propertyCollection, string propertyName, bool value)
        {
            if (value)
            {
                propertyCollection[propertyName] = value;
            }
        }
    }
}