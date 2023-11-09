using Microsoft.AspNetCore.Builder;

namespace BlazorMinimalApis.Pages.Lib;

public interface IRouteDefinition
{
	void Map(WebApplication app);
}