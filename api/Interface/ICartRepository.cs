using api.DTO.Cart;
using api.Model;

namespace api.Interface;

public interface ICartRepository
{
    Task<List<CartItem>> GetAllAsync();
    Task<Cart?> AddAsync(long courseId);
    Task<CartItem?> DeleteAsync(long ID);

}
