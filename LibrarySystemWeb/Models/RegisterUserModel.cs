using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystemWeb.Models;

public partial class RegisterUserModel
{

    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [MinLength(11, ErrorMessage = "Phone must be at least 6 characters")]
    public string? Phone { get; set; }

    public string Type { get; set; } = "USER";

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Please confirm your password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string RetypePassword { get; set; } = null!;

    public bool Blocked { get; set; } = false;
    public bool Registered { get; set; } = false;
    public string Message { get; set; } = string.Empty;

}
