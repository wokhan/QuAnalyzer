using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Data;

using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.Core.Extensions;

public static class ColumnDescriptionExtensions
{
    public static IEnumerable<DataGridBoundColumn> ToDataGridColumns(this IEnumerable<ColumnDescription> source, bool isArray = false)
    {
        ArgumentNullException.ThrowIfNull(source);

        //TODO: review for non-arrays when CustomHeaders are used as it seems incorrect
        //BTW, CustomHeaders seem useless to me (should directly use Columns, right?)
        return source.Select((h, i) => new DataGridTextColumn()
        {
            Header = h.DisplayName,
            Binding = new Binding() { Path = new PropertyPath(isArray ? $"[{i}]" : h.Name) },
            //Tag = h.Name,
            FontWeight = (h.IsKey ? FontWeights.Bold : FontWeights.Normal)
        });

    }
}

