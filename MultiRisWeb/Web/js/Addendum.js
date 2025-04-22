var coodigo_examen = '';
let selectedPatologiaCritica = -2;

let idPacienteAddendumInforme = '';
let idInstitucionAddendumInforme = 0;
let codExamenAddendumInforme = '';
let urlAddendum = ''

$(document).ready(function () {

    ObtenerEstudiosRelacionados();

    $.ajax({
        type: "POST",
        url: "Addendum.aspx/ObtenerDatos",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            ObtenerEstudiosRelacionados(objeto[0].codexamen, objeto[0].id_institucion);
        },
        error: function () {

        }
    });
});

function ObtenerEstudiosRelacionados(codExamen, idInstitucion) {

    var data = '{codExamen:"' + codExamen + '", idInstitucion: ' + idInstitucion + '}';
    var html = '';

    $.ajax({
        type: "POST",
        url: "Addendum.aspx/GetExamenesPrevios",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {
            idPacienteAddendumInforme = '';
            idInstitucionAddendumInforme = 0;
            codExamenAddendumInforme = '';

            $("#tbodyEstudiosAnteriores").html('');

            if (data.d.Ejecutado) {
                $.each(data.d.Data, function (i, item) {
                    html += "<tr>";
                    html += "<td>" + item.Centro + "</td>";
                    html += "<td>" + item.FechaText + "</td>";
                    html += "<td>" + item.Descripcion + "</td>";
                    html += "<td>" + item.Modalidad + "</td>";
                    html += "<td>" + item.Visores + "</td>";
                    html += "</tr>";

                    idPacienteAddendumInforme = item.IdPaciente;
                    idInstitucionAddendumInforme = item.IdInstitucion;
                    codExamenAddendumInforme = item.CodExamen;
                    urlAddendum = item.Url;
                });
            }
            else {
                html += "<tr><td colspan='5' class='text-center'>No existen estudios previos</td></tr>";
            }

            $("#tbodyEstudiosAnteriores").html(html);
        }
    });
}

function verdocumento(urlDocumento) {
    document.getElementById("imgDocumentos").removeAttribute("src");
    $("#imgDocumentos").attr("src", urlDocumento);
}

function cargarDocumentoPDF(urlDocumento) {
    document.getElementById("iframeDocumento").removeAttribute("src");
    $("#iframeDocumento").attr("src", urlDocumento);
}

function ImportStudy(codexamen, id_institucion) {
    $("#modalSolicitudImagenes").modal("show");

    $.getJSON("../Examen/JsonImportStudy.aspx?codexamen=" + codexamen + "&id_institucion=" + id_institucion, function (data) {
    });
}

function CargaDatosInactivo() {
    $('#modalCargando').modal('hide');
}

function CargaDatosActivo() {
    $('#modalCargando').modal('show');
}

