﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Wokhan.Data.Providers.Attributes;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;

namespace Wokhan.Data.Providers
{
    [DataProvider(Category = "Database", Name = "SQL Server", Description = "Easily connect to SQLServer databases.", Copyright="Developed by Wokhan Solutions", Icon = "/Resources/Providers/SQLServer.png")]
    public class SQLServerDataProvider : DBDataProvider, IDBDataProvider, IExposedDataProvider
    {

        public new DbDataAdapter DataAdapterInstancer()
        {
            return new SqlDataAdapter("", this.ConnectionString);
        }

        public new DbConnection GetConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        public new Dictionary<string, object> GetDefaultRepositories()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.tables", conn))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    string val;
                    while (sdr.Read())
                    {
                        var qry = String.Join(", ", GetAllColumns(sdr[0].ToString()).Select(h => h.Key));
                        val = sdr[0].ToString() + "." + sdr[1].ToString(); 
                        ret.Add(val, "SELECT " + qry + " FROM " + val);
                    }
                }
            }

            return ret;
        }
    }
}
