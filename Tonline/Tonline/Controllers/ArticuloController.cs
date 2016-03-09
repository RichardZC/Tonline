using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;

namespace Tonline.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            ViewBag.cboCategoria = new SelectList(CategoriaBl.Listar(), "CategoriaId", "Denominacion");
            ViewBag.cboMarca = new SelectList(MarcaBl.Listar(), "MarcaId", "Denominacion");

            return View();
        }

        [HttpPost]
        public JsonResult Mantener(articulo a)
        {
            if (a.ArticuloId==0)
                ArticuloBl.Crear(a);
            else
                ArticuloBl.Actualizar(a);
            return Json(true,JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult Buscar(string pClave)
        {
            return Json(ArticuloBl.Listar(x => x.Denominacion.Contains(pClave)).Take(15).ToList(), JsonRequestBehavior.AllowGet);
        }
      
    }
}