using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Bases;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using SharpSapRfc;
using SAP.Middleware.Connector;
using QuAnalyzer.Extensions;

namespace QuAnalyzer.DataProviders
{
    [DataProvider(Category = "Various", Name = "SAP RFC Connector", Copyright = "Developed by Wokhan Solutions", Icon = "pack://application:,,,/SAPDataProvider;component/Resources/SAP.png")]
    public class SAPDataProvider : DataProvider, IDataProvider, IExposedDataProvider
    {
        public SAPDataProvider() : base() { }


        [ProviderParameter("Host")]
        public string SAPHost { get; set; }

        [ProviderParameter("System Number")]
        public string SystemNumber { get; set; }

        [ProviderParameter("System ID")]
        public string SystemID { get; set; }

        [ProviderParameter("Client")]
        public string Client { get; set; }

        [ProviderParameter("Language")]
        public string Language { get; set; }

        [ProviderParameter("Function")]
        public string Function { get; set; }

        [ProviderParameter("Username")]
        public string Username { get; set; }

        [ProviderParameter("Password", IsEncoded = true)]
        public string Password { get; set; }

        public new void RemoveCachedHeaders(string repository)
        {
            if (cachedHeaders.ContainsKey(repository))
            {
                cachedHeaders.Remove(repository);
            }
        }

        private RfcConfigParameters getParameters()
        {
            RfcConfigParameters ret = new RfcConfigParameters();
            ret.Add(RfcConfigParameters.AppServerHost, SAPHost);
            ret.Add(RfcConfigParameters.SystemNumber, SystemNumber);
            ret.Add(RfcConfigParameters.SystemID, SystemID);
            ret.Add(RfcConfigParameters.User, Username);
            ret.Add(RfcConfigParameters.Password, Password);
            ret.Add(RfcConfigParameters.Client, Client);
            ret.Add(RfcConfigParameters.Language, Language);
            ret.Add(RfcConfigParameters.PoolSize, "5");

            return ret;
        }

        private static Type GetDataType(RfcDataType rfcDataType)
        {
            switch (rfcDataType)
            {
                case RfcDataType.DATE:
                    return typeof(string);
                case RfcDataType.CHAR:
                    return typeof(string);
                case RfcDataType.STRING:
                    return typeof(string);
                case RfcDataType.BCD:
                    return typeof(decimal);
                case RfcDataType.INT2:
                    return typeof(int);
                case RfcDataType.INT4:
                    return typeof(int);
                case RfcDataType.FLOAT:
                    return typeof(double);
                default:
                    return typeof(string);
            }
        }

        private Dictionary<string, Dictionary<string, Type>> cachedHeaders = new Dictionary<string, Dictionary<string, Type>>();
        public new Dictionary<string, Type> GetHeaders(string repository = null)
        {
            if (!cachedHeaders.ContainsKey(repository))
            {
                Dictionary<string, Type> ret = new Dictionary<string, System.Type>();

                var d = RfcDestinationManager.GetDestination(getParameters());
                var fnc = d.Repository.CreateFunction(repository);
                var table = fnc.GetTable(0);

                for (int i = 0; i < table.ElementCount; i++)
                {
                    var elm = table.GetElementMetadata(i);
                    ret.Add(elm.Name, GetDataType(elm.DataType));
                }

                cachedHeaders.Add(repository, ret);
            }

            return cachedHeaders[repository];
        }

        public new Dictionary<string, object> GetDefaultRepositories()
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            var d = RfcDestinationManager.GetDestination(getParameters());
            var fnc = d.Repository.CreateFunction(Function);
            //fnc.Invoke(d);

            for (int i = 0; i < fnc.ElementCount; i++)
            {
                if (fnc.GetElementMetadata(i).DataType == RfcDataType.TABLE)
                {
                    var table = fnc[i].GetTable();
                    ret.Add(table.Metadata.Name, table.Metadata.Name);
                }
            }

            return ret;
        }

        public new bool IsDirectlyBindable
        {
            get { return true; }
        }

        public new bool Test(out string details)
        {

            try
            {
                var d = RfcDestinationManager.GetDestination(getParameters());
                var fnc = d.Repository.CreateFunction(Function);
            }
            catch
            {
                details = "Failed. Please check your parameters.";
                return false;
            }

            details = "OK";
            return true;
        }

        public new IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class
        {
            return _getdata<T>(repository, attributes.ToArray()).AsQueryable();
        }

        private IEnumerable<T> _getdata<T>(string repository, string[] attributes)
        {
            var attrlst = GetHeaders(repository).Keys.ToList();
            var rep = (string)GetDefaultRepositories()[repository];

            var d = RfcDestinationManager.GetDestination(getParameters());
            var fnc = d.Repository.CreateFunction(Function);
            fnc.Invoke(d);

            var sapTable = fnc.GetTable(repository);

            var enm = sapTable.GetEnumerator();
            while (enm.MoveNext())
            {
                yield return ((IRfcStructure)enm.Current).Select(f => f.GetValue()).ToArray().ToObject<T>(attributes);
            }
        }

    }
}

