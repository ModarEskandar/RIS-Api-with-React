using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApi.Data.Migrations
{
    public partial class AlterPatientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gendre",
                table: "patients");

            migrationBuilder.AlterColumn<string>(
                name: "Nationalidnumber",
                table: "patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Insertdate",
                value: new DateTime(2023, 2, 4, 15, 30, 42, 629, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Insertdate",
                value: new DateTime(2023, 2, 4, 15, 30, 42, 629, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Insertdate",
                value: new DateTime(2023, 2, 4, 15, 30, 42, 629, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Insertdate",
                value: new DateTime(2023, 2, 4, 15, 30, 42, 629, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Insertdate",
                value: new DateTime(2023, 2, 4, 15, 30, 42, 629, DateTimeKind.Local).AddTicks(6637));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nationalidnumber",
                table: "patients",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Gendre",
                table: "patients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gendre", "Insertdate" },
                values: new object[] { 0, new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gendre", "Insertdate" },
                values: new object[] { 0, new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9342) });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Gendre", "Insertdate" },
                values: new object[] { 0, new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Gendre", "Insertdate" },
                values: new object[] { 0, new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Gendre", "Insertdate" },
                values: new object[] { 0, new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9667) });
        }
    }
}
