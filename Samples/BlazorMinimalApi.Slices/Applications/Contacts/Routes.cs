using BlazorMinimalApis.Slices.Applications.Contacts.Handlers;
using BlazorMinimalApis.Slices.Lib;

namespace BlazorMinimalApis.Slices.Applications.Contacts;

public class Routes : IRouteDefinition
{
    public void Map(WebApplication app)
	{
		// UI routes
		app.MapGet("/contacts", new ListContacts().List)
			.WithName("Contacts");

		app.MapGet("/contacts/create", new CreateContact().Create)
            .WithName("Contacts.Create");

        app.MapPost("/contacts/create", new CreateContact().Store)
            .WithName("Contacts.Store");

		app.MapGet("/contacts/{id:int}/edit", new EditContact().Edit)
			.WithName("Contacts.Edit");

		app.MapPost("/contacts/{id:int}/edit", new EditContact().Update)
			.WithName("Contacts.Update");

		app.MapGet("/contacts/{id}/delete", new DeleteContact().Delete)
			.WithName("Contacts.Delete");

		app.MapGet("/contacts/search", new SearchContacts().Search)
			.WithName("Contacts.Search");

		// API routes
		app.MapGet("/api/contacts", new ListContactsApi().List);
	}
}
