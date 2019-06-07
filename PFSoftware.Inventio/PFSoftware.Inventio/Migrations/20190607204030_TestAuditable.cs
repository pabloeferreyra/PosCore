using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PFSoftware.Inventio.Migrations
{
    public partial class TestAuditable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Clients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteUserId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteUserId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Categories");
        }
    }
}
