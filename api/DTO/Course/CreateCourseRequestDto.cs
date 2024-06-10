using System.ComponentModel.DataAnnotations.Schema;
using api.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace api.DTO.Course;

public class CreateCourseRequestDto
{

    public string? Name { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public List<long>? CategoryID { get; set; }
    // public string? TeacherID { get; set; }

}
