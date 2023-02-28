using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InformNotifications.Data;
using InformNotifications.Models;

namespace InformNotifications.Controllers;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly NotificationsContext _db;

    public StudentController(NotificationsContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = await _db.Students
            .Include(s => s.StudentParents)
                .ThenInclude(sp => sp.Parent)
            .ToListAsync();
        
        return Ok(students);
    }
}
