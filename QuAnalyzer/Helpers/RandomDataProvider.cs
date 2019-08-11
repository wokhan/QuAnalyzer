using QuAnalyzer.Features.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wokhan.Data.Providers.Attributes;
using Wokhan.Data.Providers.Bases;
using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Helpers
{
    [DataProvider(Category = "Demo", Name = "Random data", Description = "Randomly generated data following simple settings.", Copyright = "Developed by Wokhan Solutions")]
    public class RandomDataProvider : AbstractDataProvider, IExposedDataProvider
    {
        [ProviderParameter("Number of items")]
        public int ItemsCount { get; set; } = 10000;

        [ProviderParameter("Keep data cached for the current session")]
        public bool KeepCache { get; set; } = true;

        //[ProviderParameter("Custom columns (will use random columns if left empty)")]
        //public Dictionary<string, Type> Columns { get; set; }
        public override bool AllowCustomRepository => false;

        private static string GetRandomString(Random rnd, int minLength, int maxLength)
        {
            var buffer = new byte[rnd.Next(minLength, maxLength)];
            rnd.NextBytes(buffer);
            return UTF8Encoding.UTF8.GetString(buffer);
        }



        private Random rnd = new Random();

        private Dictionary<string, object> _defaultRepositories = new Dictionary<string, object>
        {
            ["Address book"] = "",
            ["Random numbers"] = ""
        };
        private Dictionary<string, Type> repositoryTypes = new Dictionary<string, Type>
        {
            ["Address book"] = typeof(AddressBookData),
            ["Random numbers"] = typeof(RandomDoubleData)
        };

        public override Dictionary<string, object> GetDefaultRepositories()
        {
            return _defaultRepositories;
        }

        public override Type GetDataType(string repository) => repositoryTypes[repository];

        public override IQueryable<T> GetQueryable<T>(string repository, IList<Dictionary<string, string>> values = null, Dictionary<string, long> statisticsBag = null)
        {
            var type = GetDataType(repository);
            return Enumerable.Range(0, ItemsCount)
                             .Select(i => (T)Activator.CreateInstance(type, rnd, i))
                             .AsQueryable();
        }

        public override void InvalidateColumnsCache(string repository)
        {

        }

        public override bool Test(out string details)
        {
            details = "OK";
            return true;
        }

        public override List<ColumnDescription> GetColumns(string repository, IList<string> names = null)
        {
            return ColumnDescription.FromType(GetDataType(repository));
        }

        public class AddressBookData
        {
            [ColumnDescription(IsKey = true)]
            public int Group { get; set; }

            [ColumnDescription(IsKey = true)]
            public string Name { get; set; }

            public string PhoneNumber { get; set; }

            public AddressBookData(Random rnd, int i)
            {
                Group = i % 20;
                Name = "Test #" + i;
                PhoneNumber = GetRandomString(rnd, 10, 10);
            }
        }

        private class RandomDoubleData
        {
            [ColumnDescription(IsKey = true)]
            public int Id { get; set; }
            public double Number { get; set; }

            public RandomDoubleData(Random rnd, int i)
            {
                Id = i;
                Number = rnd.NextDouble();
            }
        }
    }
}
