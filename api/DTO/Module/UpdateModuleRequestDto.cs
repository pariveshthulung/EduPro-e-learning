using System.ComponentModel.DataAnnotations.Schema;

namespace api.DTO.Module;

public class UpdateModuleRequestDto
{
    public string? Name { get; set; }
    public long? CourseID { get; set; }
    public int Order { get; set; } // make it unique
}
