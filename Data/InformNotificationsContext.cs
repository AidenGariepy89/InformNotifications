using Microsoft.EntityFrameworkCore;
using InformNotifications.Models;

namespace InformNotifications.Data;

public class InformNotificationsContext : DbContext
{
    public InformNotificationsContext(DbContextOptions options) : base(options)
    {}

    public DbSet<SentMessage> Messages { get; set; }
    // public DbSet<Student> Students { get; set; }
    // public DbSet<Parent> Parents { get; set; }
    // public DbSet<Recipient> Recipients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


    }
}
