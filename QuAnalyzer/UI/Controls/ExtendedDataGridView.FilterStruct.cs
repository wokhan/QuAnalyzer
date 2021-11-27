
using System;

namespace QuAnalyzer.UI.Controls;

public partial class ExtendedDataGridView
{
    public struct FilterStruct
    {
        public string Attribute { get; set; }
        public string DisplayName { get; set; }
        public Type Type { get; set; }
        public string ComparerExpression { get; set; }

        public object TargetValue { get; set; }
        /*public string TargetValue
        {
            get { return TargetValueAsObject is not null ? TargetValueAsObject.ToString() : String.Empty; }
            set { TargetValueAsObject = Convert.ChangeType(value, Type); }
        }*/
    }
}
