using MikhunaMovilXF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MikhunaMovilXF.ApiRoutes
{
    class RouteReceta
    {

        public static async Task<List<Recetas>> allRecipes()
        {

            //Para evadir el certificado de https
            //var httpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true };

            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                //request es la nueva petición que se hará
                var request = new HttpRequestMessage();


                var apiUrl = URI.URL;


                //U
                request.RequestUri = new Uri(apiUrl+"Recetas");

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

                //System.Diagnostics.Debug.WriteLine("Entra al primer if)");

                //Se ejecuta asíncronamente la petición de receta y se guarda el resultado de su status en response
                HttpResponseMessage response = await receta.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {//Si el estatus dice que la petición fué exitosa

                    //Guardamos en content el contenido del cuerpo de la respuesta recibida
                    string content = await response.Content.ReadAsStringAsync();

                    //En res se guarda una lista deserializada del tipo de dato especificado (Receta)
                    var res = JsonConvert.DeserializeObject<List<Recetas>>(content);

                    System.Diagnostics.Debug.WriteLine("Dentro del método");

                    return res;
                }
            }
            
            //Si la petición falló
            return null;
        }

        public async static Task<Boolean> EliminarReceta(int id)
        {
            var apiUrl = URI.URL;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                //Borra calificaciones
                var calificaciones = await allCalificacions();
                foreach (var i in calificaciones) {
                    if (i.RecetaID == id) {
                        HttpClient recC = new HttpClient(URI.httpHandler);

                        HttpResponseMessage resC = await recC.DeleteAsync(apiUrl + "Calificacions/" + i.CalificacionID);
                        
                    }
                }

                //Borra Comentarios
                var comentarios = await allComentarios();

                foreach (var i in comentarios)
                {
                    if (i.RecetaID == id)
                    {
                        HttpClient recCo = new HttpClient(URI.httpHandler);

                        HttpResponseMessage resCo = await recCo.DeleteAsync(apiUrl + "Comentarios/" + i.ComentarioID);
                        
                    }
                }

                //Borra Ingredientes
                var ingredientes = await allIngredientes();

                foreach (var i in ingredientes)
                {
                    if (i.RecetaID == id)
                    {
                        HttpClient recI = new HttpClient(URI.httpHandler);

                        HttpResponseMessage resI = await recI.DeleteAsync(apiUrl + "Ingredientes/" + i.IngredienteID);
                        
                    }
                }

                //Borra Pasos
                var pasos = await allPasos();

                foreach (var i in pasos)
                {
                    if (i.RecetaID == id)
                    {
                        HttpClient recP = new HttpClient(URI.httpHandler);

                        HttpResponseMessage resP = await recP.DeleteAsync(apiUrl + "Pasos/" + i.PasosID);
                        
                    }
                }


                HttpClient client = new HttpClient(URI.httpHandler);

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + "Recetas/" + id);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                throw new Exception(response.ReasonPhrase);
            }
            return false;
                
        }

        public static async Task<List<Calificacions>> allCalificacions()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var request = new HttpRequestMessage();


                var apiUrl = URI.URL;

                request.RequestUri = new Uri(apiUrl + "Calificacions");

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

                    var res = JsonConvert.DeserializeObject<List<Calificacions>>(content);

                    System.Diagnostics.Debug.WriteLine("Dentro del método");

                    return res;
                }
            }
            return null;
        }

        public static async Task<List<Pasos>> allPasos()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var request = new HttpRequestMessage();


                var apiUrl = URI.URL;

                request.RequestUri = new Uri(apiUrl + "Pasos");

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

                    var res = JsonConvert.DeserializeObject<List<Pasos>>(content);

                    System.Diagnostics.Debug.WriteLine("Dentro del método");

                    return res;
                }
            }
            return null;
        }

        public static async Task<List<Comentarios>> allComentarios()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var request = new HttpRequestMessage();


                var apiUrl = URI.URL;

                request.RequestUri = new Uri(apiUrl + "Comentarios");

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

                    var res = JsonConvert.DeserializeObject<List<Comentarios>>(content);

                    System.Diagnostics.Debug.WriteLine("Dentro del método");

                    return res;
                }
            }
            return null;
        }

        public static async Task<List<Ingredientes>> allIngredientes()
        {

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var request = new HttpRequestMessage();


                var apiUrl = URI.URL;

                request.RequestUri = new Uri(apiUrl + "Ingredientes");

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

                    var res = JsonConvert.DeserializeObject<List<Ingredientes>>(content);

                    System.Diagnostics.Debug.WriteLine("Dentro del método");

                    return res;
                }
            }
            return null;
        }

        public async static Task<Boolean> subirReceta(Recetas r) {
            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var apiUrl = URI.URL;



                string serializado = JsonConvert.SerializeObject(r);
                var dato = new StringContent(serializado, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient(URI.httpHandler);

                var httpResponse = await client.PostAsync(apiUrl + "Recetas", dato);

                if (httpResponse.Content != null)
                {
                    return true;
                }
                throw new Exception(httpResponse.ReasonPhrase);



                //WebRequest oRequest = WebRequest.Create(apiUrl + "Recetas");

                //oRequest.Method = "post";
                //oRequest.ContentType = "application/json; CHARSET-utf-8";

                //using (var Osw = new StreamWriter(oRequest.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(r);

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

        //Trae una receta por ID

        public static async Task<Recetas> getRecipe(int id)
        {

            //Para evadir el certificado de https
            //var httpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true };

            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                //request es la nueva petición que se hará
                var request = new HttpRequestMessage();

                var apiUrl = URI.URL;
                request.RequestUri = new Uri(apiUrl+"Recetas/"+id);

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
                    var res = JsonConvert.DeserializeObject<Recetas>(content);

                    System.Diagnostics.Debug.WriteLine("Dentro del método");

                    return res;
                }
            }

            //Si la petición falló
            return null;
        }

        public static async Task<Boolean> subirPasos(Pasos p)
        {
            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                //Recupera las recetas
                var recetas = await allRecipes();
                var cant = recetas.Count;
                var idReceta = recetas[cant - 1].RecetaID;
                p.RecetaID = idReceta;


                var apiUrl = URI.URL;



                string serializado = JsonConvert.SerializeObject(p);
                var dato = new StringContent(serializado, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient(URI.httpHandler);

                var httpResponse = await client.PostAsync(apiUrl + "Pasos", dato);

                if (httpResponse.Content != null)
                {
                    return true;
                }
                throw new Exception(httpResponse.ReasonPhrase);



                //WebRequest oRequest = WebRequest.Create(apiUrl + "Pasos");

                //oRequest.Method = "post";
                //oRequest.ContentType = "application/json; CHARSET-utf-8";

                //using (var Osw = new StreamWriter(oRequest.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(p);

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

        public async static Task<Boolean> subirIngredientes(Ingredientes i)
        {
            //Si hay conexión a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                //Recupera las recetas
                var recetas = await allRecipes();
                var cant = recetas.Count;
                var idReceta = recetas[cant - 1].RecetaID;
                System.Diagnostics.Debug.Write("Id Receta: " + idReceta);
                i.RecetaID = idReceta;


                var apiUrl = URI.URL;


                string serializado = JsonConvert.SerializeObject(i);
                var dato = new StringContent(serializado, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient(URI.httpHandler);

                var httpResponse = await client.PostAsync(apiUrl + "Ingredientes", dato);

                if (httpResponse.Content != null)
                {
                    return true;
                }
                throw new Exception(httpResponse.ReasonPhrase);



                //WebRequest oRequest = WebRequest.Create(apiUrl + "Ingredientes");

                

                //oRequest.Method = "post";
                //oRequest.ContentType = "application/json; CHARSET-utf-8";

                //using (var Osw = new StreamWriter(oRequest.GetRequestStream()))
                //{
                //    string json = JsonConvert.SerializeObject(i);

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

    }
    
}
