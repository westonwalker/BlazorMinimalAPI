using BlazorMinimalApis.Data;
using BlazorMinimalApis.Lib;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Components.Pages.Contacts;

public class DeleteContactHandler : PageEndpoint
{
    public IResult DeleteContact(int id)
    {
        var contact = Database.Contacts.Where(x => x.Id == id).First();
        Database.Contacts.Remove(contact);
        return Redirect($"/contacts");
    }
}