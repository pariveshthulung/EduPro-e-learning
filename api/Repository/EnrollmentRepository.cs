using api.Data;
using api.Entity;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUserRepository _userRepository;

    public EnrollmentRepository(ApplicationDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }
    public async Task<Enrollment?> AddAsync(Enrollment enrollment)
    {
        var userId = _userRepository.GetUserID();
        var isExist = await _context.Enrollments.AnyAsync(x => x.CourseID == enrollment.CourseID && x.StudentID == userId);

        if (isExist) return null;

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
    }

    public Task<Enrollment?> GetByIdAsync(long ID)
    {
        throw new NotImplementedException();
    }

    public async Task<Enrollment?> UpdateAsync(long ID, Enrollment enrollment)
    {
        var enrollmentFromDb = await _context.Enrollments.Where(x => x.ID == ID).FirstOrDefaultAsync();
        if (enrollmentFromDb == null) return null;

        var userId = _userRepository.GetUserID();
        enrollmentFromDb.StudentID = userId;
        enrollmentFromDb.CourseID = enrollment.CourseID;

        await _context.SaveChangesAsync();
        return enrollment;
    }

    public async Task<bool> DoesExist(long? CourseID)
    {
        var userId = _userRepository.GetUserID();

        var studentCourse = await _context.Enrollments.Where(x => x.StudentID == userId).ToListAsync();
        return studentCourse.Any(x => x.CourseID == CourseID);
    }


}
