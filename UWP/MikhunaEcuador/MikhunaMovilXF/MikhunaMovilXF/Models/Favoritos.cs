namespace MikhunaMovilXF.Models
{
    public partial class Favoritos
    {
        public int FavoritosID { get; set; }
        public int Calificacion { get; set; }

        public int RecetaID { get; set; }

        public int UsuarioID { get; set; }

        public Recetas Recetas { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}
