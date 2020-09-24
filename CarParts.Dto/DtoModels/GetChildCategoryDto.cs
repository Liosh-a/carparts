using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class GetChildCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ProductCount { get; set; }
    }
}
