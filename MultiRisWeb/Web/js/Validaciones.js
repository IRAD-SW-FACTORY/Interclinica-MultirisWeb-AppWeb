function numeros(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "1234567890";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function palabras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "qwertyuiopasdfghjklzxcvbnmáéúíó QWERTYUIOPASDFGHJKLÑZXCVBNMÁÉÚÍÓ";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function username(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function password(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "qwertyuiopasdfghjklzxcvbnmáéúíóQWERTYUIOPASDFGHJKLÑZXCVBNMÁÉÚÍÓ_#$%&/()=?¿¡!*";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function rut(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "1234567890-k";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function email(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_-.,@";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function telefono(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    caract = "1234567890- +";
    especiales = "";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (caract.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}