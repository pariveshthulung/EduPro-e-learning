using api.Data;
using api.DTO.Account;
using api.Entity;
using api.Mapper;
using api.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{

    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signIn;

    public AccountController(UserManager<AppUser> userManager, ITokenService token, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = token;
        _signIn = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        // var appuser = AppUserDto.ToAppUserFromCreateDto();
        try
        {
            var newUser = registerDto.ToAppUserFromCreateDto();
            var createdUser = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (createdUser.Succeeded)
            {
                var roleUser = await _userManager.AddToRoleAsync(newUser, "User");
                if (roleUser.Succeeded) return Ok(new AppUserDto
                {
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    Token = _tokenService.CreateToken(newUser)

                });
                else return StatusCode(500, roleUser.Errors);
            }
            else return StatusCode(500, createdUser.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
        if (user == null) return BadRequest("Email is not registered!!!");

        var result = await _signIn.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded) return Unauthorized("Invalid username and password");

        return Ok(new AppUserDto
        {
            UserName = user.UserName,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        });
    }
}
