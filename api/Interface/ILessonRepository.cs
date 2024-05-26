using api.DTO.Lesson;
using api.Model;

namespace api.Interface;

public interface ILessonRepository
{
    Task<List<Lesson>?> GetAllAsync(long moduleId);
    Task<Lesson?> GetByIdAsync(long ID);
    Task<Lesson?> AddAsync(Lesson lesson);
    Task<Lesson?> UpdateAsync(long ID, UpdateLessonRequestDto dto);
    Task<Lesson?> Delete(long ID);
}
