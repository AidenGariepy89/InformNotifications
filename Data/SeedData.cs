using InformNotifications.Models;
using System.IO;

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

        List<Student> students = ReadFile();
        db.Students.AddRange(students);

        List<Parent> parents = new()
        {
            new Parent()
            {
                ParentId = 1,
                FirstName = "Serge",
                LastName = "Gariepy",
                EmailAddress = "sgariepy@gcasda.org",
                PhoneNumber = "7062177138"
            },
            new Parent()
            {
                ParentId = 2,
                FirstName = "LeAnn",
                LastName = "Gariepy",
                EmailAddress = "lgariepy@gcasda.org",
                PhoneNumber = "7062177139"
            },
            new Parent()
            {
                ParentId = 3,
                FirstName = "Bruce",
                LastName = "Boggess",
                EmailAddress = "bboggess@gcasda.org",
                PhoneNumber = "4444444444"
            },
            new Parent()
            {
                ParentId = 4,
                FirstName = "Deion Senior",
                LastName = "Hareg",
                EmailAddress = "deionsdad@gmail.com",
                PhoneNumber = "5555555555"
            }
        };
        db.Parents.AddRange(parents);

        db.SaveChanges();
    }

    public static List<Student> ReadFile()
    {
        string path = "testing/students.txt";
        List<Student> students = new();
        if (File.Exists(path))
        {
            int id;
            string firstName;
            string lastName;
            string gradYear;
            string email;
            string phone;
            using (StreamReader sr = new(path))
            {
                while (sr.ReadLine() != null)
                {
                    id = Convert.ToInt32(sr.ReadLine()!);
                    firstName = sr.ReadLine()!;
                    lastName = sr.ReadLine()!;
                    gradYear = sr.ReadLine()!;
                    email = sr.ReadLine()!;
                    phone = sr.ReadLine()!;

                    students.Add(new()
                    {
                        StudentId = id,
                        FirstName = firstName,
                        LastName = lastName,
                        GraduationYear = gradYear,
                        EmailAddress = email,
                        PhoneNumber = phone
                    });
                }
            }
            
            return students;
        }
        else
        {
            return new List<Student>();
        }
    }
}


/*
List<Student> students = new()
        {
            new Student()
            {
                StudentId = 1,
                FirstName = "Aiden",
                LastName = "Gariepy",
                GraduationYear = "2023",
                EmailAddress = "aidgar23@gcasda.org",
                PhoneNumber = "7062638995"
            },
            new Student()
            {
                StudentId = 2,
                FirstName = "Jack",
                LastName = "Boggess",
                GraduationYear = "2023",
                EmailAddress = "jacbog23@gcasda.org",
                PhoneNumber = "1111111111"
            },
            new Student()
            {
                StudentId = 3,
                FirstName = "Samantha",
                LastName = "Gariepy",
                GraduationYear = "2026",
                EmailAddress = "samgar26@gcasda.org",
                PhoneNumber = "2222222222"
            },
            new Student()
            {
                StudentId = 4,
                FirstName = "Deion",
                LastName = "Hareg",
                GraduationYear = "2023",
                EmailAddress = "deihar23@gcasda.org",
                PhoneNumber = "3333333333"
            }
        };
*/