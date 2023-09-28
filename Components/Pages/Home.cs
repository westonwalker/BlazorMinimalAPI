using CustomLivewireRouter.Data;
using CustomLivewireRouter.Lib;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace CustomLivewireRouter.Components.Pages.Contacts;

public class HomeHandler
{
    public IResult Render()
    {
        return new RazorComponentResult<Home>();
    }
}