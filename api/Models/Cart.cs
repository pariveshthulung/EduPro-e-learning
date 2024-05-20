using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class Cart
{
    public long ID { get; set; }
    public long StudentID { get; set; }
    [ForeignKey("StudentID")]
    public virtual User? User { get; set; }
    public string? CartStatus { get; set; }
}
