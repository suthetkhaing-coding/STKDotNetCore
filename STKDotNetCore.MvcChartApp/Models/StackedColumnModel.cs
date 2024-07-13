namespace STKDotNetCore.MvcChartApp.Models;


public class StackedColumnModel
{
    public List<GroupModel> Series { get; set; }
    public List<string> Categories { get; set; }
}

public class GroupModel
{
    public string Name { get; set; }
    public List<int> Data { get; set; }
}
