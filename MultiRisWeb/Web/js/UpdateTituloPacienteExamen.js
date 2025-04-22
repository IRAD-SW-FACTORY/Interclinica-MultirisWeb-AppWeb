/*function CerrarPopUpTituloPacienteInforme() {
    $("#modalUpdateTituloPaciente").modal('hide');
}

function AbrirPupUpModificarTituloPaciente(idExamen, habilitado) {

    if ($("#hddPerfil").val() != "1" && $("#hddPerfil").val() != "6") {
        AbrirMensajePrestacionExamen('Ud. No posee perfil de Administrador para acceder a esta opcion de menu y/o no posee Informe, por este motivo no puede ser modificado');
        return;
    }

    $.ajax({
        type: "GET",
        url: "../Examen/ListaExamen.aspx/GetInfoTituloPaciente",
        data: { "idExamen": idExamen },
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            if (data.d.Ejecutado) {
                $("#lblInstitucionModTitulo").text(data.d.Data[0].Institucion);
                $("#lblFechaExamenModTitulo").text(data.d.Data[0].FechaExamenText);
                $("#lblMedicoModTitulo").text(data.d.Data[0].Radiologo);
                $("#lblEstadoModTitulo").text(data.d.Data[0].EstadoExamen);

                $("#txtRutInformeMod").val(data.d.Data[0].Rut);
                $("#txtNombreInformeMod").val(data.d.Data[0].Nombre);
                $("#txtPaternoInformeMod").val(data.d.Data[0].ApellidoPaterno);
                $("#txtMaternoInformeMod").val(data.d.Data[0].ApellidoMaterno);
                $("#ddlGeneroInfomrmeMod").val(data.d.Data[0].Genero);
                $("#btnUpdatePacienteInforme").attr("onclick", "UpdatePacienteInforme(" + data.d.Data[0].IdExamen + "); return false;");

                $("#divTitulos").html('');
                var html = '';
                var contador = 0;
                $.each(data.d.Data, function (id, value) {
                    contador++;
                    var idControl = 'id="txtTitulo' + value.IdInforme + '"';
                    html += '<div class="col-8">' +
                        '<label class="col-12" style = "font-size: medium" >INFORME ' + contador + ' </label >' +
                        '<input type="text" ' + idControl + ' value="' + value.TituloInforme + '" class="col-12 form-control" />' +
                        '</div>' +
                        '<div class="col-2 pt-4">' +
                        '<input type="button" id="" class="btn btn-filter" style="min-width: 110px !important" value="MODIFICAR TITULO" onclick="UpdateTituloInforme(' + value.IdInforme + ')" />' +
                        '</div>';
                    if (value.IdEstadoInforme == 3) {
                        html += '<div class="col-2 pt-4">' +
                            '<input type="button" id="" class="btn btn-danger" style="min-width: 110px !important" value="RE APERTURAR" onclick="AperturarInforme(' + value.IdInforme + ')" />' +
                            '</div>';
                    }
                });
                $("#divTitulos").html(html);

                $("#modalUpdateTituloPaciente").modal('show');
            }
            else {
                AbrirMensajePrestacionExamen(data.d.Mensaje);
            }
        },
        error: function () {

        }
    });
}
*/
/*function UpdatePacienteInforme(idExamen) {

    var idPaciente = $("#txtRutInformeMod").val();
    var nombre = $("#txtNombreInformeMod").val();
    var paterno = $("#txtPaternoInformeMod").val();
    var materno = $("#txtMaternoInformeMod").val();
    var genero = $("#ddlGeneroInfomrmeMod").val();

    if (idPaciente == '') {
        AbrirMensajePrestacionExamen("Rut del Paciente es obligatorio.");
        return;
    }
    else if (nombre == '') {
        AbrirMensajePrestacionExamen("Nombre del paciente es obligatorio.");
        return;
    }

    var jsdata = '{ idExamen :' + idExamen + ', nombre :"' + nombre + '", idPaciente :"' + idPaciente + '", paterno : "' + paterno + '", materno : "' + materno + '", genero : "' + genero + '"}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/UpdatePacienteInforme",
        data: jsdata,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            if (!data.d.Ejecutado)
                $("#modalUpdateTituloPaciente").modal('hide');
            AbrirMensajePrestacionExamen(data.d.Mensaje);
            
        },
        error: function () {

        }
    });

}
*/
function UpdateTituloInforme(idInforme) {
    var titulo = $("#txtTitulo" + idInforme).val();

    if (titulo == '') {
        AbrirMensajePrestacionExamen("Titulo de informe a modificar es obligatorio");
        return;
    }

    var jsdata = '{ idInforme :' + idInforme + ', titulo :"' + titulo + '"}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/UpdateTituloInforme",
        data: jsdata,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            if (!data.d.Ejecutado)
                $("#modalUpdateTituloPaciente").modal('hide');
            AbrirMensajePrestacionExamen(data.d.Mensaje);
           
        },
        error: function () {

        }
    });
}

function AperturarInforme(idInforme) {
    var jsdata = '{ idInforme :' + idInforme + '}';

    $.ajax({
        type: "POST",
        url: "../Examen/ListaExamen.aspx/AperturarInforme",
        data: jsdata,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            $("#modalUpdateTituloPaciente").modal('hide');
            AbrirMensajePrestacionExamen(data.d.Mensaje);
            
        },
        error: function () {

        }
    });
}
