using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: false),
                    Aditivado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCombustivel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostoId = table.Column<int>(type: "int", nullable: true),
                    TipoCombustivelId = table.Column<int>(type: "int", nullable: true),
                    PrecoLitro = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustivel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combustivel_Postos_PostoId",
                        column: x => x.PostoId,
                        principalTable: "Postos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combustivel_TipoCombustivel_TipoCombustivelId",
                        column: x => x.TipoCombustivelId,
                        principalTable: "TipoCombustivel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combustivel_PostoId",
                table: "Combustivel",
                column: "PostoId");

            migrationBuilder.CreateIndex(
                name: "IX_Combustivel_TipoCombustivelId",
                table: "Combustivel",
                column: "TipoCombustivelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combustivel");

            migrationBuilder.DropTable(
                name: "Postos");

            migrationBuilder.DropTable(
                name: "TipoCombustivel");
        }
    }
}
