using System.Collections.Generic;

namespace InformNotifications.Models;

public class Recipient
{
    public Student Student { get; set; }
    public List<Parent> Parents { get; set; }
    public bool SendToParents { get; set; }
    public string? GraduationYear { get; set; }
}
