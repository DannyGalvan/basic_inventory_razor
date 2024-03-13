using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    WarehouseName = table.Column<string>(maxLength: 100, nullable: false),
                    WarehouseAddress = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 600, nullable: true),
                    TotalQuantity = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    LastUpdate = table.Column<string>(nullable: false),
                    PartialQuantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Storage_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntOut",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    InOutDate = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IsInput = table.Column<bool>(nullable: false),
                    StorageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntOut_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { "ASH", "Aseo Hogar" },
                    { "ASP", "Aseo Personal" },
                    { "HGR", "Hogar" },
                    { "PRF", "Perfumeria" },
                    { "SLD", "Salud" },
                    { "VDJ", "Video Juegos" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "WarehouseAddress", "WarehouseName" },
                values: new object[,]
                {
                    { "0d186bef-7494-47fd-8d14-18b39759254a", "Calle 8 Con 23", "Bodega Central" },
                    { "4724267d-ad95-4dc0-b85e-5d9767ee83af", "932 Pallet Street, La Grange (Dutchess), NY 12540", "Bodega Norte" },
                    { "2553bc96-47ec-494d-ab11-1abbe2c7143e", "4447 Dane Street, Yakima, WA 98908", "Bodega Sur" },
                    { "7b4eaf42-9343-4f67-a1b1-0eb78c30405c", "3003 Arrowood Drive, Jacksonville, FL 32257", "Bodega Este" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntOut_StorageId",
                table: "IntOut",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_ProductId",
                table: "Storage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_WarehouseId",
                table: "Storage",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntOut");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
