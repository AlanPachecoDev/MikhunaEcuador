
//Añadido
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MikhunaEcuador.Models
{
    public class RecetasTerminadas
    {
        [Key]
        public int RecetaTerminadaID { get; set; }

        public virtual int RecetaID { get; set; }
        [ForeignKey("RecetaID")]
        public virtual Receta Receta { get; set; }

        public virtual int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }
    }
}