using api.DTO.Module;
using api.Model;

namespace api;

public interface IModuleRepository
{
    Task<List<Module>?> GetAllAsync(long courseId);
    Task<Module?> GetByIdAsync(long ID);
    Task<Module?> AddAsync(Module module);
    Task<Module?> UpdateAsync(long ID, UpdateModuleRequestDto dto);
    Task<Module?> Delete(long ID);
}
