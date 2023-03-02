namespace InformNotifications.Models;

public class SentMessage
{
    public int Id { get; set; }
    public DateTime TimeDelivered { get; set; }
    public string Content { get; set; }
    public string MessageInfo { get; set; }
}
