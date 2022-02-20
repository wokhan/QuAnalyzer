using Xunit;

namespace QuAnalyzer.Features.Comparison.Comparers.Tests
{
    public class DynamicComparerTests
    {
        private class MyClassA
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
            public string Prop3 { get; set; }
        }

        private class MyClassB
        {
            public string PropA { get; set; }
            public int PropB { get; set; }
        }

        private DynamicComparer<MyClassA, MyClassB> comparer;

        [Fact()]
        public void CompareTest()
        {
            var objectA = new MyClassA { Prop1 = "Test", Prop2 = 3, Prop3 = "XXX" };
            var objectB = new MyClassB { PropA = "Test", PropB = 3 };

            comparer = new DynamicComparer<MyClassA, MyClassB>(
                new[] { nameof(MyClassA.Prop1), nameof(MyClassA.Prop2) },
                new[] { nameof(MyClassB.PropA), nameof(MyClassB.PropB) }
            );
            var result = comparer.Compare(objectA, objectB);

            Assert.Equal(0, result);
        }
    }
}