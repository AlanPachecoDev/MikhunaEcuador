using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using MikhunaEcuador.Models;

namespace MikhunaEcuador.Controllers
{
    public class UsuariosController : Controller
    {
        //Creo mi objeto db que hace referencia a la dataBase
        //DbContext es, en este caso, MikhunaDB
        private MikhunaDB db = new MikhunaDB();


        //Datos del usuario que inició sesión
        public static String Usu;
        public static int idUsu;

        public string GetUrlImgUsuario() {
            var usuario = db.Usuario.Find(idUsu);
            if (usuario != null)
            {
                return usuario.Imagen;
            }
            else
            {
                return null;
            }
        }

        public Usuario BuscarUsuario() {
            var usuario = db.Usuario.Find(idUsu);
            if (usuario != null)
            {
                return usuario;
            }
            else {
                return null;
            }
        }

        public ActionResult GuardarImagenPerfil(string UrlImgPerfil) {
            if (UrlImgPerfil.CompareTo("") != 0) {
                var Us = db.Usuario.Find(idUsu);

                if (Us != null) {
                    Us.Imagen = UrlImgPerfil;
                    if (ModelState.IsValid)
                     {
                        
                        db.Entry(Us).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Perfil");
                    }
                }
            }
            return RedirectToAction("Perfil");
        }

        public void GuardarUsuario()
        {
            Usu = User.Identity.Name;
            if (Usu.CompareTo("") != 0) {
                idUsu = db.Usuario.FirstOrDefault(e => e.NickName == Usu).UsuarioID;
            }
        }

        [Authorize]
        public string GetUsu() {
            GuardarUsuario();
            var aux = "Bienvenido " + Usu;
            return aux;
        }

        [Authorize]
        public string GetSoloUsu()
        {
            GuardarUsuario();
            var aux = Usu;
            return aux;
        }

        [Authorize]
        public int GetIdUsu()
        {
            GuardarUsuario();
            var aux = idUsu;
            return aux;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        
        //Con Authorize solo se muestra cuando se inició sesión
        [Authorize]
        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", new { message=""});
        }

        //Se pone esto porque en el form de la vista, en el atributo method se especifica que es "post"
        [HttpPost]
        public ActionResult ValidarUsuario(String usuario, String clave)
        {

            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(clave))
            {
                
                

                //En user se guarda el primer o el único usuario que en la búsqueda en la base de datos, su correo y contraseña sean iguales
                var user = db.Usuario.FirstOrDefault(e => e.NickName == usuario && e.Clave == clave);

                if (user != null)
                {
                    //Esto es luego de añadir el authentication method en Web.config
                    //En System.web.security
                    //SetAuthCookie guarda las cookies del correo
                    FormsAuthentication.SetAuthCookie(user.NickName, true);

                    //Guardo el usuario
                    GuardarUsuario();
                    //Si el usuario existe / fue encontrado
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", new { message = "No se encontró un usuario con esas credenciales" });
                }
            }
            else
            {
                return RedirectToAction("Login", new { message = "El usuario no existe" });
            }


            /*Recupero los usuario de la base de datos
            List<Usuario> usuarios = db.Usuario.ToList();

            //recorre todos los elementos de la tabla Usuario
            foreach (var i in usuarios)
            {
                //Si los correos son iguales   Y   las claves son iguales
                if (i.Correo.CompareTo(correo) == 0 && i.Clave.CompareTo(clave) == 0)
                {

                    //El usuario coincide
                    //Retorna un true que significa que el usuario sí existe
                    HomeController.IniciarSesion(i.Correo, i.NickName);
                    return true;
                }
            }

            //Returna un false que significa que el usuario no existe/no fué encontrado
            return false;*/
        }





        // GET: Usuarios/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuario.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        // GET: Usuarios/Create
        public ActionResult Login(String message)
        {
            ViewBag.Message = message;
            return View();
        }
        [Authorize]
        public ActionResult Perfil()
        {
            var Usuario = db.Usuario.FirstOrDefault(e => e.UsuarioID == UsuariosController.idUsu);
            
            if (Usuario != null ) {
                return View(Usuario);
            }
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UsuarioID,NickName,Correo,Clave,Nivel")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //Aquí dejo el nivel del usuario en 0 por defecto
                usuario.Nivel = 0;
                //----------------

                db.Usuario.Add(usuario);
                db.SaveChanges();
                
                return ValidarUsuario(usuario.NickName, usuario.Clave);
            }

            return View(usuario);
        }


        //Para editar el usuario
        [HttpPost]

        public ActionResult EditarUsuario(string NombreUsuario, string Correo, string Clave) {
            //No pido Id porque los datos del usuario ya están guardados


            if (NombreUsuario.CompareTo("") != 0 && Correo.CompareTo("") != 0 && Clave.CompareTo("") != 0)
            {
                var Us = db.Usuario.Find(idUsu);

                if (Us != null)
                {
                    Us.NickName = NombreUsuario;
                    Us.Correo = Correo;
                    Us.Clave = Clave;

                    if (ModelState.IsValid)
                    {
                        FormsAuthentication.SetAuthCookie(Us.NickName, false);
                        db.Entry(Us).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Perfil");
                    }
                }
            }
            return RedirectToAction("Perfil");



        }

        //GET: Usuarios/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuario.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        // //POST: Usuarios/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        //// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UsuarioID,NickName,Correo,Clave,Nivel")] Usuario usuario)
        //{ 
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(usuario).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(usuario);
        //}

        // GET: Usuarios/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuario.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        // POST: Usuarios/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Usuario usuario = db.Usuario.Find(id);
        //    db.Usuario.Remove(usuario);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
