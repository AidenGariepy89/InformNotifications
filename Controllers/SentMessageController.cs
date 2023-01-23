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
        return (await _db.Messages.ToListAsync()).OrderByDescending(s => s.TimeDelivered).ToList();
    }

    [HttpGet("{messageId}")]
    public async Task<ActionResult<SentMessage>> GetSentMessage(int messageId)
    {
        var message = await _db.Messages
            .Where(m => m.SentMessageId == messageId)
            .SingleOrDefaultAsync();
        
        if (message == null)
        {
            return NotFound();
        }

        return message;
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddSentMessage(SentMessage message)
    {
        message.TimeDelivered = DateTime.Now;
        message.SentMessageId = _db.Messages.Count() + 1;

        _db.Messages.Add(message);
        await _db.SaveChangesAsync();

        return message.SentMessageId;
    }
}
