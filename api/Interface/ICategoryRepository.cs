using api.Model;

namespace api.Interface;

public interface ICategoryRepository
{
    Task<Category> GetAllAsync();
    Task<Category?> GetByIdAsync();
    Task<Category> AddAsync();
    Task<Category?> Update();
    Task<Category?> Delete();



}
