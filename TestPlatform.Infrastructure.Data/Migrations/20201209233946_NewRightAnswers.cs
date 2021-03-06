﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPlatform.Infrastructure.Data.Migrations
{
    public partial class NewRightAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRightAnswer",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isTruth",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Name", "QuestionId", "isTruth" },
                values: new object[,]
                {
                    { 1, "1 ответ 1 вопроса", 1, false },
                    { 2, "2 ответ 1 вопроса", 1, false },
                    { 3, "1 ответ 2 вопроса", 2, false },
                    { 4, "2 ответ 2 вопроса", 2, false },
                    { 5, "1 ответ", 3, false },
                    { 6, "2 ответ", 3, false },
                    { 7, "1 ответ", 4, false },
                    { 8, "2 ответ", 4, false },
                    { 9, "1 овтет", 5, false },
                    { 10, "2 ответ", 5, false }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09e2f6c8-f404-4297-aaa7-c0270028ab4b", "AQAAAAEAACcQAAAAEHAYRlwWoJwqT8Yk6r5ha7i+6FsLN5B+UDz3MyqcGhcmc56BSBFScV9l3+0DvsMKBg==" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdRightAnswer",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdRightAnswer",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdRightAnswer",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdRightAnswer",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "IdRightAnswer",
                value: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IdRightAnswer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "isTruth",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "DD20FD22-4350-4D1C-98C4-E82F21C1F414",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f4bd9e6-c9e0-4654-9459-8b6f1643f66d", "AQAAAAEAACcQAAAAEFca/L2bvG98yzu3LBJPCGP8wN4AWvFIjbgrvta8q421zZicOry5U/SHN6p1Wv5H1w==" });
        }
    }
}
