using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Components.Pages.Contacts;


public class ListContactsHandler : PageEndpoint
{
    public IResult Render(HttpContext context)
    {
        return Component<List>(new { Model = InitialModelState() });
	}

    public IResult Search([FromQuery] string ContactSearch)
    {
        var contacts = Database.Contacts
            .Where(x => x.Name.Contains(ContactSearch, StringComparison.OrdinalIgnoreCase))
            .ToList();
        var parameters = new { Contacts = contacts };
        return Component<ContactsSearchTable>(parameters);
    }

    private static ContactModel InitialModelState()
    {
        var model = new ContactModel();
        model.Contacts = Database.Contacts;
        return model;
    }
}

public class ContactModel
{
    public List<Contact> Contacts { get; set; } = new();
}
