using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikhunaEcuador.ViewModel
{
    public class ComentarioViewModel
    {
        public string Comentario { get; set; }
        public int RecetaId { get; set; }
        public int UsuarioId { get; set; }

    }
}