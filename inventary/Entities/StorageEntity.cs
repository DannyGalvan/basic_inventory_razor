using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class StorageEntity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        public string LastUpdate { get; set; }

        public int PartialQuantity { get; set; }

        //relacion con productos
        public string ProductId { get; set; }

        public ProductsEntity Product { get; set; }

        //relacion con bodegas

        public string WarehouseId { get; set; }
        
        public WarehouseEntity Warehouse { get; set; }

        //relacion con Movimientos (entradas y salidas)

        public List<InputOutputEntity> InputOutputs { get; set; }  
    }
}
