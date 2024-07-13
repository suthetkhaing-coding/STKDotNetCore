namespace STKDotNetCore.MvcChartApp.Models;

public class GroupBarModel
{
    public List<GroupBarDataModel> BarGroup { get; set; }
    public List<int> Categories { get; set; }
}

public class GroupBarDataModel
{
    public List<int> data { get; set; }
}
