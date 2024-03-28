using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainingym.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    member_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.member_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_memberid = table.Column<long>(type: "bigint", nullable: false),
                    fk_productid = table.Column<long>(type: "bigint", nullable: false),
                    order_dateorder = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Order_Member",
                        column: x => x.fk_memberid,
                        principalTable: "Member",
                        principalColumn: "member_id");
                    table.ForeignKey(
                        name: "FK_Order_Product",
                        column: x => x.fk_productid,
                        principalTable: "Product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_memberid",
                table: "Order",
                column: "fk_memberid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fk_productid",
                table: "Order",
                column: "fk_productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
