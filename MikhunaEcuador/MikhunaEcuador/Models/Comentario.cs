using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Añadido
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MikhunaEcuador.Models
{
    public class Comentario
    {
        //Primary Key
        [Key]
        public int ComentarioID { get; set; }

        public string Contenido { get; set; }

        public virtual int RecetaID { get; set; }

        [ForeignKey("RecetaID")]
        public virtual Receta Receta { get; set; }

        public virtual int UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }

    }
}