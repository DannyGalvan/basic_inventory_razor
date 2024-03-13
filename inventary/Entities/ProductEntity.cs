using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class ProductsEntity
    {
        [Key]
        [StringLength(10)]
        public String Id { get; set; }

        [Required]
        [StringLength (100)]
        public string Name { get; set; }

        [StringLength (600)]
        public string Description { get; set; }

        public int TotalQuantity { get; set; }

        //relacion con categorias
        public string CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

        //relacion con almacenamiento
        public List<StorageEntity> Storages { get; set; }


    }
}
