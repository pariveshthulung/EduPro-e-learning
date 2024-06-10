using System.Security.Claims;
using api.Entity;
using api.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository;

public class UserRepository : IUserRepository
{
    private IHttpContextAccessor _httpContextAccessor;

    public UserRepository(IHttpContextAccessor httpContextAccessor)
    {
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
        // var userId = GetUserID();
        // if (userId==null) return null;
        var username = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.GivenName).First().Value;
        if (username == null) return null;
        return username;

    }

    public bool IsloggedIn()
        => GetUserID() != null;
}
