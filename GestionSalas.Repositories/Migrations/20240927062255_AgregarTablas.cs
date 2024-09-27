using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionSalas.Repositories.Migrations
{
    public partial class AgregarTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notificaciones",
                columns: table => new
                {
                    id_notificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    mensaje = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificaciones", x => x.id_notificacion);
                });

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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    rol = table.Column<byte>(type: "tinyint", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    id_reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_sala = table.Column<int>(type: "int", nullable: false),
                    priority = table.Column<byte>(type: "tinyint", nullable: false),
                    hora_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    hora_fin = table.Column<DateTime>(type: "datetime", nullable: false),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.id_reserva);
                    table.ForeignKey(
                        name: "FK_reservas_salas_id_sala",
                        column: x => x.id_sala,
                        principalTable: "salas",
                        principalColumn: "id_sala",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservas_users_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_sala",
                table: "reservas",
                column: "id_sala");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_id_usuario",
                table: "reservas",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notificaciones");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "salas");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
