namespace STKDotNetCore.MvcChartApp.Models
{
    public class StackedBarChartModel
    {
        public List<StackedBarSeriesModel> Series { get; set; }
        public List<int> Categories { get; set; }
    }

    public class StackedBarSeriesModel
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }
}
