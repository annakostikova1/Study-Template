using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Study.LabWork3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    [HttpGet]
    public List<Student> Get()
    {
        using var db = new UniversityDbContext();
        return db.Students.ToList();
    }

    [HttpPost]
    public void Post(Student student)
    {
        using var db = new UniversityDbContext();
        db.Students.Add(student);
        db.SaveChanges();
    }
}
