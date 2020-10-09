using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Necruit.Infrastructure.Persistence.Migrations
{
    public partial class Jobuser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_UserId",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2020, 10, 9, 17, 5, 56, 237, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_UserId",
                table: "Job",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_UserId",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2020, 10, 9, 17, 4, 29, 854, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_UserId",
                table: "Job",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
