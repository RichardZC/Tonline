using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{

    public class ArticuloBl : Repositorio<articulo>
    {
        public static List<Producto> ListarProducto()
        {
            using (var bd = new BDEntities())
            {
                return bd.articulo.Take(6)
                    .Select(x => new Producto
                    {
                        ArticuloId = x.ArticuloId,
                        Cantidad = 1,
                        Denominacion = x.Denominacion,
                        Precio = x.Precio
                    }).ToList();
            }
        }
        public static List<Producto> BuscarProducto(string clave)
        {
            using (var bd = new BDEntities())
            {
                return bd.articulo.Where(x=>x.Denominacion.Contains(clave.Trim())).OrderBy(x=>x.Denominacion).Take(24)
                    .Select(x => new Producto
                    {
                        ArticuloId = x.ArticuloId,
                        Cantidad = 1,
                        Denominacion = x.Denominacion,
                        Precio = x.Precio
                    }).ToList();
            }
        }
    }
}
