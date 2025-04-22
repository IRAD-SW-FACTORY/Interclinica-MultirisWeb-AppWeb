
$(function () {
    CargarInstitucion();
    CargarModalidad();
    CargaTipoAtencion();
    CargarEstadoExamen();
    CargarUsuarios();
    Get();
});


function CargarInstitucion() {

    $("#Institucion").multiselect({
        selectedList: 1,
        allSelectedText: '&nbsp;&nbsp;TODOS',
        minWidth: 80,
        checkAllText: 'Todo',
        uncheckAllText: 'Nada',
        noneSelectedText: '&nbsp;&nbsp;TODOS',
        selectedText: '&nbsp;&nbsp;# Seleccionados',
        header: true,
        height: 'auto',
        width: 200,
    });


    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/CargaInstitucion",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
            var objInst = data.d.Data;

            $.each(objInst, function (i, item) {
                $('#Institucion').append('<option value="' + objInst[i].id_institucion + '">' + objInst[i].nombre + '</option>');
            })
            $('#Institucion').multiselect('refresh');
        }
    });
}

function CargarModalidad() {
    $("#Modalidad").multiselect({
        selectedList: 1,
        allSelectedText: '&nbsp;&nbsp;TODOS',
        minWidth: 100,
        checkAllText: 'Todo',
        uncheckAllText: 'Nada',
        noneSelectedText: '&nbsp;&nbsp;TODOS',
        selectedText: '&nbsp;&nbsp;# Seleccionados',
        header: true,
        height: 'auto',
        width: 130
    });

    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/CargaModalidad",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {

            var objMod = data.d.Data

            $.each(objMod, function (i, item) {
                $('#Modalidad').append('<option value="' + objMod[i].id_modalidad + '">' + objMod[i].nombre + '</option>');
            })

            $('#Modalidad').multiselect('refresh');
        }
    });
}

function CargaTipoAtencion() {
    $("#Atencion").multiselect({
        selectedList: 1,
        allSelectedText: '&nbsp;&nbsp;TODOS',
        minWidth: 140,
        checkAllText: 'Todo',
        uncheckAllText: 'Nada',
        noneSelectedText: '&nbsp;&nbsp;TODOS',
        selectedText: '&nbsp;&nbsp;# Seleccionados',
        header: true,
        height: 'auto',
        width: 150
    });

    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/CargaAtencion",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {

            var objMod = data.d.Data;

            $.each(objMod, function (i, item) {
                $('#Atencion').append('<option value="' + objMod[i].id_tipo_urgencia + '">' + objMod[i].nombre_corto + '-' + objMod[i].nombre + '</option>');
            })

            $('#Atencion').multiselect('refresh');
        }
    });
}

function CargarEstadoExamen() {

    $("#EstadoExamen").multiselect({
        selectedList: 1,
        allSelectedText: '&nbsp;&nbsp;TODOS',
        minWidth: 70,
        checkAllText: 'Todo',
        uncheckAllText: 'Nada',
        noneSelectedText: '&nbsp;&nbsp;TODOS',
        selectedText: '&nbsp;&nbsp;# Seleccionados',
        header: true,
        height: 'auto',
        width: 130
    });
    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/CargaEstado",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (arg) {
            var objMod = arg.d.Data;

            $.each(objMod, function (i, item) {               
                $('#EstadoExamen').append('<option value="' + objMod[i].id_estado_examen + '">' + objMod[i].nombre + '</option>');
            })

            $('#EstadoExamen').multiselect('refresh');
        }
    });
}

function CargarUsuarios() {
    $("#Usuario").multiselect({
        selectedList: 1,
        allSelectedText: '&nbsp;&nbsp;TODOS',
        minWidth: 70,
        checkAllText: 'Todo',
        uncheckAllText: 'Nada',
        noneSelectedText: '&nbsp;&nbsp;TODOS',
        selectedText: '&nbsp;&nbsp;# Seleccionados',
        header: true,
        height: 'auto',
        width: 130
    });

    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/CargaUsuario",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (arg) {
            var objMod = arg.d.Data;

            $.each(objMod, function (i, item) {
                $('#Usuario').append('<option value="' + objMod[i].id_usuario + '">' + objMod[i].nombre_completo + '</option>');
            })

            $('#Usuario').multiselect('refresh');
        }
    });
}

