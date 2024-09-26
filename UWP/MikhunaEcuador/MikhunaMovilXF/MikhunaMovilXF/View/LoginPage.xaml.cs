
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            if (DeviceInfo.Platform != DevicePlatform.Android) {
                logo.Source = "https://res.cloudinary.com/dbxw3bxby/image/upload/v1657848152/logoFinal_dc1qkr.png";
            }
    }

    public async void IniciarSesion(Object e, EventArgs sender) {
            var contra = txtContra.Text;
            var correo = txtCorreo.Text;

            if (!String.IsNullOrEmpty(contra) && !String.IsNullOrEmpty(correo))
            {
                var res = await RouteUsuario.allUsers();

                Usuarios usuarioEncontrado = null;

                //Comprueba si existe el usuario y tiene contraseña correcta
                foreach (var i in res) {
                    if (i.Clave.CompareTo(contra) == 0 && i.Correo.CompareTo(correo) == 0) {
                        usuarioEncontrado = i;
                    }
                }


                if (usuarioEncontrado != null)
                { //Si el usuario existe
                    Auth.setAuth(usuarioEncontrado);
                    GoToHome();
                }
                else
                {
                    await DisplayAlert("Usuario no encontrado", "El usuario ingresado no existe", "OK");
                }
            }
            else {
                await DisplayAlert("Datos invalidos", "Debe ingresar información en los campos", "OK");
            }
        }

        async void GoToRegister(Object e, EventArgs sender)
        {
            await Navigation.PushAsync(new RegisterPage());

        }

        async void GoToHome()
        {
            await Navigation.PushAsync(new Home());

        }

    }
}