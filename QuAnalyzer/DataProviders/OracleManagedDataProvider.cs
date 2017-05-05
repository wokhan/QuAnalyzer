using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Database", Name = "Oracle ODP.NET Managed Driver", Icon = "/Resources/Providers/SQL.png")]
    public class OracleManagedDataProvider : DBDataProvider, IDBDataProvider, IExposedDataProvider
    {
        [ProviderParameter("SID", ExclusionGroup = "Connection details", Position = 25)]
        public string SID { get; set; }

        private string cStringformat = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SID={2})));User ID={3};Password={4}";

        private string _host = null;
        [ProviderParameter("Host", ExclusionGroup = "Connection details", Position = 10)]
        public new string Host
        {
            get { return _host ?? Regex.Match(this.RealConnectionString, @"HOST=([^\)]*)\)", RegexOptions.IgnoreCase).Groups[1].Value; }
            set { _host = value; }
        }

        private string _schema;
        [ProviderParameter("Schema (optional)", ExclusionGroup = "Connection details", Position = 30)]
        public new string Schema
        {
            get { return String.IsNullOrEmpty(_schema) ? (String.IsNullOrEmpty(Username) ? Regex.Match(this.RealConnectionString, @"User ID=([^\)|;]*)(?:\)|;)", RegexOptions.IgnoreCase).Groups[1].Value : Username) : _schema; }
            set { _schema = value; }
        }

        private string RealConnectionString
        {
            get { return String.IsNullOrEmpty(this.ConnectionString) ? String.Format(cStringformat, _host, Port, SID, Username, Password) : this.ConnectionString; }
        }

        public new DbDataAdapter DataAdapterInstancer()
        {
            var conn = new OracleConnection(RealConnectionString);
            //conn.StateChange += conn_StateChange;

            return new OracleDataAdapter("", conn);
        }

        public new DbConnection GetConnection()
        {
            return new OracleConnection(RealConnectionString);
        }


        void conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if (e.CurrentState == System.Data.ConnectionState.Open)
            {
                var sessInfo = ((OracleConnection)sender).GetSessionInfo();
                sessInfo.DateFormat = "DD/MM/YYYY HH24:MI:SS";
                sessInfo.TimeStampFormat = "DD/MM/YYYY HH24:MI:SS";
                sessInfo.TimeStampTZFormat = "DD/MM/YYYY HH24:MI:SS";
                sessInfo.DateLanguage = "AMERICAN";
                sessInfo.Language = "AMERICAN";
                ((OracleConnection)sender).SetSessionInfo(sessInfo);
            }
        }

        public new Dictionary<string, object> GetDefaultRepositories()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();

            using (OracleConnection conn = new OracleConnection(RealConnectionString))
            {
                conn.Open();
                string req;
                if (String.IsNullOrEmpty(Schema))
                {
                    req = "SELECT TABLE_NAME FROM USER_TABLES UNION ALL SELECT VIEW_NAME FROM USER_VIEWS";
                }
                else
                {
                    req = "SELECT OWNER || '.' || TABLE_NAME FROM ALL_TABLES WHERE OWNER = '" + Schema + "' UNION ALL SELECT OWNER || '.' || VIEW_NAME FROM ALL_VIEWS WHERE OWNER = '" + Schema + "'";
                }
                using (OracleCommand cmd = new OracleCommand(req, conn))
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
