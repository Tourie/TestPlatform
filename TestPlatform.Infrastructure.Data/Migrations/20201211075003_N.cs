using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6ffa543-8179-4fd9-a478-ffd8290f2ae7", "AQAAAAEAACcQAAAAEOBVtXUHW2TKV042GHQZF42CemCLhdwQYNXHiCPTHLu07nW+IkuxapmT0TDhPoipRQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69481e0a-ff82-468a-b679-d8540b66e819", "AQAAAAEAACcQAAAAEHEGz+y8I5P245z9uQjynMIwE2DSH96S+bhwAM0FhkB1eS+s/hnUBhOf4tx1UF5rLQ==" });
        }
    }
}
