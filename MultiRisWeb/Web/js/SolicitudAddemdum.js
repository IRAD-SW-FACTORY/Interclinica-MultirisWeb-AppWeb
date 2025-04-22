function OpenProcesarAddemdum() {
    $("#modalProcesarSolicitudAddemdum").modal('show');
    CargarInstconAdd();
    CargarMedInformantesAdd();
    ListarSolicitudAddendumTodosB();
}

function CloseProcesarAddemdum() {
    $("#modalProcesarSolicitudAddemdum").modal('hide');
}

function ListarSolicitudAddendumTodosB() {

    var idPerfil = $("#hddPerfil").val();

    $("#tbDespliegueAddendum").html('');
    var html = ' ';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/ListarSolicitudAdeendumTodos",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $.each(data.d.Data, function (id, value) {
                html += '<tr>' +
                    '<td>' + value.Id + '</td>' +
                    '<td>' + value.FechaIngresoText + ' hrs. </td>' +
                    '<td>' + value.estado + '</td>' +
                    '<td>' + value.Nombre + '</td>' +
                    '<td>' + value.paciente + '</td>';

                if (idPerfil != 8 && idPerfil != 4) {
                    html += '<td>' + value.UsuarioInformadorExamen + '</td>' +
                        '<td>' + value.UsuarioValidadorExamen + '</td>' +
                        '<td>' + value.UsuarioValidadorAddendum + '</td>';
                }

                html += '<td class="text-center">' +
                    '<a href="javascript:EditarSolicitudAddemdum(' + value.IdRisExamen + ',' + value.Id + ')">' +
                    '<img src="../icon/corregir.png" title="Consultar Sol." style="max-width: 25px" />' +
                    '</a>' +
                    '</td>' +
                    '</tr>';
            });

            if (html == ' ') {
                html = '<tr class="text-center"><td colspan="9">No Existen Solicitudes Addendum</td></tr>';
            }

            $("#tbDespliegueAddendum").html(html);
        },
    });
}

function CargarInstconAdd() {
    $("#ddlInstitucionAddemdum").empty();
    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/InstitucionesAddendum",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $.each(data.d, function (id, value) {
                $("#ddlInstitucionAddemdum").append('<option value="' + value.Value + '">' + value.Text + '</option>');
            });
        },
        error: function () { }
    });
}

function CargarMedInformantesAdd() {
    $("#ddlMedicoInformadorAddemdum").empty();
    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/MedInformateInformeAddendum",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $.each(data.d, function (id, value) {
                $("#ddlMedicoInformadorAddemdum").append('<option value="' + value.Value + '">' + value.Text + '</option>');
            });
        },
        error: function () { }
    });
}

function CargarSolicitudesAdd() {
    var idInst = document.getElementById('ddlInstitucionAddemdum');
    var valor1 = idInst.options[idInst.selectedIndex].value;
    var idEstado = document.getElementById('ddlEstadosSolicitudAddemdum');
    var valor2 = idEstado.options[idEstado.selectedIndex].value;
    var idUsuarioInformador = $("#ddlMedicoInformadorAddemdum").val();   
    ListarSolicitudAddendum(valor2, valor1, idUsuarioInformador);
}

function ListarSolicitudAddendum(idSolicitud, idInstitucion, idUsuarioInformador) {

    var idPerfil = $("#hddPerfil").val();
    idUsuarioInformador = idUsuarioInformador == undefined ? 0 : idUsuarioInformador;


    var jsdata = '{idEstado:' + idSolicitud + ', idInstitucion:' + idInstitucion + ', idUsuarioValidador:' + idUsuarioInformador +'}';
    $("#tbDespliegueAddendum").html('');
    var html = ' ';
    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/ListarSolicitudAdeendum",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        success: function (data) {
            $.each(data.d.Data, function (id, value) {
                html += '<tr>' +
                    '<td>' + value.Id + '</td>' +
                    '<td>' + value.FechaIngresoText + '</td>' +
                    '<td>' + value.estado + '</td>' +
                    '<td>' + value.Nombre + '</td>' +
                    '<td>' + value.paciente + '</td>';

                if (idPerfil != 8 && idPerfil != 4) {
                    html += '<td>' + value.UsuarioInformadorExamen + '</td>' +
                        '<td>' + value.UsuarioValidadorExamen + '</td>' +
                        '<td>' + value.UsuarioValidadorAddendum + '</td>';
                }

                html += '<td class="text-center">' +
                    '<a href="javascript:EditarSolicitudAddemdum(' + value.IdRisExamen + ',' + value.Id + ')">' +
                    '<img src="../icon/corregir.png" title="Consultar Sol." style="max-width: 25px" />' +
                    '</a>' +
                    '</td>' +
                    '</tr>';
            });

            if (html == ' ') {
                html = '<tr class="text-center"><td colspan="9">No Existen Solicitudes Addendum</td></tr>';
            }

            $("#tbDespliegueAddendum").html(html);
        },
    });
}

