using System.Transactions;
using api.Data;
using api.DTO.Course;
using api.Helper;
using api.Interface;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Course> AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<Course?> Delete(long id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.ID == id);
        if (course == null) return null;
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<List<Course>> GetAllAsync([FromQuery] QueryObject query)
    {
        var courses = _context.Courses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Name))
        {
            courses = courses.Where(x => x.Name.Contains(query.Name));
        }
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Popular", StringComparison.OrdinalIgnoreCase))
            {
                courses = query.IsDecsending ? courses.OrderByDescending(x => x.NumberOfEnrollement) : courses.OrderBy(x => x.NumberOfEnrollement);
            }
        }
        var skipNumber = (query.PageNumber - 1) * query.PageSize;
        return await courses.Skip(skipNumber).Take(query.PageSize).ToListAsync();

    }

    public async Task<Course?> GetByIdAsync(long id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.ID == id);
        if (course == null) return null;

        return course;
    }

    public async Task<Course?> UpdateAsync(long id, UpdateCourseRequestDto updateDto)
    {

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.ID == id);
        if (course == null) return null;

        course.Name = updateDto.Name;
        course.Description = updateDto.Description;
        course.Price = updateDto.Price;

        await _context.SaveChangesAsync();

        return course;


    }
}
