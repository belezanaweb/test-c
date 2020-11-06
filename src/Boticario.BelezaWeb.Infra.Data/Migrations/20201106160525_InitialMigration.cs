using Microsoft.EntityFrameworkCore.Migrations;

namespace Boticario.BelezaWeb.Infra.Data.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					name: "Product",
					columns: table => new
					{
						Sku = table.Column<int>(nullable: false),
						Name = table.Column<string>(maxLength: 500, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Product", x => x.Sku);
					});

			migrationBuilder.CreateTable(
					name: "Inventory",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("Sqlite:Autoincrement", true),
						ProductSku = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Inventory", x => x.Id);
						table.ForeignKey(
											name: "FK_Inventory_Product_ProductSku",
											column: x => x.ProductSku,
											principalTable: "Product",
											principalColumn: "Sku",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					name: "Warehouse",
					columns: table => new
					{
						Id = table.Column<int>(nullable: false)
									.Annotation("Sqlite:Autoincrement", true),
						InventoryId = table.Column<int>(nullable: false),
						Locality = table.Column<string>(maxLength: 100, nullable: false),
						Quantity = table.Column<int>(nullable: false),
						Type = table.Column<string>(maxLength: 50, nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Warehouse", x => x.Id);
						table.ForeignKey(
											name: "FK_Warehouse_Inventory_InventoryId",
											column: x => x.InventoryId,
											principalTable: "Inventory",
											principalColumn: "Id",
											onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateIndex(
					name: "IX_Inventory_ProductSku",
					table: "Inventory",
					column: "ProductSku",
					unique: true);

			migrationBuilder.CreateIndex(
					name: "IX_Warehouse_InventoryId",
					table: "Warehouse",
					column: "InventoryId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					name: "Warehouse");

			migrationBuilder.DropTable(
					name: "Inventory");

			migrationBuilder.DropTable(
					name: "Product");
		}
	}
}
