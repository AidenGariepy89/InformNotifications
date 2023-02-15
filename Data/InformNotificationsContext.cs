using Microsoft.EntityFrameworkCore;
using InformNotifications.Models;

namespace InformNotifications.Data;

public class InformNotificationsContext : DbContext
{
    public InformNotificationsContext(DbContextOptions options) : base(options)
    {}

    public DbSet<SentMessage> Messages { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Recipient> Recipients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Recipient>()
            .HasOne(r => r.Student)
            .WithOne(s => s.Recipient)
            .HasForeignKey<Student>(s => s.RecipientId);
        modelBuilder.Entity<Parent>()
            .HasOne(p => p.Recipient)
            .WithMany(r => r.Parents)
            .HasForeignKey(p => p.RecipientId);

        modelBuilder.Entity<Recipient>().HasData(new Recipient { RecipientId = 1 });
        modelBuilder.Entity<Student>()
            .HasData(new Student
            {
                RecipientId = 1,
                StudentId = 1,
                FirstName = "Aiden",
                LastName = "Gariepy",
                GraduationYear = "2023",
                EmailAddress = "aidgar23@gcasda.org",
                PhoneNumber = "7062638995"
            });
        modelBuilder.Entity<Parent>()
            .HasData(new Parent
            {
                RecipientId = 1,
                ParentId = 1,
                FirstName = "Serge",
                LastName = "Gariepy",
                EmailAddress = "sgariepy@gcasda.org",
                PhoneNumber = "7062177138"
            });
        modelBuilder.Entity<Parent>()
            .HasData(new Parent
            {
                RecipientId = 1,
                ParentId = 2,
                FirstName = "LeAnn",
                LastName = "Gariepy",
                EmailAddress = "lgariepy@gcasda.org",
                PhoneNumber = "7062177139"
            });
    }
}
