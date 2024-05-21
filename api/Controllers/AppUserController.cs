using api.Data;
using api.DTO.AppUser;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller;

[Route("api/appuser")]
[ApiController]
public class AppUserController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    public AppUserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] CreateAppUserRequestDto AppUserDto)
    {
        var appuser = AppUserDto.ToAppUserFromCreateDto();
        _context.AppUsers.Add(appuser);
        _context.SaveChanges();
        return Ok();
    }
}
