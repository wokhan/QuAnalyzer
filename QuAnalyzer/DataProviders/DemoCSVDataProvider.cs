using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System.Collections.Generic;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Files", Name = "CSV (demo)", Icon = "ICON_CSVDATAPROVIDER")]
    public class DemoCSVDataProvider : CSVDataProvider, IDataProvider
    {
        public DemoCSVDataProvider()
            : base()
        {
            this.Encoding = "Latin1";
            this.Delimiter = "¤";
            this.Repositories = new Dictionary<string, object> { { "CCR", @"C:\Mon Espace Disque\CCR.csv" }, { "CCR2", @"C:\Mon Espace Disque\CCR2.csv" } };
        }

    }
}
