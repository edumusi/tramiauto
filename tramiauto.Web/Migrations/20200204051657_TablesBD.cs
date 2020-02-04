using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tramiauto.Web.Migrations
{
    public partial class TablesBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "DatosFiscalesRfc",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Automotores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroMotor = table.Column<string>(maxLength: 30, nullable: false),
                    NumeroSerie = table.Column<string>(maxLength: 20, nullable: false),
                    Marca = table.Column<string>(maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(maxLength: 10, nullable: false),
                    Tipo = table.Column<string>(maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automotores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automotores_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatosFiscales",
                columns: table => new
                {
                    Rfc = table.Column<string>(maxLength: 30, nullable: false),
                    Calle = table.Column<string>(maxLength: 50, nullable: false),
                    NumeroExterior = table.Column<int>(maxLength: 6, nullable: false),
                    NumeroInterior = table.Column<string>(maxLength: 20, nullable: false),
                    Colonia = table.Column<string>(maxLength: 50, nullable: false),
                    AlcaldiaMunicipio = table.Column<string>(maxLength: 60, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<int>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosFiscales", x => x.Rfc);
                });

            migrationBuilder.CreateTable(
                name: "TipoTramites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true),
                    Costo = table.Column<decimal>(maxLength: 7, nullable: false),
                    TiempoOperacion = table.Column<int>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTramites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 300, nullable: true),
                    Costo = table.Column<decimal>(maxLength: 7, nullable: false),
                    TiempoEntrega = table.Column<int>(maxLength: 5, nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 20, nullable: false),
                    TipoTramiteId = table.Column<int>(nullable: false),
                    AutomotorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramites_Automotores_AutomotorId",
                        column: x => x.AutomotorId,
                        principalTable: "Automotores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tramites_TipoTramites_TipoTramiteId",
                        column: x => x.TipoTramiteId,
                        principalTable: "TipoTramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TramiteAdjuntos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(maxLength: 50, nullable: true),
                    Ruta = table.Column<string>(maxLength: 300, nullable: true),
                    TramiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramiteAdjuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TramiteAdjuntos_Tramites_TramiteId",
                        column: x => x.TramiteId,
                        principalTable: "Tramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DatosFiscalesRfc",
                table: "Users",
                column: "DatosFiscalesRfc");

            migrationBuilder.CreateIndex(
                name: "IX_Automotores_UserEmail",
                table: "Automotores",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_TramiteAdjuntos_TramiteId",
                table: "TramiteAdjuntos",
                column: "TramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_AutomotorId",
                table: "Tramites",
                column: "AutomotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_TipoTramiteId",
                table: "Tramites",
                column: "TipoTramiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DatosFiscales_DatosFiscalesRfc",
                table: "Users",
                column: "DatosFiscalesRfc",
                principalTable: "DatosFiscales",
                principalColumn: "Rfc",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DatosFiscales_DatosFiscalesRfc",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DatosFiscales");

            migrationBuilder.DropTable(
                name: "TramiteAdjuntos");

            migrationBuilder.DropTable(
                name: "Tramites");

            migrationBuilder.DropTable(
                name: "Automotores");

            migrationBuilder.DropTable(
                name: "TipoTramites");

            migrationBuilder.DropIndex(
                name: "IX_Users_DatosFiscalesRfc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DatosFiscalesRfc",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
