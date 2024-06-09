using System.ComponentModel.DataAnnotations.Schema;

namespace api.DTO.Course;

public class UpdateCourseRequestDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public List<long>? CategoryID { get; set; }

}
