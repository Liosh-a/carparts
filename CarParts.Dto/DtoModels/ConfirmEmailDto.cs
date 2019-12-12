using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class ConfirmEmailDto
    {
        [Required(ErrorMessage = "Cant't be empty")]
        public string Code { get; set; }
    }
}