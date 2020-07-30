using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarParts.DataAccess.Entities
{
    [Table("tblAllCars")]
    public class AllCar
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Brand { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Model { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string ProductionStartYear { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string ProductionStopYear { get; set; }
        
        
    }
}
