using System.ComponentModel.DataAnnotations.Schema;
using api.Entity;

namespace api.Model;

public class Cart
{
    public long ID { get; set; }
    public string? StudentID { get; set; }
    [ForeignKey("StudentID")]
    public virtual AppUser? User { get; set; }
    public long? CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
    public string? CartStatus { get; set; }
}
