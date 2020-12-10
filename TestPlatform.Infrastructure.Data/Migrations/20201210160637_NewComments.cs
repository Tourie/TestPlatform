using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class NewComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c55cbec7-9dad-46b8-8309-9ef5c56a2ee9", "AQAAAAEAACcQAAAAEDVZyaYpSRu6H0nyoLeaUTpkjZDKw6m+th6ej6Iw/sk2KPZdqN5hLS+r+MBp6xUZPw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1bdc3ca0-b0e7-4d5f-8272-664664c40145", "AQAAAAEAACcQAAAAEFcxG7fOSqKYdOq6pQPubkQLfJvtIpp/YnHEuMrCK66OqMDizb3s+WiNm1oTJNNo0w==" });
        }
    }
}
