using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class ProductoDTO
    {
        public int Idproducto { get; set; }

        public int Idcategoria { get; set; }

        public string? Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal PrecioVenta { get; set; }

        public int Stock { get; set; }

        public string? Descripcion { get; set; }

        public byte[]? Imagen { get; set; }

        public bool? Estado { get; set; }
    }
}
