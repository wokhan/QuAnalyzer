using System.Collections.Generic;

namespace QuAnalyzer.Logic.Contracts
{
    public interface IDataComparer
    {
        string Name { get; set; }
        string SourceName { get; set; }
        string TargetName { get; set; }
        IList<string> SourceHeaders { get; set; }
        IList<string> TargetHeaders { get; set; }
        IList<string> SourceKeys { get; set; }
        IList<string> TargetKeys { get; set; }
    }
}
