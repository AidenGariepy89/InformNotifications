using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InformNotifications.Data;
using InformNotifications.Models;

namespace InformNotifications.Controllers;

[Route("sentmessages")]
[ApiController]
public class SentMessageController : Controller
{
    private readonly InformNotificationsContext _db;

    public SentMessageController(InformNotificationsContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<SentMessage>>> GetSentMessages()
    {
        return (await _db.Messages.ToListAsync()).OrderByDescending(s => s.SentMessageId).ToList();
    }
}
