

function pausaplay(id_ris_examen, numeroacceso) {

    var data = '{id_ris_examen:' + id_ris_examen + ', numeroacceso:"' + numeroacceso + '"}';

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/PruebaUno",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {

            if (arg.d.includes("https://demo.irad.cl/MultiRisWeb_DownLoad/Download.aspx?codexamen")) {
                alert('Las imagenes se bajaran en modo normal.');
                window.open(arg.d);
            }
            else {
                alert('Las imagenes se bajaran en modo contingencia.');
                window.open(arg.d);
            }
        },
        error: function () {

        }
    });
}


function RecargaEnvioInforme(id_ris_examen, numeroacceso) {

    var data = '{id_ris_examen:' + id_ris_examen + ', numeroacceso:"' + numeroacceso + '"}';

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/RecargaEnvioInforme",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            alert('El Informe se Reénvio de forma existosa.');
        },
        error: function () {
            alert('Error al Reenvio el Informe, Comunicar al Administrador.');
        }
    });
}


//ACA OBTIENE COMENTARIOS
function obtenerComentarios(codExamen) {
    var data = '{codExamen:"' + codExamen + '"}';

    coodigo_examen = codExamen;

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/obtenerComentariosPrueba",
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

//Obtener movimientos sobre el informe
function obtenerAcciones(id_ris_examen) {
    // var data = '{codExamen:"' + codExamen + '"}';

    var data = '{id_ris_examen:"' + id_ris_examen + '"}';

    coodigo_examen = id_ris_examen;

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/obtenerAcciones",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;

            var htmlTabla = objeto;

            var htmlTabla = htmlTabla;
            $("#tablaAcciones").children("table").remove();
            $("#tablaAcciones").append(htmlTabla);
        },
        error: function () {

        }
    });
}



function openInNewTab(href) {
    Object.assign(document.createElement('a'), {
        target: '_blank',
        rel: 'noopener noreferrer',
        href: href,
    }).click();
}

function prueba1() {
    alert("a");
}


$(document).ready(function () {
    GetDropdowns();
});

function CargaDatosInactivo() {
    $('#modalCargando').modal('hide');
}

function Asignar(id_asignacion) {
    console.log(id_asignacion);
    var validacion = true;

    if ($("#ddlUsuarioAsignacion").val() == "0") {
        $("#lblMensaje").text("Seleccione un Radiólogo");
        $("#lblMensaje").css("color", "red");
        validacion = false;
    }
    else {
        $("#lblMensaje").text("");
        $("#lblMensaje").css("color", "white");
    }

    if (validacion) {
        $.getJSON("../Examen/JsonSaveAsignacion.aspx?id_asignacion='" + id_asignacion + "'&id_radiologo=" + $("#ddlUsuarioAsignacion").val(), function (data) {
            if (data.out == 'ok') {
                $("#lblMensaje").css("color", "white");
                $("#lblMensaje").text(data.mensaje);
                alert("Estudios Asignados Existosamente.");
            }
            else {
                $("#lblMensaje").css("color", "red");
                $("#lblMensaje").text(data.mensaje);
            }
        });
    }
}

function Eliminar(id_asignacionEliminar) {
    console.log(id_asignacionEliminar);
    var validacion = true;

    if (validacion) {
        $.getJSON("../Examen/JsonDeleteExamen.aspx?id_asignacion='" + id_asignacionEliminar + "'&id_radiologo=" + $("#ddlUsuarioAsignacion").val(), function (data) {
            if (data.out == 'ok') {
                $("#lblMensajeEliminado").css("color", "white");
                $("#lblMensajeEliminado").text(data.mensaje);
                location.reload();
            }
            else {
                $("#lblMensajeEliminado").css("color", "red");
                $("#lblMensajeEliminado").text(data.mensaje);

            }
        });
    }
}

