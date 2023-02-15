using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using InformNotifications.Data;
using InformNotifications.Models;

namespace InformNotifications.Controllers;

[Route("students")]
[ApiController]
public class StudentsController : Controller
{
    private readonly InformNotificationsContext _db;

    public StudentsController(InformNotificationsContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        return (await _db.Students.ToListAsync()).OrderBy(s => s.StudentId).ToList();
    }
}
