using System.ComponentModel.DataAnnotations.Schema;
using api.Entity;

namespace api.Model;

public class Cart
{
    public long ID { get; set; }
    public string StudentID { get; set; }
    [ForeignKey("StudentID")]
    public virtual AppUser? User { get; set; }
    public string? CartStatus { get; set; }
}
