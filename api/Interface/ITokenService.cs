using api.Entity;

namespace api;

public interface ITokenService
{
    string CreateToken(AppUser appUser);
}
