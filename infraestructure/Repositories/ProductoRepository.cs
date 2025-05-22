using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities;
using domain.Interfaces;
using infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using domain.Entities;
using domain.Interfaces;
using infraestructure.Data;
 


namespace infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosLosProductos()
            => await _context.Productos.ToListAsync();

        public async Task<Producto?> ObtenerDetalleProducto(int id)
            => await _context.Productos.FindAsync(id);

        public async Task CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProducto(Producto producto)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }


    }
}
