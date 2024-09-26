using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MikhunaMovilXF.ViewModels
{   
    class ImagenActual
    {
        public static string Foto = null;

        public static void setFoto(string f) {
            Foto = f;
        }

        public static string getFoto() {
            return Foto;
        }
    }
    
}
