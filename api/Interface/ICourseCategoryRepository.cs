using api.Model;

namespace api.Interface;

public interface ICourseCategoryRepository
{
    Task<CourseCategory> GetAllAsync();
    Task<CourseCategory?> GetByIdAsync();
    Task<CourseCategory> AddAsync();
    Task<CourseCategory?> Update();
    Task<CourseCategory?> Delete();
}