function Descargar(id_asignacionDescargar) {
    console.log(id_asignacionDescargar);

    var data = '{id_ris_examen:' + id_asignacionDescargar + '"}';

    $.ajax(
        {
            url: "JsonGetDownloadExamen.aspx/EnviarCorreo",
            data: JSON.stringify({ id_ris_examen: id_asignacionDescargar }),
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (response) {

                console.log(response.d);

                for (i = 0; i < response.d.length; i++) {
                    window.open(response.d[i]);
                }

                /*window.open(response.d);*/
            },
            error: function (result) {
                alert("ERROR " + result.status + ' ' + result.statusText);
            }
        });
    return ids;

    //$.ajax({
    //    type: "post",
    //    url: "ListaExamen.aspx/PruebaUno",
    //    data: data,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (arg) {
    //        window.open(arg.d);
    //    },
    //    error: function () {

    //    }
    //});


    //var validacion = true;

    //if (validacion) {
    //    $.getJSON("../Examen/JsonGetDownloadExamen.aspx?id_asignacion='" + id_asignacionDescargar + "'&id_radiologo=" + $("#ddlUsuarioAsignacion").val(), function (data) {
    //        if (data.out == 'ok') {
    //            $("#lblMensajeDescargar").css("color", "white");
    //            $("#lblMensajeDescargar").text(data.mensaje);

    //        }
    //        else {
    //            $("#lblMensajeDescargar").css("color", "red");
    //            $("#lblMensajeDescargar").text(data.mensaje);

    //        }
    //    });
    //}
}


function SeleccionarTodo() {
    $(".chkGridView").each(function () {
        $(this).prop('checked', true);
    });
}

function DeseleccionarTodo() {
    $(".chkGridView").each(function () {
        $(this).prop('checked', false);
    });
}

function EstudiosAsignados() {
    var cantidad = 0;
    var id_asignacion = '';
    $("#lblMensaje").text("");

    $('input[name=chkGridView]:checked').each(function () {
        cantidad++;
        id_asignacion += $(this).prop("id").replace('chk', '') + ",";
        console.log(id_asignacion);
    });

    $("#lblCantidadSeleccionados").text("Cantidad de Estudios Seleccionados: " + cantidad);

    if (cantidad == 0) {
        $("#lblMensaje").text("No hay estudios seleccionados.");
        $("#lblMensaje").css("color", "red");
        $("#btnGuardarAsignacion").css("visibility", "hidden");
    }
    else {
        $("#btnGuardarAsignacion").css("visibility", "visible");
        $("#btnGuardarAsignacion").attr("onclick", "Asignar('" + id_asignacion + "');");
    }
}

function ReenvioInformeInstituciones(codexamen, id_institucion) {
    $("#divEstudiosRelacionados").children("table").remove();
    $("#divEstudiosRelacionados").children("div").remove();

    var img = "<div style='width: 100%; text-align: center'><img src='../icon/preloader.gif' style='width: 40px; cursor: pointer'/></div>";
    $("#divEstudiosRelacionados").append(img);

    //$.getJSON("../Examen/JsonGetEstudiosRelacionados.aspx?codexamen=" + codexamen + "&id_institucion=" + id_institucion, function (data) {
    //    if (data.out == "ok") {
    //        $("#divEstudiosRelacionados").children("table").remove();
    //        $("#divEstudiosRelacionados").children("div").remove();
    //        $("#divEstudiosRelacionados").append(data.estudios_anteriores);
    //    }
    //});
    alert('aqui');

    CargaDatosInactivo();
}


function EstudiosAsignadosEliminar() {
    var cantidad = 0;
    var id_asignacionEliminar = '';
    $("#lblMensajeEliminar").text("");

    $('input[name=chkGridView]:checked').each(function () {
        cantidad++;
        id_asignacionEliminar += $(this).prop("id").replace('chk', '') + ",";
        console.log(id_asignacionEliminar);
    });

    $("#lblCantidadSeleccionadosEliminar").text("Cantidad de Estudios Seleccionados: " + cantidad);

    if (cantidad == 0) {
        $("#lblMensaje").text("No hay estudios seleccionados.");
        $("#lblMensaje").css("color", "red");
        $("#btnGuardarAsignacionEliminar").css("visibility", "hidden");
    }
    else {
        $("#btnGuardarAsignacionEliminar").css("visibility", "visible");
        $("#btnGuardarAsignacionEliminar").attr("onclick", "Eliminar('" + id_asignacionEliminar + "');");
    }
}

