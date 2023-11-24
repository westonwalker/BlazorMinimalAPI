using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Home;

public class Home : XPage 
{
    public override void Map(WebApplication app)
    {
        app.MapGet("/", Index);
        app.MapGet("/random-number", RandomNumber);
    }
    
    public IResult Index()
    {
        return Page<HomePage>();
    }

    public IResult RandomNumber()
    {
        Random rnd = new Random();
        var num = rnd.Next();
        return Page<RandomNumberPartial>(new { Num = num });
    }
}