using BlazorMinimalApis.Features.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Features.Lib;

namespace BlazorMinimalApis.Features.Features.Contacts.Handlers;

public class DeleteContact : XHandler
{
    public IResult Delete(int id)
    {
        var contact = Database.Contacts.First(x => x.Id == id);
        Database.Contacts.Remove(contact);
        return Redirect($"/contacts");
    }
}