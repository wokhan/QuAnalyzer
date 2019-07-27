using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.Features.Performance
{
    public class TestCase
    {
        public string Name { get; set; }
        public IDataProvider Provider { get; set; }
    }
}