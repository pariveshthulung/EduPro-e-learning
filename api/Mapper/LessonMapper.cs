using api.DTO.Enrollment;
using api.DTO.Lesson;
using api.Model;

namespace api.Mapper;

public static class LessonMapper
{
    public static LessonDto ToLessonDto(this Lesson lesson)
    {
        return new LessonDto
        {
            ID = lesson.ID,
            Name = lesson.Name,
            Description = lesson.Description,
            VideoUrl = lesson.VideoUrl,
            Order = lesson.Order,
            ModuleID = lesson.ModuleID,
        };
    }

    public static Lesson ToCreateLessonDto(this CreateLessonRequestDto dto)
    {
        return new Lesson
        {
            Name = dto.Name,
            Description = dto?.Description,
            VideoUrl = dto?.VideoUrl,
            Order = dto.Order,
            ModuleID = dto.ModuleID,
        };
    }

    public static Lesson ToUpdateLessonDto(this UpdateLessonRequestDto dto)
    {
        return new Lesson
        {
            Name = dto?.Name,
            Description = dto?.Description,
            VideoUrl = dto?.VideoUrl,
            Order = dto.Order,
            ModuleID = dto.ModuleID,

        };
    }
}
