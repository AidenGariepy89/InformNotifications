using InformNotifications.Models;
using InformNotifications.Models;

namespace InformNotifications.Data;

public static class SeedData
{
    public static void Initialize(InformNotificationsContext db)
    {
        // var aiden = new Recipient()
        // {
        //     Student = new Student()
        //     {
        //         FirstName = "Aiden",
        //         LastName = "Gariepy",
        //         GraduationYear = "2023"
        //     },
        //     Parents = new List<Parent>(),
        //     SendToParents = false
        // };
        // var jack = new Recipient()
        // {
        //     Student = new Student()
        //     {
        //         FirstName = "Jack",
        //         LastName = "Boggess",
        //         GraduationYear = "2026"
        //     },
        //     Parents = new List<Parent>(),
        //     SendToParents = false
        // };
        // var deion = new Recipient()
        // {
        //     Student = new Student()
        //     {
        //         FirstName = "Deion",
        //         LastName = "Hareg",
        //         GraduationYear = "2021"
        //     },
        //     Parents = new List<Parent>(),
        //     SendToParents = false
        // };
        
        List<SentMessage> messages = new()
        {
            new SentMessage()
            {
                SentMessageId = 1,
                TimeDelivered = DateTime.Now,
                Contents = "This is a message about a time that I died. Farewell."
            },
            new SentMessage()
            {
                SentMessageId = 2,
                TimeDelivered = DateTime.Now,
                Contents = "Now you will perish. Farewell."
            }
        };
        db.Messages.AddRange(messages);
        db.SaveChanges();
    }
}
