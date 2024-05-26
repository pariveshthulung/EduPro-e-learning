namespace api.DTO.Lesson;

public class UpdateLessonRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }

    public int Order { get; set; }
    public long ModuleID { get; set; }
}
