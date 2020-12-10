using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class FixUserTestResultId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_testResults_AspNetUsers_UserId1",
                table: "testResults");

            migrationBuilder.DropIndex(
                name: "IX_testResults_UserId1",
                table: "testResults");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "testResults");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "testResults",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78379fca-3870-46f3-8b54-9fcabae8fea7", "AQAAAAEAACcQAAAAECxrH31K3xOVVNX7e2kX0zCv/4/vgvkanKiBiXRTLLg8trfghAeu5Yq76+MhtTWpfA==" });

            migrationBuilder.CreateIndex(
                name: "IX_testResults_UserId",
                table: "testResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_testResults_AspNetUsers_UserId",
                table: "testResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_testResults_AspNetUsers_UserId",
                table: "testResults");

            migrationBuilder.DropIndex(
                name: "IX_testResults_UserId",
                table: "testResults");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "testResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "testResults",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2cf9020-174d-4949-84d0-69bb1d6947f9", "AQAAAAEAACcQAAAAEOFC7pH7SmvDXU5u56V+lezDQwft8RhAHuoMfUC9fJO5lw7KXBSM+QNh8qO0C0fzFQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_testResults_UserId1",
                table: "testResults",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_testResults_AspNetUsers_UserId1",
                table: "testResults",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
