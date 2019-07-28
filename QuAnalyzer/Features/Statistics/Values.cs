namespace QuAnalyzer.Features.Statistics
{
    public class Values
    {
        public string FrequencyStr { get { return Category + " [" + Frequency + "]"; } }
        public object SelectedItem { get; set; }
        public string Category { get; set; }
        public int Frequency { get; set; }
    }
}
