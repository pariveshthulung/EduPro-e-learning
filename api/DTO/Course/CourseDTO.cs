using System.ComponentModel.DataAnnotations.Schema;

namespace api.DTO.Course;

public class CourseDTO
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    // public long TeacherID { get; set; }
    // [ForeignKey("TeacherID")]
    // public virtual AppUser? User { get; set; } // Teacher
    public long NumberOfEnrollement { get; set; }
    // public DateTime LastUpdated { get; set; } = DateTime.Now;

    // public List<CourseCategory>? CourseCategories { get; set; }
}
