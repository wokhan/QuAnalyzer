using QuAnalyzer.DataProviders.Attributes;
using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Linq.Dynamic;
using System.Runtime.Serialization;
using System.Net.NetworkInformation;
using System.ComponentModel;
using QuAnalyzer.Helpers;
using System.Diagnostics;
using QuAnalyzer.UI.Windows;

namespace QuAnalyzer.DataProviders.Bases
{
    public class DataProviderStruct
    {
        public string Copyright { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string IconPath { get; set; }
        public Type Type { get; set; }

        public bool IsExternal { get; set; }
    }

    public class DataProviderMemberStruct : NotifierHelper
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type MemberType { get; set; }
        public bool IsFile { get; set; }
        public string FileFilter { get; set; }
        public ProviderParameterAttribute.MethodDel ValuesGetter { get; set; }
        public bool HasValuesGetter { get { return ValuesGetter != null; } }
        public Dictionary<string, string> Values { get { return ValuesGetter(); } }
        public string ExclusionGroup { get; set; }
        public object ValueWrapper
        {
            get { return Container.Type.GetProperty(Name).GetValue(Container); }
            set { Container.Type.GetProperty(Name).SetValue(Container, value); NotifyPropertyChanged("ValueWrapper"); }
        }

        public IDataProvider Container { get; internal set; }
        public bool IsActive { get; internal set; }

    }

    [DataContract]
    public class DataProvider : AbstractDataProvider, IDataProvider
    {
        [DataMember]
        public string Name { get; set; }

        private List<string> _selectedGroups = new List<string>();
        [DataMember]
        public List<string> SelectedGroups
        {
            get { return _selectedGroups; }
            set { _selectedGroups = value; }
        }

        public List<IGrouping<string, DataProviderMemberStruct>> ExpParameters { get { return GetExpParameters(this); } }

        public DataProviderStruct ProviderTypeInfo { get { return DataProvider.AllProviders.Single(d => d.Type == this.GetType()); } }

        public Type Type { get { return this.GetType(); } }

        public string Host { get { return "localhost"; } }

        private Dictionary<string, string> _monitoringTypes = new Dictionary<string, string> {
            { "COUNTALL", "Count" },
            { "CHECKVAL", "Retrieve attributes values" },
            { "PERF", "Performance check" },
            { "PING", "Server ping" }
            //{ "Any modification", "CHECKMOD" },
        };

        public Dictionary<string, string> MonitoringTypes { get { return _monitoringTypes; } }

        public bool IsDirectlyBindable { get { return false; } }

        private Dictionary<string, object> _repositories = new Dictionary<string, object>();
        [DataMember]
        public Dictionary<string, object> Repositories
        {
            get { return _repositories; }
            set { _repositories = value.OrderBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value); }
        }

        public string[] RepositoriesColumnNames
        {
            get { return new[] { "Key", "Value" }; }
            set { }
        }

        public void RemoveCachedHeaders(string repository)
        {
            return;
        }

        public string GetFormattedValue(object src, object c)
        {
            /*if (CustomFormats != null && CustomFormats.ContainsKey(GetFormatKey(null, c)))
            {
                return ((IFormattable)src).ToString(CustomFormats[GetFormatKey(null, c)], null);
            }
            else*/
            {
                return src.ToString();
            }
        }

        public List<IGrouping<string, DataProviderMemberStruct>> GetExpParameters()
        {
            return GetExpParameters(this);
        }

        public static List<IGrouping<string, DataProviderMemberStruct>> GetExpParameters(IDataProvider prv)
        {
            var tr = prv.Type.GetProperties();
            return tr.Where(t => t.GetCustomAttributes<ProviderParameterAttribute>(true).Any())
                    .Select(p =>
                    {
                        var attr = p.GetCustomAttribute<ProviderParameterAttribute>(true);
                        return new { Pos = attr.Position, Prov = new DataProviderMemberStruct() { IsActive = prv.SelectedGroups.Contains(attr.ExclusionGroup), Container = prv, Name = p.Name, Description = attr.Description, MemberType = p.PropertyType, IsFile = attr.IsFile, FileFilter = attr.FileFilter, ExclusionGroup = attr.ExclusionGroup, ValuesGetter = attr.Method } };
                    })
                    .Where(t => t.Prov.Description != null)
                    .OrderBy(t => t.Pos)
                    .ThenBy(t => t.Prov.Description)
                    .Select(t => t.Prov)
                    .GroupBy(c => c.ExclusionGroup ?? null)
                    .ToList();
        }


        private static IEnumerable<DataProviderStruct> _cachedProviders = null;
        public static IEnumerable<DataProviderStruct> AllProviders
        {
            get
            {
                if (_cachedProviders == null)
                {
                    var to = Assembly.GetExecutingAssembly()
                                     .GetTypes()
                                     .Where(t => t.IsClass && typeof(IExposedDataProvider).IsAssignableFrom(t))
                                     .Select(t => new { External = false, Type = t, Attributes = t.GetCustomAttributes<DataProviderAttribute>(true).SingleOrDefault() });

                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\providers"))
                    {
                        try
                        {
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\providers");
                        }
                        catch { }
                    }
                    else
                    {
                        var external = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\providers", "*.dll")
                                                .SelectMany(f =>
                                                {
                                                    try
                                                    {
                                                        return Assembly.LoadFrom(f).GetTypes();
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        return new Type[0];
                                                    }
                                                });

                        to = to.Concat(external.Where(t => t.IsClass && typeof(IExposedDataProvider).IsAssignableFrom(t))
                               .Select(t => new { External = true, Type = t, Attributes = t.GetCustomAttributes<DataProviderAttribute>(true).SingleOrDefault() }));
                    }

                    var tb = to.Select(t => new DataProviderStruct() { IsExternal = t.External, Description = t.Attributes.Description, Name = t.Attributes.Name, Category = t.Attributes.Category, Copyright = t.Attributes.Copyright, IconPath = t.Attributes.Icon, Type = t.Type }).ToArray();

                    _cachedProviders = tb;
                }

                return _cachedProviders;
            }
        }


