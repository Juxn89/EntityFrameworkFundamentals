using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkFundamentals.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[] { new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf2"), null, "Pending activities", 20 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "Weight" },
                values: new object[] { new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf3"), null, "Personal activities", 50 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "Priority", "Title" },
                values: new object[] { new Guid("10be4d76-8e50-4606-8628-ce9aede5cd10"), new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf2"), new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), null, 1, "Paymente of public sercices" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CategoryId", "CreationDate", "Description", "Priority", "Title" },
                values: new object[] { new Guid("10be4d76-8e50-4606-8628-ce9aede5cd20"), new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf3"), new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), null, 0, "Finish watching movie on Netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("10be4d76-8e50-4606-8628-ce9aede5cd10"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("10be4d76-8e50-4606-8628-ce9aede5cd20"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("10be4d76-8e50-4606-8628-ce9aede5cdf3"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
