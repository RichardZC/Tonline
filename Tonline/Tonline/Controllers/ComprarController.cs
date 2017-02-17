using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tonline.Controllers
{
    public class ComprarController : Controller
    {
        
        // GET: Comprar
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public JsonResult RealizarPedido(int pClienteId, List<Pedido>pPedidos) {
            return Json(true);
        }
    }
    public class Pedido
    {
        public int ProductoId { get; set; }
        public string Denominacion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}