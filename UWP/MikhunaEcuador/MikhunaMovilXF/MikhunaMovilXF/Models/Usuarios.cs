namespace MikhunaMovilXF.Models
{
    using System.Collections.Generic;

    public partial class Usuarios
    {
        public int UsuarioID { get; set; }
        public string NickName { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        public int Nivel { get; set; }
        public string Imagen { get; set; }

        public ICollection<Calificacions> Calificacions { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }

        public ICollection<Favoritos> Favoritos { get; set; }

        public ICollection<RecetasTerminadas> RecetasTerminadas { get; set; }
    }
}
