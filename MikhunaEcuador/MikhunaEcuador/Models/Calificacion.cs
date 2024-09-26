using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Añadido
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MikhunaEcuador.Models
{
    public class Calificacion
    {
        //Primary Key
        [Key]
        public int CalificacionID { get; set; }

        [Required]
        public float NumeroEstrellas { get; set; }

        public virtual int RecetaID { get; set; }

        [ForeignKey("RecetaID")]
        public virtual Receta Receta { get; set; }

        public virtual int UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }

    }
}

//Ayudas de html Helpers para definición de datos en CodeFirst
/*
    Para dar un límite de caracteres
    [StringLength(50)]
    
    //Para que sea rango
    [StringLength(50, MinimumLength=2)]
 

    Para dar formato a la fecha, la 2da línea define el formato de impresión
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime EnrollmentDate { get; set; }

    Valida la entrada de texto
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]

    //Para poner texto de placeHolder
    [Display(Name = "Last Name")]


    Relacion con muchos
    public ICollection<CourseAssignment> CourseAssignments { get; set; }

    Importante actualizar en la consola de migraciones con:
    dotnet ef migrations add MaxLengthOnNames
    dotnet ef database update



    Así es como se llama a un método de instancia en el Controlador:

    @{
      ((HomeController)this.ViewContext.Controller).Method1();
    }
    Así es como llamas a un método estático en cualquier clase.

    @{
        SomeClass.Method();
    }


    //Método ubicado en el Index
    <!--Crea el cuadro de búsqueda-->
    @using (Html.BeginForm(method)) {
        @Html.TextBox("Nombre")
        <input type="submit" value="Buscar" />
    }


    //El método en Index
        public class ArtistasController : Controller
            {
                private APCancionesCF db = new APCancionesCF();

                // GET: Artistas
                public ActionResult Index(string Nombre)
                {
                    if (!String.IsNullOrEmpty(Nombre))
                    {
                        //Método de búsqueda Arstista
                        //db.Artista es el contenedor de los datos (Es el strList en la sintaxis)
                        //NombrePilaArtista es un atributo que tiene s
                        var arts = from s in db.Artista where s.NombreArtistico.Contains(Nombre) select s;
                        return View(arts.ToList());          
                    }
                    else {
                        return View(db.Artista.ToList());
                    }

            

                    //var result = strList.where(s => s.Contains("Tutorials"));
            

                }



    public System.Windows.Forms.HtmlElement GetElementById (string id);

 */