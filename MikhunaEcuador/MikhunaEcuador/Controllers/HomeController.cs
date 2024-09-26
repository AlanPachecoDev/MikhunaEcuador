using MikhunaEcuador.Controllers;
using MikhunaEcuador.Models;
using MikhunaEcuador.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mikhuna_Ecuador.Controllers
{
    
    public class HomeController : Controller
    {

        private MikhunaDB db = new MikhunaDB();

        [Authorize]
        // GET: Home
        public ActionResult Index( String Nombre)
        {
            if (Nombre != null) {

                var receta = from b in db.Receta
                             where b.Nombre.Contains(Nombre)
                             select b;

                return View(receta.ToList());
            }
            return View(db.Receta.ToList());
        }



        [HttpPost]
        public ActionResult BuscarNombreReceta(string Nombre) {
            if (Nombre != null) {
                var receta = from b in db.Receta
                                   where b.Nombre.Contains(Nombre) 
                                   select b;



                return RedirectToAction("Index", new { recetas = receta.ToList()});
            }
            return RedirectToAction("Index");
        }




        public ActionResult BuscarReceta(int id)
        {
            if (id > 0) {
                var receta = db.Receta.Find(id);
                if (receta != null)
                {
                    var ingredientes = from b in db.Ingrediente
                                       where b.RecetaID == id
                                       select b;
                    var pasos = from b in db.Pasos
                                where b.RecetaID == id
                                select b;
                    var comentarios = from b in db.Comentario
                                      where b.RecetaID == id
                                      select b;

                    var calificacion = from b in db.Calificacion
                                       where b.UsuarioID == UsuariosController.idUsu
                                       where b.RecetaID == id
                                       select b;


                    Calificacion calific = calificacion.FirstOrDefault();
                    if (calific == null)
                    {
                        calific = new Calificacion
                        {
                            NumeroEstrellas = -1
                        };
                    }



                    var aux = new ImprimirRecetaViewModel
                    {
                        Receta = receta,
                        Ingredientes = ingredientes.ToList(),
                        Pasos = pasos.ToList(),
                        Comentarios = comentarios.ToList(),
                        Calificacion = calific



                    };


                    return View(aux) ;
                }
            }

            var aux2 = new ImprimirRecetaViewModel
            {
                Receta = null,
                Ingredientes = null,
                Pasos = null
            };

            return View(aux2);

        }

        /* GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Login()
        {
            return View();
        }

        /* POST: Home/Create
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
