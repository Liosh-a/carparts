using System.ComponentModel.DataAnnotations;

namespace CarParts.Dto.DtoModels
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Має бути пошта!")]
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Password { get; set; }
    }
}