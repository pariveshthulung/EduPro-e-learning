using api.Data;
using api.DTO.Cart;
using api.Interface;
using api.Mapper;
using api.Model;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;

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

    public async Task<Cart> AddAsync(long courseId)
    {
        var islogin = _userRepository.IsloggedIn();

        if (islogin)
        {
            var dto = new CreateCartRequestDto()
            {
                CourseID = courseId,
                StudentID = _userRepository.GetUserID(),
            };
            await _context.Carts.AddAsync(dto.ToCreateCartRequestDto());
            await _context.SaveChangesAsync();
        }
        if (!islogin)
        {
            var storage = new LocalStorage();
            var key = courseId.ToString();
            var value = courseId;
            storage.Store(key, value);
        }
        return new Cart();
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
