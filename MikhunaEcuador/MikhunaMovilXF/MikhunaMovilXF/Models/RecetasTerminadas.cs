namespace MikhunaMovilXF.Models
{
    public partial class RecetasTerminadas
    {
        public int RecetaTerminadaID { get; set; }

        public int RecetaID { get; set; }

        public int UsuarioID { get; set; }

        public Recetas Recetas { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}
