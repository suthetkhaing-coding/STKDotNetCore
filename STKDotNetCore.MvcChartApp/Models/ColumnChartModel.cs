namespace STKDotNetCore.MvcChartApp.Models
{
    public class ColumnChartModel
    {
        public List<ColumnChartSeriesModel> Series { get; set; }
        public List<string> Categories { get; set; }
    }

    public class ColumnChartSeriesModel
    {
        public string Name { get; set; }
        public List<int> Data { get; set; }
    }
}
