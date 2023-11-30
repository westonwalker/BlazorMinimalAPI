using System.ComponentModel.DataAnnotations;
using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class EditContact : XPage
{
	public EditContactForm Form = new();
	public int Id;

	public IResult Get(int id)
	{
		var record = Database.Contacts.Where(x => x.Id == id).First();
		Form = new EditContactMapper().ContactToForm(record);
		Id = id;
		return Page<_EditContact>();
	}

	public IResult Post(int id, [FromForm] EditContactForm form)
	{
		var validation = Validate(form);
		if (validation.HasErrors)
		{
			Id = id;
			Form = form;
			return Page<_EditContact>();
		}
		var oldContact = Database.Contacts.First(x => x.Id == id);
		var newContact = new EditContactMapper().FormToContact(form);
		newContact.Id = oldContact.Id;
		Database.Contacts.Add(newContact);
		Database.Contacts.Remove(oldContact);

		return Redirect($"/contacts/{newContact.Id}/edit");
	}
}

public class EditContactForm
{
	[Required] public string Name { get; set; }
	[Required, EmailAddress] public string Email { get; set; }
	[Required] public string City { get; set; }
	[Required, Phone] public string Phone { get; set; }
}

[Mapper]
public partial class EditContactMapper
{
	public partial EditContactForm ContactToForm(Contact contact);
	public partial Contact FormToContact(EditContactForm contact);
}