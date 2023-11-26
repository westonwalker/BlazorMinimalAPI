using BlazorMinimalApis.Features.Data;
using BlazorMinimalApis.Lib.Routing;

namespace BlazorMinimalApis.Features.Features.Contacts.Handlers;

public class ListContactsApi : XHandler
{
	public IResult List()
	{
		var data = new { Contacts = Database.Contacts };
		return Results.Ok(data);
	}
}
