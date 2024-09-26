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
    public class ComentariosController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        [Authorize]
        [HttpPost]
        //Para agregar un comentario
        public ActionResult AgregarComentario(String comentario, String i) {
            if (ModelState.IsValid)
            {
                if (comentario.CompareTo("") != 0)
                {
                    //Si el comentario no está vacío
                    Comentario contenido = new Comentario {
                        ComentarioID = 1,
                        Contenido = comentario,
                        RecetaID = Convert.ToInt32(i),
                        UsuarioID = UsuariosController.idUsu
                    };

                    db.Comentario.Add(contenido);

                    db.SaveChanges();
                    return RedirectToAction("BuscarReceta","Home", new {id = Convert.ToInt32(i) });
                }
            }

            return RedirectToAction("BuscarReceta", "Home", new { id = Convert.ToInt32(i) });

        }

        
        // GET: Comentarios
        public ActionResult Index()
        {
            var comentario = db.Comentario.Include(c => c.Receta).Include(c => c.Usuario);
            return View(comentario.ToList());
        }

        [Authorize]
        [HttpPost]
        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre");
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "NickName");
            return View();
        }

        // POST: Comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComentarioID,Contenido,RecetaID,UsuarioID")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre", comentario.RecetaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "NickName", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre", comentario.RecetaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "NickName", comentario.UsuarioID);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComentarioID,Contenido,RecetaID,UsuarioID")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecetaID = new SelectList(db.Receta, "RecetaID", "Nombre", comentario.RecetaID);
            ViewBag.UsuarioID = new SelectList(db.Usuario, "UsuarioID", "NickName", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
