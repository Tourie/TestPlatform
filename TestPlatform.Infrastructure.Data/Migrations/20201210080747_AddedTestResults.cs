using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class AddedTestResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRightAnswer",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "testResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RightAnswers = table.Column<int>(type: "int", nullable: false),
                    Answers = table.Column<int>(type: "int", nullable: false),
                    finished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_testResults_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_testResults_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54a391f4-3ece-4276-850d-7c84b1e06eb7", "AQAAAAEAACcQAAAAEEfhiqjeKqP8zBD8GsIVvHeeTlblxIo5PbNMfFhaQ+tBAZI8+yAALnc/UNkoS6diUA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_testResults_TestId",
                table: "testResults",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_testResults_UserId1",
                table: "testResults",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_UserId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "testResults");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "IdRightAnswer",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20daa07d-fdb0-445f-b5c3-8ca37c375e32", "AQAAAAEAACcQAAAAECOfojkWNc4sojzPjKN0dBbXVKHTU6JSv9KepkcayG0eLXefLFlZ78GFSb1VaC7nAw==" });
        }
    }
}
