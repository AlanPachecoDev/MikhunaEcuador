namespace MikhunaMovilXF.Models
{
    using MikhunaMovilXF.Views;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;

    public partial class Recetas
    {
        public static object Navigation { get; private set; }
        public int RecetaID { get; set; }

        public string Nombre { get; set; }

        public float Duracion { get; set; }

        public string UrlImagen { get; set; }

        public float CalificacionPromedio { get; set; }

        public ICollection<Calificacions> Calificacions { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }

        public ICollection<Favoritos> Favoritos { get; set; }

        public ICollection<Ingredientes> Ingredientes { get; set; }

        public ICollection<Pasos> Pasos { get; set; }

        public ICollection<RecetasTerminadas> RecetasTerminadas { get; set; }


        



            
        //public ICommand Comandito { get; } = new Command(async () => {
        //    await App.Current.MainPage.DisplayAlert("Button Pressed", "Button Was Pressed", "OK");
            
        //        System.Diagnostics.Debug.WriteLine("Entra- ID: " + Int32.Parse(id));
        //        await Navigation.PushAsync(new BuscarReceta());


        //});


    }

    
}
