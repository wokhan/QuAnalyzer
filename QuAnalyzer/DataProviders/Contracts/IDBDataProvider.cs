using System.Data.Common;

namespace QuAnalyzer.DataProviders.Contracts
{
    public interface IDBDataProvider : IDataProvider
    {
        DbDataAdapter DataAdapterInstancer();
        DbConnection GetConnection();
        string Schema { get; set; }
    }
}
