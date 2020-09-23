using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class GetCategoryDto
    {
        public CategoryDto parentCategory { get; set; }
        public List<CategoryDto> childCategories { get; set; }
    }
}
