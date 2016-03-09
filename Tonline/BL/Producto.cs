using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class Producto
    {
        public int ArticuloId { get; set; }
        public string Denominacion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
