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
        public JsonResult Crear(articulo a)
        {
            ArticuloBl.Crear(a);
            return Json(a,JsonRequestBehavior.AllowGet);
        }
    }
}