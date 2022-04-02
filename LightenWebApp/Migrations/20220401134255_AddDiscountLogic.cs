using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightenWebApp.Migrations
{
    public partial class AddDiscountLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "RegCustDiscount",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoPiecesDiscount",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TwoPiecesDiscountPercentage",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegCustDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TwoPiecesDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TwoPiecesDiscountPercentage",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
