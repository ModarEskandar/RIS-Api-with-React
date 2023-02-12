using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApi.Data.Migrations
{
    public partial class AddOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "patients",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "RadOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insertdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadOrder_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Insertdate",
                value: new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Insertdate",
                value: new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Insertdate",
                value: new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Insertdate",
                value: new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Insertdate",
                value: new DateTime(2023, 2, 3, 21, 8, 31, 934, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.CreateIndex(
                name: "IX_RadOrder_PatientId",
                table: "RadOrder",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadOrder");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "patients",
                newName: "PatientId");

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "Insertdate",
                value: new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "Insertdate",
                value: new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "Insertdate",
                value: new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 4,
                column: "Insertdate",
                value: new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "PatientId",
                keyValue: 5,
                column: "Insertdate",
                value: new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9194));
        }
    }
}
