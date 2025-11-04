using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSubtotalComputedToDetalleFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "DetallesFactura",
                type: "numeric(12,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "DetallesFactura");
        }
    }
}
