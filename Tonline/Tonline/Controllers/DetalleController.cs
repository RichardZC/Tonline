using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Tonline.Models;
namespace Tonline.Controllers
{

    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index(int id=0)
        {
            ViewBag.ArticuloId = id;
            return View();
        }

        public JsonResult ListarCompra()
        {
            if (Session["compras"] == null)
                return Json(new List<Producto>(), JsonRequestBehavior.AllowGet);

            var compra = (List<Producto>)Session["compras"];
            return Json(compra, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarArticuloPrincipal()
        {
            return Json(ArticuloBl.ListarProducto(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerArticulo(int pArticuloId)
        {
            return Json(ArticuloBl.Obtener(pArticuloId), JsonRequestBehavior.AllowGet);
        }
    }
}