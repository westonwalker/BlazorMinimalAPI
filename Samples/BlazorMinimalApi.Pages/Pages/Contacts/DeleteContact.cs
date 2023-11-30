using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class DeleteContact : XPage
{
	public IResult Get(int id)
	{
		var contact = Database.Contacts.First(x => x.Id == id);
		Database.Contacts.Remove(contact);
		return Redirect($"/contacts");
	}
}