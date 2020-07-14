using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarParts.DataAccess.Entities
{
    [Table("tblImage")]
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Name { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Path { get; set; }

        [ForeignKey("ProductOf")]
        public int ProductId { get; set; }

        public virtual Product ProductOf { get; set; }
    }
}
