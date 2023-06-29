using System.ComponentModel.DataAnnotations;

namespace HouseSale.Blazor.Models;

public class RegisterModels
{
    [StringLength(50, ErrorMessage = "FullName is less then 50"), MinLength(5, ErrorMessage = "FullName is more then 5"), Required(ErrorMessage = "FullName is Required")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Field can't be empty")]
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Profile picture is required")]
    public IFormFile ProfilePicture { get; set; }
}


