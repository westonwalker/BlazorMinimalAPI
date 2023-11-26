using BlazorMinimalApis.Features.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Features.Lib;
using BlazorMinimalApis.Features.Features.Contacts.Views;

namespace BlazorMinimalApis.Features.Features.Contacts.Handlers;

public class ListContacts : XHandler
{

    public IResult List(HttpContext context)
    {
        var parameters = new { Database.Contacts };
        return View<List>(parameters);
    }
}