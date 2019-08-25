using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PFSoftware.Inventio.Migrations
{
    public partial class PaymentMethodSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Sales");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "Sales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PaymentMethodId",
                table: "Sales",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentMethods_PaymentMethodId",
                table: "Sales",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaymentMethods_PaymentMethodId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_PaymentMethodId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Sales",
                nullable: true);
        }
    }
}
