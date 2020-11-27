using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "538c5006-8094-4102-8449-7ca2f5f8c023", "AQAAAAEAACcQAAAAEDBpKMFpOYdDi7YmifvULQ0LAKSZKTG1g55FjqZONL0ILBJNd4AqcljAU8guwJ6eiw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a79a7137-8943-47f4-b74f-6d94d91ade90", "AQAAAAEAACcQAAAAEKeEzDUBHGKEhu59gv/LjnHPGQxmaYBYzRgCTMROfp4bfDrekdce7CHwRsHo0j6mtQ==" });
        }
    }
}
