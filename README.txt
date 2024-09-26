Visite el gitHub de este proyecto en: https://github.com/AlanPachecoCueva/MikhunaEcuador.git


Mikhuna es un proyecto que busca rescatar la cultura de la gastronomia enfocándose en
la diversa cultura del Ecuador.

La solución del proyecto cuenta con 4 partes, una solución web, móvil, UWP y una API.

Para poder ejecutar correctamente cada una de las versiones deberá seguir las siguientes
indicaciones.

1. Para ejecutar la solución WEB.
   Deberá acceder a la carpeta del proyecto e ingresar a la carpeta MikhunaEcuador y
   ejecutar la solución de VS que allí se encuentra.
   
   Una vez dentro de esa solución se encontrará con dos proyectos, el web es el que se llama
   "mikhunaEcuador", deberá iniciar ese proyecto, pero antes, necesitará cambiar la connection
   string que generará la base de datos.
   
   Para cambiar la cadena de conexión debe ingresar a Views>web.config y buscar la etiqueta
   llamada <connectionStrings>, allí, modificar el nombre del data source al de su máquina.

2. Para ejecutar la versión móvil.
   La versión móvil se encuentra dentro de la misma solución web, solo deberá elegir ejecutar
   el proyecto "MikhunaMovilXF.Android".

   El proyecto movil cuenta con un par de particularidades, si se desea ejecutar desde el celular
   se debe seguir los siguientes pasos:

	Primero se debe instalar la extensión para vs llamada Conveyor. Para ello vaya a: 
	Extensiones>Administrar Extensiones>En línea y buscar Conveyor by keyoty. Se debe instalar esta extensión 
	y reiniciar VS.
	
	Para este paso debe asegurarse de estar en el proyecto de la API, el cual está dentro de la carpeta del proyecto
	y se llama "MikhunaAPI". Cuando ejecutemos la solución de la API, en la parte inferior podremos visualizar una 
	nueva consola de conveyor, si no está podemos habilitarla desde Herramientas>Conveyor: Allow remote acces.

	Cuando iniciemos la ejecución del proyecto se nos mostrará en esa consola las ips disponibles, en este caso,
	para acceder desde el teléfono necesitaremos habilitar una dirección ip con la opción "Access Over Internet"
	cuando demos clic en esa opción se nos pedirá registrarnos, lo hacemos y luego se nos habilitará una ip con la 
	que podremos conectarnos a través de internet, la usaremos más adelante.

	Ahora, ejecutamos la API y nos vamos a la solución móvil, desplegamos las ventanas del proyecto
	"MikhunaMovilXF", vamos a la carpeta APIRoutes y abrimos el archivo "URI.cs". Aquí deberemos cambiar 
	la ip a utilizar, para conectarnos por internet copiamos la dirección antes generada en la línea 12, en la variable
	"uriConveyorInternet", debemos asegurarnos que la ip temine con el símbolo "/", sino se pone, el programa no podrá
	reconocer correctamente la ip de la API.Luego ponemos la variable en la línea 12, debe quedar de estar forma:
	
	
	public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? uriConveyorInternet: uriUWP;

   	Una vez realizado este proceso, conectamos el celular y la aplicación debería poder acceder a la API sin problemas
	La velocidad de carga no será la más veloz porque la extensión es gratuita y carece de cualidades de pago.

Para conectarse desde el emulador de android se debe realizar lo siguiente:
	Debe deshabilitarla extensión del conveyor y reiniciar el VS, si no se hace esto, la conexión con la api desde
	emulador, fallará.
	Primero, se debe acceder a la carpeta donde está el proyecto de la API, allí, se debe habilitar las vista de 
	elementos ocultos, luego, ingresar a .vs>MikhunaAPI>config y abrir el archivo applicationhost
	En ese archivo se debe asegurar de lo siguiente:

	Deberá buscar la etiqueta <site> y verificar que la última que haya sido generada este dispúesta de la siguiente 
	forma, con la etiqueta <bindings> de la siguiente manera:
	<bindings>
             <binding protocol="http" bindingInformation="*:57324:localhost" />
             <binding protocol="https" bindingInformation="*:44308:127.0.0.1" />
        </bindings>

	Una vez hecho esto debemos regresar al proyecto movil, y dentro de "MikhunaMovilXF" entrar a ApiRoutes y abrir 
	el archivo "URI.cs"
	Allí se deberá poner la línea 20 de esta forma:
	
	public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? uriAndroidEmulador : uriUWP;

Para ejecutar el UWP solo deberá iniciar la ejecución, para esto nuevamente deberá deshabilitar conveyor, la conexión dentro de
ApiRoute
	public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? uriConveyorInternet : uriUWP;
	Lo importante en este caso es que después de los ":" esté uirUWP, pues así se conectará con la ip del localHost.



	
