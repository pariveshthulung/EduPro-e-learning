using System.ComponentModel.DataAnnotations.Schema;
using api.Model;

namespace api.DTO.Module;

public class CreateModuleRequestDto
{
    public string? Name { get; set; }
    public long? CourseID { get; set; }
    public int Order { get; set; } // make it unique
}
