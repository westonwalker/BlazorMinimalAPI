using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class ContactsTable : XController, IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/contacts/search", Search)
			.WithName("Contacts.Search");
	}

	public IResult Search([FromQuery] string ContactSearch)
	{
		var contacts = Database.Contacts
			.Where(x => x.Name.Contains(ContactSearch, StringComparison.OrdinalIgnoreCase))
			.ToList();
		var model = new { Contacts = contacts };
		return View<ContactsTablePartial>(model);
	}
}