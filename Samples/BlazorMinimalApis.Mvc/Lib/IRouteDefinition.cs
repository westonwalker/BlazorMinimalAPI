using Microsoft.AspNetCore.Builder;

namespace BlazorMinimalApis.Mvc.Lib;

public interface IRouteDefinition
{
	void Map(WebApplication app);
}