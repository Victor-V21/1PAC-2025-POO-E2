using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E1U2POO.API.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Detalle",
                table: "Detalle");

            migrationBuilder.RenameTable(
                name: "Detalle",
                newName: "Detalle_Planilla");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detalle_Planilla",
                table: "Detalle_Planilla",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Planilla_empleado_id",
                table: "Detalle_Planilla",
                column: "empleado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Planilla_planilla_id",
                table: "Detalle_Planilla",
                column: "planilla_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Planilla_Empleados_empleado_id",
                table: "Detalle_Planilla",
                column: "empleado_id",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Planilla_Planilla_planilla_id",
                table: "Detalle_Planilla",
                column: "planilla_id",
                principalTable: "Planilla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Planilla_Empleados_empleado_id",
                table: "Detalle_Planilla");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Planilla_Planilla_planilla_id",
                table: "Detalle_Planilla");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detalle_Planilla",
                table: "Detalle_Planilla");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_Planilla_empleado_id",
                table: "Detalle_Planilla");

            migrationBuilder.DropIndex(
                name: "IX_Detalle_Planilla_planilla_id",
                table: "Detalle_Planilla");

            migrationBuilder.RenameTable(
                name: "Detalle_Planilla",
                newName: "Detalle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detalle",
                table: "Detalle",
                column: "id");
        }
    }
}
