using Microsoft.EntityFrameworkCore.Migrations;

namespace Operadoras.API.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operadoras",
                columns: table => new
                {
                    OperadoraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeOperadora = table.Column<string>(type: "TEXT", nullable: true),
                    NumTelefone = table.Column<string>(type: "TEXT", nullable: true),
                    ObsOperadora = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadoras", x => x.OperadoraId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operadoras");
        }
    }
}
