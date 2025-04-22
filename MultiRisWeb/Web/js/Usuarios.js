function cargarUsuario(id_usuario) {

    var data = '{id_usuario:' + id_usuario + '}';

    $.ajax({
        type: "POST",
        url: "UsuariosOld.aspx/cargarUsuario",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            for (var i = 0; i < objeto.length; i++) {

                var htmlTablaPerfiles = objeto[i].tablaPerfiles;
                $("#tablaPerfiles").children("table").remove();
                $("#tablaPerfiles").html("");
                $("#tablaPerfiles").append(htmlTablaPerfiles);

                var htmlTablaVisores = objeto[i].tablaVisores;
                $("#tablaVisores").children("table").remove();
                $("#tablaVisores").html("");
                $("#tablaVisores").append(htmlTablaVisores);

                var htmlTablaInstituciones = objeto[i].tablaInstituciones;
                $("#tablaInstituciones").children("table").remove();
                $("#tablaInstituciones").html("");
                $("#tablaInstituciones").append(htmlTablaInstituciones);

                var htmlTablaRadiologs = objeto[i].tablaRadiologos;
                $("#tablaRadiologos").html("");
                $("#tablaRadiologos").append(htmlTablaRadiologs);

                if (objeto[i].id_perfil == 7 || objeto[i].id_perfil == 9 || objeto[i].id_perfil == 10)
                    $("#trRadiologos").show();
                else
                    $("#trRadiologos").hide();

                $("#txtNombre").val(objeto[i].nombre);
                $("#txtApellidoPaterno").val(objeto[i].apellido_paterno);
                $("#txtApellidoMaterno").val(objeto[i].apellido_materno);

                if (objeto[i].estado == '1') {
                    document.getElementById('rbtnEstado1').checked = true;
                }
                else {
                    document.getElementById('rbtnEstado0').checked = true;
                }

                $("#txtUsername").val(objeto[i].username);
                $("#txtPassword").val(objeto[i].password);

                $("#txtRut").val(objeto[i].rut);
                $("#txtEmailPrincipal").val(objeto[i].email1);
                $("#txtEmailSecundario").val(objeto[i].email2);
                $("#txtTelefonoPrincipal").val(objeto[i].telefono1);
                $("#txtTelefonoSecundario").val(objeto[i].telefono2);
                $("#txtDiasExamenes").val(objeto[i].dias_examenes);

                if (objeto[i].vocali == '1') {
                    document.getElementById('rbtnVocali1').checked = true;
                }
                else {
                    document.getElementById('rbtnVocali0').checked = true;
                }

                if (objeto[i].agente_vocali == '1') {
                    document.getElementById('rbtnAgenteVocali1').checked = true;
                }
                else {
                    document.getElementById('rbtnAgenteVocali0').checked = true;
                }

                var rbtnSelectedPerfil = "rbtnPerfil" + objeto[i].id_perfil;
                document.getElementById(rbtnSelectedPerfil).checked = true;

                var rbtnSelectedVisor = "rbtnVisor" + objeto[i].id_visor;
                document.getElementById(rbtnSelectedVisor).checked = true;

                $("#btnGuardar").attr("onclick", "guardarUsuario(" + id_usuario + "); return false;");
            }
        },
        error: function () {

        }
    });
}

function guardarUsuario(id_usuario) {

    let valoresCheck = [];

    $("input[type=checkbox]:checked").each(function () {
        if (this.name == "institucion")
            valoresCheck.push(this.value);
    });

    var valordias = 0;
    if ($("#txtDiasExamenes").val() != '')
    {
        valordias = $("#txtDiasExamenes").val()
    }

    var id_perfil = $('input:radio[name=perfil]:checked').val();

    if (typeof (id_perfil) === "undefined") {
        id_perfil = 0;
    }

    var id_visor = $('input:radio[name=visor]:checked').val();

    if (typeof (id_visor) === "undefined") {
        id_visor = 1;
    }




    console.log(valoresCheck);

    var data = '{id_usuario: ' + id_usuario
        + ', nombre:"' + $("#txtNombre").val()
        + '", apellido_paterno:"' + $("#txtApellidoPaterno").val()
        + '", apellido_materno:"' + $("#txtApellidoMaterno").val()
        + '", estado:' + $('input:radio[name=estado]:checked').val()
        + ', username:"' + $("#txtUsername").val()
        + '", password:"' + $("#txtPassword").val()
        + '", id_perfil:' + id_perfil
        + ', rut:"' + $("#txtRut").val()
        + '", email1:"' + $("#txtEmailPrincipal").val()
        + '", email2:"' + $("#txtEmailSecundario").val()
        + '", telefono1:"' + $("#txtTelefonoPrincipal").val()
        + '", telefono2:"' + $("#txtTelefonoSecundario").val()
        + '", dias_examenes:' + valordias
        + ', vocali:' + $('input:radio[name=activarVocali]:checked').val()
        + ', agente_vocali:' + $('input:radio[name=activarAgenteVocali]:checked').val()
        + ', instituciones:"' + GetInstitucionesSeleccionadas()
        + '", radiologosBecado:"' + GetRadiologosSeleccionados()
        + '", id_visor:' + id_visor + '}';

   
    $.ajax({
        type: "POST",
        url: "UsuariosOld.aspx/guardarUsuario",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
           
            var objeto = arg.d;
            var aplicado = objeto;

            if (aplicado == -2) {
                alert('Debe Ingresar los datos minimos para crear el Usuario.');
            }
            else if (aplicado == -1) {
                alert('El Usuario ya fue creado con ese username.');
            }
            else if (aplicado == -2)
            {
                alert("Perfil seleccionado corresponde a Becado, debe seleccionar el o los radiologos que estaran trabajando con el");
            }
            else {
                if (id_usuario == 0)
                    alert('El Usuario fue creado existosamente.');
                else
                    alert('El Usuario fue modificado existosamente.');

                location.href = "UsuariosOld.aspx";
            }
            
        },
        error: function () {

        }
    });
}

