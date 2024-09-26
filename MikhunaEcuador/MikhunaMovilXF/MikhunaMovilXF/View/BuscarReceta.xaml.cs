using MikhunaMovilXF.ApiRoutes;
using MikhunaMovilXF.AUTH;
using MikhunaMovilXF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MikhunaMovilXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarReceta : ContentPage
    {
        Recetas rece;
        public BuscarReceta(Recetas re, List<Usuarios> usus)
        {
            InitializeComponent();
            ImagenComentario.Source = Auth.getAuth().Imagen;
            rece = re;
            
            //Datos de la receta seleccioanda
            urlReceta.Source = re.UrlImagen;
            nombreReceta.Text = re.Nombre;
            cantidadMinutos.Text = re.Duracion.ToString();


            //Cambiar a la calificacion del usuario que inció sesión
            var cantEstrellas = (int)(re.CalificacionPromedio);

            //Para las estrellas
            if (cantEstrellas > 0) {
                ChangeTextColor(cantEstrellas, Color.Yellow);
            }
            else{
                //Pone las estrellas grises
                Reset();
            }

            //Cargar Comentarios

            //Setea las imagenes
            int i = 0;
            foreach (var u in re.Comentarios) {
                u.UrlImagenUsuario = usus[i].Imagen;
                i++;
            }

            //Setea la lista de comentarios a la listView del xaml
            listaComentarios.HeightRequest = calcularTamaniComentarios(re.Comentarios);
            listaComentarios.ItemsSource = re.Comentarios;

            //Cargar Pasos
            //29 caracteres por paso
            listaPasos.HeightRequest = calcularTamanio(re.Pasos);

            ponerNumeroPaso(re.Pasos);
            listaPasos.ItemsSource = re.Pasos;
            
            System.Diagnostics.Debug.WriteLine("Cantidad de pasos" + re.Pasos.Count());


            //Cargar ingredientes
            setearNombresIngredientes(re.Ingredientes);
            ListaIngredientes.HeightRequest = calcularTamanioIngredientes(re.Ingredientes);
            ListaIngredientes.ItemsSource = re.Ingredientes;
        }

        public async void subirComentario(Object e, EventArgs sender) {
            var comentario = txtComentario.Text;

            if (!String.IsNullOrEmpty(comentario))
            {

                Comentarios c = new Comentarios
                {
                    Contenido = comentario,
                    RecetaID = rece.RecetaID
                };

                var res = await RouteUsuario.putComment(c);
                //char de = ',';
                //var contenido = res.Split(de)[2];!String.IsNullOrEmpty(contenido)
                if (res)
                {
                    await DisplayAlert("Comentario agregado", "El comentario se añadió correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Comentario no agregado", "El comentario no se añadió debido a un error", "OK");
                }
            }
            else {
                await DisplayAlert("Contenido vacío", "No puede tener campos de texto vacíos", "OK");
            }
            txtComentario.Text = "";

        }

        public async void exit(Object e, EventArgs sender)
        {

            //Cierra todas las ventanas
            await Navigation.PopToRootAsync();
        }
        async void EnviarComentario(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new Perfil());

        }



        public void setearNombresIngredientes(ICollection<Ingredientes>ingredientes) {
            foreach (var i in ingredientes) {
                i.NombreIngre = i.Nombre +" - "+i.Unidad;
            }
        }
        public int calcularTamanio(ICollection<Pasos> pasos) {
            int count = 0;
            
            foreach (var i in pasos) {
                var aux = Math.Ceiling(i.Paso.Length/29d);
                count += ((int)aux * 40);
            }
            return count;
        }

        public int calcularTamaniComentarios(ICollection<Comentarios> comentarios)
        {
            int count = 0;

            foreach (var i in comentarios)
            {
                var aux = Math.Ceiling(i.Contenido.Length / 33d);
                count += ((int)aux * 40);
            }
            return count;
        }

        public int calcularTamanioIngredientes(ICollection<Ingredientes> ingredientes)
        {
            int count = 0;

            foreach (var i in ingredientes)
            {
                var aux = Math.Ceiling(i.Nombre.Length / 30d);
                count += ((int)aux * 30);
            }
            return count;
        }

        public void ponerNumeroPaso(ICollection<Pasos> pasos) {
            int cont = 1;
            foreach (var p in pasos) {
                p.numeroPaso = cont;
                cont++;
            }
        }

        async void GoToAddFood(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new AgregarReceta());

        }
        async void GoToProfile(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new Perfil());

        }
        async void GoToHome(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new Home());

        }






        /*Para calificar Receta*/
        void Reset()
        {
            ChangeTextColor(5, Color.Gray);
        }

        void ChangeTextColor(int starcount, Color color)
        {
            for (int i = 1; i <= starcount; i++)
            {
                (FindByName($"star{i}") as Label).TextColor = color;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Reset();
            Label clicked = sender as Label;
            ChangeTextColor(Convert.ToInt32(clicked.StyleId.Substring(4, 1)), Color.Yellow);
        }

        async void GoToLogin(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new LoginPage());

        }



        /*-------------------------------------*/
    }
}