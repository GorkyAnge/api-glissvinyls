using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProductos.Migrations
{
    /// <inheritdoc />
    public partial class ProductosEnCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosEnCarrito_Productos_ProductoIdProducto",
                table: "ProductosEnCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ProductosEnCarrito_ProductoIdProducto",
                table: "ProductosEnCarrito");

            migrationBuilder.DropColumn(
                name: "ProductoIdProducto",
                table: "ProductosEnCarrito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoIdProducto",
                table: "ProductosEnCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosEnCarrito_ProductoIdProducto",
                table: "ProductosEnCarrito",
                column: "ProductoIdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosEnCarrito_Productos_ProductoIdProducto",
                table: "ProductosEnCarrito",
                column: "ProductoIdProducto",
                principalTable: "Productos",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
