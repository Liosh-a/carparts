using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class GerCarDto
    {
        public int[] Pagination { get; set; }
        public Decimal[] Price { get; set; }
        public List<int> FilterList { get; set; }
    }
}
