using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGerenciamento.EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    IdCompany = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Process",
                        column: x => x.IdCompany,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CNPJ", "Name", "State" },
                values: new object[] { 1L, "00000000000001", "Empresa A", "Rio de Janeiro" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CNPJ", "Name", "State" },
                values: new object[] { 2L, "00000000000002", "Empresa B", "São Paulo" });

            migrationBuilder.InsertData(
                table: "Process",
                columns: new[] { "Id", "Active", "CreationDate", "IdCompany", "Number", "State", "Value" },
                values: new object[,]
                {
                    { 1L, true, new DateTimeOffset(new DateTime(2007, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), 1L, "00001CIVELRJ", "Rio de Janeiro", 200000m },
                    { 2L, true, new DateTimeOffset(new DateTime(2007, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)), 1L, "00002CIVELSP", "São Paulo", 100000m },
                    { 3L, false, new DateTimeOffset(new DateTime(2007, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)), 1L, "00003TRABMG", "Minas Gerais", 10000m },
                    { 4L, false, new DateTimeOffset(new DateTime(2007, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)), 1L, "00004CIVELRJ", "Rio de Janeiro", 20000m },
                    { 5L, true, new DateTimeOffset(new DateTime(2007, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -2, 0, 0, 0)), 1L, "00005CIVELSP", "São Paulo", 35000m },
                    { 6L, true, new DateTimeOffset(new DateTime(2007, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), 2L, "00006CIVELRJ", "Rio Janeiro", 20000m },
                    { 7L, true, new DateTimeOffset(new DateTime(2007, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), 2L, "00007CIVELRJ", "Rio de Janeiro", 700000m },
                    { 8L, false, new DateTimeOffset(new DateTime(2007, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), 2L, "00008CIVELSP", "São Paulo", 500m },
                    { 9L, true, new DateTimeOffset(new DateTime(2007, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), 2L, "00009CIVELSP", "São Paulo", 32000m },
                    { 10L, false, new DateTimeOffset(new DateTime(2007, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), 2L, "00010TRABAM", "Amazonas", 1000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process_IdCompany",
                table: "Process",
                column: "IdCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
