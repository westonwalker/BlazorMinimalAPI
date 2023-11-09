using System.ComponentModel.DataAnnotations;
using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class EditContact : PageController, IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/contacts/{id:int}/edit", Edit)
			.WithName("Contacts.Edit");
		app.MapPost("/contacts/{id:int}/edit", Update)
			.WithName("Contacts.Update");
	}

	public IResult Edit(int id)
	{
		var record = Database.Contacts.Where(x => x.Id == id).First();
		var form = new EditContactMapper().ContactToForm(record);
		var model = new { Form = form };
		return Page<EditContactPage>(model);
	}

	public IResult Update(int id, [FromForm] EditContactForm form)
	{
		var validation = Validate(form);
		if (validation.HasErrors)
		{
			var model = new { Form = form };
			return Page<EditContactPage>(model);
		}
		var oldContact = Database.Contacts.First(x => x.Id == id);
		var newContact = new EditContactMapper().FormToContact(form);
		newContact.Id = oldContact.Id;
		Database.Contacts.Add(newContact);
		Database.Contacts.Remove(oldContact);

		return Redirect($"/contacts/{newContact.Id}/edit");
	}

	public class EditContactForm
	{
		public int Id { get; set; }
		[Required] public string Name { get; set; }
		[Required, EmailAddress] public string Email { get; set; }
		[Required] public string City { get; set; }
		[Required, Phone] public string Phone { get; set; }
	}
}

[Mapper]
public partial class EditContactMapper
{
	public partial EditContact.EditContactForm ContactToForm(Contact contact);
	public partial Contact FormToContact(EditContact.EditContactForm contact);
}