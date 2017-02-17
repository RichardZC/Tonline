using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;

namespace Tonline.Controllers
{

    public class MaestroController : Controller
    {
        // GET: Maestro
        public ActionResult Index()
        {
            ViewBag.cboRubro = new SelectList(RubroBl.Listar(), "RubroId", "Denominacion");
            return View();
        }

        [HttpPost]
        public JsonResult MantenerRubro(rubro r)
        {
            if (r.RubroId == 0)
                RubroBl.Crear(r);
            else
                RubroBl.Actualizar(r);
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarRubros()
        {
            return Json(RubroBl.Listar(), JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        public JsonResult MantenerMarca(marca m)
        {
            if (m.MarcaId == 0)
                MarcaBl.Crear(m);
            else
                MarcaBl.Actualizar(m);
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarMarcas()
        {
            return Json(MarcaBl.Listar(), JsonRequestBehavior.AllowGet);
        }
        // GET: Maestro
       

        [HttpPost]
        public JsonResult MantenerCategoria(categoria c)
        {
            if (c.CategoriaId == 0)
                CategoriaBl.Crear(c);
            else
                CategoriaBl.Actualizar(c);
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarCategoriaRubro()
        {
            return Json(CategoriaBl.ListarCategoriaRubro(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerPersonaUsuario(string usuario)
        {
            var p = PersonaBL.ObtenerPersona(usuario);
            p.usuario = null;
            return Json(p, JsonRequestBehavior.AllowGet);
        }

    }


}



