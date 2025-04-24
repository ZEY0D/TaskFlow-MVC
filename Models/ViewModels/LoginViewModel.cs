using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.ViewModels;

// for the data in the Login form

public class LoginViewModel
{

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
