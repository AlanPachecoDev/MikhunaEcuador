namespace MikhunaMovilXF.Models
{
    public partial class Calificacions
    {
        public int CalificacionID { get; set; }

        public float NumeroEstrellas { get; set; }

        public int RecetaID { get; set; }

        public int UsuarioID { get; set; }

        public Recetas Recetas { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}
