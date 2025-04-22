
$(document).ready(function () {  
    ObtenerTodosInformesPrevios();
});

function ObtenerTodosInformesPrevios() {
   
    iframeInformeVacio();

    var idPaciente = $("#hddIdPaciente").val();
    var idInstitucion = $("#hddIdInstitucion").val();
    var codExamen = $("#hddCodExamen").val();

    var data = '{id_paciente:"' + idPaciente + '", id_institucion:' + idInstitucion + ', codexamen:"' + codExamen + '"}';

    $.ajax({
        type: "POST",
        url: "AddendumExamenPrevios.aspx/ObtenerInformesPrevios",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
           
            var objeto = arg.d;
            var htmlTabla = objeto;
            var htmlTabla = htmlTabla;

            $("#tablaInformesPrevios").children("table").remove();
            $("#tablaInformesPrevios").append(htmlTabla);

            //cargarInforme(urlInforme, identificador);
        },
        error: function () {

        }
    });
}

function cargarInforme(urlInforme, identificador) {
    iframeInformeVacio();
    limpiarColoresInformesPrevios();

    $("#iframeInforme").attr("src", urlInforme);
    $("#" + identificador).css("background-color", "#FF7500");
    $("#" + identificador).css("color", "white");
}

function iframeInformeVacio() {
    $("#iframeInforme").attr("src", "../Control/Vacio.html");
}

function limpiarColoresInformesPrevios() {
    $(".btn_informes_previos").css("background-color", "white");
    $(".btn_informes_previos").css("color", "black");
}