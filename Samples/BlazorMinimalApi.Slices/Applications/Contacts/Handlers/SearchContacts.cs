using BlazorMinimalApis.Slices.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Slices.Lib;
using Microsoft.AspNetCore.Mvc;
using BlazorMinimalApis.Slices.Applications.Contacts.Views;

namespace BlazorMinimalApis.Slices.Applications.Contacts.Handlers;

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