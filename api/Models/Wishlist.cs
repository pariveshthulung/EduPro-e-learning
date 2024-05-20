using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Wishlist
{
    public long ID { get; set; }
    public long StudentID { get; set; }
    public long CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
}
