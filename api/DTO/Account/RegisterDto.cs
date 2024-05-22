using System.ComponentModel.DataAnnotations;
using api.Constant;

namespace api.DTO.Account;

public class RegisterDto
{
    public string? UserName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public long PhoneNo { get; set; }
    public string? Password { get; set; }

}
