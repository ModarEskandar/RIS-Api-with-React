using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApi.Data.Migrations
{
    public partial class SeedOrdersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4de9b7a9-9578-4d8c-8401-80da9149cd30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bebc506-7f21-48a5-936b-a233dd179b3b");

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "972637b6-57e6-4ae5-afe6-3178dbefeab8", "d50e7bab-4d40-4af9-95d4-51bbd6456a71", "administrator", "ADMINISTRATOR" },
                    { "e3b3b495-ba6c-4ad6-87a9-284b3957c8e2", "acefe6d3-26a7-4d61-990e-21ba16e32fc7", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "RadOrder",
                columns: new[] { "Id", "Insertdate", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 6, 19, 30, 23, 746, DateTimeKind.Local).AddTicks(6904), 1 },
                    { 2, new DateTime(2023, 2, 6, 19, 30, 23, 746, DateTimeKind.Local).AddTicks(6929), 2 },
                    { 3, new DateTime(2023, 2, 6, 19, 30, 23, 746, DateTimeKind.Local).AddTicks(6931), 3 },
                    { 4, new DateTime(2023, 2, 6, 19, 30, 23, 746, DateTimeKind.Local).AddTicks(6933), 4 },
                    { 5, new DateTime(2023, 2, 6, 19, 30, 23, 746, DateTimeKind.Local).AddTicks(6935), 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "972637b6-57e6-4ae5-afe6-3178dbefeab8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3b3b495-ba6c-4ad6-87a9-284b3957c8e2");

            migrationBuilder.DeleteData(
                table: "RadOrder",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RadOrder",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RadOrder",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RadOrder",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RadOrder",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4de9b7a9-9578-4d8c-8401-80da9149cd30", "9c429331-1a89-40f0-9213-2288e7e90c59", "user", "USER" },
                    { "6bebc506-7f21-48a5-936b-a233dd179b3b", "cc33cedf-ce48-49db-aaf8-ceb8fe2252de", "administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Firstname", "Givenid", "Insertdate", "Lastname", "Middlename", "Nationalidnumber" },
                values: new object[,]
                {
                    { 1, "patient1", "11111", new DateTime(2023, 2, 6, 19, 12, 32, 187, DateTimeKind.Local).AddTicks(8157), "father1", null, "11111111111" },
                    { 2, "patient2", "22222", new DateTime(2023, 2, 6, 19, 12, 32, 187, DateTimeKind.Local).AddTicks(8330), "father2", null, "11111111111" },
                    { 3, "patient3", "33333", new DateTime(2023, 2, 6, 19, 12, 32, 187, DateTimeKind.Local).AddTicks(8350), "father3", null, "11111111111" },
                    { 4, "patient4", "44444", new DateTime(2023, 2, 6, 19, 12, 32, 187, DateTimeKind.Local).AddTicks(8368), "father4", null, "11111111111" },
                    { 5, "patient5", "55555", new DateTime(2023, 2, 6, 19, 12, 32, 187, DateTimeKind.Local).AddTicks(8385), "father5", null, "11111111111" }
                });
        }
    }
}
