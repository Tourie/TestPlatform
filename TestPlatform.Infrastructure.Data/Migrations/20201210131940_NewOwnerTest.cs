using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class NewOwnerTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestUser");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26e7b209-d870-496d-bee8-24de4e4e1a07", "AQAAAAEAACcQAAAAEPRf9sotFqljVNg2bX5PLsLTM4TJhnOzdkCoE+GdTqZt1df9fRbx93w2HjeqWxdpwA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_OwnerId",
                table: "Tests",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_OwnerId",
                table: "Tests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_OwnerId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_OwnerId",
                table: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TestUser",
                columns: table => new
                {
                    CreatedTestsId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUser", x => new { x.CreatedTestsId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_TestUser_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestUser_Tests_CreatedTestsId",
                        column: x => x.CreatedTestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd8070e8-2448-4efe-b47f-a87984969b7f", "AQAAAAEAACcQAAAAEJDR1PJPmn3EJIrjgHGZPO0/jSctSZVlY8ip0li3w2dU5hLyCb2kVhZ5TMRmAJbX0w==" });

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_ParticipantsId",
                table: "TestUser",
                column: "ParticipantsId");
        }
    }
}
