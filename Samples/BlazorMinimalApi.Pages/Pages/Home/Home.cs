using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Home;

public class Home : XController, IRouteDefinition
{
    public void Map(WebApplication app)
    {
        app.MapGet("/", Index);
        app.MapGet("/random-number", RandomNumber);
    }
    
    public IResult Index()
    {
        return View<HomePage>();
    }

    public IResult RandomNumber()
    {
        Random rnd = new Random();
        var num = rnd.Next();
        return View<RandomNumberPartial>(new { Num = num });
    }
}