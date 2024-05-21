using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model;

public class CartItem
{
    public long ID { get; set; }
    public long CartID { get; set; }
    [ForeignKey("CartID")]
    public virtual Cart? Cart { get; set; }
    public long? CourseID { get; set; }
    [ForeignKey("CourseID")]
    public virtual Course? Course { get; set; }
    public bool IsChecked { get; set; }
}
