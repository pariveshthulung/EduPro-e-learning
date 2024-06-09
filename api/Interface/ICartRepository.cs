using api.DTO.Cart;
using api.Model;

namespace api.Interface;

public interface ICartRepository
{
    Task<List<Cart>> GetAllAsync();
    Task<Cart> AddAsync(long courseId);
    Task<Cart?> Delete(long ID);
}
