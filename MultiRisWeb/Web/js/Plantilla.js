


function CargarPlantillaSelected() {
    var data = '{ codExamen :"' + $("#hddCod").val() + '"}';
   
    $.ajax({
        type: "POST",
        url: "Informar.aspx/GetPlantillas",
        contentType: "application/json; charset=utf-8",
        data: data,
        datatype: "json",
        async: false,
        success: function (data) {
            var plantillas = data.d.Data;
            $('#ddlPlantilla').empty();
            $.each(plantillas, function (i, item) {
                $('#ddlPlantilla').append('<option value="' + item.id_plantilla + '">' + item.nombre + '</option>');
            })
        }
    });

}

function UpdatePlantilla() {
    var idPlantilla = $("#ddlPlantilla").val();    

    var objPlantilla = new Object();
    objPlantilla.id_plantilla = idPlantilla;   
    objPlantilla.titulo = invoxCKEditor.editor.getData();
    objPlantilla.tecnica = invoxCKEditor2.editor.getData();
    objPlantilla.hallazgos = invoxCKEditor4.editor.getData();
    objPlantilla.impresion = invoxCKEditor5.editor.getData();
    objPlantilla.CodExamen = $("#hddCod").val();

    $.ajax({
        type: "POST",
        url: "Informar.aspx/ActualizarPlantilla",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ plantilla: objPlantilla }),
        datatype: "json",
        success: function (data) {

            ModalInformacion(data.d.Mensaje);
        }
    });
}

function InsertPlantilla() {
    
    var idPlantilla = 0;
    var nombrePlantilla = $("#txtPlantilla").val();
    
    if (nombrePlantilla == '') {
        MensajeInsertOrUpdatePlantilla('Debe seleccionar nombre de plantilla');
        return;
    }

    var objPlantilla = new Object();
    objPlantilla.id_plantilla = idPlantilla;
    objPlantilla.nombre = nombrePlantilla;
    objPlantilla.titulo = invoxCKEditor.editor.getData();
    objPlantilla.tecnica = invoxCKEditor2.editor.getData();
    objPlantilla.hallazgos = invoxCKEditor4.editor.getData();
    objPlantilla.impresion = invoxCKEditor5.editor.getData();
    objPlantilla.CodExamen = $("#hddCod").val();
    
    $.ajax({
        type: "POST",
        url: "Informar.aspx/CrearPlantilla",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ plantilla: objPlantilla }),
        datatype: "json",
        async: false,
        success: function (data) {
           
            $("#txtPlantilla").val('');
            CargarPlantillaSelected();
            MensajeInsertOrUpdatePlantilla(data.d.Mensaje);
        }
    });
}

function SeleccionarPlantilla(value) {

    if (value == 0)
        $("#btnActualizarPlantilla").hide();
    else
        $("#btnActualizarPlantilla").show();

    $.ajax({
        type: "GET",
        url: "Informar.aspx/GetPlantilla",
        contentType: "application/json; charset=utf-8",
        data: { 'idPlantilla': value },
        datatype: "json",
        success: function (data) {

            var plantilla = data.d.Data;
            invoxCKEditor3.editor.setData('');
            invoxCKEditor.editor.setData(plantilla.titulo);
            invoxCKEditor2.editor.setData(plantilla.tecnica);
            invoxCKEditor4.editor.setData(plantilla.hallazgos);
            invoxCKEditor5.editor.setData(plantilla.impresion);
        }
    });
}

function MensajeInsertOrUpdatePlantilla(mensaje) {
    $("#lblMensajePlantilla").text(mensaje);
}

function CerrarInsertOrUpdatePlantilla() {
    $("#modalGuardarPlantilla").modal('hide');
}

function AbrirInsertOrUpdatePlantilla() {
    $("#lblMensajePlantilla").text('');
    $("#modalGuardarPlantilla").modal('show');
}

function CerrarModalInformacion() {
    $("#modalInformacion").modal('hide');
}

function ModalInformacion(mensaje) {
    $("#modalCargando").modal('hide');
    $("#modalInformacion").modal('show');
    $("#lblMensajeModal").text(mensaje);
    
}