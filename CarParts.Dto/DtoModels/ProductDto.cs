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

        public int CarId { get; set; }

        public int CategoryId { get; set; }

        public List<FilterDto> Filter { get; set; }
    }
}
