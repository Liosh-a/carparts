using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Dto.DtoModels
{
    public class ForgotPasswordDto
    {
        [EmailAddress(ErrorMessage = "Має бути пошта!")]
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Email { get; set; }
    }
}