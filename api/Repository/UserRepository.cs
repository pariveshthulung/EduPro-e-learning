using api.Entity;
using api.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository;

public class UserRepository : ControllerBase, IUserRepository
{
    private readonly UserManager<AppUser> _userManager;

    public UserRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public string GetUserID()
    {
        bool isloggedIn = IsloggedIn();
        if (isloggedIn) return _userManager.GetUserId(User);
    }

    public string GetUserName()
    {
        bool isloggedIn = IsloggedIn();
        if (isloggedIn) return _userManager.GetUserName(User);
    }

    public bool IsloggedIn()
    {
        var user = _userManager.GetUserId(User);
        if (user == null) return false;
        else return true;
    }
}
