using MikhunaMovilXF.AUTH;
using MikhunaMovilXF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MikhunaMovilXF.ApiRoutes
{
    class RouteUsuario
    {
        public static async Task<List<Usuarios>> allUsers()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var request = new HttpRequestMessage();


                var apiUrl = URI.URL;


                request.RequestUri = new Uri(apiUrl + "Usuarios");

                
                request.Method = HttpMethod.Get;

                
                request.Headers.Add("Accept", "application/json");

                HttpClient receta;
                
                if (!apiUrl.Contains("10.0.2.2") && !apiUrl.Contains("localhost"))
                {
                    receta = new HttpClient();
                }
                else
                {
                    receta = new HttpClient(URI.httpHandler);
                }

                HttpResponseMessage response = await receta.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    string content = await response.Content.ReadAsStringAsync();

                   var res = JsonConvert.DeserializeObject<List<Usuarios>>(content);

                    return res;
                }
            }

            return null;
        }

        public Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, Boolean>
            ServerCertificateCustomValidationCallback
        { get; set; }

        public static async Task<Usuarios> getUser(int id)
        {

            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                //request es la nueva petición que se hará
                var request = new HttpRequestMessage();

                var apiUrl = URI.URL;

                request.RequestUri = new Uri(apiUrl+"Usuarios/"+id); 

                //Declara que la petición que se hará es tipo GET
                request.Method = HttpMethod.Get;

                //Declara la cabecera del tipo de dato que recibirá "JSON"
                request.Headers.Add("Accept", "application/json");

                HttpClient receta;
                //Si no es la del emulador no le mando el certificado del https
                if (!apiUrl.Contains("10.0.2.2") && !apiUrl.Contains("localhost"))
                {
                    //Ahora receta contiene la petición 
                    receta = new HttpClient();
                }
                else
                {//Si es la del emulador o UWP sí le mando el certificado del https
                    receta = new HttpClient(URI.httpHandler);
                }

                //Se ejecuta asíncronamente la petición de receta y se guarda el resultado de su status en response
                HttpResponseMessage response = await receta.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {//Si el estatus dice que la petición fué exitosa

                    //Guardamos en content el contenido del cuerpo de la respuesta recibida
                    string content = await response.Content.ReadAsStringAsync();

                    //En res se guarda una lista deserializada del tipo de dato especificado (Receta)
                    var res = JsonConvert.DeserializeObject<Usuarios>(content);

                    return res;
                }
            }

            //Si la petición falló
            return null;
        }

        public static async Task<Boolean> putUser(Usuarios u)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var apiUrl = URI.URL;



                string serializado = JsonConvert.SerializeObject(u);
                var dato = new StringContent(serializado, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient(URI.httpHandler);

                var httpResponse = await client.PostAsync(apiUrl + "Usuarios", dato);

                if (httpResponse.Content != null)
                {
                    return true;
                }
                throw new Exception(httpResponse.ReasonPhrase);





                //WebRequest oRequest = WebRequest.Create(apiUrl + "Usuarios");

                //oRequest.Method = "post";
                //oRequest.ContentType = "application/json; CHARSET-utf-8";

                //using (var Osw = new StreamWriter(oRequest.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(u);

                //    Osw.Write(json);
                //    Osw.Flush();
                //    Osw.Close();

                //}

                //WebResponse oResponse = oRequest.GetResponse();
                

                //using (var oSR = new StreamReader(oResponse.GetResponseStream()))
                //{
                //    result = oSR.ReadToEnd().Trim();
                //}

                //return result;
            }
            //Si la petición falló
            return false;

        }

        public static async Task<Boolean> putComment(Comentarios c)
        {

            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                //Usuario ID
                c.UsuarioID = Auth.getAuth().UsuarioID;
                System.Diagnostics.Debug.Write("ID USUARIO: "+c.UsuarioID);

                var apiUrl = URI.URL;



                string serializado = JsonConvert.SerializeObject(c);
                var dato = new StringContent(serializado, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient(URI.httpHandler);

                var httpResponse = await client.PostAsync(apiUrl + "Comentarios", dato);

                if (httpResponse.Content != null)
                {
                    return true;
                }
                throw new Exception(httpResponse.ReasonPhrase);


            }
            //Si la petición falló
            return false;

        }

        //Editar Usuario
        public static async Task<Boolean> editUser(Usuarios u)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string result = "";

                var apiUrl = URI.URL;

                string serializado = JsonConvert.SerializeObject(u);
                var dato = new StringContent(serializado, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient(URI.httpHandler);

                var httpResponse = await client.PutAsync(apiUrl + "Usuarios/"+Auth.getAuth().UsuarioID, dato);

                if (httpResponse.Content != null)
                {
                    return true;
                }
                throw new Exception(httpResponse.ReasonPhrase);
            }
            //Si la petición falló
            return false;

        }

    }
}
