using Wokhan.Data.Providers.Attributes;
using Wokhan.Data.Providers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure.Interception;

namespace Wokhan.Data.Providers.Bases
{
    public class DBDataProvider : DataProvider, IDBDataProvider
    {
        public new bool IsDirectlyBindable { get { return true; } }

        [ProviderParameter("Connection String", ExclusionGroup = "Connection string", Position = 0)]
        public string ConnectionString { get; set; }

        [ProviderParameter("Schema (optional)", ExclusionGroup = "Connection details", Position = 30)]
        public string Schema { get; set; }

        [ProviderParameter("Host", ExclusionGroup = "Connection details", Position = 10)]
        public new string Host { get; set; }

        [ProviderParameter("Port", ExclusionGroup = "Connection details", Position = 20)]
        public int Port { get; set; }

        [ProviderParameter("Username", ExclusionGroup = "Connection details", Position = 40)]
        public string Username { get; set; }

        [ProviderParameter("Password", true, ExclusionGroup = "Connection details", Position = 50)]
        public string Password { get; set; }

        static DBDataProvider()
        {
            DbInterception.Add(new DbInterceptor());
        }

        public DbDataAdapter DataAdapterInstancer()
        {
            return null;
        }

        public DbConnection GetConnection()
        {
            return null;
        }

        public static new string GetFormatKey(List<object> srcAttributesCollection, object srcAttribute)
        {
            return ((DataColumn)srcAttribute).ColumnName;
        }

        public new IEnumerable GetDataDirect(string repository = null, IEnumerable<string> attributes = null)
        {
            DataTable tmp = new DataTable();
            if (Repositories.ContainsKey(repository))
            {
                using (var oda = ((IDBDataProvider)this).DataAdapterInstancer())
                {
                    if (attributes == null || !attributes.Any())
                    {
                        oda.SelectCommand.CommandText = (string)Repositories[repository];
                    }
                    else
                    {
                        oda.SelectCommand.CommandText = "SELECT " + String.Join(", ", attributes) + " FROM (" + Repositories[repository] + ") a";
                    }

                    tmp.BeginLoadData();
                    oda.Fill(tmp);
                    tmp.EndLoadData();
                }
            }
            return tmp.DefaultView;
        }

        public Dictionary<string, Type> GetAllColumns(string repository)
        {
            using (var oda = ((IDBDataProvider)this).DataAdapterInstancer())
            {
                DataTable tmp = new DataTable();
                oda.SelectCommand.CommandText = "SELECT * FROM " + repository + " WHERE ROWNUM = 1";
                oda.FillSchema(tmp, SchemaType.Source);

                return tmp.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => c.DataType);
            }
        }

        private Dictionary<string, string[]> _keys = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> CachedKeys
        {
            get { return _keys; }
            set { _keys = value; }
        }

        private Dictionary<string, Dictionary<string, Type>> _headers = new Dictionary<string, Dictionary<string, Type>>();
        public Dictionary<string, Dictionary<string, string>> CachedHeaders
        {
            get { return _headers.ToDictionary(h => h.Key, h => h.Value.ToDictionary(k => k.Key, k => k.Value.FullName)); }
            set { _headers = value.ToDictionary(h => h.Key, h => h.Value.ToDictionary(k => k.Key, k => Type.GetType(k.Value))); }
        }

        public new void RemoveCachedHeaders(string repository)
        {
            if (_headers.ContainsKey(this.Name + "_" + repository))
            {
                _headers.Remove(this.Name + "_" + repository);
            }
        }

        public new Dictionary<string, Type> GetHeaders(string repository)
        {
            Dictionary<string, Type> ret;

            lock (_headers)
            {
                if (!_headers.TryGetValue(this.Name + "_" + repository, out ret))
                {
                    DataTable tmp = new DataTable();
                    if (Repositories.ContainsKey(repository))
                    {
                        using (var oda = ((IDBDataProvider)this).DataAdapterInstancer())
                        {
                            oda.SelectCommand.CommandText = (string)Repositories[repository];
                            oda.FillSchema(tmp, SchemaType.Source);
                        }
                    }

                    ret = tmp.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => GetRealType(c));
                    _headers.Add(this.Name + "_" + repository, ret);
                }
            }