function Get() {

   
    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/Get",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
          
            var filtro = data.d.Data;
            if (data.d.Ejecutado) {

                $("#filtro").val(filtro.Nombre);
                $("#EstadoFiltro").val(filtro.IdEstado);

                $.each(filtro.EstadosExamenes, function (i, item) {
                    $('#EstadoExamen > option').each(function () {
                        if ($(this).val() == item) $("#EstadoExamen option[value=" + $(this).val() + "]").prop("selected", true);
                    });
                });
                $('#EstadoExamen').multiselect('refresh');

                $.each(filtro.UsuariosAsignados, function (i, item) {
                    $('#Usuario > option').each(function () {
                        if ($(this).val() == item) $("#Usuario option[value=" + $(this).val() + "]").prop("selected", true);
                    });
                });
                $('#Usuario').multiselect('refresh');

                $.each(filtro.Instituciones, function (i, item) {
                    $('#Institucion > option').each(function () {                        
                        if ($(this).val() == item) $("#Institucion option[value=" + $(this).val() + "]").prop("selected", true);                        
                    });
                });
                $('#Institucion').multiselect('refresh');

                $.each(filtro.Atenciones, function (i, item) {
                    $('#Atencion > option').each(function () {
                        if ($(this).val() == item) $("#Atencion option[value=" + $(this).val() + "]").prop("selected", true);
                    });
                });
                $('#Atencion').multiselect('refresh');

                $.each(filtro.Modalidades, function (i, item) {
                    $('#Modalidad > option').each(function () {
                        if ($(this).val() == item) $("#Modalidad option[value=" + $(this).val() + "]").prop("selected", true);
                    });
                });
                $('#Modalidad').multiselect('refresh');
               
            }
        }
    });
}

function InsertOrUpdate() {

    $("#lblMensaje").html('');
    var mensaje = ValidaInsertOrUpdate();
    if (mensaje != '') {
        $("#modalValidador").modal('show');
        $("#lblMensaje").html(mensaje);
        return;
    }

    var filtro = new Object();
    filtro.idFiltro = 0;
    filtro.Nombre = $("#filtro").val();
    filtro.IdEstado = $("#EstadoFiltro").val();
    filtro.Instituciones = [];
    filtro.Modalidades = [];
    filtro.Atenciones = [];
    filtro.EstadosExamenes = [];
    filtro.UsuariosAsignados = [];

    $('#Institucion > option:selected').each(function () {
        filtro.Instituciones.push($(this).val());
    });

    $('#Modalidad > option:selected').each(function () {
        filtro.Modalidades.push($(this).val());
    });

    $('#Atencion > option:selected').each(function () {
        filtro.Atenciones.push($(this).val());
    });

    $('#EstadoExamen > option:selected').each(function () {
        filtro.EstadosExamenes.push($(this).val());
    });

    $('#Usuario > option:selected').each(function () {
        filtro.UsuariosAsignados.push($(this).val());
    });

    var data = "{ filtro: " + JSON.stringify(filtro) + "}";

    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Mantenedor.aspx/InsertUpdateFiltro",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {

            if (data.d.Ejecutado) {
                $("#modalValidador").modal('show');
                $("#lblMensaje").html('Filtro se ingereso o modifico correctamente en el sistema.');
                Get();
            }
            else {
				console.log(data.d.Mensaje);
                $("#modalValidador").modal('show');
                $("#lblMensaje").html('Hubo un error al procesar el filtro en el sistema.');
            }
        }
    });
}

function ValidaInsertOrUpdate() {

    var validaFiltros = 0;
    var validaUsuarios = 0;
    var mensaje = '';

    if ($("#filtro").val() == '')
        mensaje += '- Nombre del Filtro es obligatorio.&nbsp;';

    $('#Institucion > option:selected').each(function () {
        validaFiltros++;
    });

    $('#Modalidad > option:selected').each(function () {
        validaFiltros++;
    });

    $('#Atencion > option:selected').each(function () {
        validaFiltros++;
    });

    $('#EstadoExamen > option:selected').each(function () {
        validaFiltros++;
    });

    if (validaFiltros == 0)
        mensaje += '- Debe seleccionar al menos un filtro.&nbsp;';

    $('#Usuario > option:selected').each(function () {
        validaUsuarios++;
    });

    if (validaUsuarios == 0)
        mensaje += '- Debe seleccionar usuarios asigandos del filtro.&nbsp;';

    return mensaje;
}

function CerrarModalValidar() {
    $("#modalValidador").modal('hide');
}

