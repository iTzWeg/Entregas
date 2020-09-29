using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entregas.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacao = table.Column<string>(nullable: true),
                    DataEntrega = table.Column<DateTime>(nullable: false),
                    Remetente = table.Column<string>(nullable: true),
                    Destinatario = table.Column<string>(nullable: true),
                    EnderecoDestinatario = table.Column<string>(nullable: true),
                    ValorEntrega = table.Column<float>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    Entregador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregas");
        }
    }
}
