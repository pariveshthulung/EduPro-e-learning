using api.Data;
using api.DTO.Cart;
using api.DTO.CartItem;
using api.Interface;
using api.Mapper;
using api.Migrations;
using api.Model;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUserRepository _userRepository;

    public CartRepository(ApplicationDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<Cart?> AddAsync(long courseId)
    {
        var islogin = _userRepository.IsloggedIn();

        if (islogin)
        {
            var userId = _userRepository.GetUserID();
            var cartExist = await _context.Carts.Where(c => c.StudentID == userId).FirstOrDefaultAsync();
            if (cartExist == null)
            {
                var cart = new Cart()
                {
                    StudentID = _userRepository.GetUserID(),
                };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
                var cartitem = new CreateCartItemRequestDto()
                {
                    CourseID = courseId,
                    CartID = cart.ID,
                };
                await _context.CartItems.AddAsync(cartitem.ToCreateCartItemRequestDto());
                await _context.SaveChangesAsync();
            }
            if (cartExist != null)
            {
                var cartitem = new CreateCartItemRequestDto()
                {
                    CourseID = courseId,
                    CartID = cartExist.ID,
                };
                await _context.CartItems.AddAsync(cartitem.ToCreateCartItemRequestDto());
                await _context.SaveChangesAsync();
            }

        }
        if (!islogin)
        {
            //temporary save data to database and move to user entity once login,clear temporary data
            var storage = new LocalStorage();
            var key = courseId.ToString();
            var value = courseId;
            storage.Store(key, value);
        }
        return new Cart();
    }

    public async Task<CartItem?> Delete(long courseId)
    {
        var currentUserId = _userRepository.GetUserID();
        var cartId = _context.Carts.Where(x => x.StudentID == currentUserId).Select(x => x.ID).FirstOrDefault();
        var cartItem = await _context.CartItems.Where(x => x.CartID == cartId && x.CourseID == courseId).FirstOrDefaultAsync();
        if (cartItem == null) return null;
        _context.CartItems.Remove(cartItem);
        return cartItem;
    }

    public async Task<List<CartItem>> GetAllAsync()
    {
        var currentUserId = _userRepository.GetUserID();
        var cartId = _context.Carts.Where(x => x.StudentID == currentUserId).Select(x => x.ID).FirstOrDefault();
        return await _context.CartItems.Where(x => x.CartID == cartId).ToListAsync();
    }

}


