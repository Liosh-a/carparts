using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class GerCarDto
    {
        public List<int> Pagination { get; set; }
        public List<int> Price { get; set; }
        public List<int> FilterList { get; set; }
    }
}
