using Microsoft.AspNetCore.Builder;

namespace BlazorMinimalApis.Slices.Lib;

public interface IRouteDefinition
{
	void Map(WebApplication app);
}