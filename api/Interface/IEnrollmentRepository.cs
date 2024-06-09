using api.Model;

namespace api.Interface;

public interface IEnrollmentRepository
{
    Task<List<Course>?> GetUserCoursesAsync(string ID);
    Task<Enrollment?> GetByIdAsync(long ID);
    Task<Enrollment?> AddAsync(Enrollment enrollment);
    Task<Enrollment?> UpdateAsync(long ID, Enrollment enrollment);
    Task<Enrollment?> Delete(long ID);
    Task<bool> DoesExist(long? CourseID, string StudentID);

}
