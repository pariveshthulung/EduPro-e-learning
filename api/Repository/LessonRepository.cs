using api.Data;
using api.DTO.Lesson;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationDbContext _context;

    public LessonRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Lesson?> AddAsync(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
        return lesson;
    }

    public async Task<Lesson?> Delete(long ID)
    {
        var lesson = await _context.Lessons.Where(x => x.ID == ID).FirstOrDefaultAsync();
        if (lesson == null) return null;
        _context.Remove(lesson);
        await _context.SaveChangesAsync();
        return lesson;
    }

    public async Task<List<Lesson>?> GetAllAsync(long moduleId)
    {
        return await _context.Lessons.Where(x => x.ModuleID == moduleId).ToListAsync();
    }

    public async Task<Lesson?> GetByIdAsync(long ID)
    {
        return await _context.Lessons.Where(x => x.ID == ID).FirstOrDefaultAsync();
    }

    public async Task<Lesson?> UpdateAsync(long ID, UpdateLessonRequestDto dto)
    {
        var lesson = _context.Lessons.Where(x => x.ID == ID).FirstOrDefault();
        if (lesson == null) return null;
        lesson.Description = dto.Description;
        lesson.Name = dto.Name;
        lesson.VideoUrl = dto.VideoUrl;
        lesson.Order = dto.Order;
        lesson.ModuleID = dto.ModuleID;
        await _context.SaveChangesAsync();
        return lesson;
    }
}