function EstudiosAsignadosDescargar() {
    var cantidad = 0;
    var id_asignacionDescargar = '';
    $("#lblMensajeDescargar").text("");

    $('input[name=chkGridView]:checked').each(function () {
        cantidad++;
        id_asignacionDescargar += $(this).prop("id").replace('chk', '') + ",";
        console.log(id_asignacionDescargar);
    });

    $("#lblCantidadSeleccionadosDescargar").text("Cantidad de Estudios Seleccionados: " + cantidad);

    if (cantidad > 30) {
        alert("Favor seleccione solamente hasta 30 registros.");
        $("#btnGuardarAsignacionDescargar").css("visibility", "hidden");
    }
    else {
        if (cantidad == 0) {
            $("#lblMensaje").text("No hay estudios seleccionados.");
            $("#lblMensaje").css("color", "red");
            $("#btnGuardarAsignacionDescargar").css("visibility", "hidden");
        }
        else {
            $("#btnGuardarAsignacionDescargar").css("visibility", "visible");
            $("#btnGuardarAsignacionDescargar").attr("onclick", "Descargar('" + id_asignacionDescargar + "');");
        }


    }


}

function opciones(id_ris_examen, numeroacceso) {

    var data = '{id_ris_examen:' + id_ris_examen + ', numeroacceso:"' + numeroacceso + '"}';

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/ObtenerDatosPaciente",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            document.getElementById("imgOrdenMedica").removeAttribute("src");

            for (var i = 0; i < objeto.length; i++) {

                //DATOS DEMOGRAFICOS
                $("#lblModalNombrePaciente").text(objeto[i].nombre + ' ' + objeto[i].apellidoPaterno + ' ' + objeto[i].apellidoMaterno);
                $("#lblModalIdPaciente").text(objeto[i].rut);
                $("#lblModalInstitucion").text(objeto[i].institucion);
                $("#lblModalFechaExamen").text(objeto[i].fechaexamen);
                $("#lblModalDescripcion").text(objeto[i].descripcion);
                $("#lblModalMedico").text(objeto[i].medico);
                $("#lblModalEstado").text(objeto[i].estado);
                $("#imgOrdenMedica").attr("src", objeto[i].ordenMedica);

                //LINKS DE DESCARGAS

                //$("#linkVerImagenes").text('Visualizar');
                $("#linkVerImagenes").attr("href", objeto[i].linkVerImagenes);

                //$("#linkModalRadiant").text('Radiant');
                $("#linkModalRadiant").attr("href", objeto[i].linkRadiant);

                //$("#linkModalDescargarExamen").text('Descargar Examen');
                $("#linkModalDescargarExamen").attr("href", objeto[i].linkDescargaExamen);

                $("#btnInformar").attr("onclick", "informar('" + objeto[i].codExamen + "', " + objeto[i].id_institucion + "); return false;");

                var htmlTabla = objeto[i].tablaPrestaciones;
                $("#tablaPrestaciones").children("table").remove();
                $("#tablaPrestaciones").append(htmlTabla);

                //$("#linkModalOsirix").text('Osirix');
                $("#linkModalOsirix").attr("href", objeto[i].linkOsirix);

                var htmlTablaComentarios = objeto[i].tablaComentarios;
                $("#tablaComentarios").children("table").remove();
                $("#tablaComentarios").children("label").remove();
                $("#tablaComentarios").append(htmlTablaComentarios);

                $("#btnInformar").css("visibility", objeto[i].btnInformar);
                $("#lblPrestaciones").css("visibility", objeto[i].btnInformar);

                var htmlTabla = objeto[i].tablaDocumentos;
                $("#tablaDocumentos").children("table").remove();
                $("#tablaDocumentos").append(htmlTabla);
                //btnInformar
            }
        },
        error: function () {

        }
    });
}



