using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Necruit.Infrastructure.Persistence.Migrations
{
    public partial class Jobuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateTime", "Email", "IsActive", "LastUpdateTime", "Location", "MobilePhone", "Name", "Password", "Surname" },
                values: new object[] { 1, new DateTime(2020, 10, 9, 17, 1, 41, 723, DateTimeKind.Local).AddTicks(8087), "admin@admin.com", true, null, "Turkey", null, "admin", "1234", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}