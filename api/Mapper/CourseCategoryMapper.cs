using api.Model;

namespace api.Mapper;

public static class CourseCategoryMapper
{
    public static CourseCategoryDto ToCourseCategoryDto(this CourseCategory courseCategory)
    {
        return new CourseCategoryDto
        {
            ID = courseCategory.ID,
            CourseID = courseCategory.CourseID,
            CategoryID = courseCategory.CategoryID,
        };
    }

    public static CourseCategory ToCreateCourseCategoryDto(this CourseCategoryDto dto)
    {
        return new CourseCategory
        {
            ID = dto.ID,
            CourseID = dto.CourseID,
            CategoryID = dto.CategoryID,
        };
    }
}
