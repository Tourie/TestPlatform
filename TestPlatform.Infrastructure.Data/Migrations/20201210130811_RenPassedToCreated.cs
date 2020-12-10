using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class RenPassedToCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestUser_Tests_PassedTestsId",
                table: "TestUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestUser",
                table: "TestUser");

            migrationBuilder.DropIndex(
                name: "IX_TestUser_PassedTestsId",
                table: "TestUser");

            migrationBuilder.RenameColumn(
                name: "PassedTestsId",
                table: "TestUser",
                newName: "CreatedTestsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestUser",
                table: "TestUser",
                columns: new[] { "CreatedTestsId", "ParticipantsId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestUser_Tests_CreatedTestsId",
                table: "TestUser",
                column: "CreatedTestsId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestUser_Tests_CreatedTestsId",
                table: "TestUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestUser",
                table: "TestUser");

            migrationBuilder.DropIndex(
                name: "IX_TestUser_ParticipantsId",
                table: "TestUser");

            migrationBuilder.RenameColumn(
                name: "CreatedTestsId",
                table: "TestUser",
                newName: "PassedTestsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestUser",
                table: "TestUser",
                columns: new[] { "ParticipantsId", "PassedTestsId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78379fca-3870-46f3-8b54-9fcabae8fea7", "AQAAAAEAACcQAAAAECxrH31K3xOVVNX7e2kX0zCv/4/vgvkanKiBiXRTLLg8trfghAeu5Yq76+MhtTWpfA==" });

            migrationBuilder.CreateIndex(
                name: "IX_TestUser_PassedTestsId",
                table: "TestUser",
                column: "PassedTestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestUser_Tests_PassedTestsId",
                table: "TestUser",
                column: "PassedTestsId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
