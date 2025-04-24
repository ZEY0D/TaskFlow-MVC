using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public string Fullname { get; set; }
}
