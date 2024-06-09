using api.Interface;
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
    public IActionResult GetAll()
    {
        return Ok();
    }
    [HttpPost]
    [Route("CourseID:long")]
    public async Task<IActionResult> Add([FromQuery] long CourseID)
    {
        await _cartRepo.AddAsync(CourseID);
        return Ok();
    }
}
