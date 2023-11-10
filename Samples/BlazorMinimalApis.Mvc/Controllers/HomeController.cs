using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Mvc.Views.Home;

namespace BlazorMinimalApis.Mvc.Controllers;

public class HomeController : PageController
{
	public void Map(WebApplication app)
	{
		app.MapGet("/", Index);
		app.MapGet("/random-number", RandomNumber);
	}

	public IResult Index()
	{
		return Page<Home>();
	}

	public IResult RandomNumber()
	{
		Random rnd = new Random();
		var num = rnd.Next();
		return Page<_RandomNumber>(new { Num = num });
	}
}
