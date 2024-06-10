using System.ComponentModel.DataAnnotations.Schema;
using api.Entity;

namespace api.Model;

public class Review
{
    public long ID { get; set; }
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }

    public string? StudentID { get; set; }
    [ForeignKey("StudentID")]
    public virtual AppUser? User { get; set; } // Student
    public long? CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
}
