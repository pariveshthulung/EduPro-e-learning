using System.Windows.Markup;
using api.DTO.Category;
using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[Route("api/category")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepo = categoryRepository;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCategoryRequestDto categoryDto)
    {
        await _categoryRepo.AddAsync(categoryDto);

        return Ok(categoryDto);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var category = await _categoryRepo.GetAllAsync();
        var categoryDto = category.Select(x => x.ToCategoryDto());
        return Ok(categoryDto);
    }

    [HttpGet("{ID:long}")]
    public async Task<IActionResult> GetById([FromRoute] long ID)
    {
        var category = await _categoryRepo.GetByIdAsync(ID);
        if (category == null) return NotFound();
        return Ok(category.ToCategoryDto());
    }

    [HttpPut("{ID:long}")]
    public async Task<IActionResult> Update([FromRoute] long ID, [FromBody] UpdateCategoryRequestDto dto)
    {
        var category = await _categoryRepo.UpdateAsync(ID, dto);
        if (category == null) return NotFound();
        return Ok(category.ToCategoryDto());
    }
}
