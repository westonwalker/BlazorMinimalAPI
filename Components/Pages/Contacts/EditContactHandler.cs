using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Components.Pages.Contacts;

public class EditContactHandler : PageEndpoint
{
    public IResult Render(int id)
    {
        var record = Database.Contacts.Where(x => x.Id == id).First();
		var form = new EditContactMapper().ContactToForm(record);
		var model = new { Form = form };
        return Component<Edit>(model);
    }

    public IResult UpdateContact(int id, [FromForm] EditContactForm form)
    {
        var validation = Validate(form);
        if (validation.HasErrors)
        {
            var model = new { Form = form };
            return Component<Edit>(model);
        }
        var oldContact = Database.Contacts.Where(x => x.Id == id).First();
        var newContact = new EditContactMapper().FormToContact(form);
        newContact.Id = oldContact.Id;
        Database.Contacts.Add(newContact);
        Database.Contacts.Remove(oldContact);

        return Redirect($"/contacts/{newContact.Id}/edit");
    }
}

public class EditContactForm
{
    public int Id { get; set; }
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
