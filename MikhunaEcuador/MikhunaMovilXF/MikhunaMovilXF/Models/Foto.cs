using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MikhunaMovilXF.Models
{
    public class Foto
    {

        public Foto() {
            Imagen = new Image();
        }

        public string name { get; set; }
        public Image Imagen { get; set; }
    }
}
