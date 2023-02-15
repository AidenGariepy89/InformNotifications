using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InformNotifications.Data;
using InformNotifications.Models;

namespace InformNotifications.Controllers;

[Route("recipients")]
[ApiController]
public class RecipientController : Controller
{
    private readonly InformNotificationsContext _db;

    public RecipientController(InformNotificationsContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Recipient>>> GetRecipients()
    {
        return (await _db.Recipients
                .Include(r => r.Student)
                //.Include(r => r.Parents)
                .ToListAsync())
            .OrderBy(r => r.RecipientId)
            .ToList();
    }
}
