namespace STKDotNetCore.MvcChartApp.Models
{
    public class MultiSeriesTimelineChartModel
    {
        public string Name { get; set; }
        public List<TimelinesModel> Timelines { get; set; }
    }

    public class TimelinesModel
    {
        public string Title { get; set; }
        public List<DateTime> DateTimes { get; set; }
    }
}
