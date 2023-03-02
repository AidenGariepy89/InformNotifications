namespace InformNotifications.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public ICollection<StudentParent> StudentParents { get; set; }
}
