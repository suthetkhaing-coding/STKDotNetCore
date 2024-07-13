namespace STKDotNetCore.MvcChartApp.Models
{
    public class BasicSlopeChartModel
    {
        public List<string> Categories { get; set; }
        public List<SeriesDataModel> Series { get; set; }
    }

    public class SeriesDataModel
    {
        public string Name { get; set; }
        public List<DataPointModel> Data { get; set; }
    }

    public class DataPointModel
    {
        public string Jan { get; set; }
        public int Feb { get; set; }
    }
}