function GetDropdowns() {
    $.getJSON("../Examen/JsonGetDropdown.aspx", function (data) {
        if (data.out == 'ok') {
            $("#divMedicoRadiologo").children("select").remove();
            $("#divMedicoRadiologo").append(data.usuario_asignar);

            if (data.asignar == '1') {
                $("#btnAsignar").css("visibility", "visible");
            }
            else {
                $("#btnAsignar").css("visibility", "hidden");
            }
        }
    });
}

function ocultarDvInformarResumido() {

    $("#dvInformarResumidoResultado").hide();
    $("#dvInformarResumidoCargando").hide();
    $("#dvInformarResumidoError").hide();
    //$("#dvImagenes").hide();
}

function informarResumido(id_ris_examen, numeroacceso) {
   
    ocultarDvInformarResumido();
    $("#tablaImagenes").children("div").remove();


    var data = '{id_ris_examen:' + id_ris_examen + ', numeroacceso:"' + numeroacceso + '"}';

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/InformarResumido",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;
            console.log(arg);
            $('#modalCargando').modal('hide');

            for (var i = 0; i < objeto.length; i++) {

                if (objeto[i].urlPrestacion != "") {
                    document.location.href = objeto[i].urlPrestacion;
                }
                else {
                    $('#modalInformarResumido').modal('show');
                    $("#dvInformarResumidoCargando").show();
                    var htmlTablaInformes = objeto[i].tablaInformes;
                    $("#tablaInformesResumido").children("table").remove();
                    $("#tablaInformesResumido").children("b").remove();
                    $("#tablaInformesResumido").append(htmlTablaInformes);

                    var htmlTablaPrestaciones = objeto[i].tablaPrestaciones;
                    $("#tablaPrestacionesResumido").children("table").remove();
                    $("#tablaPrestacionesResumido").append(htmlTablaPrestaciones);

                    var htmlTablaImagenes = objeto[i].imagenes;
                    $("#tablaImagenes").children("div").remove();
                    $("#tablaImagenes").append(htmlTablaImagenes);
                }
            }

            ocultarDvInformarResumido();
            $("#dvInformarResumidoResultado").show();
            $('#modalCargando').modal('hide');
        },
        error: function () {
            ocultarDvInformarResumido();
            $("#dvInformarResumidoError").show();
        }
    });
    CargaDatosInactivo();
}

function informar(codExamen, id_institucion) {
    var prestaciones = "";
    var sini = "";
    $('.chkprestacionclass:checked').each(function (i) {
        prestaciones += sini + $(this).val();
        sini = ",";
    });
    if (prestaciones.length > 0) {

        var data = '{cod_examen:"' + codExamen + '", id_institucion: "' + id_institucion + '", prestaciones: "' + prestaciones + '"}';

        $.ajax({
            type: "POST",
            url: "ListaExamen.aspx/ObtenerURLInformar",
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: data,
            success: function (arg) {
                var objeto = arg.d;

                document.location.href = objeto;
            },
            error: function () {

            }
        });

        //document.location.href = ObtenerUrlInformar(codExamen, id_institucion, prestaciones);//'Informar.aspx?codexamen=' + codExamen + '&idInstitucion=' + id_institucion + '&idprestacion=' + prestaciones + "";
    }
    else {
        $('.nombre_prestacion').css({ 'color': 'red', 'font-weight': 'bold' });
    }
}

function verdocumento(urlDocumento) {

    document.getElementById("imgOrdenMedica").removeAttribute("src");
    $("#imgOrdenMedica").attr("src", urlDocumento);
}

function alertaModalAgregarFiltro() {
    alert("Se agrega filtro correctamente, Se cargara la pagina.");
}

function guardarFiltro(id_filtro) {
    var data = '{id_ris_examen:' + id_ris_examen + ', numeroacceso:"' + numeroacceso + '"}';
}

