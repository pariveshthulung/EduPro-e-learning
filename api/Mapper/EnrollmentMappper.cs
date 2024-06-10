using api.DTO.Enrollment;
using api.Model;

namespace api.Mapper;

public static class EnrollmentMappper
{
    public static EnrollmentDto ToEnrollmentDto(this Enrollment enrollment)
    {
        return new EnrollmentDto
        {
            StudentID = enrollment.StudentID,
            CourseID = enrollment.CourseID,
        };
    }

    public static Enrollment ToCreateEnrollmentDto(this CreateEnrollmentRequestDto dto)
    {
        return new Enrollment
        {
            CourseID = dto.CourseID,
        };
    }
    public static Enrollment ToUpdateEnrollmentDto(this UpdateEnrollmentRequestDto dto)
    {
        return new Enrollment
        {
            CourseID = dto.CourseID,
        };
    }
}
