using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSalas.Repositories.Migrations
{
    public partial class CreacionTablaSala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "salas",
                columns: table => new
                {
                    id_sala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    cod_sala = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    floor_sala = table.Column<byte>(type: "tinyint", nullable: false),
                    capacity_sala = table.Column<byte>(type: "tinyint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salas", x => x.id_sala);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "salas");
        }
    }
}
