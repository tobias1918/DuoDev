using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSalas.Repositories.Migrations
{
    public partial class crearReservaConLlavesForaneas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_sala",
                table: "reservas",
                column: "id_sala");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_usuario",
                table: "reservas",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_salas_id_sala",
                table: "reservas",
                column: "id_sala",
                principalTable: "salas",
                principalColumn: "id_sala",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservas_usuarios_id_usuario",
                table: "reservas",
                column: "id_usuario",
                principalTable: "usuarios",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservas_salas_id_sala",
                table: "reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_reservas_usuarios_id_usuario",
                table: "reservas");

            migrationBuilder.DropIndex(
                name: "IX_reservas_id_sala",
                table: "reservas");

            migrationBuilder.DropIndex(
                name: "IX_reservas_id_usuario",
                table: "reservas");
        }
    }
}
