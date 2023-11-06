using BlazorMinimalApis.Lib.Routing;

namespace BlazorMinimalApis.Pages.Home;

public class HomeHandler : PageHandler
{
    public IResult Index()
    {
        return Page<Home>();
    }
}