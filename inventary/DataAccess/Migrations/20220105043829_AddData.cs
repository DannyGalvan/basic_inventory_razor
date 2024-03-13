using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Warehouse_WarehouseId",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "WherehouseId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "WarehouseAdress",
                table: "Warehouse");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId",
                table: "Warehouse",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseAddress",
                table: "Warehouse",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WarehouseId");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
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
                columns: new[] { "WarehouseId", "WarehouseAddress", "WarehouseName" },
                values: new object[,]
                {
                    { "5f6965ed-6c00-4de3-91dc-1b4fa8e58f39", "Calle 8 Con 23", "Bodega Central" },
                    { "d00d441b-1c15-4666-8d0b-6f0265e73b92", "932 Pallet Street, La Grange (Dutchess), NY 12540", "Bodega Norte" },
                    { "2cb270a8-1cf6-42f6-95a0-57f2c9cd3866", "4447 Dane Street, Yakima, WA 98908", "Bodega Sur" },
                    { "e2575230-b216-4a87-84e0-29b37c9ed6ae", "3003 Arrowood Drive, Jacksonville, FL 32257", "Bodega Este" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Warehouse_WarehouseId",
                table: "Storage",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Warehouse_WarehouseId",
                table: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "ASH");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "ASP");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "HGR");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "PRF");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "SLD");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: "VDJ");

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "WarehouseId",
                keyValue: "2cb270a8-1cf6-42f6-95a0-57f2c9cd3866");

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "WarehouseId",
                keyValue: "5f6965ed-6c00-4de3-91dc-1b4fa8e58f39");

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "WarehouseId",
                keyValue: "d00d441b-1c15-4666-8d0b-6f0265e73b92");

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "WarehouseId",
                keyValue: "e2575230-b216-4a87-84e0-29b37c9ed6ae");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "WarehouseAddress",
                table: "Warehouse");

            migrationBuilder.AddColumn<string>(
                name: "WherehouseId",
                table: "Warehouse",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseAdress",
                table: "Warehouse",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "WherehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Warehouse_WarehouseId",
                table: "Storage",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "WherehouseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
