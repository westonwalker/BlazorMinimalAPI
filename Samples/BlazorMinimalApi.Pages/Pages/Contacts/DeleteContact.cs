using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class DeleteContact : PageController, IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/contacts/{id}/delete", Delete)
			.WithName("Contacts.Delete");
	}

	public IResult Delete(int id)
	{
		var contact = Database.Contacts.First(x => x.Id == id);
		Database.Contacts.Remove(contact);
		return Redirect($"/contacts");
	}
}