using BlazorMinimalApis.Slices.Data;
using BlazorMinimalApis.Lib.Routing;

namespace BlazorMinimalApis.Slices.Applications.Contacts.Handlers;

public class ListContactsApi : XHandler
{
	public IResult List()
	{
		var data = new { Contacts = Database.Contacts };
		return Results.Ok(data);
	}
}
