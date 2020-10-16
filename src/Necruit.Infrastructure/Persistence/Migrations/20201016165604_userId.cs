using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Necruit.Infrastructure.Persistence.Migrations
{
    public partial class userId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_User_UserId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Talent_User_UserId",
                table: "Talent");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Talent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InterviewFeedback",
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
                value: new DateTime(2020, 10, 16, 19, 56, 3, 183, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_User_UserId",
                table: "InterviewFeedback",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Talent_User_UserId",
                table: "Talent",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewFeedback_User_UserId",
                table: "InterviewFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Talent_User_UserId",
                table: "Talent");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Talent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InterviewFeedback",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateTime(2020, 10, 9, 17, 5, 56, 237, DateTimeKind.Local).AddTicks(4985));

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewFeedback_User_UserId",
                table: "InterviewFeedback",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Talent_User_UserId",
                table: "Talent",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}