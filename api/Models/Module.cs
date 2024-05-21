using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model;

public class Module
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public long? CourseID { get; set; }
    [ForeignKey("CouseID")]
    public virtual Course? Course { get; set; }
    public int Order { get; set; } // make it unique
}
