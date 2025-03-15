using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E1U2POO.API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    planilla_id = table.Column<int>(type: "INTEGER", nullable: false),
                    empleado_id = table.Column<int>(type: "INTEGER", nullable: false),
                    salario_base = table.Column<decimal>(type: "TEXT", nullable: false),
                    horas_extra = table.Column<decimal>(type: "TEXT", nullable: false),
                    monto_horas_extra = table.Column<decimal>(type: "TEXT", nullable: false),
                    bonificacion = table.Column<decimal>(type: "TEXT", nullable: false),
                    salario_neto = table.Column<decimal>(type: "TEXT", nullable: false),
                    comentarios = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    apellidos = table.Column<string>(type: "TEXT", nullable: false),
                    documento = table.Column<string>(type: "TEXT", nullable: false),
                    fecha_contratacio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    departamento = table.Column<string>(type: "TEXT", nullable: true),
                    puesto_de_trabajo = table.Column<string>(type: "TEXT", nullable: true),
                    salario_base = table.Column<decimal>(type: "TEXT", nullable: false),
                    activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planilla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    periodo = table.Column<string>(type: "TEXT", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planilla", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Planilla");
        }
    }
}
