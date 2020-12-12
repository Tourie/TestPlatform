using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class CreateTestAndTestsResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Started",
                table: "testResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b438a1d1-c339-4652-b40b-226df006aed0", "AQAAAAEAACcQAAAAEPC/aQbjbxIuIpIM0fUvvYULE2RmRgkK2fHJkvvh4sKHAX3WZ9NDZDsMBqizDZm+QA==" });

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 12, 12, 19, 38, 23, 208, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 12, 12, 19, 38, 23, 209, DateTimeKind.Utc).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2020, 12, 12, 19, 38, 23, 209, DateTimeKind.Utc).AddTicks(943));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Started",
                table: "testResults");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6ffa543-8179-4fd9-a478-ffd8290f2ae7", "AQAAAAEAACcQAAAAEOBVtXUHW2TKV042GHQZF42CemCLhdwQYNXHiCPTHLu07nW+IkuxapmT0TDhPoipRQ==" });
        }
    }
}
