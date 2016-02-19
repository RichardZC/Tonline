using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BE;
using BL;

namespace Tonline.Controllers
{
    public class CategoriaController : Controller
    {
       

        // GET: Categoria
        public ActionResult Index()
        {
            ViewBag.cboRubro = new SelectList(RubroBl.Listar(), "RubroId", "Denominacion");
            return View();
        }
        public JsonResult Lista()
        {
            return Json(CategoriaBl.Listar(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CboRubro()
        {
            return Json(RubroBl.Listar(), JsonRequestBehavior.AllowGet);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = CategoriaBl.Obtener(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(categoria categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriaBl.Crear(categoria);
                return Json(categoria,JsonRequestBehavior.AllowGet) ;
            }
            return Json(false, JsonRequestBehavior.AllowGet); ;
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = CategoriaBl.Obtener(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Denominacion")] categoria categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriaBl.Actualizar(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoria categoria = CategoriaBl.Obtener(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaBl.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
