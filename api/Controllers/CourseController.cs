using api.Data;
using api.DTO.Course;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[Route("api/stock")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CourseController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var course = _context.Courses.ToList().Select(x => x.ToCourseDto());
        return Ok(course);
    }

    [HttpGet("{ID:long}")]
    public IActionResult GetById([FromRoute] long ID)
    {
        var Course = _context.Courses.Find(ID);
        if (Course == null)
        {
            return NotFound();
        }
        return Ok(Course.ToCourseDto());
    }

    [HttpPost]
    public IActionResult AddCourse([FromBody] CreateCourseRequestDto courseDTO)
    {
        var course = courseDTO.ToCourseFromCourseDto();
        _context.Courses.Add(course);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { course.ID }, course.ToCourseDto());
        /**                             |               |                   |
                                goto GetById controller |              return type
                                                  send ID as parameter    
        **/
    }


}
