using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Necruit.Infrastructure.Persistence.Migrations
{
    public partial class Jobuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruitment_Job_JobId",
                table: "Recruitment");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Recruitment",
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
                value: new DateTime(2020, 10, 9, 17, 4, 29, 854, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.AddForeignKey(
                name: "FK_Recruitment_Job_JobId",
                table: "Recruitment",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recruitment_Job_JobId",
                table: "Recruitment");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Recruitment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2020, 10, 9, 17, 1, 41, 723, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.AddForeignKey(
                name: "FK_Recruitment_Job_JobId",
                table: "Recruitment",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
