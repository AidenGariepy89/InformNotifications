using Microsoft.EntityFrameworkCore;
using InformNotifications.Models;

namespace InformNotifications.Data;

public class InformNotificationsContext : DbContext
{
    public InformNotificationsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<SentMessage> Messages { get; set; }
}
