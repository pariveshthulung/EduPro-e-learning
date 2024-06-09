using api.DTO.Wishlist;
using api.Entity;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;
[ApiController]
[Route("api/wishlist")]
[Authorize]
public class WishlistController : ControllerBase
{
    private readonly IWishlistRepository _wishlistRepo;
    private readonly UserManager<AppUser> _userManager;

    public WishlistController(IWishlistRepository wishlistRepository, UserManager<AppUser> userManager)
    {
        _wishlistRepo = wishlistRepository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var wishlist = await _wishlistRepo.GetAllAsync();
        if (wishlist == null) return NotFound();
        return Ok(wishlist.Select(x => x.ToWishlistDto()));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateWishlistRequestDto dto)
    {
        var userId = _userManager.GetUserId(User);
        dto.StudentID = userId;
        var wishlist = await _wishlistRepo.AddAsync(dto.ToCreateWishlistDto());
        return Ok(wishlist);
    }

    [HttpDelete]
    [Route("ID:long")]
    public IActionResult Delete([FromRoute] long ID)
    {
        var wishlist = _wishlistRepo.Delete(ID);
        if (wishlist == null) return NotFound();
        return NoContent();
    }


}
