using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApi.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Insertdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Givenid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationalidnumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gendre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientId);
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "PatientId", "Firstname", "Gendre", "Givenid", "Insertdate", "Lastname", "Middlename", "Nationalidnumber" },
                values: new object[,]
                {
                    { 1, "patient1", 0, "11111", new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9019), "father1", null, "11111111111" },
                    { 2, "patient2", 0, "22222", new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9150), "father2", null, "11111111111" },
                    { 3, "patient3", 0, "33333", new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9166), "father3", null, "11111111111" },
                    { 4, "patient4", 0, "44444", new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9180), "father4", null, "11111111111" },
                    { 5, "patient5", 0, "55555", new DateTime(2023, 2, 2, 21, 34, 19, 393, DateTimeKind.Local).AddTicks(9194), "father5", null, "11111111111" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
