using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class CategoriaBl:Repositorio<categoria>
    {
        public static List<CategoriaRubro> ListarCategoriaRubro()
        {
            using (var bd = new BDEntities())
            {
                return bd.categoria
                    .Select(x => new CategoriaRubro
                    {
                        CategoriaId = x.CategoriaId,
                        Denominacion = x.Denominacion,
                        RubroId = x.rubro.RubroId,
                        Rubro = x.rubro.Denominacion
                    }).ToList();
            }
        }
    }
}
