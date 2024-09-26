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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            if (DeviceInfo.Platform != DevicePlatform.Android)
            {
                logo.Source = "https://res.cloudinary.com/dbxw3bxby/image/upload/v1657848152/logoFinal_dc1qkr.png";
            }

        }

        public async void RegistrarUsuario(Object e, EventArgs sender) {
            var nUsuario = txtNombreUsuario.Text;
            var correo = txtCorreo.Text;
            var contra = txtContra.Text;

            if (!String.IsNullOrEmpty(nUsuario) && !String.IsNullOrEmpty(correo) && !String.IsNullOrEmpty(contra))
            {
                Usuarios user = new Usuarios
                {
                    NickName = nUsuario,
                    Correo = correo,
                    Clave = contra,
                    Nivel = 1
                };

                var res = await RouteUsuario.putUser(user);

                System.Diagnostics.Debug.WriteLine("Respuesta al subir Usuario: " + res);

                Auth.setAuth(user);
                GoToHome();
            }
            else {
                DisplayAlert("Datos invalidos", "Debe ingresar información en los campos", "OK");
            }


        }

        async void GoToLogin(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new LoginPage());

        }

        async void GoToHome()
        {
            await Navigation.PushAsync(new Home());

        }
    }
}