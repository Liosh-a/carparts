using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarParts.DataAccess.Entities
{
    [Table("tblCars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public Decimal Price { get; set; }

        //[Column]
        //public int HorsePower { get; set; }

        //[Column]
        //public int Mileage { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string UniqueName { get; set; }

        public virtual ICollection<Filter> Filtres { get; set; }
    }
}
