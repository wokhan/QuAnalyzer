using QuAnalyzer.DataProviders.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuAnalyzer.DataProviders.Contracts
{
    public interface IDataProvider
    {
        Type GetTypedClass(string repository);

        string GetFormatKey(List<object> srcAttributesCollection, object srcAttribute);

        Type Type { get; }

        string Host { get; }

        bool Test(out string details);

        List<string> SelectedGroups { get; }

        void RemoveCachedHeaders(string repository);

        Dictionary<string, Type> GetHeaders(string repository = null);

        IQueryable<dynamic> GetData(string repository = null, IEnumerable<string> attributes = null, Dictionary<string, Type> keys = null);

        IQueryable<T> GetTypedData<T, TK>(string repository, IEnumerable<string> attributes) where T : class;

        Dictionary<string, object> GetDefaultRepositories();

        IEnumerable GetDataDirect(string repository = null, IEnumerable<string> attributes = null);

        List<IGrouping<string, DataProviderMemberStruct>> GetExpParameters();

        List<IGrouping<string, DataProviderMemberStruct>> ExpParameters { get; }

        bool IsDirectlyBindable { get; }

        Dictionary<string, object> Repositories { get; set; }

        Dictionary<string, string> MonitoringTypes { get; }

        string[] RepositoriesColumnNames { get; set; }

        DataProviderStruct ProviderTypeInfo { get; }

        string Name { get; set; }

        long Monitor(string key, string repository, out object data, string filter = null, string attribute = null);

        long Ping(string host);

        long PerfTest(string repository);

        void OpenEditor();
    }
}
