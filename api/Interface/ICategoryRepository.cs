using api.DTO.Category;
using api.Model;

namespace api.Interface;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(long ID);
    Task<Category> AddAsync(CreateCategoryRequestDto categoryDto);
    Task<Category?> UpdateAsync(long ID, UpdateCategoryRequestDto dto);
    Task<Category?> Delete(long ID);

}
