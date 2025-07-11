using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOF.Desafios.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "desafio");

            migrationBuilder.CreateTable(
                name: "InformacionGeneral",
                schema: "desafio",
                columns: table => new
                {
                    IdDesafio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSegmentacion = table.Column<int>(type: "int", nullable: false),
                    TituloDesafio = table.Column<string>(type: "varchar(100)", nullable: false),
                    DescripcionDesafio = table.Column<string>(type: "varchar(500)", nullable: false),
                    LogotipoDesafio = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Promocion = table.Column<string>(type: "varchar(50)", nullable: false),
                    PuntosExtra = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<string>(type: "varchar(15)", nullable: false),
                    JsonMateriales = table.Column<string>(type: "varchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioPublicacion = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCierre = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    FechaCancela = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCancela = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionGeneral", x => x.IdDesafio);
                });

            migrationBuilder.CreateTable(
                name: "InformacionParticipante",
                schema: "desafio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDesafio = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<string>(type: "varchar(20)", nullable: false),
                    IdEstatusDesafio = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaUltimaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionParticipante", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacionGeneral",
                schema: "desafio");

            migrationBuilder.DropTable(
                name: "InformacionParticipante",
                schema: "desafio");
        }
    }
}
