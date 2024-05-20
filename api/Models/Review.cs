using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Review
{
    public long ID { get; set; }
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
    public DateTime ReviewDate { get; set; }

    public long StudentID { get; set; }
    [ForeignKey("StudentID")]
    public virtual User? User { get; set; } // Student
    public int CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
}
