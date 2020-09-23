using CarParts.Helpers.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace CarParts.Dto.DtoModels
{
    public class CreateCategoryDto
    {
        
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string UrlSlug { get; set; }
        [Required(ErrorMessage = "Поле не може бути пустим!")]
        public string Image { get; set; }
        public string Description { get; set; }
        public int? Parent_id { get; set; }
    }
}