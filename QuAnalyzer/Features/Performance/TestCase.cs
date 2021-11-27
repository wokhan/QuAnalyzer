using System;
using System.Collections;
using System.Collections.Generic;

namespace QuAnalyzer.Features.Performance;

public class TestCase
{
    public string Name { get; set; }
    public Func<IList<Dictionary<string, string>>, Dictionary<string, long>, IEnumerable> GetData { get; set; }
    public string Repository { get; set; }
}
