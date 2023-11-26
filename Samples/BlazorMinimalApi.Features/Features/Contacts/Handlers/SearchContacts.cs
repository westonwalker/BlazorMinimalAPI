using BlazorMinimalApis.Features.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Features.Lib;
using Microsoft.AspNetCore.Mvc;
using BlazorMinimalApis.Features.Features.Contacts.Views;

namespace BlazorMinimalApis.Features.Features.Contacts.Handlers;

public class SearchContacts : XHandler
{
    public IResult Search([FromQuery] string ContactSearch)
    {
        var contacts = Database.Contacts
            .Where(x => x.Name.Contains(ContactSearch, StringComparison.OrdinalIgnoreCase))
            .ToList();
        var model = new { Contacts = contacts };
        return View<ContactsTable>(model);
    }
}