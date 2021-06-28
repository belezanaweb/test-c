using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBoticario.DataAccess.Migrations
{
    public partial class bw_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bw_product",
                columns: table => new
                {
                    Sku = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 90, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdkeyReference = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bw_product", x => x.Sku);
                });

            migrationBuilder.CreateTable(
                name: "bw_inventory",
                columns: table => new
                {
                    Sku = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdkeyReference = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bw_inventory", x => x.Sku);
                    table.ForeignKey(
                        name: "FK_bw_inventory_bw_product_IdkeyReference",
                        column: x => x.IdkeyReference,
                        principalTable: "bw_product",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bw_warehouse",
                columns: table => new
                {
                    Sku = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Locality = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeWareHouseId = table.Column<string>(type: "TEXT", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdkeyReference = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bw_warehouse", x => x.Sku);
                    table.ForeignKey(
                        name: "FK_bw_warehouse_bw_inventory_IdkeyReference",
                        column: x => x.IdkeyReference,
                        principalTable: "bw_inventory",
                        principalColumn: "Sku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bw_inventory_IdkeyReference",
                table: "bw_inventory",
                column: "IdkeyReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bw_warehouse_IdkeyReference",
                table: "bw_warehouse",
                column: "IdkeyReference");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bw_warehouse");

            migrationBuilder.DropTable(
                name: "bw_inventory");

            migrationBuilder.DropTable(
                name: "bw_product");
        }
    }
}