function ObtenerTodosInformesPrevios(id_paciente, id_institucion, urlInforme, identificador) {

    iframeInformeVacio();

    var data = '{id_paciente:"' + id_paciente + '", id_institucion:' + id_institucion + ', codexamen:"' + coodigo_examen + '"}';

    $.ajax({
        type: "POST",
        url: "Addendum.aspx/ObtenerInformesPrevios",
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

    CargaDatosInactivo();
}

function verdocumento(urlDocumento) {
    document.getElementById("imgDocumentos").removeAttribute("src");
    $("#imgDocumentos").attr("src", urlDocumento);
}

function cargarDocumentoPDF(urlDocumento) {
    document.getElementById("iframeDocumento").removeAttribute("src");
    $("#iframeDocumento").attr("src", urlDocumento);
    window.open(urlDocumento); //RVN 18-08-2023
}

function cargarDocumento(urlDocumento) {

    $("#imgDocumento").attr("src", urlDocumento);
    window.open(urlDocumento); //RVN 18-08-2023
}

function iframeInformeVacio() {
    $("#iframeInforme").attr("src", "../Control/Vacio.html");
}

function cargarInforme(urlInforme, identificador) {
    iframeInformeVacio();
    limpiarColoresInformesPrevios();

    $("#iframeInforme").attr("src", urlInforme);
    $("#" + identificador).css("background-color", "#FF7500");
    $("#" + identificador).css("color", "white");
}

function limpiarColoresInformesPrevios() {
    $(".btn_informes_previos").css("background-color", "white");
    $(".btn_informes_previos").css("color", "black");
}
/*Inicio Seccion de manejo de opciones de informe patologia grave*/
function SelectedCriticaNo() {
    $("#imgNo").attr("src", "../img/checkBlanco.png");
    $("#imgSi").attr("src", "");
    document.getElementById("divSelectPatologiaGrave").style.display = "none";
    /*  document.getElementById("lblMensajeError").style.display = "none";*/
    document.getElementById("lblPatologia").style.color = "white";
    selectedPatologiaCritica = 0;

}
function SelectedCriticaSi() {
    $("#imgSi").attr("src", "../img/checkBlanco.png");
    $("#imgNo").attr("src", "");
    document.getElementById("divSelectPatologiaGrave").style.display = "block";
    /*document.getElementById("lblMensajeError").style.display = "none";*/
    document.getElementById("lblPatologia").style.color = "white";
    selectedPatologiaCritica = 1;
    CargarControlPatologias();
}
/*Fin Seccion de manejo de opciones de informe patologia grave*/

/* funciones Patologias Criticas */
function CargarControlPatologias() {

    $.ajax({
        type: "GET",
        url: "Addendum.aspx/CargarPatologias",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
            var patologias = data.d.Data;

            $('#ddlSeleccionePatologia').empty();
            $.each(patologias, function (i, item) {
                $('#ddlSeleccionePatologia').append('<option value="' + item.id_patologia_critica + '">' + item.nombre + '</option>');
            })
        }
    });

}
/* fin funciones Patologias Criticas */

/*Manejo Mensajes*/
function AbrirMensajeAddendum(mensaje) {
    $("#lblMensajeModal").text(mensaje);
    $("#modalInformacionAddendum").modal('show');
}

function CerrarModalInformacionAddendum() {
    $("#modalInformacionAddendum").modal('hide');
}
/*Fin Manejo Mensajes*/

function Validar() {
    
    $("#lblMensaje").css("color", "Red");
    $("#lblMensaje").text('');

    var addendumComentario = invoxCKEditor.editor.getData();
    var patologiaCritica = selectedPatologiaCritica == 1 ? $("#ddlSeleccionePatologia option:selected").text() : '';

    if (addendumComentario == null || addendumComentario == '') {
        $("#lblMensaje").text('- Debe ingresar texto addendum para validar');
        return;
    }

    if (selectedPatologiaCritica == -2) {
        $("#lblMensaje").text('- Debe seleccion opcion de patologia critica');
        return;
    }

    var data = '{esPatologiaCritica:' + selectedPatologiaCritica + ', addendumText:"' + addendumComentario + '", patologiaCritica:"' + patologiaCritica + '"}';

    $.ajax({
        type: "POST",
        url: "Addendum.aspx/Validar",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
            if (arg.d == "true") {
                $("#lblMensaje").css("color", "Green");
                $("#lblMensaje").text('- Addendum se almaceno correctamente.');
                $('#btnRegresar').trigger('click');
            }
            else {
                $("#lblMensaje").css("color", "Red");
                $("#lblMensaje").text('- Addendum no se almaceno correctamente.');
            }

        },
        error: function () {

        }
    });
}

function VerInformes() {

    if (idPacienteAddendumInforme == '') {
        return;
    }
    window.open(urlAddendum + idPacienteAddendumInforme + ' &idInstitucion=' + idInstitucionAddendumInforme + '&codExamen=' + codExamenAddendumInforme, '_blank')
}

