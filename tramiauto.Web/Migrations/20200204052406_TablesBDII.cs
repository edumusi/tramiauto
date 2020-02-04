using Microsoft.EntityFrameworkCore.Migrations;

namespace tramiauto.Web.Migrations
{
    public partial class TablesBDII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Tramites",
                type: "decimal(18,4)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "TipoTramites",
                type: "decimal(18,4)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Tramites",
                type: "decimal(18,2)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "TipoTramites",
                type: "decimal(18,2)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldMaxLength: 7);
        }
    }
}
