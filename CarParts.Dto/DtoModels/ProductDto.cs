using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Dto.DtoModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Decimal PurchasePrice { get; set; }

        public Decimal SellingPrice { get; set; }

        public int ProductionStartYear { get; set; }

        public int ProductionStopYear { get; set; }

        public string UniqueName { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public string CategoryName { get; set; }

        public List<GetFilterDto> Filter { get; set; }
    }
}
