using domain.Entities;
using domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "ApiKeyScheme")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _service.ObtenerTodosLosProductos();
            return Ok(new
            {
                success = true,
                message = "Productos obtenidos correctamente.",
                status = 200,
                data = productos
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _service.ObtenerDetalleProducto(id);
            if (producto == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"No se encontró un producto con el ID {id}.",
                    status = 404
                });
            }

            return Ok(new
            {
                success = true,
                message = "Producto obtenido correctamente.",
                status = 200,
                data = producto
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            await _service.CrearProducto(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, new
            {
                success = true,
                message = "Producto creado correctamente.",
                status = 201,
                data = producto
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            var existente = await _service.ObtenerDetalleProducto(id);
            if (existente == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"No se encontró un producto con el ID {id} para actualizar.",
                    status = 404
                });
            }

            await _service.ActualizarProducto(id, producto);
            return Ok(new
            {
                success = true,
                message = "Producto actualizado correctamente.",
                status = 200
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existente = await _service.ObtenerDetalleProducto(id);
            if (existente == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"No se encontró un producto con el ID {id} para eliminar.",
                    status = 404
                });
            }

            await _service.EliminarProducto(id);
            return Ok(new
            {
                success = true,
                message = "Producto eliminado correctamente.",
                status = 200
            });
        }
    }
}
