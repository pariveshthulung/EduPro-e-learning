using api.Data;
using api.DTO.Course;
using api.Entity;
using api.Extentions;
using api.Helper;
using api.Interface;
using api.Mapper;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{

    private readonly ICourseRepository _courseRepo;
    private readonly UserManager<AppUser> _userManager;
    public CourseController(UserManager<AppUser> userManager, ICourseRepository courseRepo)
    {
        _courseRepo = courseRepo;
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        var user = User.GetUsername(); // User is an object of controllerbase and GetUsername() is an claim extentions method
        var currentUser = await _userManager.FindByNameAsync(user);
        var course = await _courseRepo.GetAllAsync(query);
        var courseDTO = course.Select(x => x.ToCourseDto());
        return Ok(courseDTO);
    }

    [HttpGet("{ID:long}")]
    public async Task<IActionResult> GetById([FromRoute] long ID)
    {
        var course = await _courseRepo.GetByIdAsync(ID);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course.ToCourseDto());
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] CreateCourseRequestDto courseDTO)
    {
        var course = courseDTO.ToCourseFromCourseDto();

        await _courseRepo.AddAsync(course);
        return CreatedAtAction(nameof(GetById), new { course.ID }, course.ToCourseDto());
        /**                             |               |                   |
                                goto GetById controller |              return type
                                                  send ID as parameter    
        **/
    }

    [HttpPut("{ID}")]
    // [Route("ID")]
    public async Task<IActionResult> Update([FromRoute] long ID, [FromBody] UpdateCourseRequestDto updateDto)
    {
        var course = await _courseRepo.UpdateAsync(ID, updateDto);
        if (course == null) return NotFound();

        return Ok(course.ToCourseDto());
    }

    [HttpDelete]
    [Route("ID")]
    public async Task<IActionResult> Delete([FromRoute] long ID)
    {
        var course = await _courseRepo.GetByIdAsync(ID);
        if (course == null) return NotFound();
        return NoContent();
    }

}