function cargarPerfiles() {

    $.ajax({
        type: "POST",
        url: "UsuariosOld.aspx/PerfilesModal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
       // data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);

            var htmlTablaPerfiles = objeto;

            $("#tablaPerfiles").children("table").remove();
            $("#tablaPerfiles").html("");
            $("#tablaPerfiles").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });
}

function cargarInstituciones() {

    $.ajax({
        type: "POST",
        url: "UsuariosOld.aspx/InstitucionesModal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        // data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            var htmlTablaPerfiles = objeto;

            $("#tablaInstituciones").children("table").remove();
            $("#tablaInstituciones").html("");
            $("#tablaInstituciones").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });
}

function cargarRadiologos() {

    $.ajax({
        type: "POST",
        url: "UsuariosOld.aspx/RadiologosModal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        // data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            var htmlTablaRadiologos = objeto;

            $("#tablaRadiologos").html("");
            $("#tablaRadiologos").append(htmlTablaRadiologos);


        },
        error: function () {

        }
    });
}


function cargarVisor() {

    $.ajax({
        type: "POST",
        url: "UsuariosOld.aspx/VisoresModal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        // data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            var htmlTablaPerfiles = objeto;

            $("#tablaVisores").children("table").remove();
            $("#tablaVisores").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });
}


function nuevoUsuario() {
    cargarPerfiles();
    cargarInstituciones();
    cargarVisor();
    cargarRadiologos();
    //$("#modalUsuario").show();
    $("#trRadiologos").hide();
    $('#modalUsuario').modal('show');


    $("#txtNombre").val('');
    $("#txtApellidoPaterno").val('');
    $("#txtApellidoMaterno").val('');
    $("#txtUsername").val('');
    $("#txtPassword").val('');
    $("#txtRut").val('');
    $("#txtEmailPrincipal").val('');
    $("#txtEmailSecundario").val('');
    $("#txtTelefonoPrincipal").val('');
    $("#txtTelefonoSecundario").val('');
    $("#txtDiasExamenes").val('');
    document.getElementById('rbtnEstado1').checked = true;
    document.getElementById('rbtnVocali0').checked = true;
    document.getElementById('rbtnAgenteVocali0').checked = true;

    $("#btnGuardar").attr("onclick", "guardarUsuario(0); return false;");
}

function show() {
    var texto = $("#btnShow").val();
    console.log(texto);
    if (texto == 'show') {
        $("#btnShow").val('hide');
        $("#txtPassword").get(0).type = 'text';
    }
    else if (texto == 'hide') {
        $("#btnShow").val('show');
        $("#txtPassword").get(0).type = 'password';
    }
}

function GetRadiologosSeleccionados() { 

    var valoresCheck = [];
    $("input[type=checkbox]:checked").each(function () {
        if (this.name == "radiologos")
           valoresCheck.push(this.value);
    });
    return valoresCheck;
}

function GetInstitucionesSeleccionadas() {

    var valoresCheck = [];
    $("input[type=checkbox]:checked").each(function () {
        if (this.name == "institucion")
            valoresCheck.push(this.value);
    });
    return valoresCheck;
}

function MostrarRadiologo(valor) {
    cargarRadiologos();
    if (valor == 7 || valor == 9 || valor == 10)
        $("#trRadiologos").show();    
    else
        $("#trRadiologos").hide();

}