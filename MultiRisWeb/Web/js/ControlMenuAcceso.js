
function guardarControlMenuAcceso() {

    let valoresCheck = [];
    let valoresCheck1 = [];
    let valoresCheck2 = [];

    var idperfil = $("#ddrPerfil option:selected").val();

    if (idperfil == '0') {
        alert("Debe Seleccionar un Perfil para Asignar Acceso.")
        return;
    }
    //var id_perfil = 1; //idPerfil;

    $("input[name=Menu]:checked").each(function () {
        valoresCheck.push(this.value);
    });

    $("input[name=SubMenu1]:checked").each(function () {
        valoresCheck1.push(this.value);
    });

    $("input[name=SubMenu2]:checked").each(function () {
        valoresCheck2.push(this.value);
    });


    var data = '{id_perfil: ' + idperfil
        + ' , menu:"' + valoresCheck
        + '", subMenuGestion_1:"' + valoresCheck1
        + '", subMenuGestion_2:"' + valoresCheck2 + '"}';


    $.ajax({
        type: "POST",
        url: "ControlMenuAcceso.aspx/guardarControlMenuAcceso",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            var aplicado = objeto;

            if (aplicado == 0)
                alert('Acceso almacenado Existosamente.');

        },
        error: function () {

        }
    });
}

function cargarPerfiles() {

    $.ajax({
        type: "POST",
        url: "ControlMenuAcceso.aspx/PerfilesModal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        // data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);

            var htmlTablaPerfiles = objeto;

            $("#tablaPerfiles").children("table").remove();
            $("#tablaPerfiles").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });

    $("#btnGuardar").attr("onclick", "guardarControlMenuAcceso(); return false;");
}

function cargarMenu(id_perfil) {

    var data = '{idPerfil:' + id_perfil + '}';

    $.ajax({
        type: "POST",
        url: "ControlMenuAcceso.aspx/MenuModal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);

            var htmlTablaPerfiles = objeto;

            $("#tablaMenu").children("table").remove();
            $("#tablaMenu").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });


}

function cargarSubMenuGrupo1(id_perfil) {

    var data = '{idPerfil:' + id_perfil + '}';

    $.ajax({
        type: "POST",
        url: "ControlMenuAcceso.aspx/SubMenuModalGrupo1",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);

            var htmlTablaPerfiles = objeto;

            $("#tablaSubMenu1").children("table").remove();
            $("#tablaSubMenu1").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });
}

function cargarSubMenuGrupo2(id_perfil) {

    var data = '{idPerfil:' + id_perfil + '}';

    $.ajax({
        type: "POST",
        url: "ControlMenuAcceso.aspx/SubMenuModalGrupo2",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);

            var htmlTablaPerfiles = objeto;

            $("#tablaSubMenu2").children("table").remove();
            $("#tablaSubMenu2").append(htmlTablaPerfiles);


        },
        error: function () {

        }
    });
}


function cargarNuevoAcceso() {
    cargarPerfiles();
    //cargarMenu();
    //cargarSubMenuGrupo1();
    //cargarSubMenuGrupo2();
}

//function VolverSitio()
//{
//    window.location.href = response.redirect;
//}
function CargaDatosInactivo() {
    $('#modalCargando').modal('hide');
}

function CargaDatosActivo() {
    $('#modalCargando').modal('show');
}


function cargarPerfilMenu() {

    var idperfil = $("#ddrPerfil option:selected").val();

    cargarMenu(idperfil);
    cargarSubMenuGrupo1(idperfil);
    cargarSubMenuGrupo2(idperfil);
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

$(document).ready(function () {

    cargarPerfiles();

    $("#ddrPerfil").click(function () {
        $("#myselection").val('0');
    });

});
