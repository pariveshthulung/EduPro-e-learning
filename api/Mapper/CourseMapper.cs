using api.DTO.Course;
using api.Model;

namespace api.Mapper;

public static class CourseMapper
{
    public static CourseDTO ToCourseDto(this Course course)
    {
        return new CourseDTO
        {
            ID = course.ID,
            Name = course.Name,
            Description = course.Description,
            Price = course.Price,
            NumberOfEnrollement = course.NumberOfEnrollement,
            TeacherID = course.TeacherID,
            CourseCategories = course.CourseCategories.Where(x => x.CourseID == course.ID).ToList(),

        };
    }

    public static Course ToCourseFromCourseDto(this CreateCourseRequestDto courseDTO)
    {
        return new Course
        {
            Name = courseDTO.Name,
            Description = courseDTO.Description,
            Price = courseDTO.Price,
            TeacherID = courseDTO.TeacherID,

        };
    }
}
