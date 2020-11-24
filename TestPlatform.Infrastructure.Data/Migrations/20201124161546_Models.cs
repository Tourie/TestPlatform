using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTest",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    TestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTest", x => new { x.CategoriesId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_CategoryTest_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTest_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Testid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_Testid",
                        column: x => x.Testid,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Вопросы по математике", "Математика" },
                    { 2, "Вопросы по физике", "Физика" },
                    { 3, "Вопросы по программированию", "Программирование" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Description", "Name", "Time" },
                values: new object[,]
                {
                    { 1, "Описание", "Вопросы начального уровня", 12L },
                    { 2, "Описание 2 теста", "Вопросы среднего уровня", 16L },
                    { 3, "Описание 3 теста", "Вопросы повышенного уровня", 20L }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name", "Testid" },
                values: new object[,]
                {
                    { 1, "1 вопрос 1 теста", 1 },
                    { 2, "2 вопрос 1 теста", 1 },
                    { 3, "1 вопрос 2 теста", 2 },
                    { 4, "2 вопрос 2 теста", 2 },
                    { 5, "1 вопрос 3 теста", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTest_TestsId",
                table: "CategoryTest",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Testid",
                table: "Questions",
                column: "Testid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTest");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
