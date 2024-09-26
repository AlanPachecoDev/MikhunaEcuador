//Añadido
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MikhunaEcuador.Models
{
    public class Pasos
    {
        [Key]
        public int PasosID { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 2)]
        public string Paso { get; set; }
        public virtual int RecetaID { get; set; }
        [ForeignKey("RecetaID")]
        public virtual Receta Recetas { get; set; }
    }
}