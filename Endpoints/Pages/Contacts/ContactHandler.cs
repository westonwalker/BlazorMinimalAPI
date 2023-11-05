using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Lib.Session;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Endpoints.Pages.Contacts;

public class ContactHandler : PageHandler
{
    public IResult List(HttpContext context)
    {
        var model = new ContactModel()
        {
            Contacts = Database.Contacts
        };
        var parameters = new { Model = model };
        return Page<List>(parameters);
    }

    public IResult Search([FromQuery] string ContactSearch)
    {
        var contacts = Database.Contacts
            .Where(x => x.Name.Contains(ContactSearch, StringComparison.OrdinalIgnoreCase))
            .ToList();
        var model = new { Contacts = contacts };
        return Page<ContactsSearchTable>(model);
    }

    public IResult Create()
    {
        var model = new { Form = new CreateContactForm() };
        return Page<Create>(model);
    }

    public IResult Store([FromForm] CreateContactForm form, SessionManager Session)
    {
        if (Validate(form).HasErrors)
        {
            var model = new { Form = form };
            return Page<Create>(model);
        }
        var newContact = new CreateContactMapper().FormToContact(form);
        newContact.Id = Database.Contacts.Count() + 1;
        Database.Contacts.Add(newContact);

        Session.SetFlash("success", "Contact successfully added.");

        return Redirect("/contacts/create");
    }

    public IResult Edit(int id)
    {
        var record = Database.Contacts.Where(x => x.Id == id).First();
        var form = new EditContactMapper().ContactToForm(record);
        var model = new { Form = form };
        return Page<Edit>(model);
    }

    public IResult Update(int id, [FromForm] EditContactForm form)
    {
        var validation = Validate(form);
        if (validation.HasErrors)
        {
            var model = new { Form = form };
            return Page<Edit>(model);
        }
        var oldContact = Database.Contacts.Where(x => x.Id == id).First();
        var newContact = new EditContactMapper().FormToContact(form);
        newContact.Id = oldContact.Id;
        Database.Contacts.Add(newContact);
        Database.Contacts.Remove(oldContact);

        return Redirect($"/contacts/{newContact.Id}/edit");
    }

    public IResult Delete(int id)
    {
        var contact = Database.Contacts.Where(x => x.Id == id).First();
        Database.Contacts.Remove(contact);
        return Redirect($"/contacts");
    }
}

public class ContactModel
{
    public List<Contact> Contacts { get; set; } = new();
}


public class CreateContactForm
{
    [Required] public string Name { get; set; }
    [Required, EmailAddress] public string Email { get; set; }
    [Required] public string City { get; set; }
    [Required, Phone] public string Phone { get; set; }
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
public partial class CreateContactMapper
{
    public partial CreateContactForm ContactToForm(Contact contact);
    public partial Contact FormToContact(CreateContactForm contact);
}

[Mapper]
public partial class EditContactMapper
{
    public partial EditContactForm ContactToForm(Contact contact);
    public partial Contact FormToContact(EditContactForm contact);
}