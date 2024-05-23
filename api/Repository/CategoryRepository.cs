using api.Data;
using api.DTO.Category;
using api.Interface;
using api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;


public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Category> AddAsync(CreateCategoryRequestDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
        };
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> Delete(long ID)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.ID == ID);
        if (category == null) return null;
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(long ID)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID);
        return category == null ? null : category;
    }

    public async Task<Category?> UpdateAsync(long ID, UpdateCategoryRequestDto dto)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID);
        if (category == null) return null;

        category.Name = dto.Name;

        await _context.SaveChangesAsync();
        return category;

    }
}
