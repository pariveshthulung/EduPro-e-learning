using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model;

public class CourseCategory
{
    public long ID { get; set; }
    public long CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
    public long CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    public virtual Category? Category { get; set; }
}
