using api.DTO.Account;
using api.Entity;

namespace api.Mapper;

//extention class/method
public static class AppUserMapper
{
    public static AppUser ToAppUserFromCreateDto(this RegisterDto registerDto)
    {
        return new AppUser
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            PhoneNo = registerDto.PhoneNo,
        };
    }
}
