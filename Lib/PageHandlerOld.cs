using CustomLivewireRouter.Components;
using CustomLivewireRouter.Components.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Endpoints;

namespace CustomLivewireRouter.Lib;

public static class PageHandlerOld
{
    public static IResult Render<TComponent>() where TComponent : IComponent
    {
        var parameters = new Dictionary<string, object>();
        return new RazorComponentResult<SparkRouter>(new { ComponentType = typeof(TComponent), Parameters = parameters });
    }

    public static IResult Render<TComponent>(object Model) where TComponent : IComponent
	{
        var parameters = new Dictionary<string, object>();
        parameters.Add("Model", Model);
        return new RazorComponentResult<SparkRouter>(new { ComponentType = typeof(TComponent), Parameters = parameters });
    }

    public static IResult Render<TComponent>(object Model, Type Layout) where TComponent : IComponent
    {
        var parameters = new Dictionary<string, object>();
        parameters.Add("Model", Model);
        parameters.Add("Layout", Layout);
        return new RazorComponentResult<SparkRouter>(new { ComponentType = typeof(TComponent), Parameters = parameters });
    }
}
