using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarParts.DataAccess.Entities
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Name { get; set; }

        [Column(TypeName= "date")]
        public DateTime ProductionStart { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime ProductionStop { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public Decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public Decimal SellingPrice { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string ProductionStartYear { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string ProductionStopYear { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string UniqueName { get; set; }

        public virtual ICollection<Filter> Filtres { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
