//Añadido
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MikhunaEcuador.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]*$", ErrorMessage = "Debe ingresar sol" +
            "o letras.")]
        public string NickName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Clave { get; set; }
      
        public int Nivel { get; set; }

        [StringLength(400)]
        public string Imagen { get; set; }

        //public virtual int RecetaTerminadaID { get; set; }
        //[ForeignKey("RecetaTerminadaID")]
        //public virtual ICollection<RecetasTerminadas> RecetasTerminadas { get; set; }

        //public virtual int FavoritoID { get; set; }
        //[ForeignKey("FavoritoID")]
        //Apunta a varios favoritos
        public virtual ICollection<Favoritos> Favoritos { get; set; }

    }
}