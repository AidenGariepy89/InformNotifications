using InformNotifications.Models;

namespace InformNotifications.Data;

public static class SeedData
{
    public static void Initialize(InformNotificationsContext db)
    {   
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
            },
            new SentMessage()
            {
                SentMessageId = 3,
                TimeDelivered = new DateTime(2022, 8, 9),
                Contents = "This is a message from your favorite thing in the whole wide world. Farewell."
            }
        };
        db.Messages.AddRange(messages);
        db.SaveChanges();
    }
}
