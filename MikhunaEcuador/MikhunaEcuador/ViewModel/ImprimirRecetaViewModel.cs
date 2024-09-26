using MikhunaEcuador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikhunaEcuador.ViewModel
{
    public class ImprimirRecetaViewModel
    {
        public Receta Receta { get; set; }

        //Ingrediente
        public IList<Ingrediente> Ingredientes { get; set; }
        //RecetaID

        //Pasos
        public IList<Pasos> Pasos { get; set; }

        //Comentarios
        public IList<Comentario> Comentarios { get; set; }


        public Calificacion Calificacion { get; set; }
    }
}