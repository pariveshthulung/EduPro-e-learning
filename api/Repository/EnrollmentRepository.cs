using api.Data;
using api.Entity;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly ApplicationDbContext _context;

    public EnrollmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Enrollment?> AddAsync(Enrollment enrollment)
    {

        await _context.Enrollments.AddAsync(enrollment);
        await _context.SaveChangesAsync();
        return enrollment;
    }

    public async Task<Enrollment?> Delete(long ID)
    {
        var Enrollment = await _context.Enrollments.FirstOrDefaultAsync(x => x.ID == ID);
        if (Enrollment == null) return null;
        _context.Enrollments.Remove(Enrollment);
        await _context.SaveChangesAsync();
        return Enrollment;
    }

    public async Task<List<Course>?> GetUserCoursesAsync(string ID)
    {
        return await _context.Enrollments.Where(x => x.StudentID == ID).Include(x => x.Course).ThenInclude(y => y.CourseCategories).Select(course => new Course
        {
            ID = course.ID,
            Name = course.Course.Name,
            Description = course.Course.Description,
            Price = course.Course.Price,
            NumberOfEnrollement = course.Course.NumberOfEnrollement,
            CourseCategories = course.Course.CourseCategories,

        }).ToListAsync();
        // return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
        //     .Select(stock => new Stock
        //     {
        //         Id = stock.StockId,
        //         Symbol = stock.Stock.Symbol,
        //         CompanyName = stock.Stock.CompanyName,
        //         Purchase = stock.Stock.Purchase,
        //         LastDiv = stock.Stock.LastDiv,
        //         Industry = stock.Stock.Industry,
        //         MarketCap = stock.Stock.MarketCap
        //     }).ToListAsync();
    }

    public Task<Enrollment?> GetByIdAsync(long ID)
    {
        throw new NotImplementedException();
    }

    public Task<Enrollment?> UpdateAsync(long ID, Enrollment enrollment)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DoesExist(long? CourseID, string StudentID)
    {
        var studentCourse = await _context.Enrollments.Where(x => x.StudentID == StudentID).ToListAsync();
        return studentCourse.Any(x => x.CourseID == CourseID);
    }


}
