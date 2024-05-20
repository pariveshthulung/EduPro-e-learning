using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Course
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public long TeacherID { get; set; }
    [ForeignKey("TeacherID")]
    public virtual User? User { get; set; } // Teacher
    public long NumberOfEnrollement { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;

    public List<CourseCategory>? CourseCategories { get; set; }


}
