using System.Data.Common;

namespace Wokhan.Data.Providers.Contracts
{
    public interface IDBDataProvider : IDataProvider
    {
        DbDataAdapter DataAdapterInstancer();
        DbConnection GetConnection();
        string Schema { get; set; }
    }
}
