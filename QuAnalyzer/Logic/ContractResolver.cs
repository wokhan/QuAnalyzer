using QuAnalyzer.DataProviders.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuAnalyzer.Logic
{
    class ContractResolver
    {

       // Used at deserialization
        // Allows users to map xsi:type name to any Type 
        public override Type ResolveName(string typeName, string typeNamespace, DataContractResolver knownTypeResolver)
       {
           return DataProvider.GetAllProviders().SingleOrDefault(a => a.Type.Namespace == typeNamespace && a.Type.Name == typeName).Type;
       }

       // Used at serialization
        // Maps any Type to a new xsi:type representation
        public override void ResolveType(Type dataContractType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            typeName = new XmlDictionaryString(XmlDictionary.Empty, dataContractType.Name, 0);
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, dataContractType.Namespace, 0);
        }
    }
}
