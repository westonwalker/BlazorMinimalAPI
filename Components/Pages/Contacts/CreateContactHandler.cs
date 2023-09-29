using BlazorMinimalApis.Components.Layout;
using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib;
using FluentValidation;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Components.Pages.Contacts;

public class CreateContactHandler : PageEndpoint
{
    public IResult Render()
    {
        var model = new { Form = new CreateContactForm() };
        return Component<Create>(model);
    }

    public IResult SaveContact([FromForm] CreateContactForm form)
    {
        var validation = Validate(form);
        if (validation.HasErrors)
        {
            var model = new { Form = form };
            return Component<Create>(model);
        }
        var newContact = new CreateContactMapper().FormToContact(form);
        newContact.Id = Database.Contacts.Count() + 1;
		Database.Contacts.Add(newContact);

        return Redirect("/contacts");
    }
}

public class CreateContactForm
{
    [Required] public string Name { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string City { get; set; }
    [Required, Phone] public string Phone { get; set; }
}

[Mapper]
public partial class CreateContactMapper
{
    public partial CreateContactForm ContactToForm(Contact contact);
    public partial Contact FormToContact(CreateContactForm contact);
}