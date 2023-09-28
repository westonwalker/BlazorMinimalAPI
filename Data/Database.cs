namespace CustomLivewireRouter.Data;

public static class Database
{
    public static List<Contact> Contacts = new();
}

public class Contact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool SendMeDeals { get; set; }
}
