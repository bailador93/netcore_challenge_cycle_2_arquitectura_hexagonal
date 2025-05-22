using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Producto
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public  string Categoria { get; set; }= string.Empty;
        public string Descripcion { get; set; } = string.Empty; 
        public string Imagen { get; set; } = string.Empty; // BASE 64
        public decimal Precio { get; set; }

        public bool Estado { get; set; }
         

    }
}
