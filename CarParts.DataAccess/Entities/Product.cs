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

        public DateTime ProductionStart { get; set; }

        public DateTime ProductionStop { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public Decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public Decimal SellingPrice { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string UniqueName { get; set; }

        public virtual ICollection<Filter> Filtres { get; set; }
    }
}
