using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Enrollment
{
    public long ID { get; set; }
    public long StudentID { get; set; }
    [ForeignKey("StudentID")]
    public virtual Student? Student { get; set; }
    public long CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }

    public DateTime EnrollmentDate { get; set; }
    public DateTime CompletedDate { get; set; }
}
