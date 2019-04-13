# ChatRoom

El proyecto cuenta con 4 Proyectos. los cuales debe correr

### Authenticacion: IdentitiServer ChatRoom.IdentityServer

### Logica principal de la aplicacion: ChatRoom.Controllers

### Logica principal de la aplicacion: ChatRoom.Controllers Recurso del identity server

### Cliente tipo resource owner el cual realiza el logeo de usuarios: ChatRoom.Client
 
### Bot de la aplicacion: ChatRoom.Boot - Actualmente solo lee el csv y lo decodifica en un diccionario

### Correr el proyecto

En el proyecto identity server esta iniciados unos usuarios en memoria los cuales se usaran.

#### Insercion de usuarios

Para la insercion solo es posible insertar los usuarios que se tiene  en el identity server. para lo cual tiene que utilizar el cliente obtener el token y utulizar el proceso de registro.

#### Sedders

Actualmetne el proyecto cuenta con 1 sedder en el cual se inicializa los chatroms

### para correr el proyecto no nesesita nada
 - unicamente un cadena de coneccion la cual la puede cambiar en el app appsettings.json una vez que cambie esto la generacion de la base es automatica.
 
### Nota primero correr el proyecto del identity server
