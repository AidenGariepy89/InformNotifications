namespace InformNotifications.Models;

public class Student
{
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public string? GraduationYear { get; set; }
    public override string ToString()
    {
        return FullName + " - " + GraduationYear;
    }
}
