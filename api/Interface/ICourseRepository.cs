using api.DTO.Course;
using api.Helper;
using api.Model;

namespace api.Interface;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync(QueryObject query);
    Task<Course?> GetByIdAsync(long id);

    Task<Course> AddAsync(Course course);

    Task<Course?> UpdateAsync(long id, UpdateCourseRequestDto updateDto);

    Task<Course?> Delete(long id);
}
