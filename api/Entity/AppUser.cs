using System.ComponentModel.DataAnnotations;
using api.Constant;
using Microsoft.AspNetCore.Identity;

namespace api.Entity;

public class AppUser : IdentityUser
{
    // public string? Name { get; set; }
    public long PhoneNo { get; set; }
    public string? UserType { get; set; } = UserTypeConstant.Student;
    public string? UserStatus { get; set; } = UserStatusConstant.Active;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

}
