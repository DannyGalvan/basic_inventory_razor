using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class CategoryEntity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength (50)]
        public string CategoryName { get; set; }

        //relacion con productos
        public List<ProductsEntity> Products { get; set; }
    }
}