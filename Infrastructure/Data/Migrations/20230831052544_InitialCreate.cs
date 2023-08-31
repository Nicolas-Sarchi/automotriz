using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CedulaPersona = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoPersona = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especialidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialidad", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlacaVehiculo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaVehiculo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModeloVehiculo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ColorVehiculo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KilometrajeVehiculo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdClienteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehiculo_cliente_IdClienteFk",
                        column: x => x.IdClienteFk,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEspecialidadFk = table.Column<int>(type: "int", nullable: false),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CedulaPersona = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoPersona = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPersona = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empleado_especialidad_IdEspecialidadFk",
                        column: x => x.IdEspecialidadFk,
                        principalTable: "especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NroOrden = table.Column<int>(type: "int", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    DiagnosticoCliente = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVehiculoFK = table.Column<int>(type: "int", nullable: false),
                    IdFacturaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_servicio_cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_servicio_vehiculo_IdVehiculoFK",
                        column: x => x.IdVehiculoFK,
                        principalTable: "vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "diagnostico_empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    IdOrdenServicioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnostico_empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diagnostico_empleado_empleado_IdEmpleadoFK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diagnostico_empleado_orden_servicio_IdOrdenServicioFK",
                        column: x => x.IdOrdenServicioFK,
                        principalTable: "orden_servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado_orden_servicio",
                columns: table => new
                {
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdOrdenServicioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado_orden_servicio", x => new { x.IdEmpleadoFk, x.IdOrdenServicioFk });
                    table.ForeignKey(
                        name: "FK_empleado_orden_servicio_empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_orden_servicio_orden_servicio_IdOrdenServicioFk",
                        column: x => x.IdOrdenServicioFk,
                        principalTable: "orden_servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpleadoOrdenServicio",
                columns: table => new
                {
                    EmpleadosId = table.Column<int>(type: "int", nullable: false),
                    OrdenesServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoOrdenServicio", x => new { x.EmpleadosId, x.OrdenesServicioId });
                    table.ForeignKey(
                        name: "FK_EmpleadoOrdenServicio_empleado_EmpleadosId",
                        column: x => x.EmpleadosId,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoOrdenServicio_orden_servicio_OrdenesServicioId",
                        column: x => x.OrdenesServicioId,
                        principalTable: "orden_servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrdenServicioFK = table.Column<int>(type: "int", nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<double>(type: "double", nullable: false),
                    ValorTotal = table.Column<double>(type: "double", nullable: false),
                    Iva = table.Column<double>(type: "double", nullable: false),
                    ValorManoObra = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_facturas_cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_facturas_orden_servicio_IdOrdenServicioFK",
                        column: x => x.IdOrdenServicioFK,
                        principalTable: "orden_servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orden_aprobacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NroOrdenAprobacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaOrdenAprobacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    IdOrdenServicioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orden_aprobacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orden_aprobacion_empleado_IdEmpleadoFK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orden_aprobacion_orden_servicio_IdOrdenServicioFK",
                        column: x => x.IdOrdenServicioFK,
                        principalTable: "orden_servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacturaFK = table.Column<int>(type: "int", nullable: false),
                    Repuesto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_factura_facturas_IdFacturaFK",
                        column: x => x.IdFacturaFK,
                        principalTable: "facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_aprobacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrdenAprobacionFK = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Repuesto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_aprobacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_aprobacion_orden_aprobacion_IdOrdenAprobacionFK",
                        column: x => x.IdOrdenAprobacionFK,
                        principalTable: "orden_aprobacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_aprobacion_IdOrdenAprobacionFK",
                table: "detalle_aprobacion",
                column: "IdOrdenAprobacionFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_factura_IdFacturaFK",
                table: "detalle_factura",
                column: "IdFacturaFK");

            migrationBuilder.CreateIndex(
                name: "IX_diagnostico_empleado_IdEmpleadoFK",
                table: "diagnostico_empleado",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_diagnostico_empleado_IdOrdenServicioFK",
                table: "diagnostico_empleado",
                column: "IdOrdenServicioFK");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_IdEspecialidadFk",
                table: "empleado",
                column: "IdEspecialidadFk");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_orden_servicio_IdOrdenServicioFk",
                table: "empleado_orden_servicio",
                column: "IdOrdenServicioFk");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoOrdenServicio_OrdenesServicioId",
                table: "EmpleadoOrdenServicio",
                column: "OrdenesServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_IdClienteFK",
                table: "facturas",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_IdOrdenServicioFK",
                table: "facturas",
                column: "IdOrdenServicioFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orden_aprobacion_IdEmpleadoFK",
                table: "orden_aprobacion",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_orden_aprobacion_IdOrdenServicioFK",
                table: "orden_aprobacion",
                column: "IdOrdenServicioFK");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_IdClienteFK",
                table: "orden_servicio",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_orden_servicio_IdVehiculoFK",
                table: "orden_servicio",
                column: "IdVehiculoFK");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_IdClienteFk",
                table: "vehiculo",
                column: "IdClienteFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_aprobacion");

            migrationBuilder.DropTable(
                name: "detalle_factura");

            migrationBuilder.DropTable(
                name: "diagnostico_empleado");

            migrationBuilder.DropTable(
                name: "empleado_orden_servicio");

            migrationBuilder.DropTable(
                name: "EmpleadoOrdenServicio");

            migrationBuilder.DropTable(
                name: "orden_aprobacion");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "orden_servicio");

            migrationBuilder.DropTable(
                name: "especialidad");

            migrationBuilder.DropTable(
                name: "vehiculo");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
