using api.DTO.AppUser;
using api.Entity;

namespace api.Mapper;

//extention class/method
public static class AppUserMapper
{
    public static AppUser ToAppUserFromCreateDto(this CreateAppUserRequestDto createAppUserRequestDto)
    {
        return new AppUser
        {
            Email = createAppUserRequestDto.Email,
            Name = createAppUserRequestDto.Name,
            PhoneNo = createAppUserRequestDto.PhoneNo,
            PasswordHash = createAppUserRequestDto.PasswordHash,
            UserType = createAppUserRequestDto.UserType,

        };
    }
}
