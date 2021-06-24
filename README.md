# Backend AppClima .NET Core

Esta es la parte de backend para app de consultas de clima, esta realizada en .NET Core.
Si encuentran algo que se pueda mejorar pueden decirme siempre estoy aprendiendo.
Gracias!

# App Clima
En la aplicación se puede consultar el clima de una ciudad, te muestra la temperatura y la sensación térmica del lugar en Celcius.
Posee una opción de incluir historico, la cual al estar hablilitada nos muestra una grilla con todas las consultas realizadas de la ciudad seleccionada.

# Configuración

Modificar el archivo **appsettings.json** que se encuentra en la carpeta config.
```JSON
{
		"Logging": {
		"LogLevel": {
			"Default": "Information",
			"Microsoft": "Warning",
			"Microsoft.Hosting.Lifetime": "Information"
		}
	},
	"AllowedHosts": "*",
	"ConnectionStrings": {
		"ClimaDatabase": "Server=DESKTOP-KJ3R4G9;Database=Clima;Trusted_Connection=True;",
		"ApiWeather": "http://api.openweathermap.org/data/2.5/weather?appid=39cc7c49d8f126ff2d359609ff3d7a16&units=metric&lang=es"
	}
}
```
Reemplazar **ClimaDatabase** por la dirección donde monten la base de datos.

Después tienen que correr los script que se encuentra en la carpeta **DataBase** en el orden establecido.
Tambien deje un backup de mi base para que tengan datos.

Luego tienen que montar la app de forma local en el IIS y modificar las Urls de la parte de Frontend.

**Frontend:** https://github.com/fwaicen/frontend_appclima
