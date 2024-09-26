using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace MikhunaMovilXF.ApiRoutes
{
    class URI
    {
        
        public static String uriConveyorInternet = "https://rightredpage86.conveyor.cloud/";

        public static String uriAndroidEmulador = "https://10.0.2.2:44308/api/";

        public static String uriUWP = "https://localhost:44308/api/";

        //Para saber en qué plataforma se está utilizando
        //Si está en android le pasamos la uri del conveyor        //Sino la del localHost
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? uriConveyorInternet : uriUWP;

        public static String URL = BaseAddress;

        //Para evadir el certificado de https
        public static HttpClientHandler httpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true };


    }
}
