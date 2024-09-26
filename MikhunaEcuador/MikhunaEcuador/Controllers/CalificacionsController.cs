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
    public class CalificacionsController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        public ActionResult Calificar(int IDReceta, int Calificacion)
        {

            var califi = from a in db.Calificacion
                         where a.RecetaID == IDReceta
                         where a.UsuarioID == UsuariosController.idUsu
                         select a;

            var califica = califi.ToList();

            if (califica.Count() == 0)
            {
                if (Calificacion > 0 && IDReceta != 0)
                {
                    db.Calificacion.Add(new Calificacion
                    {
                        NumeroEstrellas = Calificacion,
                        RecetaID = IDReceta,
                        UsuarioID = UsuariosController.idUsu

                    });

                    db.SaveChanges();
                }
            }
            else
            {
                if (Calificacion > 0 && IDReceta != 0)
                {

                    if (califica != null)
                    {
                        califica.First().NumeroEstrellas = Calificacion;


                        if (ModelState.IsValid)
                        {

                            db.Entry(califica.First()).State = EntityState.Modified;
                            db.SaveChanges();

                        }
                    }
                }




            }


            return RedirectToAction("BuscarReceta", "Home", new { id = Convert.ToInt32(IDReceta) });
        }


        // GET: Calificacions
        public ActionResult Index()
        {
            return View(db.Calificacion.ToList());
        }

        // GET: Calificacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // GET: Calificacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calificacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalificacionID,NumeroEstrellas")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Calificacion.Add(calificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calificacion);
        }

        // GET: Calificacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // POST: Calificacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalificacionID,NumeroEstrellas")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calificacion);
        }

        // GET: Calificacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = db.Calificacion.Find(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // POST: Calificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacion calificacion = db.Calificacion.Find(id);
            db.Calificacion.Remove(calificacion);
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
