using MikhunaMovilXF.Models;
using MikhunaMovilXF.ApiRoutes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MikhunaMovilXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            cargarRecetas();


        }

        public async void exit(Object e, EventArgs sender)
        {

            //Cierra todas las ventanas
            await Navigation.PopToRootAsync();
        }

        //Recetas de API
        private async void cargarRecetas() {
            var recetas = await RouteReceta.allRecipes();

            ListaRecetas.ItemsSource = recetas;
        }

        //Navegación entre pestañas (footer)
        async void GoToAddFood(Object e, EventArgs sender) {
            await Navigation.PushAsync(new AgregarReceta());

        } 
        async void GoToProfile(Object e, EventArgs sender) {
            await Navigation.PushAsync(new Perfil());

        } 
        async void GoToHome(Object e, EventArgs sender) {
            await Navigation.PushAsync(new Home());

        }

        async void EliminarReceta(Object e, EventArgs sender) {
            var btn = e as Button;
            var id = Convert.ToInt32(btn.BindingContext);

            if (id > 0)
            {
                var res = await RouteReceta.EliminarReceta(id);

                if (res)
                {
                    await DisplayAlert("Receta Eliminada", "La receta se eliminó correctamente", "OK");
                }
                else {
                    await DisplayAlert("Receta No Eliminada", "La receta no se eliminó correctamente", "OK");

                }
            }
        }

        async void GoToBuscarReceta(Object e, EventArgs sender) {
            //Button btn = (Button)e;
            var btn = e as Button;
            var id = Convert.ToInt32(btn.BindingContext);
            System.Diagnostics.Debug.WriteLine("Entra- ID: " + id);

            if (id != 0)
            {

                Recetas r = await buscarReceta(id);

                var u = await buscarUsuarios(r.Comentarios);

                await Navigation.PushAsync(new BuscarReceta(r, u));
            }
        }

        private async Task<Recetas> buscarReceta(int id)
        {
            System.Diagnostics.Debug.WriteLine("Ejecute buscarReceta");
            var aux = await RouteReceta.getRecipe(id);
            System.Diagnostics.Debug.WriteLine("Tipo: " + aux.Nombre);
            return aux;
        }

        private async Task<List<Usuarios>> buscarUsuarios(ICollection<Comentarios> comentarios)
        {
            List<int> ids = new List<int>();

            //Recuperamos los UsuarioID de los comentarios
            foreach (var i in comentarios) {
                ids.Add(i.UsuarioID);
            }

            //Ahora recuperamos los Usuarios con los ids recuperados
            List<Usuarios> usus = new List<Usuarios>();

            foreach (var i in ids) {
                usus.Add(await RouteUsuario.getUser(i));
            }

            //Retorna la lista de usuarios
            return usus;
        }

        public void GirarCard(Object e, EventArgs sender)
        {
            System.Diagnostics.Debug.WriteLine("IAAAA");
            var imgB = ((ImageButton)e);
            imgB.IsVisible = false;
            var A = sender;

            if (ListaRecetas.SelectedItem != null)
            {

                
                var listItem = ListaRecetas.SelectedItem;
                
                Recetas receta = (Recetas)listItem;
                System.Diagnostics.Debug.WriteLine("List Item To String: " + receta.RecetaID);


            }
        }

        async void GoToLogin(Object e, EventArgs sender) {
            await Navigation.PushAsync(new LoginPage());
        
        } 
    }
}