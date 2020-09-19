using CarParts.Helpers.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace CarParts.Dto.DtoModels
{
    public class CreateUser
    {
        [checkEmailExisting(ErrorMessage = "Already exist")]
        [EmailAddress(ErrorMessage = "Має бути пошта!")]
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,24}$", ErrorMessage = "Password must be at least 6 characters and contain digits, upper and lower case")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string UserName { get; set; }
        [RegularExpression(@"(38)?0[0-9]{2}[0-9]{7}", ErrorMessage = "Invalid Number")]
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Phone { get; set; }
    }
}