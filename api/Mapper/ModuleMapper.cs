using api.DTO.Module;
using api.Model;

namespace api.Mapper;

public static class ModuleMapper
{
    public static ModuleDto ToModuleDto(this Module module)
    {
        return new ModuleDto
        {
            ID = module.ID,
            Name = module.Name,
            CourseID = module.CourseID,
            Order = module.Order,
        };
    }

    public static Module ToCreateModuleDto(this CreateModuleRequestDto dto)
    {
        return new Module
        {
            Name = dto.Name,
            CourseID = dto.CourseID,
            Order = dto.Order,
        };
    }

    public static Module ToUpdateModuleDto(this ModuleDto dto)
    {
        return new Module
        {
            Name = dto.Name,
            CourseID = dto.CourseID,
            Order = dto.Order,
        };
    }
}
