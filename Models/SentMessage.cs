using System.Collections.Generic;

namespace InformNotifications.Models;

public class SentMessage
{
    public int MessageId { get; set; }
    public DateTime TimeDelivered { get; set; }
    public List<Recipient> Recipients { get; set; }
    public string? Contents { get; set; }
}
