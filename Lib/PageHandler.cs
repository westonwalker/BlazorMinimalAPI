using CustomLivewireRouter.Components;
using CustomLivewireRouter.Components.Pages.Contacts;
using Microsoft.AspNetCore.Components.Endpoints;

namespace CustomLivewireRouter.Lib;

// todo
public abstract class PageHandler
{
    public virtual IResult Component<TComponent>(object Params)
    {
        return new RazorComponentResult(typeof(TComponent), Params);
    }

    //public IResult Render<TComponent>()
    //{

    //    return new RazorComponentResult<Create>(
    //        new { Model = InitialModelState() }
    //    );
    //    return new RazorComponentResult<SparkRouter>(new { ComponentType = typeof(TComponent), Parameters = parameters });
    //}

    //public virtual void InitialModelState()
    //{

    //}
}
