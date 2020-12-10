using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class TestsOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_UserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassedTestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => new { x.ParticipantsId, x.PassedTestsId });
                    table.ForeignKey(
                        name: "FK_TestUser_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestUser_Tests_PassedTestsId",
                        column: x => x.PassedTestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2cf9020-174d-4949-84d0-69bb1d6947f9", "AQAAAAEAACcQAAAAEOFC7pH7SmvDXU5u56V+lezDQwft8RhAHuoMfUC9fJO5lw7KXBSM+QNh8qO0C0fzFQ==" });

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerId",
                value: "DD20FD22-4350-4D1C-98C4-E82F21C1F414");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerId",
                value: "DD20FD22-4350-4D1C-98C4-E82F21C1F414");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3,
                column: "OwnerId",
                value: "DD20FD22-4350-4D1C-98C4-E82F21C1F414");

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_PassedTestsId",
                table: "TestUser",
                column: "PassedTestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
