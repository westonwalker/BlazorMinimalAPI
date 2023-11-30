using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class ListContacts : XPage
{
    public List<Contact> Contacts = new();

    public IResult Get(HttpContext context)
	{
		Contacts = Database.Contacts;
		return Page<_ListContacts>();
	}

	public IResult GetSearch([FromQuery] string ContactSearch)
	{
		Contacts = Database.Contacts
			.Where(x => x.Name.Contains(ContactSearch, StringComparison.OrdinalIgnoreCase))
			.ToList();

		return Page<_SearchContacts>();
	}
}