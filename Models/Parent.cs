namespace InformNotifications.Models;

public class Parent
{
    public int ParentId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => FirstName + " " + LastName;
    public string EmailAddress { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public int RecipientId { get; set; }
    public Recipient Recipient { get; set; }
}
