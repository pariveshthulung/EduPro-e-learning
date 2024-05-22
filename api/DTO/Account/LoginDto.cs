﻿using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account;

public class LoginDto
{

    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]

    public string? Password { get; set; }
}
