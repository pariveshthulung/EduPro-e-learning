using api.DTO.Module;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[ApiController]
[Route("api/module")]
[Authorize]
public class ModuleController : ControllerBase
{
    private readonly IModuleRepository _moduleRepo;

    public ModuleController(IModuleRepository moduleRepository)
    {
        _moduleRepo = moduleRepository;
    }

    [HttpGet("{courseId:long}")]
    public async Task<IActionResult> GetAll([FromRoute] long courseId)
    {
        var module = await _moduleRepo.GetAllAsync(courseId);
        if (module == null) return NotFound();
        return Ok(module.Select(x => x.ToModuleDto()));
    }

    [HttpGet]
    [Route("getById{ID}")]
    public async Task<IActionResult> GetById([FromRoute] long ID)
    {
        var module = await _moduleRepo.GetByIdAsync(ID);
        if (module == null) return NotFound();
        return Ok(module.ToModuleDto());
    }

    [HttpPut]
    [Route("{ID:long}")]
    public async Task<IActionResult> Update([FromRoute] long ID, [FromBody] UpdateModuleRequestDto dto)
    {
        var module = await _moduleRepo.UpdateAsync(ID, dto);
        if (module == null) return NotFound();
        return Ok(module.ToModuleDto());

    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateModuleRequestDto dto)
    {
        var module = await _moduleRepo.AddAsync(dto.ToCreateModuleDto());
        return Ok(module);
    }
}
