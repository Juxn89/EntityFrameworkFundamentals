﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkFundamentals.Migrations
{
    public partial class AddedWeightPropertyOnCatetegoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Category");
        }
    }
}
