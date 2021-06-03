# Projeto Permiso


## Preparar el proyecto
1. Clone el repositorio raiz

	`git clone https://gitlab.com/icalapuja/empresax.permiso.git`

2. El proyecto `empresax.permiso.api` se conecta a una base de datos Postgree existente. Sin embargo, puede conectarse a otra base de datos cambiando el parámetro ConnectionString del archivo `appsettings.json` y ejecutando el archivo `script.sql` en la base de datos. 

## Ejecutar el proyeto

Haciendo uso de la terminal siga los siguientes pasos

1. Ejecutar API

	`cd empresax.permiso.api`
	`dotnet run`


2.  Ejecutar Web
    `cd empresax.permiso.web`
	`npm install`
    `npm run serve`