function OpenProcesarAddemdumDetalle() {
    $("#modalSolicitudDetalleAddemdum").modal('show');
    $("#modalProcesarSolicitudAddemdum").modal('hide');
}

function EditarSolicitudAddemdum(idExamen, idSolicitud) {
    $("#modalProcesarSolicitudAddemdum").modal('hide');
    $("#modalSolicitudDetalleAddemdum").modal('show');
    GetDetalleAddendum2(idExamen, idSolicitud);
}

function GetDetalleAddendum2(idExamen, idSolicitud) {
    const btnProcAdd = document.getElementById('btnProcesarAdd');
    btnProcAdd.disabled = false;
    const btnFinAdd = document.getElementById('btnFinalizarAdd');
    btnFinAdd.disabled = false;

    $("#txtComentarioRechazo").val('');

    var jsdata = '{ idExamen :' + idExamen + ' IdSolicitud :' + idSolicitud + '}';
    $.ajax({
        type: "GET",
        url: "../Examen/ListaExamen.aspx/GetExamenSolicitudAddendumEdit",
        contentType: "application/json; charset=utf-8",
        data: { "idExamen": idExamen, "IdSolicitud": idSolicitud },
        datatype: "json",
        async: false,
        success: function (data) {
            var obj = data.d.Data;
            $("#lblIdExamen2").text(obj.IdRisExamen);
            $("#hddIdSolicitudAddendum").val(obj.Id);
            $("#hddIdEstadoSolicitudAddendum").val(obj.EstadoSolicitudAdedemdum);
            $("#lblFechaIngresoAddemdumDetalle").text(obj.FechaIngreso);
            $("#lblUsuarioIngresoAddemdumDetalle").text(obj.Usuario);
            $("#lblMailIngresoAddemdumDetalle").text(obj.Mail);
            $("#lblInstitucionAddemdumDetalle").text(obj.Institucion);
            $("#lblTipoAtencionExamenAddemdumDetalle").text(obj.TipoAtencion);
            $("#lblTipoSolicitudExamenAddemdumDetalle").text(obj.NomTipoSolicitud);
            $("#lblModalidadExamenAddemdumDetalle").text(obj.Modalidad);
            $("#lblFechaExamenAddemdumDetalle").text(obj.FechaExamen);
            $("#lblRutPacienteExamenAddemdumDetalle").text(obj.IdPaciente);
            $("#lblNombrePacienteExamenAddemdumDetalle").text(obj.Paciente);
            $("#lblMedicoSolicitanteExamenAddemdumDetalle").text(obj.Medico);
            $("#lblDetalleSolicitudAddemdumDetalle").text(obj.Detalle);
            if (obj.Perfil != 4 && obj.Perfil != 8) {
                $("#lblMedicoInformadorAddemdumDetalle").text(obj.UsuarioInformadorExamen);
                $("#lblMedicoValidadorExamenAddemdumDetalle").text(obj.UsuarioValidadorExamen);
                $("#lblMedicoAddendumExamenAddemdumDetalle").text(obj.UsuarioValidadorAddendum);
            }
            $("#txtComentarioRechazo").val(obj.Comentario);
            if (obj.Perfil != 1) {
                const btnProcAdd = document.getElementById('btnProcesarAdd');
                btnProcAdd.disabled = true;
                const btnFinAdd = document.getElementById('btnFinalizarAdd');
                btnFinAdd.disabled = true;
                const btnEli = document.getElementById('btnEliminarAdd');
                btnEli.disabled = true;
                $("#lblMensajeDeshabilita2").text("Usted NO tiene perfil para procesar/finalizar solicitudes");
            };

            if (obj.Perfil == 8) {

                const btnProcAdd = document.getElementById('btnProcesarAdd');
                btnProcAdd.disabled = true;
                const btnFinAdd = document.getElementById('btnFinalizarAdd');
                btnFinAdd.disabled = true;
                const btnEli = document.getElementById('btnEliminarAdd');
                btnEli.disabled = true;
                const btnAddendum = document.getElementById('btnAddendar');
                btnAddendum.disabled = true;
                const txtdetalle = document.getElementById('lblDetalleSolicitudAddemdumDetalle');
                txtdetalle.disabled = true;
                const txtrechazo = document.getElementById('txtComentarioRechazo');
                txtrechazo.disabled = true;
            };
        },
        error: function () {

        }
    });
}

