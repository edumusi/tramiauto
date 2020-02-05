using Microsoft.EntityFrameworkCore.Migrations;

namespace tramiauto.Web.Migrations
{
    public partial class UserDbII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automotores_User_UserId",
                table: "Automotores");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Automotores_UserId",
                table: "Automotores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Automotores");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Automotores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLoginId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    FixedPhone = table.Column<string>(maxLength: 20, nullable: true),
                    DatosFiscalesRfc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_DatosFiscales_DatosFiscalesRfc",
                        column: x => x.DatosFiscalesRfc,
                        principalTable: "DatosFiscales",
                        principalColumn: "Rfc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_AspNetUsers_UserLoginId",
                        column: x => x.UserLoginId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automotores_UsuarioId",
                table: "Automotores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DatosFiscalesRfc",
                table: "Usuarios",
                column: "DatosFiscalesRfc");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UserLoginId",
                table: "Usuarios",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automotores_Usuarios_UsuarioId",
                table: "Automotores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automotores_Usuarios_UsuarioId",
                table: "Automotores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Automotores_UsuarioId",
                table: "Automotores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Automotores");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Automotores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatosFiscalesRfc = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FixedPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserLoginId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_DatosFiscales_DatosFiscalesRfc",
                        column: x => x.DatosFiscalesRfc,
                        principalTable: "DatosFiscales",
                        principalColumn: "Rfc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_AspNetUsers_UserLoginId",
                        column: x => x.UserLoginId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automotores_UserId",
                table: "Automotores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DatosFiscalesRfc",
                table: "User",
                column: "DatosFiscalesRfc");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserLoginId",
                table: "User",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automotores_User_UserId",
                table: "Automotores",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
