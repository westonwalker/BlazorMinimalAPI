using BlazorMinimalApis.Slices.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Slices.Lib;

namespace BlazorMinimalApis.Slices.Applications.Contacts.Handlers;

public class DeleteContact : XHandler
{
    public IResult Delete(int id)
    {
        var contact = Database.Contacts.First(x => x.Id == id);
        Database.Contacts.Remove(contact);
        return Redirect($"/contacts");
    }
}