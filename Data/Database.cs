namespace BlazorMinimalApis.Data;

public static class Database
{
    public static List<Contact> Contacts = new();
}

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
}
