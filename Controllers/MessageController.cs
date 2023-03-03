using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InformNotifications.Data;
using InformNotifications.Models;

namespace InformNotifications.Controllers;

[ApiController]
[Route("messages")]
public class MessageController : ControllerBase
{
    private readonly NotificationsContext _db;

    public MessageController(NotificationsContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<SentMessage>>> GetMessages()
    {
        var messages = await _db.SentMessages.ToListAsync();

        return Ok(messages);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SentMessage>> GetMessageById(int id)
    {
        var message = await _db.SentMessages.FindAsync(id);

        return Ok(message);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddMessage([FromBody] SentMessage message)
    {
        message.TimeDelivered = DateTime.Now;
        await _db.SentMessages.AddAsync(message);
        await _db.SaveChangesAsync();

        return message.Id;
    }

    [HttpDelete("{messageId}")]
    public async Task<ActionResult<int>> DeleteMessage(int messageId)
    {
        var message = await _db.SentMessages
            .Where(m => m.Id == messageId)
            .SingleOrDefaultAsync();
        if (message is null)
        {
            return -1;
        }
        _db.Remove(message);
        await _db.SaveChangesAsync();

        return message.Id;
    }
}
