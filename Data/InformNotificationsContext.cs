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
        
        DataSeeding(modelBuilder);
    }

    void DataSeeding(ModelBuilder modelBuilder)
    {
        List<Student> students = SeedData.ReadFile();

        int i = 0;
        int j = -1;
        foreach (var student in students)
        {
            i++;
            j += 2;

            modelBuilder.Entity<Recipient>().HasData(new Recipient { RecipientId = i });
            student.RecipientId = i;
            modelBuilder.Entity<Student>().HasData(student);

            modelBuilder.Entity<Parent>().HasData(new Parent
            {
                RecipientId = i,
                ParentId = j,
                FirstName = "Mother",
                LastName = student.LastName,
                EmailAddress = $"mother{student.LastName}@gmail.com",
                PhoneNumber = "number of mom"
            });
            modelBuilder.Entity<Parent>().HasData(new Parent
            {
                RecipientId = i,
                ParentId = j + 1,
                FirstName = "Father",
                LastName = student.LastName,
                EmailAddress = $"father{student.LastName}@gmail.com",
                PhoneNumber = "number of dad"
            });
        }
    }
}
