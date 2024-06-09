using api.DTO.Enrollment;
using api.Entity;
using api.Extentions;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[ApiController]
[Route("api/enrollment")]
[Authorize]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentRepository _enrollmentRepo;
    private readonly UserManager<AppUser> _userManager;

    public EnrollmentController(IEnrollmentRepository enrollmentRepository, UserManager<AppUser> userManager)
    {
        _enrollmentRepo = enrollmentRepository;
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = _userManager.GetUserId(User);
        if (userId == null) return NotFound("user not login");
        var courses = await _enrollmentRepo.GetUserCoursesAsync(userId);
        if (courses == null) return NotFound();
        return Ok(courses.Select(x => x.ToCourseDto()));
    }

    [HttpPost]
    [Route("getEnrolled")]
    public async Task<IActionResult> Add([FromBody] CreateEnrollmentRequestDto dto)
    {
        dto.StudentID = _userManager.GetUserId(User);
        var isExist = await _enrollmentRepo.DoesExist(dto.CourseID, dto.StudentID);
        if (isExist) return BadRequest("Cant add same courses!!");
        await _enrollmentRepo.AddAsync(dto.ToCreateEnrollmentDto());
        return Ok(dto);
    }

    [HttpPut("ID:long")]
    public async Task<IActionResult> Update([FromRoute] long ID, [FromBody] UpdateEnrollmentRequestDto dto)
    {
        // we dont need update in enrollment
        var username = User.GetUsername();
        var user = await _userManager.FindByNameAsync(username);
        dto.StudentID = user.Id;
        await _enrollmentRepo.UpdateAsync(ID, dto.ToUpdateEnrollmentDto());
        return Ok(dto);
    }
    [HttpDelete("{ID:long}")]
    public async Task<IActionResult> Delete([FromRoute] long ID)
    {
        var enrollment = await _enrollmentRepo.Delete(ID);
        if (enrollment == null) return NotFound();
        return Ok(enrollment);
    }
}
