using System.ComponentModel.DataAnnotations;

namespace Unitagram.Application.Models.Identity;

public class RegisterRequest
{
    [Required(ErrorMessage = "Email can't be blank")]
    [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Username can't be blank")]
    [StringLength(15, MinimumLength = 4, ErrorMessage = "Username should be 4-15 chracters long")]
    [RegularExpression("^(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "Invalid input, please change you username")]
    public string UserName { get; set; } = string.Empty;


    [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain digits only")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password can't be blank")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirm Password can't be blank")]
    [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}