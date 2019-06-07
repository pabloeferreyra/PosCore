using Microsoft.EntityFrameworkCore.Migrations;

namespace PFSoftware.Inventio.Migrations
{
    public partial class Productv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sales",
                table: "Products",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Sales",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "0");
        }
    }
}
