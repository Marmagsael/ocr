using System.ComponentModel.DataAnnotations;

namespace Ocr.Models.Login;

public class AuthenticationDataModel
{
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "Please enter a user name")]
    public string UserName { get; set; } = string.Empty;


    [DataType(DataType.EmailAddress, ErrorMessage = "Invalid data type, please enter email address")]
    [Display(Name = "Email Address")]
    [Required]
    public string Email { get; set; } = string.Empty;


    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    [Required]
    [StringLength(20, ErrorMessage = "The {0} must be at least 8 characters long.", MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;


    [StringLength(20, ErrorMessage = "The {0} must be at least 8 characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Please confirm your password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ComfirmPassword { get; set; } = string.Empty;



}
