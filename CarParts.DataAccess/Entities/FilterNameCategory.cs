using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarParts.DataAccess.Entities
{
    [Table("tblFilterNameCategories")]
    public class FilterNameCategory
    {
        [ForeignKey("FilterNameOf"), Key, Column(Order = 0)]
        public int FilterNameId { get; set; }
        public virtual FilterName FilterNameOf { get; set; }

        [ForeignKey("CategoryOf"), Key, Column(Order = 1)]
        public int CategoryId { get; set; }
        public virtual Category CategoryOf { get; set; }
    }
}
