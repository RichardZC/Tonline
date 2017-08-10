using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;
using System.IO;

namespace Tonline.Controllers
{
    public class ArticuloController : Controller
    {
        private object db;

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
            if (a.ArticuloId == 0)
                ArticuloBl.Crear(a);
            else
                ArticuloBl.Actualizar(a);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Buscar(string pClave)
        {
            return Json(ArticuloBl.Listar(x => x.Denominacion.Contains(pClave)).Take(15).ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MantenerCaracteristica(caracteristica m)
        {
            if (m.CaracteristicaId == 0)
                CaracteristicaBl.Crear(m);
            else
                CaracteristicaBl.Actualizar(m);
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarCaracteristica(int ArticuloId)
        {
            return Json(CaracteristicaBl.Listar(), JsonRequestBehavior.AllowGet);

        }


        public JsonResult EliminarCaracteristica(int pid)
        {
            CaracteristicaBl.Eliminar(pid);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
      


    }
}