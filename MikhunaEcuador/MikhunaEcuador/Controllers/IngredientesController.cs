using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MikhunaEcuador.Models;
using MikhunaEcuador.ViewModel;

namespace MikhunaEcuador.Controllers
{
    public class IngredientesController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: Ingredientes
        public ActionResult Index()
        {
            var ingrediente = db.Ingrediente.Include(i => i.Recetas);
            return View(ingrediente.ToList());
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre");
            return View();
        }

        // POST: Ingredientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecetaViewModel ingrediente)
        {
            if (ModelState.IsValid)
            {
                //Si existen recetas
                if (db.Receta.Count() > 0) {
                    Ingrediente ing = new Ingrediente
                    {
                        Nombre = ingrediente.NombreIngrediente,
                        Unidad = ingrediente.UnidadIngrediente,
                        RecetaID = 0
                    };

                    //Obtiene el último ID
                    var v = db.Receta.OrderByDescending(t => t.RecetaID).Take(1).FirstOrDefault();

                    ing.RecetaID = v.RecetaID;
                    db.Ingrediente.Add(ing);
                    db.SaveChanges();
                }
                
            }
            return RedirectToAction("Create", "Recetas");

        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre", ingrediente.RecetaID);
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredienteID,Nombre,Unidad,RecetaID")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre", ingrediente.RecetaID);
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            db.Ingrediente.Remove(ingrediente);
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
