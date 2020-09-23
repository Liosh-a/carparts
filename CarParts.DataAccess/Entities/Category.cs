﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarParts.DataAccess.Entities
{
    [Table("tblCategories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(128)]
        public string UrlSlug { get; set; }
        [Required, StringLength(255)]
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        [StringLength(2000)]
        public string Description { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Category Parent { get; set; }



        public virtual ICollection<FilterNameCategory> FilterNameCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
