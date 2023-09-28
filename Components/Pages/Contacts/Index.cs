using CustomLivewireRouter.Data;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomLivewireRouter.Components.Pages.Contacts;


public class IndexContactHandler
{
    public IResult Render()
    {
        return new RazorComponentResult<Index>(
            new { Model = InitialModelState() }
        );
    }

    private static ContactModel InitialModelState()
    {
        var model = new ContactModel();
        model.Contacts = Database.Contacts;
        return model;
    }
}

public class ContactModel
{
    public List<Contact> Contacts { get; set; } = new();
}
