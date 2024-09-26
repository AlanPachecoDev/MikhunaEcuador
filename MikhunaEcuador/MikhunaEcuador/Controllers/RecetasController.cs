
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MikhunaEcuador.Models;
using MikhunaEcuador.ViewModel;

namespace MikhunaEcuador.Controllers
{
    public class RecetasController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: Recetas
        //public ActionResult Index()
        //{
        //    return View(db.Receta.ToList());
        //}

        // GET: Recetas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Receta receta = db.Receta.Find(id);
        //    if (receta == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(receta);
        //}

        // GET: Recetas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RecetaViewModel receta, string u)
        {
            if (ModelState.IsValid)
            {

                db.Receta.Add(new Receta
                {
                    Nombre = receta.Nombre,
                    Duracion = receta.Duracion,
                    CalificacionPromedio = 1,
                    UrlImagen = u
                }) ;
                db.SaveChanges();
                
            }

            return RedirectToAction("Create");
        }

        

        // GET: Recetas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Receta receta = db.Receta.Find(id);
        //    if (receta == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(receta);
        //}

        // POST: Recetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RecetaID,Nombre,Duracion,CalificacionPromedio")] Receta receta)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(receta).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(receta);
        //}


        // GET: Recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Home");
        }

        // [POST: Recetas/Delete/5]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = db.Receta.Find(id);
            if (receta != null)
            {
                var ingre = from a in db.Ingrediente
                            where a.RecetaID == receta.RecetaID
                            select a;

                var pasos = from b in db.Pasos
                            where b.RecetaID == receta.RecetaID
                            select b;
                //Elimina todos los ingredientes de la receta
                foreach (var a in ingre)
                {
                    db.Ingrediente.Remove(a);
                }

                //Elimina todos los pasos de la receta
                foreach (var a in pasos)
                {
                    db.Pasos.Remove(a);
                }

                //Elimina la receta
                db.Receta.Remove(receta);

                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Index", "Home");

        }


    



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
