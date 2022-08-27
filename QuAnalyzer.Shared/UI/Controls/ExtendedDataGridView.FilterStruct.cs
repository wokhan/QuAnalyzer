using CommunityToolkit.WinUI.UI.Controls;

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

    public static Dictionary<string, string> Operators { get; } = new()
    {
        { "Equals", "=" },
        { "Differs from", "<>" },
        { "Greater than", ">" },
        { "Greater than or equal", ">=" },
        { "Less than", "<" },
        { "Less than or equal", "<=" }
    };

}
