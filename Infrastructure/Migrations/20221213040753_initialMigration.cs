using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comprador",
                columns: table => new
                {
                    compradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    nombreTienda = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    tipoTienda = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprador", x => x.compradorId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    stock = table.Column<int>(type: "int", maxLength: 250, precision: 12, nullable: false, defaultValue: 0),
                    precio = table.Column<decimal>(type: "decimal(14,2)", maxLength: 250, precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    ventaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    compradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.ventaId);
                    table.ForeignKey(
                        name: "FK_Ventas_Comprador_compradorId",
                        column: x => x.compradorId,
                        principalTable: "Comprador",
                        principalColumn: "compradorId");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    detalleVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    ventaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.detalleVentaId);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Producto_productoId",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Ventas_ventaId",
                        column: x => x.ventaId,
                        principalTable: "Ventas",
                        principalColumn: "ventaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_productoId",
                table: "DetalleVenta",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_ventaId",
                table: "DetalleVenta",
                column: "ventaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_compradorId",
                table: "Ventas",
                column: "compradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Comprador");
        }
    }
}
