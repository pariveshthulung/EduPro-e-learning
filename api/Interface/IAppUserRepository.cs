using api.DTO.Account;
using api.Entity;

namespace api.Interface;
public interface IAppUserRepository
{
    Task<AppUser> GetAllAsync();
    Task<AppUser> GetByIdAsync();


}
