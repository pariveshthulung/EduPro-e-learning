using System.ComponentModel.DataAnnotations.Schema;
using api.Entity;

namespace api.Model;

public class Course
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string TeacherID { get; set; }
    [ForeignKey("TeacherID")]
    public virtual AppUser? User { get; set; } // Teacher
    public long NumberOfEnrollement { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public List<CourseCategory>? CourseCategories { get; set; }
}
