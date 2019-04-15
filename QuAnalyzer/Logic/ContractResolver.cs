using Wokhan.Data.Providers.Bases;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace QuAnalyzer.Logic
{
    class ContractResolver
    {

       // Used at deserialization
        // Allows users to map xsi:type name to any Type 
        public Type ResolveName(string typeName, string typeNamespace, DataContractResolver knownTypeResolver)
       {
           return DataProvider.AllProviders.SingleOrDefault(a => a.Type.Namespace == typeNamespace && a.Type.Name == typeName).Type;
       }

       // Used at serialization
        // Maps any Type to a new xsi:type representation
        public void ResolveType(Type dataContractType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            typeName = new XmlDictionaryString(XmlDictionary.Empty, dataContractType.Name, 0);
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, dataContractType.Namespace, 0);
        }
    }
}
