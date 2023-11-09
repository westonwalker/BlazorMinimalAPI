using System.ComponentModel.DataAnnotations;
using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Lib.Session;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class CreateContact : PageController, IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/contacts/create", Create)
			.WithName("Contacts.Create");
		app.MapPost("/contacts/create", Store)
			.WithName("Contacts.Store");
	}

	public IResult Create()
	{
		var model = new { Form = new CreateContactForm() };
		return Page<CreateContactPage>(model);
	}

	public IResult Store([FromForm] CreateContactForm form, SessionManager Session)
	{
		if (Validate(form).HasErrors)
		{
			var model = new { Form = form };
			return Page<CreateContactPage>(model);
		}
		var newContact = new CreateContactMapper().FormToContact(form);
		newContact.Id = Database.Contacts.Count() + 1;
		Database.Contacts.Add(newContact);

		Session.SetFlash("success", "Contact successfully added.");

		return Redirect("/contacts/create");
	}
	
	public class CreateContactForm
	{
		[Required] public string Name { get; set; }
		[Required, EmailAddress] public string Email { get; set; }
		[Required] public string City { get; set; }
		[Required, Phone] public string Phone { get; set; }
	}
}


[Mapper]
public partial class CreateContactMapper
{
	public partial CreateContact.CreateContactForm ContactToForm(Contact contact);
	public partial Contact FormToContact(CreateContact.CreateContactForm contact);
}