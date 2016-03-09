using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tonline.Models;

namespace Tonline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
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

        [HttpPost]
        public JsonResult Autenticar(sesionBE s)
        {
            //string login = Request.Form["login_name"].Trim();
            //string pass = Request.Form["login_pw"].Trim();
            if (true)
            {
                s.sesion = true;
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

    }
}