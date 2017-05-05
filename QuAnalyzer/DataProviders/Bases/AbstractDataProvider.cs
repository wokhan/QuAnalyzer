using QuAnalyzer.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuAnalyzer.DataProviders.Bases
{

    [DataContract]
    public abstract class AbstractDataProvider
    {

        protected abstract long Count(string repository = null);

        public abstract IQueryable<dynamic> GetData(string repository = null, IEnumerable<string> attributes = null, Dictionary<string, Type> keys = null);
        
    }
}
