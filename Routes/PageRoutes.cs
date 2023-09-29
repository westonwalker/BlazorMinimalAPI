using BlazorMinimalApis.Components.Pages;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using BlazorMinimalApis.Lib;
using BlazorMinimalApis.Components;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using BlazorMinimalApis.Data;
using BlazorMinimalApis.Components.Pages.Contacts;
using Microsoft.AspNetCore.Builder;

namespace BlazorMinimalApis.Routes;

public static class PageRoutes
{
	public static WebApplication MapPageRoutes(this WebApplication app)
    {
        app.MapGet("/", new HomeHandler().Render)
            .WithName("Home");

        app.MapGet("/random-number", new HomeHandler().RandomNumber)
            .WithName("Home.RandomNumber");

        app.MapGet("/contacts", new ListContactsHandler().Render)
            .WithName("Contacts");

        app.MapGet("/contacts/search", new ListContactsHandler().Search)
            .WithName("Contacts.Search");

        app.MapGet("/contacts/create", new CreateContactHandler().Render)
            .WithName("Contacts.Create");

        app.MapPost("/contacts/create", new CreateContactHandler().SaveContact)
            .WithName("Contacts.Store");

		app.MapGet("/contacts/{id:int}/edit", new EditContactHandler().Render)
			.WithName("Contacts.Edit");

		app.MapPost("/contacts/{id:int}/edit", new EditContactHandler().UpdateContact)
			.WithName("Contacts.Update");

        app.MapGet("/contacts/{id:int}/delete", new DeleteContactHandler().DeleteContact)
            .WithName("Contacts.Delete");

        return app;
	}
}