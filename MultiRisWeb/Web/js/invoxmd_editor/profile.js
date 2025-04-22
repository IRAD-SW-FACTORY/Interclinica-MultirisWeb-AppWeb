// Por favor, rellene los siguientes campos para configurar la conexión a INVOX. 

var myUser = 'mavila';         // Ejemplo: var myUser = 'test_user';  
var myPassword = '0002';     // Ejemplo: var myPassword = 'test_password';
var myHostServer = 'localhost';   // Ejemplo: var myHostServer = 'test_server';
var myPort = 1212;         // Ejemplo: var myPort = 8443;
var useAgent = true;       // Ejemplo: var useAgent = true; 

var msg = "Debe editar el archivo profile.js y rellenar los datos de conexión: \n";
if (myUser === undefined) msg += 'El usuario no está especificado.\n';
if (myPassword === undefined) msg += 'La contraseña no está especificada.\n';
if (myHostServer === undefined) msg += 'El servidor no está especificado.\n';
if (myPort === undefined) msg += 'El puerto no está especificado.\n';
if (useAgent === undefined) msg += 'El uso del agente no está especificado.\n';

if (myUser === undefined || myPassword === undefined || myHostServer === undefined || myPort === undefined || useAgent === undefined) alert(msg);