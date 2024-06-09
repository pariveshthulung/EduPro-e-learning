using api.Data;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class WishlistRepository : IWishlistRepository
{
    private readonly ApplicationDbContext _context;

    public WishlistRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Wishlist?> AddAsync(Wishlist wishlist)
    {
        await _context.Wishlists.AddAsync(wishlist);
        await _context.SaveChangesAsync();
        return wishlist;
    }


    public async Task<Wishlist?> Delete(long ID)
    {
        var wishlist = await _context.Wishlists.Where(x => x.ID == ID).FirstOrDefaultAsync();
        if (wishlist == null) return null;
        _context.Wishlists.Remove(wishlist);
        await _context.SaveChangesAsync();

        return wishlist;
    }

    public async Task<List<Wishlist>?> GetAllAsync()
    {
        return await _context.Wishlists.ToListAsync();
    }
}
