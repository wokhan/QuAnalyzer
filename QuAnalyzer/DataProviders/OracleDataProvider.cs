using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Database", Name = "Oracle .NET Provider (deprecated)", Copyright = "Developed by Wokhan Solutions", Icon = "/Resources/Providers/SQL.png")]
    public class OracleDataProvider : DBDataProvider, IDBDataProvider, IExposedDataProvider
    {
        public new DbDataAdapter DataAdapterInstancer()
        {
            return new OracleDataAdapter("", this.ConnectionString);
        }

        public new DbConnection GetConnection()
        {
            return new OracleConnection(this.ConnectionString);
        }

        public OracleDataProvider()
        {
            //this.oda = new OracleDataAdapter("", new OracleConnection());
        }


        public new Dictionary<string, object> GetDefaultRepositories()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();

            using (OracleConnection conn = new OracleConnection(this.ConnectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("SELECT TABLE_NAME FROM USER_TABLES UNION ALL SELECT VIEW_NAME FROM USER_VIEWS", conn))
                {
                    OracleDataReader sdr = cmd.ExecuteReader();
                    string val;
                    while (sdr.Read())
                    {
                        val = sdr[0].ToString();
                        var qry = String.Join(", ", GetAllColumns(val).Select(h => h.Key));
                        ret.Add(val, "SELECT " + qry + " FROM " + val);
                    }
                }
            }

            return ret;
        }

    }
}
