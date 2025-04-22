function obtenerDocumentos(codExamen, numeroacceso, id_institucion) {
    var data = '{codExamen:"' + codExamen + '", numeroacceso:"' + numeroacceso + '", id_institucion: ' + id_institucion + '}';

    $.ajax({
        type: "POST",
        url: "InformarOIT.aspx/ObtenerDocumentos",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;

            for (var i = 0; i < objeto.length; i++) {

                var htmlTabla = objeto[i].tablaDocumentos;

                htmlTabla = htmlTabla.replace('#', "'");
                $("#tablaDocumentos").children("table").remove();
                $("#tablaDocumentos").append(htmlTabla);
            }
        },
        error: function () {

        }
    });
}

function actualizarBloqueoExamen() {
    $.ajax({
        type: "POST",
        url: "InformarOIT.aspx/actualizarBloqueoExamen",
        contentType: "application/json; charset=utf-8",
        success: function (arg) {

        },
        error: function () {

        }
    });

    setTimeout(actualizarBloqueoExamen, 20000);
}

function verdocumento(urlDocumento) {
    document.getElementById("imgDocumentos").removeAttribute("src");
    $("#imgDocumentos").attr("src", urlDocumento);
}

function obtenerComentarios(codExamen, numeroAcceso, id_institucion) {
    var data = '{codExamen:"' + codExamen + '", numeroAcceso:"' + numeroAcceso + '", id_institucion: ' + id_institucion + '}';

    $('#aGuardarComentario').removeAttr('onclick');
    $('#aGuardarComentario').attr('onClick', 'guardarComentario("' + codExamen + '", "' + numeroAcceso + '", ' + id_institucion + '); return false;');

    $.ajax({
        type: "POST",
        url: "InformarOIT.aspx/obtenerComentarios",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;

            var htmlTabla = objeto;

            var htmlTabla = htmlTabla;
            $("#tablacomentarios").children("table").remove();
            $("#tablacomentarios").append(htmlTabla);
        },
        error: function () {

        }
    });
}

function CargaDatosInactivo() {
    $('#modalCargando').modal('hide');
}

function CargaDatosActivo() {
    $('#modalCargando').modal('show');
}

function guardarComentario(codExamen, numeroAcceso, id_institucion) {

    var data = '{codExamen:"' + codExamen + '", numeroAcceso:"' + numeroAcceso + '", id_institucion: ' + id_institucion + ', comentario:"' + $("#txtComentario").val() + '"}';

    $.ajax({
        type: "POST",
        url: "InformarOIT.aspx/guardarComentario",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {

            obtenerComentarios(codExamen, numeroAcceso, id_institucion);

            $("#txtComentario").val("");
        },
        error: function () {

        }
    });
}

function cargarDocumento(urlDocumento) {

    $("#imgDocumento").attr("src", urlDocumento);
    window.open(urlDocumento); //RVN 18-08-2023
}

function obtenerEstudiosRelacionados(codexamen, id_institucion) {
    $("#divEstudiosRelacionados").children("table").remove();
    $("#divEstudiosRelacionados").children("div").remove();

    var img = "<div style='width: 100%; text-align: center'><img src='../icon/preloader.gif' style='width: 40px; cursor: pointer'/></div>";
    $("#divEstudiosRelacionados").append(img);

    $.getJSON("../Examen/JsonGetEstudiosRelacionados.aspx?codexamen=" + codexamen + "&id_institucion=" + id_institucion, function (data) {
        if (data.out == "ok") {
            $("#divEstudiosRelacionados").children("table").remove();
            $("#divEstudiosRelacionados").children("div").remove();
            $("#divEstudiosRelacionados").append(data.estudios_anteriores);
        }
    });

    CargaDatosInactivo();
}

function ObtenerTodosInformesPrevios(id_paciente, id_institucion, urlInforme, identificador) {

    iframeInformeVacio();

    var data = '{id_paciente:"' + id_paciente + '", id_institucion:' + id_institucion + '}';

    $.ajax({
        type: "POST",
        url: "InformarOIT.aspx/ObtenerInformesPrevios",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {

            var objeto = arg.d;

            var htmlTabla = objeto;

            var htmlTabla = htmlTabla;

            $("#tablaInformesPrevios").children("table").remove();
            $("#tablaInformesPrevios").append(htmlTabla);

            cargarInforme(urlInforme, identificador);
        },
        error: function () {

        }
    });
}

function iframeInformeVacio() {
    $("#iframeInforme").attr("src", "../Control/Vacio.html");
}

function cargarInforme(urlInforme, identificador) {
    iframeInformeVacio();
    limpiarColoresInformesPrevios();

    $("#iframeInforme").attr("src", urlInforme);
    $("#" + identificador).css("background-color", "#FA4B3F");
    $("#" + identificador).css("color", "white");
}

function limpiarColoresInformesPrevios() {
    $(".btn_informes_previos").css("background-color", "white");
    $(".btn_informes_previos").css("color", "black");
}


$(document).ready(function () {
    /*validarVocali();*/
    actualizarBloqueoExamen();

    $.ajax({
        type: "POST",
        url: "InformarOIT.aspx/ObtenerDatos",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            obtenerEstudiosRelacionados(objeto[0].codexamen, objeto[0].id_institucion);

            $("#btnRecargarEstudiosAnteriores").removeAttr("onclick");
            $("#btnRecargarEstudiosAnteriores").attr("onclick", "obtenerEstudiosRelacionados('" + objeto[0].codexamen + "', " + objeto[0].id_institucion + ")");
        },
        error: function () {

        }
    });

    CargaDatosInactivo();
});