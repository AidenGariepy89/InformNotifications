using Microsoft.EntityFrameworkCore;
using InformNotifications.Models;

namespace InformNotifications.Data;

public class NotificationsContext : DbContext
{
    public NotificationsContext(DbContextOptions options)
        : base(options)
    {}

    public DbSet<SentMessage> SentMessages { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<StudentParent> StudentParents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentParent>()
            .HasKey(sp => new { sp.StudentId, sp.ParentId });
        
        modelBuilder.Entity<StudentParent>()
            .HasOne(sp => sp.Student)
            .WithMany(s => s.StudentParents)
            .HasForeignKey(sp => sp.StudentId);
        
        modelBuilder.Entity<StudentParent>()
            .HasOne(sp => sp.Parent)
            .WithMany(p => p.StudentParents)
            .HasForeignKey(sp => sp.ParentId);
    }   
}
