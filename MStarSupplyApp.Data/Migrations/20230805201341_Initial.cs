using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MStarSupplyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MERCADORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NUMEROREGISTRO = table.Column<int>(type: "int", nullable: false),
                    FABRICANTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TIPO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCADORIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMENTACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOCAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MERCADORIAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMENTACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MOVIMENTACAO_MERCADORIA_MERCADORIAID",
                        column: x => x.MERCADORIAID,
                        principalTable: "MERCADORIA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTACAO_MERCADORIAID",
                table: "MOVIMENTACAO",
                column: "MERCADORIAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMENTACAO");

            migrationBuilder.DropTable(
                name: "MERCADORIA");
        }
    }
}
