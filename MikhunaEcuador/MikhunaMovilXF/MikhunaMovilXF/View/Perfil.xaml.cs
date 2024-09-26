using Firebase.Storage;
using MikhunaMovilXF.ApiRoutes;
using MikhunaMovilXF.AUTH;
using MikhunaMovilXF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MikhunaMovilXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {

        FileResult ph;
        public Perfil()
        {
            InitializeComponent();
            ImagenPerfil.Source = Auth.getAuth().Imagen;
        }

        public async void EditProfile(Object e, EventArgs sender) {
            var Nombre = txtNombreUsuario.Text;
            var Correo2 = txtCorreo.Text;
            var Clave2 = txtClave.Text;

            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Correo2) && !String.IsNullOrEmpty(Clave2))
            {
                Usuarios usu;
                if (ph == null)
                {
                    usu = new Usuarios
                    {
                        NickName = Nombre,
                        Correo = Correo2,
                        Clave = Clave2,
                        UsuarioID = Auth.getAuth().UsuarioID,
                        Imagen = Auth.getAuth().Imagen
                    };
                }
                else {

                    subirFirebase();
                    usu = new Usuarios
                    {
                        NickName = Nombre,
                        Correo = Correo2,
                        Clave = Clave2,
                        UsuarioID = Auth.getAuth().UsuarioID,
                        Imagen = await subirFirebase()
                    };
                }
                var res = await RouteUsuario.editUser(usu);

                if (res)
                {
                    await DisplayAlert("Usuario Modificado", "El usuario se modificó exitosamente", "OK");
                }
                else {
                    await DisplayAlert("Usuario No Modificado", "El usuario no se modificó exitosamente", "OK");
                }

            }
            else
            {
                await DisplayAlert("Contenido vacío", "No puede tener campos de texto vacíos", "OK");
            }

            txtNombreUsuario.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";

        }

        async void SubirFoto(Object e, EventArgs sender)
        {

            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null)
            {
                return;
            }

            ImagenPerfil.Source = photo.FullPath;
            ph = photo;
        }

        public async Task<string> subirFirebase() {
            if (ph != null) {
                var task = new FirebaseStorage("mikhunaimages.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("ImagenesPerfil")
                .Child(ph.FileName)
                .PutAsync(await ph.OpenReadAsync());
                //task.Progress.ProgressChanged 1 = (sbyte, args) =>
                // {
                //     ProgressBar.ProgressColorProperty = args.Percentage;
                // };
                return await task;
            }
            return null;
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

        public async void exit(Object e, EventArgs sender) {

            //Cierra todas las ventanas
            await Navigation.PopToRootAsync();
        }
    }
}