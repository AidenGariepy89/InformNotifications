using System.Collections.Generic;

namespace InformNotifications.Models;

public class SentMessage
{
    public int SentMessageId { get; set; }
    public DateTime TimeDelivered { get; set; }
    public string Contents { get; set; } = string.Empty;
}

// public class SentMessage
// {
//     public int MessageId { get; set; }
//     public DateTime TimeDelivered { get; set; }
//     public List<int> RecipientIds { get; set; }
//     public List<Recipient> Recipients { get; set; }
//     public string? Contents { get; set; }
// }
