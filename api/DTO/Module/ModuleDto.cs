using System.ComponentModel.DataAnnotations.Schema;
using api.Model;

namespace api.DTO.Module;

public class ModuleDto
{
    public long ID { get; set; }
    public string? Name { get; set; }
    public long? CourseID { get; set; }
    public int Order { get; set; } // make it unique
}
