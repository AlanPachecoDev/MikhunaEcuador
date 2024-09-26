using Firebase.Storage;
using MikhunaMovilXF.ApiRoutes;
using MikhunaMovilXF.Models;
using MikhunaMovilXF.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MikhunaMovilXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarReceta : ContentPage
    {
        public AgregarReceta()
        {
            InitializeComponent();
        }

        async void SubirFoto(Object e, EventArgs sender) {

            
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null)
            {
                return;
            }
            var task = new FirebaseStorage("mikhunaimages.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("ImagenesMikhunaMovilAndroid")
                .Child(photo.FileName)
                .PutAsync(await photo.OpenReadAsync());
            //task.Progress.ProgressChanged 1 = (sbyte, args) =>
            // {
            //     ProgressBar.ProgressColorProperty = args.Percentage;
            // };
            var link = await task;
            ImagenActual.setFoto(link);
            img.Source = link;
        }

        public async void exit(Object e, EventArgs sender)
        {

            //Cierra todas las ventanas
            await Navigation.PopToRootAsync();
        }

        public async void EnviarReceta(Object e, EventArgs sender)
        {
            string nombreR = NombreReceta.Text;
            float duracionR =  float.Parse(DuracionReceta.Text);

            if (!String.IsNullOrEmpty(nombreR) && duracionR > 0)
            {
                Recetas r = new Recetas
                {
                    Nombre = nombreR,
                    Duracion = duracionR,
                    UrlImagen = ImagenActual.getFoto()
                };

                var res = await RouteReceta.subirReceta(r);
                //char de = ',';
                //var resNom = res.Split(de)[2]; !String.IsNullOrEmpty(resNom)
                if (res)
                {
                    await DisplayAlert("Receta Agregada", "La receta se agregó exitosamente", "OK");
                }
                else
                {
                    await DisplayAlert("Subida fallida", "La receta no se agregó debido a un error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Contenido vacío", "No puede tener campos de texto vacíos", "OK");
            }
            NombreReceta.Text = "";
            DuracionReceta.Text = "";
    }

        async void AgregarIngrediente(Object e, EventArgs sender)
        {
            string nombreI = txtNombreIngrediente.Text;
            string cantidadI = txtCantidad.Text;

            if (!String.IsNullOrEmpty(nombreI) && !String.IsNullOrEmpty(cantidadI)) {
                Ingredientes r = new Ingredientes
                {
                    Nombre = nombreI,
                    Unidad = cantidadI
                };

                var res = await RouteReceta.subirIngredientes(r);
                //char de = ',';
                //var ingNom = aux.Split(de)[2];!String.IsNullOrEmpty(ingNom)
                if (res)
                {
                    await DisplayAlert("Ingrediente agregado", "El ingrediente se añadió correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Ingrediente no agregado", "El ingrediente no se añadió debido a un error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Contenido vacío", "No puede tener campos de texto vacíos", "OK");

            }

            txtNombreIngrediente.Text = "";
            txtCantidad.Text = "";
        }

        async void AgregarPaso(Object e, EventArgs sender)
        {
            string paso = txtPaso.Text;

            if (!String.IsNullOrEmpty(paso))
            {
                Pasos p = new Pasos
                {
                    Paso = paso
                };

                var res = await RouteReceta.subirPasos(p);
                //char de = ',';
                //var pasoNom = res.Split(de)[2];!String.IsNullOrEmpty(pasoNom)
                if (res)
                {
                    await DisplayAlert("Paso agregado", "El paso se añadió correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Paso no agregado", "El paso no se añadió debido a un error", "OK");
                }
            }
            else {
                await DisplayAlert("Contenido vacío", "Debe ingresar algo en el campo de texto", "OK");

            }
            txtPaso.Text = "";

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

        async void GoToLogin(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new LoginPage());

        }
    }
}