using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APIProductos.Data;
using APIProductos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoEnCarritoController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public ProductoEnCarritoController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet("IdProductoEnCarrito/{IdProductoEnCarrito}")]
        public async Task<IActionResult> ObtenerProductoEnCarrito(int IdProductoEnCarrito)
        {
            try
            {
                var productoEnCarrito = await _db.ProductosEnCarrito.FirstOrDefaultAsync(pc => pc.IdProductoEnCarrito == IdProductoEnCarrito);
                if (productoEnCarrito == null)
                {
                    return NoContent();
                }
                return Ok(productoEnCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerProductosEnCarrito/IdUsuario/{IdUsuario}")]
        public async Task<IActionResult> ObtenerProductosEnCarrito(int IdUsuario)
        {
            try
            {
                List<ProductoEnCarrito> productosEnCarrito = await _db.ProductosEnCarrito.Where(pc => pc.IdUsuario == IdUsuario).ToListAsync();
                if (productosEnCarrito == null)
                {
                    return NoContent();
                }
                return Ok(productosEnCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AgregarAlCarrito/{IdUsuario}/{IdProducto}")]
        public async Task<IActionResult> AgregarAlCarrito(int IdUsuario, int IdProducto)
        {
            try
            {
                ProductoEnCarrito productoEnCarrito = await _db.ProductosEnCarrito.FirstOrDefaultAsync(pc => pc.IdUsuario == IdUsuario && pc.IdProducto == IdProducto);

                if (productoEnCarrito == null)
                {
                    productoEnCarrito = new ProductoEnCarrito
                    {
                        IdUsuario = IdUsuario,
                        IdProducto = IdProducto,
                        Cantidad = 1
                    };

                    await _db.ProductosEnCarrito.AddAsync(productoEnCarrito);
                }
                else
                {
                    productoEnCarrito.Cantidad++;
                    _db.ProductosEnCarrito.Update(productoEnCarrito);
                }

                await _db.SaveChangesAsync();
                return Ok(productoEnCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EliminarProductoEnCarrito/{IdProductoEnCarrito}")]
        public async Task<IActionResult> EliminarProductoEnCarrito(int IdProductoEnCarrito)
        {
            try
            {
                var productoEnCarrito = await _db.ProductosEnCarrito.FindAsync(IdProductoEnCarrito);
                if (productoEnCarrito == null)
                {
                    return NotFound();
                }

                _db.ProductosEnCarrito.Remove(productoEnCarrito);
                await _db.SaveChangesAsync();

                return Ok(productoEnCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("EliminarProductosEnCarritoPorUsuario/{IdUsuario}")]
        public async Task<IActionResult> EliminarProductosEnCarritoPorUsuario(int IdUsuario)
        {
            try
            {
                var productosEnCarritoUsuario = await _db.ProductosEnCarrito.Where(pc => pc.IdUsuario == IdUsuario).ToListAsync();
                if (productosEnCarritoUsuario == null || productosEnCarritoUsuario.Count == 0)
                {
                    return NotFound("No se encontraron productos en el carrito para el usuario especificado.");
                }

                _db.ProductosEnCarrito.RemoveRange(productosEnCarritoUsuario);
                await _db.SaveChangesAsync();

                return Ok(productosEnCarritoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // Otros métodos (actualizar cantidad, eliminar producto del carrito, etc.) pueden seguir el mismo patrón.
    }
}
