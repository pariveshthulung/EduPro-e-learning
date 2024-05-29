using api.Data;
using api.DTO.Module;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api;

public class ModuleRepository : IModuleRepository
{
    private readonly ApplicationDbContext _context;
    public ModuleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Module?> AddAsync(Module module)
    {
        await _context.Modules.AddAsync(module);
        await _context.SaveChangesAsync();
        return module;
    }

    public async Task<Module?> Delete(long ID)
    {
        var module = await _context.Modules.Where(x => x.ID == ID).FirstOrDefaultAsync();
        if (module == null) return null;
        _context.Modules.Remove(module);
        await _context.SaveChangesAsync();
        return module;
    }

    public async Task<List<Module>?> GetAllAsync(long courseId)
    {
        return await _context.Modules.Where(x => x.CourseID == courseId).ToListAsync();
    }

    public async Task<Module?> GetByIdAsync(long ID)
    {
        return await _context.Modules.Where(x => x.ID == ID).FirstOrDefaultAsync();
    }

    public async Task<Module?> UpdateAsync(long ID, UpdateModuleRequestDto dto)
    {
        var module = await _context.Modules.Where(x => x.ID == ID).FirstOrDefaultAsync();
        if (module == null) return null;
        module.CourseID = dto.CourseID;
        module.Name = dto.Name;
        module.Order = dto.Order;
        await _context.SaveChangesAsync();
        return module;

    }
}
