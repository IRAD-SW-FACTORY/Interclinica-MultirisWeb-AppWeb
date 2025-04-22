
function ProcesarPrestacionesExamen(idExamen) {

    var jsdata = '{ idExamen :' + idExamen + '}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/ProcesarPrestacionesExamen",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        success: function (data) {
            CerrarPopUpMantenedorPrestacion();
            AbrirMensajePrestacionExamen(data.d.Mensaje);
           
        },
        error: function () {

        }
    });
}

function CargarMantenedorExamen(idExamen) {
   
    if ($("#hddPerfil").val() != "1") {       
        AbrirMensajePrestacionExamen('Ud. No posee perfil de Administrador para acceder a esta opcion de menu');
        return;
    }


    $.ajax({
        type: "GET",
        url: "../Examen/ListaExamen.aspx/GetInfoMantedorPrestacion",
        data: { "idExamen" :  idExamen },
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {          
            $("#lblRutPrestacion").text(data.d.Data.MantendorPrestacion.Rut);
            $("#lblNombrePrestacion").text(data.d.Data.MantendorPrestacion.Nombre);
            $("#lblEdadPrestacion").text(data.d.Data.MantendorPrestacion.Edad);
            $("#lblInstitucionPrestacion").text(data.d.Data.MantendorPrestacion.Institucion);
            $("#lblFechaExamenPrestacion").text(data.d.Data.MantendorPrestacion.FechaExamenText);
            $("#lblMedicoPrestacion").text(data.d.Data.MantendorPrestacion.Radiologo);
            $("#lblEstadoPrestacion").text(data.d.Data.MantendorPrestacion.Estado);
            CargarPrestacionesMantenedor(data.d.Data.Prestaciones);
            CargarPrestacionesExamen(data.d.Data.PrestacionesExamen);
            $("#btnInsertOrUpdatePrestacion").attr("onclick", "ProcesarPrestacionesExamen(" + data.d.Data.MantendorPrestacion.IdExamen + "); return false;");
            $("#modalMantenedorPrestacion").modal('show');
        },
        error: function () {

        }
    });
}

function AgregarPrestacionExamen() {

    var idPrestacion = $("#ddlPrestacionesMantenedor").val();

    $.ajax({
        type: "GET",
        url: "../Examen/ListaExamen.aspx/AgregarPrestacionExamen",
        data: { "idPrestacion": idPrestacion },
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            CargarPrestacionesMantenedor(data.d.Data.Prestaciones);
            CargarPrestacionesExamen(data.d.Data.PrestacionesExamen);            
        },
        error: function () {

        }
    });
}

function EliminarPrestacionExamen(idPrestacion) {

    $.ajax({
        type: "GET",
        url: "../Examen/ListaExamen.aspx/EliminarPrestacionExamen",
        data: { "idPrestacion": idPrestacion },
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {           
            if (data.d.Ejecutado) {
                CargarPrestacionesMantenedor(data.d.Data.Prestaciones);
                CargarPrestacionesExamen(data.d.Data.PrestacionesExamen);               
            }
            else {                
                AbrirMensajePrestacionExamen(data.d.Mensaje);
            }
        },
        error: function () {

        }
    });
}

function CerrarPopUpMensajeMantenedorPrestacion() {
    $("#modalMensajeMantenedorPrestacion").modal('hide');
}

function AbrirMensajePrestacionExamen(mensaje) {
    $("#lblMensajeMantenedorPrestacion").text(mensaje);
    $("#modalMensajeMantenedorPrestacion").modal("show");
}


function CargarPrestacionesMantenedor(data) {
    $("#ddlPrestacionesMantenedor").empty();
    $.each(data, function (id, value) {
        $("#ddlPrestacionesMantenedor").append('<option value="' + value.Value + '">' + value.Text + '</option>');
    });
}

function CargarPrestacionesExamen(data) {
    $("#tbPrestacionesExamen").html('');
    var html = '';
    $.each(data, function (id, value) {
        html += '<tr>' +
            '<td>' + value.CodigoPrestacion +'</td>' +
            '<td>' + value.NombrePrestacion + '</td>' +
            '<td class="text-center">' +
            '<a href="javascript:EliminarPrestacionExamen(' + value.IdPrestacion +')">' +
            '<img src="../icon/eliminar.png" title="Eliminar Prestacion" style="max-width: 25px !important" />' +
            '</a>' +
            '</td>' +
            '</tr>';
    });
    $("#tbPrestacionesExamen").html(html);
}

function CerrarPopUpMantenedorPrestacion() {
    $("#modalMantenedorPrestacion").modal('hide');
}
function EnviarCorreoProcesado() {

}