namespace InformNotifications.Models;

public class Recipient
{
    public int RecipientId { get; set; }

    public Student Student { get; set; }

    public List<Parent> Parents { get; set; }
}
