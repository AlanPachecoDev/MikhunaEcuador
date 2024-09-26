
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MikhunaEcuador.Models;
using MikhunaEcuador.ViewModel;

namespace MikhunaEcuador.Controllers
{
    public class PasosController : Controller
    {
        private MikhunaDB db = new MikhunaDB();

        // GET: Pasos
        public ActionResult Index()
        {
            return View(db.Pasos.ToList());
        }

        // GET: Pasos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasos pasos = db.Pasos.Find(id);
            if (pasos == null)
            {
                return HttpNotFound();
            }
            return View(pasos);
        }

        // GET: Pasos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pasos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecetaViewModel pasos)
        {
            
            if (ModelState.IsValid)
            {

                Pasos pas = new Pasos
                {
                    Paso = pasos.Paso
                };

                //Obtiene el último ID
                var v = db.Receta.OrderByDescending(t => t.RecetaID).First();

                pas.RecetaID = v.RecetaID;
                db.Pasos.Add(pas);
                db.SaveChanges();
            }
            
                        return RedirectToAction("Create", "Recetas");
        }

        // GET: Pasos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasos pasos = db.Pasos.Find(id);
            if (pasos == null)
            {
                return HttpNotFound();
            }
            return View(pasos);
        }

        // POST: Pasos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PasosID,Paso")] Pasos pasos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasos);
        }

        // GET: Pasos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasos pasos = db.Pasos.Find(id);
            if (pasos == null)
            {
                return HttpNotFound();
            }
            return View(pasos);
        }

        // POST: Pasos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pasos pasos = db.Pasos.Find(id);
            db.Pasos.Remove(pasos);
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
