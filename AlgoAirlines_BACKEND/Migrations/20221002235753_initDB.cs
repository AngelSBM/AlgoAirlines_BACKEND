using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgoAirlines_BACKEND.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuertos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuertos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oficiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oficiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasajeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPasaporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajeros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLugarSalida = table.Column<int>(type: "int", nullable: false),
                    IdLugarLlegada = table.Column<int>(type: "int", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAvion = table.Column<int>(type: "int", nullable: false),
                    AvionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aeropuertos_IdLugarLlegada",
                        column: x => x.IdLugarLlegada,
                        principalTable: "Aeropuertos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Aeropuertos_IdLugarSalida",
                        column: x => x.IdLugarSalida,
                        principalTable: "Aeropuertos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vuelos_Aviones_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Aviones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VuelosPasajeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVuelo = table.Column<int>(type: "int", nullable: false),
                    IdPasajero = table.Column<int>(type: "int", nullable: false),
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    PasajeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VuelosPasajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VuelosPasajeros_Pasajeros_PasajeroId",
                        column: x => x.PasajeroId,
                        principalTable: "Pasajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VuelosPasajeros_Vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AvionId",
                table: "Vuelos",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_IdLugarLlegada",
                table: "Vuelos",
                column: "IdLugarLlegada");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_IdLugarSalida",
                table: "Vuelos",
                column: "IdLugarSalida");

            migrationBuilder.CreateIndex(
                name: "IX_VuelosPasajeros_PasajeroId",
                table: "VuelosPasajeros",
                column: "PasajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_VuelosPasajeros_VueloId",
                table: "VuelosPasajeros",
                column: "VueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oficiales");

            migrationBuilder.DropTable(
                name: "VuelosPasajeros");

            migrationBuilder.DropTable(
                name: "Pasajeros");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aeropuertos");

            migrationBuilder.DropTable(
                name: "Aviones");
        }
    }
}