function UpdateAddendum(idEstado) {
    var idSolicitud = $("#hddIdSolicitudAddendum").val();
    var sComentario2 = $("#txtComentarioRechazo").val();
    var sComentario = sComentario2.replaceAll(String.fromCharCode(34), "'");

    var jsdata = '{ id :' + idSolicitud + ', idEstado :' + idEstado + ', sComentario :"' + sComentario + '"}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/UpdateSolicitudAdeendum",
        contentType: "application/json; charset=utf-8",
        beforeSend: function () { $("#modalMessageBox").modal('show'); $("#messagePrestacion").text('Espere mientras se actualiza la solicitud'); },
        data: jsdata,
        datatype: "json",
        async: true,
        error: function () {
            $("#modalSolicitudDetalleAddemdum").modal('hide');
            $("#modalMessageBox").modal('hide');
            alert('error');
        }
    }).done(function (arg) {
        if (arg.d.Ejecutado) {
            $("#modalSolicitudDetalleAddemdum").modal('hide');

            OpenProcesarAddemdum();

            if (arg.d.Mensaje != '') {
                $("#messagePrestacion").text(arg.d.Mensaje);
            } else $("#modalMessageBox").modal('hide');
        }
    });
}

function CargarInformesAdd() {
    var idExamenLbl = document.getElementById('lblIdExamen2').textContent;
    ListarInformesAddendum(idExamenLbl);
}

function ListarInformesAddendum(idExamen) {
    var jsdata = '{idExamen : ' + idExamen + '}';
    $("#tbDespliegueInformes").html('');
    var html = ' ';
    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/InformesResumido2",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        async: false,
        success: function (data) {
            $("#modalSolicitudDetalleAddemdum").modal('hide');
            $("#divInformes").html(data.d.Data);
            $("#modalSolicitudInformes").modal('show');
        },
    })
}

function EditarSolicitudAddemdum(idExamen, idSolicitud) {
    $("#modalProcesarSolicitudAddemdum").modal('hide');
    $("#modalSolicitudDetalleAddemdum").modal('show');
    GetDetalleAddendum2(idExamen, idSolicitud);
}

function CerrarPopUpMantenedorSolicituAddemdumDetalle() {
    $("#modalSolicitudDetalleAddemdum").modal('hide');
    $("#modalProcesarSolicitudAddemdum").modal('show');
}

function DeleteSolAddendum() {
    var jsdata = '{ id :' + $("#hddIdSolicitudAddendum").val() + '}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/EliminaSolicitudAdeendum",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        async: true,
        error: function () {
            $("#modalSolicitudDetalleAddemdum").modal('hide');

            $("#modalMessageBox").modal('show');

            $("#messagePrestacion").text('Error en el llamado de operacion eliminar');
        }
    }).done(function (arg) {
        if (arg.d.Ejecutado) {
            $("#modalSolicitudDetalleAddemdum").modal('hide');
            OpenProcesarAddemdum();
        } else {
            $("#modalMessageBox").modal('show');
            $("#messagePrestacion").text(arg.d.Mensaje);
        }
    });
}

