using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_Estacionamento.Migrations
{
    public partial class criacaoBancoSqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(nullable: false),
                    HorarioChegada = table.Column<DateTime>(nullable: false),
                    HorarioSaida = table.Column<DateTime>(nullable: false),
                    HoraCobrada = table.Column<int>(nullable: false),
                    Preco = table.Column<string>(nullable: true),
                    ValorPagar = table.Column<double>(nullable: false),
                    Duracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamentos");
        }
    }
}
