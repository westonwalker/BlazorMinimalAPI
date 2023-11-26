using BlazorMinimalApis.Slices.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Slices.Lib;
using BlazorMinimalApis.Slices.Applications.Contacts.Views;

namespace BlazorMinimalApis.Slices.Applications.Contacts.Handlers;

public class ListContacts : XHandler
{

    public IResult List(HttpContext context)
    {
        var parameters = new { Database.Contacts };
        return View<List>(parameters);
    }
}