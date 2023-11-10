using BlazorMinimalApis.Mvc.Controllers;
using BlazorMinimalApis.Mvc.Lib;
using BlazorMinimalApis.Mvc.Views.Contacts;
using BlazorMinimalApis.Mvc.Views.Home;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace BlazorMinimalApis.Mvc.Routes;

public class Web : IRouteDefinition
{
	public void Map(WebApplication app)
	{
		#region Home

		app.MapGet("/", new HomeController().Index);

		app.MapGet("/random-number", new HomeController().RandomNumber);

		#endregion

		#region Contacts

		app.MapGet("/contacts", new ContactController().List)
			.WithName("Contacts");

		app.MapGet("/contacts/search", new ContactController().Search)
			.WithName("Contacts.Search");

		app.MapGet("/contacts/create", new ContactController().Create)
			.WithName("Contacts.Create");

		app.MapPost("/contacts/create", new ContactController().Store)
			.WithName("Contacts.Store");

		app.MapGet("/contacts/{id:int}/edit", new ContactController().Edit)
			.WithName("Contacts.Edit");

		app.MapPost("/contacts/{id:int}/edit", new ContactController().Update)
			.WithName("Contacts.Update");

		app.MapGet("/contacts/{id}/delete", new ContactController().Delete)
			.WithName("Contacts.Delete");

		#endregion
	}
}