function cargarTablaFiltros() {
    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/cargarMisFiltros",
        contentType: "application/json; charset=utf-8",
        success: function (arg) {
            var objeto = arg.d;

            for (var i = 0; i < objeto.length; i++) {

                var htmlTablaFiltros = objeto[i].tablaFiltros;
                $("#tablaFiltros").children("table").remove();
                $("#tablaFiltros").append(htmlTablaFiltros);
            }
        },
        error: function () {

        }
    });
}

function cargarPagina() {
    location.reload();
}

function cargarTablaFiltrosPrincipales() {
    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/cargarFiltrosPrincipales",
        contentType: "application/json; charset=utf-8",
        success: function (arg) {
            var objeto = arg.d;

            for (var i = 0; i < objeto.length; i++) {

                var htmlTablaFiltros = objeto[i].tablaFiltros;
                $("#tabla2Filtros").children("table").remove();
                $("#tabla2Filtros").append(htmlTablaFiltros);
            }
        },
        error: function () {

        }
    });
}

function eliminarFiltro(id_filtro) {

    var data = '{id_filtro:' + id_filtro + '}';

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/eliminarFiltro",
        contentType: "application/json; charset=utf-8",
        data: data,
        datatype: "json",
        success: function (arg) {
            alert("Filtro eliminado, pagina se recargara.");
            cargarTablaFiltros();
            cargarTablaFiltrosPrincipales();
            location.reload();
        },
        error: function () {

        }
    });
}

function activarFiltro(id_filtro) {
    var data = '{id_filtro:' + id_filtro + '}';

    //$('#modalCargando').modal('show');

    $.ajax({
        type: "POST",
        url: "ListaExamen.aspx/activarFiltro",
        contentType: "application/json; charset=utf-8",
        data: data,
        datatype: "json",
        success: function (arg) {
            window.location.href = "ListaExamen.aspx";
        },
        error: function () {

        }
    });


}

function prueba() {
    let now = new Date();
    let hora = now.getHours();
    /*            alert(hora);*/

    if (hora >= 8 && hora <= 20) {
        $('#modalInicioPopUpHabil').modal('show');
    }
    else {
        $('#modalInicioPopUpNoHabil').modal('show');
    }
}

function GetAddendumsPendientes() {
    console.log('bandera1');
    $.getJSON("../Examen/JsonGetAddendumsPendientes.aspx", function (data) {
        console.log(data);
        if (data.out == 'ok') {
            $("#divAddendums").children("table").remove();

            var table = "";

            table += "<table class='table table-striped table-dark table-hover'>";
            table += "<tr>";
            table += "<th>";
            table += "Institución";
            table += "</th>";
            table += "<th>";
            table += "#Acceso";
            table += "</th>";
            table += "<th>";
            table += "Radiologo";
            table += "</th>";
            table += "<th>";
            table += "Fecha Solicitud";
            table += "</th>";
            table += "<th>";
            table += "Solicitante";
            table += "</th>";
            table += "<th>";
            table += "Motivo";
            table += "</th>";
            table += "<th>";
            table += "Aciones";
            table += "</th>";
            table += "</tr>";

            for (var x = 0; x < data.cantidad; x++) {
                table += "<tr>";
                table += "<td>";
                table += data.solicitudes[x].institucion;
                table += "</td>";
                table += "<th>";
                table += data.solicitudes[x].numero_acceso;
                table += "</td>";
                table += "<td>";
                table += data.solicitudes[x].username;
                table += "</td>";
                table += "<td>";
                table += data.solicitudes[x].fecha_solicitud;
                table += "</td>";
                table += "<td>";
                table += data.solicitudes[x].usuario_solicitud;
                table += "</td>";
                table += "<td>";
                table += data.solicitudes[x].motivo;
                table += "</td>";
                table += "<td>";
                if (data.solicitudes[x].addendum != "") {
                    table += "<a href=" + data.solicitudes[x].addendum + " title='Generar Addendum'><img src='../icon/corregir.png' style='width: 20px'/></a>";
                }
                table += "</td>";
                table += "</tr>";
            }

            table += "</table>";

            $("#divAddendums").append(table);
        }
    });
}