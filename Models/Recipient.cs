using System.Collections.Generic;

namespace InformNotifications.Models;

public class Recipient
{
    public int RecipientId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = new Student();
    public List<Parent> Parents { get; set; } = new List<Parent>();
    public bool SendToParents { get; set; }
}
