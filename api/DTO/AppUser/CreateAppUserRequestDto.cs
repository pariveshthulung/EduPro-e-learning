﻿using System.ComponentModel.DataAnnotations;
using api.Constant;

namespace api.DTO.AppUser;

public class CreateAppUserRequestDto
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public long PhoneNo { get; set; }
    public string? PasswordHash { get; set; }
    public string? UserType { get; set; } = UserTypeConstant.Student;
    public string? UserStatus { get; set; } = UserStatusConstant.Active;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
