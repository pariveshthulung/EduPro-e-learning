using System.Security.Claims;
using api.Entity;
using api.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository;

public class UserRepository : ControllerBase, IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private IHttpContextAccessor _httpContextAccessor;

    public UserRepository(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetUserID()
    {
        // bool isloggedIn = IsloggedIn();
        // if (isloggedIn) return _userManager.GetUserId(User);
        // return "No login";
        var userId = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
        // var newID = _userManager.GetUserId(_httpContextAccessor.HttpContext?.User);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return null;
        }
        return userId;
    }

    public string GetUserName()
    {
        bool isloggedIn = IsloggedIn();
        if (isloggedIn) return _userManager.GetUserName(User);
        return "No login";

    }

    public bool IsloggedIn()
        => GetUserID() != null;
}
