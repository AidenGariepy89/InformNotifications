using System.Collections.Generic;

namespace InformNotifications.Models;

public class Recipient
{
    public int RecipientId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public List<int> ParentIds { get; set; }
    public List<Parent> Parents { get; set; }
    public bool SendToParents { get; set; }
}
