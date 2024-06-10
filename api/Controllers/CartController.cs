using api.Interface;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;
[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepo;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepo = cartRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var cartItems = await _cartRepo.GetAllAsync();
        return Ok(cartItems.Select(x => x.ToCartDto()));
    }
    [HttpPost]
    [Route("CourseID:long")]
    public async Task<IActionResult> Add([FromQuery] long CourseID)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var cartitem = await _cartRepo.AddAsync(CourseID);
        return Ok(cartitem.ToCartDto());
    }
    [HttpDelete]
    [Route("courseId:long")]
    public async Task<IActionResult> Delete([FromQuery] long courseId)
    {
        var cartItem = await _cartRepo.DeleteAsync(courseId);
        if (cartItem == null) return NotFound("No item");
        return NoContent();
    }
}
