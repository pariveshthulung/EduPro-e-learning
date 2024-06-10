using api.DTO.Lesson;
using api.Interface;
using api.Mapper;
using api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[ApiController]
[Route("api/lesson")]
[Authorize]
public class LessonController : ControllerBase
{
    private readonly ILessonRepository _lessonRepo;

    public LessonController(ILessonRepository lessonRepository)
    {
        _lessonRepo = lessonRepository;
    }

    [HttpGet("{moduleId:long}")]
    // [Route("{moduleId}")]
    public async Task<IActionResult> GetAll([FromRoute] long moduleId)
    {
        var lessons = await _lessonRepo.GetAllAsync(moduleId);
        if (lessons == null) return NotFound();

        return Ok(lessons.Select(x => x.ToLessonDto()));
    }

    [HttpGet]
    [Route("{ID}")]
    public async Task<IActionResult> GetById([FromRoute] long ID)
    {
        var lesson = await _lessonRepo.GetByIdAsync(ID);
        if (lesson == null) return NotFound();
        return Ok(lesson.ToLessonDto());
    }
    [HttpPut]
    [Route("{ID}")]
    public async Task<IActionResult> Update([FromRoute] long ID, [FromBody] UpdateLessonRequestDto dto)
    {
        var lesson = await _lessonRepo.UpdateAsync(ID, dto);
        if (lesson == null) return NotFound();
        return Ok(lesson.ToLessonDto());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonRequestDto dto)
    {
        await _lessonRepo.AddAsync(dto.ToCreateLessonDto());

        return Ok();
    }
}
