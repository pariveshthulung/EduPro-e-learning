using api.Data;
using api.DTO.Cart;
using api.Interface;
using api.Model;

namespace api.Repository;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Cart> AddAsync(CreateCartRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Cart?> Delete(long ID)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cart>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

}
