using Microsoft.AspNetCore.Builder;

namespace BlazorMinimalApis.Features.Lib;

public interface IRouteDefinition
{
	void Map(WebApplication app);
}