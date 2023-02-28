using InformNotifications.Models;

namespace InformNotifications.Data;

public static class SeedData
{
    public static void Initialize(NotificationsContext db)
    {
        var timmy = new Student
        {
            FirstName = "Timmy",
            LastName = "Submachinegun"
        };

        var lauren = new Parent
        {
            FirstName = "Lauren",
            LastName = "Submachinegun"
        };
        var thompson = new Parent
        {
            FirstName = "Thompson",
            LastName = "Submachinegun"
        };

        timmy.StudentParents = new List<StudentParent>
        {
            new StudentParent { Parent = lauren },
            new StudentParent { Parent = thompson }
        };

        db.Students.Add(timmy);
        db.SaveChanges();
    }
}
