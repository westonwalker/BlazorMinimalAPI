using BlazorMinimalApis.Slices.Applications.Contacts.Models;
using BlazorMinimalApis.Slices.Data;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Slices.Applications.Contacts.Mappers;

[Mapper]
public partial class ContactMapper
{
	public partial CreateContactForm ContactToCreateContactForm(Contact contact);
	public partial Contact CreateContactFormToContact(CreateContactForm contact);

	public partial EditContactForm ContactToEditContactForm(Contact contact);
	public partial Contact EditContactFormToContact(EditContactForm contact);
}