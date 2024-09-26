using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Añadido
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MikhunaEcuador.Models
{
    public class Ingrediente
    {

        [Key]
        public int IngredienteID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Debe ingresar solo letras")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Unidad { get; set; }
        public virtual int RecetaID { get; set; }
        [ForeignKey("RecetaID")]
        public virtual Receta Recetas { get; set; }

    }
}