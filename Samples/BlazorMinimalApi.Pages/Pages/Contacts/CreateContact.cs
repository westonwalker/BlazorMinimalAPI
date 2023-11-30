using System.ComponentModel.DataAnnotations;
using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Lib.Session;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class CreateContact : XPage
{
	public CreateContactForm Form = new();

	public IResult Get()
	{
		Form = new CreateContactForm();
		return Page<_CreateContact>();
	}

	public IResult Post([FromForm] CreateContactForm form, SessionManager Session)
	{
		if (Validate(form).HasErrors)
		{
			Form = form;
			return Page<_CreateContact>();
		}
		var newContact = new CreateContactMapper().FormToContact(form);
		newContact.Id = Database.Contacts.Count() + 1;
		Database.Contacts.Add(newContact);

		Session.SetFlash("success", "Contact successfully added.");
		return Redirect("/contacts/create");
    }
}

public class CreateContactForm
{
	[Required] public string Name { get; set; }
	[Required, EmailAddress] public string Email { get; set; }
	[Required] public string City { get; set; }
	[Required, Phone] public string Phone { get; set; }
}


[Mapper]
public partial class CreateContactMapper
{
	public partial CreateContactForm ContactToForm(Contact contact);
	public partial Contact FormToContact(CreateContactForm contact);
}