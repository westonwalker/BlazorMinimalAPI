namespace BlazorMinimalApis.Lib.Views;

public class PageState
{
    public Dictionary<string, string> QueryString { get; set; }
    public Uri Uri { get; set; }
    public Route Route { get; set; }
}
