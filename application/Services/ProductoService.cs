using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities;
using domain.Interfaces;
using static application.Services.ProductoService;

namespace application.Services
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _repo;

        public ProductoService(IProductoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Producto>> ObtenerTodosLosProductos() => _repo.ObtenerTodosLosProductos();
        public Task<Producto?> ObtenerDetalleProducto(int id) => _repo.ObtenerDetalleProducto(id);
        public Task CrearProducto(Producto producto) => _repo.CrearProducto(producto);

        public async Task ActualizarProducto(int id, Producto producto)
        {
            var prod = await _repo.ObtenerDetalleProducto(id);
            if (prod == null) return;

            prod.Nombre = producto.Nombre;
            prod.Descripcion = producto.Descripcion;
            prod.Precio = producto.Precio;
            prod.Categoria = producto.Categoria;
            prod.Imagen = producto.Imagen;
            prod.Estado = producto.Estado;

            await _repo.ActualizarProducto(prod);
        }

        public async Task EliminarProducto(int id)
        {
            var prod = await _repo.ObtenerDetalleProducto(id);
            if (prod != null)
                await _repo.EliminarProducto(prod);
        }


    }


}

