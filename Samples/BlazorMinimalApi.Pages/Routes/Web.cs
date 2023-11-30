using BlazorMinimalApis.Pages.Lib;
using BlazorMinimalApis.Pages.Pages.Contacts;
using BlazorMinimalApis.Pages.Pages.Home;
using static System.Formats.Asn1.AsnWriter;

namespace BlazorMinimalApis.Pages.Routes;

public class Web : IRouteDefinition
{
	public void Map(WebApplication app)
	{
        #region Home

        app.MapGet("/", new Home().Get);

        app.MapGet("/random-number", new Home().RandomNumber);

        #endregion

        #region Contacts

        app.MapGet("/contacts", new ListContacts().Get)
            .WithName("ListContacts.Get");

        app.MapGet("/contacts/search", new ListContacts().GetSearch)
            .WithName("SearchContacts.Get");

        app.MapGet("/contacts/create", new CreateContact().Get)
            .WithName("CreateContact.Get");

        app.MapPost("/contacts/create", new CreateContact().Post)
            .WithName("CreateContact.Post");

		app.MapGet("/contacts/{id:int}/edit", new EditContact().Get)
			.WithName("EditContact.Get");

		app.MapPost("/contacts/{id:int}/edit", new EditContact().Post)
			.WithName("EditContact.Post");

		app.MapGet("/contacts/{id}/delete", new DeleteContact().Get)
			.WithName("DeleteContact.Get");

		#endregion
	}
}
