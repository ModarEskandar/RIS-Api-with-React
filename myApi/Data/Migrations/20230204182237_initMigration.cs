using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApi.Data.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insertdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Givenid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalidnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Firstname", "Givenid", "Insertdate", "Lastname", "Middlename", "Nationalidnumber" },
                values: new object[,]
                {
                    { 1, "patient1", "11111", new DateTime(2023, 2, 4, 21, 22, 37, 48, DateTimeKind.Local).AddTicks(8540), "father1", null, "11111111111" },
                    { 2, "patient2", "22222", new DateTime(2023, 2, 4, 21, 22, 37, 48, DateTimeKind.Local).AddTicks(8652), "father2", null, "11111111111" },
                    { 3, "patient3", "33333", new DateTime(2023, 2, 4, 21, 22, 37, 48, DateTimeKind.Local).AddTicks(8666), "father3", null, "11111111111" },
                    { 4, "patient4", "44444", new DateTime(2023, 2, 4, 21, 22, 37, 48, DateTimeKind.Local).AddTicks(8679), "father4", null, "11111111111" },
                    { 5, "patient5", "55555", new DateTime(2023, 2, 4, 21, 22, 37, 48, DateTimeKind.Local).AddTicks(8691), "father5", null, "11111111111" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadOrder_PatientId",
                table: "RadOrder",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RadOrder");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
