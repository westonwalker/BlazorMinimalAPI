using BlazorMinimalApis.Lib.Routing;
using Microsoft.AspNetCore.Builder;

namespace BlazorMinimalApis.Pages.Lib;

public static class RegisterRoutesExtension
{
	public static void RegisterRoutes(this WebApplication app)
	{
		var endpointDefinitions = typeof(Program).Assembly
			.GetTypes()
			.Where(t => t.IsAssignableTo(typeof(XPage))
			            && !t.IsAbstract && !t.IsInterface)
			.Select(Activator.CreateInstance)
			.Cast<XPage>();

		foreach (var endpointDef in endpointDefinitions)
		{
			endpointDef.Map(app);
		}
	}
}