using CarParts.Helpers.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace CarParts.Dto.DtoModels
{
    public class RegisterDto
    {
        [checkEmailExisting(ErrorMessage = "Already exist")]
        [EmailAddress(ErrorMessage = "Має бути пошта!")]
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$", ErrorMessage = "Password must be at least 6 characters and contain digits, upper and lower case")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string PasswordConfirm { get; set; }
    }
}