/*
function InsertarSolicitudAddendum() {
    if ($("#txtDetalleSolicitudAddemdum").val() == "") {
        AbrirMensajePrestacionExamen("Detalle de la solicitud Addendum es obligatorio");
    }

    var idExamen = $("#hddIdExamenAddendum").val();
    var detalle1 = $("#txtDetalleSolicitudAddemdum").val();
    var detalle = detalle1.replaceAll(String.fromCharCode(34),"'");
    var tipoSolicitud = $("#ddlTipoSolAddendum").val();
   // var adjunto = $("#B1").val();
     var adjunto = "Sin Adjunto";
    btnCrearAdd.disabled;

    var jsdata = '{ idExamen :' + idExamen + ', detalle :"' + detalle + '", tipoSolicitud : ' + tipoSolicitud + ', adjunto :"' + adjunto + '"}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/InsertarSolicitudAdeendum",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        async: false,
        success: function (data) {
            $("#modalSolicitudAddemdum").modal('hide');
            AbrirMensajePrestacionExamen(data.d.Mensaje);

        },
        error: function () {

        }
    });
}

function InsertaAdjunto() {
    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/registraAdjunto",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        async: false,
        success: function (data) {
                   },
        error: function () {

        }
    });

    
}

function CargarTipoSolicitud() {
  
    $("#ddlTipoSolAddendum").empty();
    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/TipoSolicitudAddendum",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $.each(data.d, function (id, value) {
                $("#ddlTipoSolAddendum").append('<option value="' + value.Value + '">' + value.Text + '</option>');
            });
        },
        error: function () {

        }
    });
}


 

function GetDetalleAddendum(idExamen) {
    const btnCreaAdd = document.getElementById('btnCrearAdd');
    btnCreaAdd.disabled = false;
    $("#lblMensajeDeshabilita").text("");
    var jsdata = '{ idExamen :' + idExamen + '}';
    $.ajax({
        type: "GET",
        url: "../Examen/ListaExamen.aspx/GetExamenSolicitudAddendum",
        data: { "idExamen": idExamen },
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
            var obj = data.d.Data;
            $("#hddIdExamenAddendum").val(obj.Id);
            $("#lblFechaIngresoAddemdum").text(obj.FechaIngreso);
            $("#lblUsuarioIngresoAddemdum").text(obj.Usuario);
            $("#lblMailIngresoAddemdum").text(obj.Mail);
            $("#lblInstitucionAddemdum").text(obj.Institucion);
            $("#lblTipoAtencionExamenAddemdum").text(obj.TipoAtencion);
            $("#lblModalidadExamenAddemdum").text(obj.Modalidad);
            $("#lblFechaExamenAddemdum").text(obj.FechaExamen);
            $("#lblRutPacienteExamenAddemdum").text(obj.IdPaciente);
            $("#lblNombrePacienteExamenAddemdum").text(obj.Paciente);
            $("#lblMedicoSolicitanteExamenAddemdum").text(obj.Medico);
            $("#txtDetalleSolicitudAddemdum").val("");
            if (obj.Estado < 3) {
                const btnCreaAdd = document.getElementById('btnCrearAdd');
                btnCreaAdd.disabled = true;
                $("#lblMensajeDeshabilita").text("El Exámen debe estar VALIDADO para poder generar esta solicitud");
            };
            if (obj.Perfil != 8 && obj.Perfil != 1)  {
                const btnCreaAdd = document.getElementById('btnCrearAdd');
                btnCreaAdd.disabled = true;
                $("#lblMensajeDeshabilita").text("Usted NO tiene perfil para crear esta solicitud");
            };
        },
        error: function () {

        }
    });

}


    Id = examenDb.id_ris_examen,
    FechaIngreso = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
    Usuario = usuario.nombre + " " + usuario.apellido_paterno,
    Mail = usuario.email1 == null ? "--" : usuario.email1,
    Institucion = institucionDb.nombre,
    TipoAtencion = examenDb.idtipoorden == "A" ? "Ambulatoria" : examenDb.idtipoorden == "U" ? "Urgencia" : "Hospitalizacion",
    Modalidad = examenDb.modalidad,
    FechaExamen = examenDb.fechaexamen.ToString("dd-MM-yyyy HH:mm"),
    IdPaciente = examenDb.idpaciente,
    Paciente = examenDb.nombre,
    Medico = examenDb.medicosolicitante,
    TipoSolicitud = SolAdd.TipoSolicitud,
    Detalle = SolAdd.Detalle,
    estado = SolAdd.estado,
    EstadoSolicitudAdedemdum = SolAdd.EstadoSolicitudAdedemdum






function CargarSolicitudAddemdum(id) {
    $("#modalSolicitudAddemdum").modal('show');
    GetDetalleAddendum(id);
    CargarTipoSolicitud();
}


*/

/*
function InsertarAdjuntoAddendum() {

    if ($("#txtDetalleSolicitudAddemdum").val() == "") {
        AbrirMensajePrestacionExamen("Archivo Cargado");
    }

    var nombreAdjunto = $("#fuArchivo.PostedFile").val();

    var jsdata = '{ Adjunto :' + nombreAdjunto + '}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/AdjuntarSolAdd",
        contentType: "application/json; charset=utf-8",
        data: jsdata,
        datatype: "json",
        async: false,
        success: function (data) {
            AbrirMensajePrestacionExamen(data.d.Mensaje);

        },
        error: function () {

        }
    });
}
function DespliegaConfirmacion(idExa) {
    $("#modalConfirmArchivSolicitudAddemdum").modal('show');
    CargarSolicitudAddemdum(idExa);
    
}

*/