using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tonline.Controllers
{
    public class BuscarController : Controller
    {
        // GET: Buscar
        public ActionResult Productos(string id = "")
        {
            ViewBag.id = id;
            return View();
        }
    }
}