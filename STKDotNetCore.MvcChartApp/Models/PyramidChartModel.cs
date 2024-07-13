namespace STKDotNetCore.MvcChartApp.Models
{
    public class PyramidChartModel
    {
        public List<PyramidChartSeriesDataModel> Series { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Categories { get; set; }
    }

    public class PyramidChartSeriesDataModel
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }
}
