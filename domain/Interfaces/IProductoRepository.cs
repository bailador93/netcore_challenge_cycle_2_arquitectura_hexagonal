using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities;


namespace domain.Interfaces
{
     public interface IProductoRepository
    {

        Task<IEnumerable<Producto>> ObtenerTodosLosProductos();
        Task<Producto?> ObtenerDetalleProducto(int id);
        Task CrearProducto(Producto producto);

        Task ActualizarProducto(Producto producto);

        Task EliminarProducto(Producto producto);

    }

    public interface IProductoService
    {

        Task<IEnumerable<Producto>> ObtenerTodosLosProductos();

        Task<Producto?> ObtenerDetalleProducto(int id);

        Task CrearProducto(Producto producto);

        Task ActualizarProducto(int id, Producto producto);

        Task EliminarProducto(int id);

    }

}
