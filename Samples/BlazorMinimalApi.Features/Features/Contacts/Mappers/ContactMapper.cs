using BlazorMinimalApis.Features.Features.Contacts.Models;
using BlazorMinimalApis.Features.Data;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Features.Features.Contacts.Mappers;

[Mapper]
public partial class ContactMapper
{
	public partial CreateContactForm ContactToCreateContactForm(Contact contact);
	public partial Contact CreateContactFormToContact(CreateContactForm contact);

	public partial EditContactForm ContactToEditContactForm(Contact contact);
	public partial Contact EditContactFormToContact(EditContactForm contact);
}