using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Model;

[Index(nameof(Order), IsUnique = true)]
public class Lesson
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
    public int Order { get; set; }
    public long ModuleID { get; set; }
    [ForeignKey("ModuleID")]
    public virtual Module? Module { get; set; }
}
