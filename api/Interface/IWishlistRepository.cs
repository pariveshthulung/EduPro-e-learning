using api.Model;

namespace api;

public interface IWishlistRepository
{
    Task<List<Wishlist>?> GetAllAsync();
    Task<Wishlist?> AddAsync(Wishlist wishlist);
    Task<Wishlist?> Delete(long ID);
}