        public string GetFormatKey(List<object> srcAttributesCollection, object srcAttribute)
        {
            return null;
        }

        public Dictionary<string, Type> GetHeaders(string repository = null)
        {
            return null;
        }

        public override sealed IQueryable<dynamic> GetData(string repository = null, IEnumerable<string> attributes = null, Dictionary<string, Type> keys = null)
        {
            var th = ((IDataProvider)this).GetTypedClass(repository);
            Type xt;
            /*if (keys != null)
            {
                lock (cachedTypes)
                {
                    var kx = keys.Select(k => k.Key).Aggregate((a, b) => a + "_" + b);
                    var cachekey = this.GetHashCode() + "_" + repository + kx; 
                    if (!cachedTypes.TryGetValue(cachekey, out xt))
                    {
                        xt = DynamicExpression.CreateClass(keys.Select(t => new DynamicProperty(t.Key, t.Value)));
                        cachedTypes.Add(cachekey, xt);
                    }
                }
            }
            else*/
            {
                xt = typeof(string);
            }
            var m = this.GetType().GetMethod("GetTypedData").MakeGenericMethod(th, xt);

            return (IQueryable<dynamic>)m.Invoke(this, new object[] { repository, attributes });
        }

        public IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class
        {
            return null;
        }

        public Dictionary<string, object> GetDefaultRepositories()
        {
            return null;
        }

        public IEnumerable GetDataDirect(string repository = null, IEnumerable<string> attributes = null)
        {
            return null;
        }

        public long Monitor(string key, string repository, out object data, string filter = null, string attribute = null)
        {
            if (!MonitoringTypes.ContainsKey(key))
            {
                throw new ArgumentException("The specified monitoring type does not exist for the current provider.");
            }

            switch (key)
            {
                case "PING":
                    data = null;
                    return ((IDataProvider)this).Ping(Host);

                case "PERF":
                    data = null;
                    return ((IDataProvider)this).PerfTest(repository);

                case "CHECKVAL":
                    if (String.IsNullOrEmpty(attribute))
                    {
                        throw new ArgumentNullException("attribute");
                    }
                    var q = ((IDataProvider)this).GetData(repository);
                    if (!String.IsNullOrEmpty(filter))
                    {
                        q = q.Where(filter);
                    }
                    data = ((IEnumerable<dynamic>)q.Select("new(" + attribute + ")")).ToList();
                    return ((IList)data).Count;

                case "COUNTALL":
                    data = null;
                    var qc = ((IDataProvider)this).GetData(repository);
                    if (!String.IsNullOrEmpty(filter))
                    {
                        qc = qc.Where(filter);
                    }
                    return qc.Count();

                default:
                    data = null;
                    return 0;
            }

        }

        private static Dictionary<string, Type> cachedTypes = new Dictionary<string, Type>();
        public Type GetTypedClass(string repository)
        {
            Type ret;
            lock (cachedTypes)
            {
                var cachekey = this.GetHashCode() + "_" + repository;
                if (!cachedTypes.TryGetValue(cachekey, out ret))
                {
                    var properties = new[] { new DynamicProperty("__UID", typeof(long)) }.Concat(((IDataProvider)this).GetHeaders(repository).Select(t => new DynamicProperty(t.Key, t.Value)));

                    ret = System.Linq.Dynamic.DynamicExpression.CreateClass(properties);

                    cachedTypes.Add(cachekey, ret);
                }
            }

            return ret;
        }


        protected override long Count(string repository = null)
        {
            return ((IDataProvider)this).GetData(repository).Count();
        }

        public long GetMTU(string host)
        {
            Ping pong = new System.Net.NetworkInformation.Ping();
            PingReply ret = null;

            int startsize = 2000;
            int smaller = 0;
            int higher = 4000;

            bool keepgoing = true;
            while (keepgoing)
            {
                ret = pong.Send(host, 5000, new byte[startsize], new PingOptions() { DontFragment = true });

                if (ret.Status == IPStatus.PacketTooBig)
                {
                    higher = startsize;
                    startsize = higher - ((higher - smaller) / 2);
                }

                if (ret.Status == IPStatus.Success)
                {
                    smaller = startsize;
                    startsize = smaller + ((higher - smaller) / 2);
                }


                if (smaller == higher - 1)
                {
                    keepgoing = false;
                    startsize = smaller;
                }
            }

            return startsize;
        }

        public long PerfTest(string repository)
        {
            var sw = Stopwatch.StartNew();
            ((IDataProvider)this).GetData(repository).ToList();
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        public long Ping(string host)
        {
            Ping pong = new System.Net.NetworkInformation.Ping();

            return pong.Send(host).RoundtripTime;
        }


        public double MeasureBandwidth(string host)
        {
            long optsize = GetMTU(host);

            Ping pong = new System.Net.NetworkInformation.Ping();
            PingReply ret = null;

            ret = pong.Send(host, 5000, new byte[optsize * 10], new PingOptions() { DontFragment = false });

            if (ret.Status == IPStatus.Success)
            {
                return (optsize / ret.RoundtripTime / 10) * 1000;
            }
            else
            {
                return 0;
            }
        }


        public bool Test(out string details)
        {
            details = "Not implemented";
            return false;
        }

        public void OpenEditor()
        {
            var editor = new ProvidersEditor(this);
            editor.Show();
            editor.Activate();
        }
    }
}
