using CustomLivewireRouter.Components.Pages;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using CustomLivewireRouter.Lib;
using CustomLivewireRouter.Components;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using CustomLivewireRouter.Data;
using CustomLivewireRouter.Components.Pages.Contacts;

namespace CustomLivewireRouter.Routes;

public static class PageRoutes
{
	public static WebApplication MapPageRoutes(this WebApplication app)
    {
        app.MapGet("/", new HomeHandler().Render).WithName("Home");

        app.MapGet("/contacts", new IndexContactHandler().Render)
            .WithName("Contacts");

        app.MapGet("/contacts/create", new CreateContactHandler().Render)
            .WithName("Contacts.Create");

        app.MapPost("/contacts", new CreateContactHandler().SaveContact)
            .WithName("Contacts.Store");

        return app;
	}
}
