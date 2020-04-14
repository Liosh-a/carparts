using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class GetCarDto
    {
        public int pageIndex { get; set; }
        //public Decimal[] Price { get; set; }
        public List<long> FilterList { get; set; }
    }
}
