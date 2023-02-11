using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InformNotifications.Models;
using InformNotifications.Data;

namespace InformNotifications.Controllers;

[Route("parents")]
[ApiController]
public class ParentsController : Controller
{
    private readonly InformNotificationsContext _db;

    public ParentsController(InformNotificationsContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Parent>>> GetParents()
    {
        return (await _db.Parents.ToListAsync()).OrderBy(p => p.ParentId).ToList();
    }
}
