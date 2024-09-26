namespace MikhunaMovilXF.Models
{
    public partial class Comentarios
    {
        public int ComentarioID { get; set; }

        public string Contenido { get; set; }

        public int RecetaID { get; set; }

        public int UsuarioID { get; set; }
        public string UrlImagenUsuario { get; set; }

        public Recetas Recetas { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}
