using System.ComponentModel.DataAnnotations;
using api.Constant;

namespace api.DTO.Account;

public class AppUserDto
{
    public string? UserName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Token { get; set; }

}
