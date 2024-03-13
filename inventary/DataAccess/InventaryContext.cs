using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class InventaryContext: DbContext
    {
        public InventaryContext() : base()
        {

        }

        public InventaryContext(DbContextOptions<InventaryContext> options) : base(options)
        {

        }

        //producto
        public DbSet<ProductsEntity> Products { get; set; }   
        //categoria
        public DbSet<CategoryEntity> Category { get; set; } 
        //almacenamiento
        public DbSet<StorageEntity> Storage { get; set; }
        //bodegas
        public DbSet<WarehouseEntity> Warehouse { get; set; }
        //entradas y salidas
        public DbSet<InputOutputEntity> IntOut  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("server=DESKTOP-4L7JSNJ; Database=InventoryDb;User Id=sa; Password=andrea2911");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { Id = "ASH", CategoryName ="Aseo Hogar"},
                new CategoryEntity { Id = "ASP", CategoryName = "Aseo Personal" },
                new CategoryEntity { Id = "HGR", CategoryName = "Hogar" },
                new CategoryEntity { Id = "PRF", CategoryName = "Perfumeria" },
                new CategoryEntity { Id = "SLD", CategoryName = "Salud" },
                new CategoryEntity { Id = "VDJ", CategoryName = "Video Juegos" }
                );

            modelBuilder.Entity<WarehouseEntity>().HasData(
                new WarehouseEntity 
                {   
                    Id = Guid.NewGuid().ToString(), 
                    WarehouseName = "Bodega Central", 
                    WarehouseAddress="Calle 8 Con 23" 
                },
                new WarehouseEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Norte",
                    WarehouseAddress = "932 Pallet Street, La Grange (Dutchess), NY 12540"
                },
                new WarehouseEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Sur",
                    WarehouseAddress = "4447 Dane Street, Yakima, WA 98908"
                },
                new WarehouseEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Este",
                    WarehouseAddress = "3003 Arrowood Drive, Jacksonville, FL 32257"
                }
                );


        }
    }
}
