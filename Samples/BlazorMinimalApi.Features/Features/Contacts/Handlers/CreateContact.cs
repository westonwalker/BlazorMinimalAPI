using System.ComponentModel.DataAnnotations;
using BlazorMinimalApis.Features.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Lib.Session;
using BlazorMinimalApis.Features.Features.Contacts.Mappers;
using BlazorMinimalApis.Features.Features.Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;
using BlazorMinimalApis.Features.Features.Contacts.Views;

namespace BlazorMinimalApis.Features.Features.Contacts.Handlers;

public class CreateContact : XHandler
{
	public IResult Create()
	{
		var model = new { Form = new CreateContactForm() };
		return View<Create>(model);
	}

	public IResult Store([FromForm] CreateContactForm form, SessionManager Session)
	{
		if (Validate(form).HasErrors)
		{
			var model = new { Form = form };
			return View<Create>(model);
		}
		var newContact = new ContactMapper().CreateContactFormToContact(form);
		newContact.Id = Database.Contacts.Count() + 1;
		Database.Contacts.Add(newContact);

		Session.SetFlash("success", "Contact successfully added.");

		return Redirect("/contacts/create");
	}
}