namespace STKDotNetCore.MvcChartApp.Models
{
    public class MixedLineColumnChartModel
    {
        public string Title { get; set; }
        public List<LineColumnChartSerieModel> Series { get; set; }
        public List<string> Labels { get; set; }
    }

    public class LineColumnChartSerieModel
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public List<int> data { get; set; }
    }
}
