using System.Collections.Generic;

namespace InformNotifications.Models;

public class SentMessage
{
    public int SentMessageId { get; set; }
    public DateTime TimeDelivered { get; set; }
    public string Contents { get; set; } = string.Empty;
}
