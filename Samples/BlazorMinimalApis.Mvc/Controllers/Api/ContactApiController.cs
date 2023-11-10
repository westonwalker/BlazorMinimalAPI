using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Mvc.Data;

namespace BlazorMinimalApis.Mvc.Controllers.Api;

public class ContactApiController : ApiController
{
	public IResult List()
	{
		var data = new { Contacts = Database.Contacts };
		return Results.Ok(data);
	}
}
