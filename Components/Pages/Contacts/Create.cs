using CustomLivewireRouter.Components.Layout;
using CustomLivewireRouter.Data;
using CustomLivewireRouter.Lib;
using Microsoft.AspNetCore.Components.Endpoints;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CustomLivewireRouter.Components.Pages.Contacts;

public class CreateContactHandler
{
    public IResult Render()
    {
        return new RazorComponentResult<Create>(
            new { Form = new CreateContactForm() }
        );
    }

    public IResult SaveContact([FromForm] CreateContactForm form, 
        HttpContext context)
    {
        var newContact = new Contact();
        newContact.Name = form.Name;
        newContact.Email = form.Email;
        newContact.SendMeDeals = form.SendMeDeals;

        Database.Contacts.Add(newContact);

        return Results.Redirect("/contacts");
    }



    //public IResult Render()
    //{
    //    var parameters = new { Model = InitialModelState() };
    //    return Component<Create>(parameters);
    //    // return new RazorComponentResult<Create>(parameters);
    //    // return RenderPage(parameters);
    //    //return new RazorComponentResult<Create>(
    //    //    new { Model = InitialModelState() }
    //    //);
    //    //return PageHandler.Render<Create>(new { Model = new CreateContactModel() });
    //}

    //public IResult SaveContact([FromForm]CreateContactForm form, HttpContext context)
    //{
    //    // map
    //    var ctx = new ValidationContext(form);
    //    var results = new List<ValidationResult>();
    //    if (!Validator.TryValidateObject(form, ctx, results, true))
    //    {
    //        foreach (var errors in results)
    //        {
    //            Console.WriteLine("Error {0}", errors);
    //        }

    //        return new RazorComponentResult<Create>(
    //            new { Model = new CreateContactModel(), Form = form }
    //        );
    //    }
    //    var newContact = new Contact();
    //    newContact.Name = form.Name;
    //    newContact.Email = form.Email;
    //    newContact.SendMeDeals = form.SendMeDeals;

    //    // todo: validate
    //    Database.Contacts.Add(newContact);

    //    return new RazorComponentResult<Create>(
    //        new { Model = InitialModelState() }
    //    );
    //}
}

public class CreateContactForm
{
    [Required] public string Name { get; set; }
    public string Email { get; set; }
    public bool SendMeDeals { get; set; }
}