            return ret;
        }

        private Type GetRealType(DataColumn c)
        {
            if (c.AllowDBNull && c.DataType.IsValueType)
            {
                return typeof(Nullable<>).MakeGenericType(c.DataType);
            }
            else
            {
                return c.DataType;
            }
        }

        Dictionary<string, Type> cachedTypes = new Dictionary<string, Type>();
        public new IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class
        {
            var h = GetHeaders(repository);

            Type tx;
            lock (cachedTypes)
            {
                if (!cachedTypes.TryGetValue(repository, out tx))
                {
                    tx = typeof(DynamicDbContext<,>).MakeGenericType(typeof(T), typeof(TK));
                    cachedTypes.Add(repository, tx);
                }
            }
            
            var conn = ((IDBDataProvider)this).GetConnection();

            var dbc = (IDynamicDbContext)Activator.CreateInstance(tx, conn, "DYNAMICSCHEMA", repository, h.Select(hd => hd.Key).ToArray());

            dbc.basequery = (string)Repositories[repository];

            return (IQueryable<T>)dbc.GetSet().AsNoTracking();//.AsStreaming();
        }

        public interface IDynamicDbContext
        {
            string table { get; set; }
            string schema { get; set; }
            string basequery { get; set; }

            IQueryable GetSet();
        }

        //[DbConfigurationType("Wokhan.Data.Providers.DBDataProvider.DbConfigurationWrapper")]
        public partial class DynamicDbContext<T, TK> : DbContext, IDynamicDbContext
            where T : class
            where TK : class
        {
          /*  public class DbConfigurationWrapper : DbConfiguration
            {
                public DbConfigurationWrapper()
                {
                    
                }
            }
*/
            private string[] keys;
            public string table { get; set; }
            public string schema { get; set; }
            public string basequery { get; set; }

            static DynamicDbContext()
            {
                Database.SetInitializer<DynamicDbContext<T, TK>>(null);
            }

            public DynamicDbContext(DbConnection cstring, string schema, string table, params string[] keys)
                : base(cstring, true)
            {
                this.table = table;
                this.keys = keys;
                this.schema = schema;
                this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                this.Database.Connection.StateChange += Connection_StateChange;
            }

            private void Connection_StateChange(object sender, StateChangeEventArgs e)
            {
                /*if (e.OriginalState != ConnectionState.Open || e.CurrentState == ConnectionState.Open)
                {
                    this.Database.ExecuteSqlCommand("ALTER SESSION SET NLS_COMP = BINARY");
                }*/
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                this.Configuration.AutoDetectChangesEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;
                
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                
                modelBuilder.HasDefaultSchema(schema);

                ParameterExpression param = Expression.Parameter(typeof(T));
                Expression<Func<T, long>> keyExpression = Expression.Lambda<Func<T, long>>(Expression.Property(param, "__UID"), param);

                modelBuilder.Entity<T>().HasEntitySetName(table)
                                        .ToTable("DYNAMICTABLE")
                                        .HasKey(keyExpression);
            }

            public IQueryable GetSet()
            {
                this.Database.ExecuteSqlCommand("ALTER SESSION SET NLS_SORT = UNICODE_BINARY");
                return this.Set<T>();
            }
        }

        //public new IEnumerable<object[]> GetData(string repository, IEnumerable<string> attributes = null)
        //{
        //    DataTable ret = new DataTable();

        //    try
        //    {
        //        if (Repositories.ContainsKey(repository))
        //        {
        //            using (var oda = ((IDBDataProvider)this).DataAdapterInstancer())
        //            {
        //                var cn = oda.SelectCommand.Connection;
        //                {
        //                    if (attributes == null || !attributes.Any())
        //                    {
        //                        oda.SelectCommand.CommandText = (string)Repositories[repository];
        //                    }
        //                    else
        //                    {
        //                        oda.SelectCommand.CommandText = "SELECT " + String.Join(", ", attributes) + " FROM (" + Repositories[repository] + ") a";
        //                    }

        //                    cn.Open();
        //                    var sdr = oda.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //                    return innerGetData(sdr);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Unknown source");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        protected override long Count(string repository = null)
        {
            try
            {
                if (Repositories.ContainsKey(repository))
                {
                    using (var oda = ((IDBDataProvider)this).DataAdapterInstancer())
                    {
                        var cn = oda.SelectCommand.Connection;
                        oda.SelectCommand.CommandText = "SELECT COUNT(*) FROM (" + (string)Repositories[repository] + ") a";

                        cn.Open();
                        var res = oda.SelectCommand.ExecuteScalar();
                        long ret = (long)((decimal)res);
                        cn.Close();

                        return ret;
                    }
                }
                else
                {
                    throw new Exception("Unknown source");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private IEnumerable<object[]> innerGetData(DbDataReader sdr)
        {
            while (sdr.Read())
            {
                object[] ot = new object[sdr.FieldCount];

                sdr.GetValues(ot);

                yield return ot;
            }

            sdr.Close();
        }


        public new bool Test(out string details)
        {
            try
            {
                using (var oda = ((IDBDataProvider)this).DataAdapterInstancer())
                {
                    var cn = oda.SelectCommand.Connection;
                    oda.SelectCommand.CommandText = "SELECT 1 FROM DUAL";

                    cn.Open();
                    oda.SelectCommand.ExecuteScalar();
                    cn.Close();
                }

                details = "OK";
                return true;
            }
            catch (Exception e)
            {
                details = e.Message;
                return false;
            }
        }
    }
}
