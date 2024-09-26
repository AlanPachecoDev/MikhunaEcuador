using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MikhunaEcuador.Models;

namespace MikhunaEcuador.Controllers
{
    public class FavoritosController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: Favoritos
        public ActionResult Index()
        {
            return View(db.Favoritos.ToList());
        }

        // GET: Favoritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favoritos favoritos = db.Favoritos.Find(id);
            if (favoritos == null)
            {
                return HttpNotFound();
            }
            return View(favoritos);
        }

        // GET: Favoritos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favoritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FavoritosID")] Favoritos favoritos)
        {
            if (ModelState.IsValid)
            {
                db.Favoritos.Add(favoritos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favoritos);
        }

        // GET: Favoritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favoritos favoritos = db.Favoritos.Find(id);
            if (favoritos == null)
            {
                return HttpNotFound();
            }
            return View(favoritos);
        }

        // POST: Favoritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FavoritosID")] Favoritos favoritos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoritos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favoritos);
        }

        // GET: Favoritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favoritos favoritos = db.Favoritos.Find(id);
            if (favoritos == null)
            {
                return HttpNotFound();
            }
            return View(favoritos);
        }

        // POST: Favoritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favoritos favoritos = db.Favoritos.Find(id);
            db.Favoritos.Remove(favoritos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
