using api.Data;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api;

public class CourseCategoryRepository : ICourseCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CourseCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<CourseCategory>> AddAsync(long courseID, List<long> categoryIDs)
    {
        foreach (var ID in categoryIDs)
        {
            var courseCategory = new CourseCategory();
            courseCategory.CourseID = courseID;
            courseCategory.CategoryID = ID;
            await _context.CourseCategories.AddAsync(courseCategory);
            await _context.SaveChangesAsync();

        }
        return await _context.CourseCategories.Where(c => c.CourseID == courseID).ToListAsync();
    }

    public Task<CourseCategory?> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<CourseCategory> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CourseCategory?> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CourseCategory?> Update()
    {
        throw new NotImplementedException();
    }
}
