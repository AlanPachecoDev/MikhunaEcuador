using MikhunaEcuador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MikhunaEcuador.ViewModel
{
    public class RecetaViewModel
    {
        //Receta
        public string Nombre { get; set; }
        public float Duracion { get; set; }
        public float Calificacion { get; set; }
        public string UrlImagen { get; set; }

        //Ingrediente
        public string NombreIngrediente { get; set; }
        public string UnidadIngrediente { get; set; }
        public int RecetaID { get; set; }
        //RecetaID

        //Pasos
        public string Paso { get; set; }
        //RecetaID

    }
}