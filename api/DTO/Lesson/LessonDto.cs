﻿namespace api.DTO.Lesson;

public class LessonDto
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
    public int Order { get; set; }
    public long ModuleID { get; set; }
}
