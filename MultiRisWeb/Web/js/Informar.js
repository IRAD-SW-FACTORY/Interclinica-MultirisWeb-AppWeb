let selectedPatologiaCritica = -2;
var coodigo_examen = '';

let idPacienteInforme = '';
let idInstitucionAddendumInforme = 0;
let codExamenAddendumInforme = '';
let urlInforme = ''


function obtenerDocumentos(codExamen, numeroacceso, id_institucion) {
    var data = '{codExamen:"' + codExamen + '", numeroacceso:"' + numeroacceso + '", id_institucion: ' + id_institucion + '}';

    coodigo_examen = codExamen;


    $.ajax({
        type: "POST",
        url: "Informar.aspx/ObtenerDocumentos",
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

function verdocumento(urlDocumento) {
    document.getElementById("imgDocumentos").removeAttribute("src");
    $("#imgDocumentos").attr("src", urlDocumento);
}

function ImportStudy(codexamen, id_institucion) {
    $("#modalSolicitudImagenes").modal("show");

    $.getJSON("../Examen/JsonImportStudy.aspx?codexamen=" + codexamen + "&id_institucion=" + id_institucion, function (data) {
    });
}

function CargaDatosInactivo() {
    //$('#modalCargando').modal('hide');
}

function CargaDatosActivo() {
    //$('#modalCargando').modal('show');
}

function ObtenerEstudiosRelacionados(codExamen, idInstitucion) {

    var data = '{codExamen:"' + codExamen + '", idInstitucion: ' + idInstitucion + '}';
    var html = '';

    $.ajax({
        type: "POST",
        url: "Informar.aspx/GetExamenesPrevios",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {
            idPacienteInforme = '';
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

                    idPacienteInforme = item.IdPaciente;
                    idInstitucionAddendumInforme = item.IdInstitucion;
                    codExamenAddendumInforme = item.CodExamen;
                    urlInforme = item.Url;
                });
            }
            else {
                html += "<tr><td colspan='5' class='text-center'>No existen estudios previos</td></tr>";
            }

            $("#tbodyEstudiosAnteriores").html(html);
        }
    });
}



function obtenerComentarios(codExamen, numeroAcceso, id_institucion) {
    var data = '{codExamen:"' + codExamen + '", numeroAcceso:"' + numeroAcceso + '", id_institucion: ' + id_institucion + '}';

    coodigo_examen = codExamen;

    $('#aGuardarComentario').removeAttr('onclick');
    $('#aGuardarComentario').attr('onClick', 'guardarComentario("' + codExamen + '", "' + numeroAcceso + '", ' + id_institucion + '); return false;');

    $.ajax({
        type: "POST",
        url: "Informar.aspx/obtenerComentarios",
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

function actualizarBloqueoExamen() {

    var data = '{ codExamen:"' + $("#hddCod").val() + '" }';

    $.ajax({
        type: "POST",
        url: "Informar.aspx/actualizarBloqueoExamen",
        contentType: "application/json; charset=utf-8",
        data: data,
        success: function (arg) {

        },
        error: function () {

        }
    });

    setTimeout(actualizarBloqueoExamen, 20000);
}

function savePlantilla() {
    var nombre = $("#txtNombrePlantilla").val();
    var titulo = $("#txtTitulo").val();
    var tecnica = $("#txtTecnica").val();
    var hallazgos = $("#txtHallazgos").val();


    var impresion = $("#txtImpresion").val();
    var modalidad = $("#val_modalidad").val();
    var id_plantilla = 0;

    console.log(hallazgos);
    $.getJSON("../Plantilla/JsonSavePlantilla.aspx?modalidad=" + reemplazarTexto(modalidad) + "&impresion=" + reemplazarTexto(impresion) + "&hallazgos=" + reemplazarTexto(hallazgos) + "&tecnica=" + reemplazarTexto(tecnica) + "&titulo=" + reemplazarTexto(titulo) + "&nombre=" + reemplazarTexto(nombre) + "&id_plantilla=" + id_plantilla + "&rnd" + Math.round(Math.random() * 1000), function (data) {
        if (data.out == 'ok') {
            $("#divModalAlertModalidad").css("height", "70px");

            $("#modalGuardarplantillaExito").css("visibility", "visible");
            $("#modalGuardarplantillaError").css("visibility", "hidden");
            $("#lblGuardarPlantillaExito").text(data.mensaje);
        }
        else {
            $("#divModalAlertModalidad").css("height", "70px");

            $("#modalGuardarplantillaExito").css("visibility", "hidden");
            $("#modalGuardarplantillaError").css("visibility", "visible");
            $("#lblGuardarPlantillaError").text(data.mensaje);
        }
    });
}

function reemplazarTexto(texto) {
    texto = texto.replaceAll('&Aacute;', 'Á');
    texto = texto.replaceAll('&aacute;', 'á');
    texto = texto.replaceAll('&Eacute;', 'É');
    texto = texto.replaceAll('&eacute;', 'é');
    texto = texto.replaceAll('&Iacute;', 'Í');
    texto = texto.replaceAll('&iacute;', 'í');
    texto = texto.replaceAll('&Oacute;', 'Ó');
    texto = texto.replaceAll('&oacute;', 'ó');
    texto = texto.replaceAll('&Uacute;', 'Ú');
    texto = texto.replaceAll('&uacute;', 'ú');
    texto = texto.replaceAll('&Ntilde;', 'Ñ');
    texto = texto.replaceAll('&ntilde;', 'ñ');

    return texto;
}

function modalPlantilla() {
    $("#divModalAlertModalidad").css("height", "10px");
    $("#modalGuardarplantillaExito").css("visibility", "hidden");
    $("#modalGuardarplantillaError").css("visibility", "hidden");
    $("#txtNombrePlantilla").val('');
}

function guardarComentario(codExamen, numeroAcceso, id_institucion) {

    var data = '{codExamen:"' + codExamen + '", numeroAcceso:"' + numeroAcceso + '", id_institucion: ' + id_institucion + ', comentario:"' + $("#txtComentario").val() + '"}';

    coodigo_examen = codExamen;

    $.ajax({
        type: "POST",
        url: "Informar.aspx/guardarComentario",
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

function validarVocali() {
    $.ajax({
        type: "POST",
        url: "Informar.aspx/obtenerCredenciales",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (arg) {
            var objeto = arg.d;
            for (var i = 0; i < objeto.length; i++) {
                $('#a1').attr('href', objeto[i].urlImagenes);

                if (objeto[i].activarVocali == 1) {

                    var myUser = objeto[i].username;
                    var myPassword = objeto[i].password;
                    var myHostServer = objeto[i].host;
                    var myPort = objeto[i].port;
                    var useAgent = objeto[i].agent;

                    if (myUser === undefined || myPassword === undefined || myHostServer === undefined || myPort === undefined || useAgent === undefined) alert(msg);

                    if (location.protocol === 'file: ') {
                        Invox.ShowLocalSampleError();
                    } else {

                        var config = { height: 2 };
                        var configTitulo = { height: 20 };
                        var configTecnica = { height: 20 };
                        var configAntecedentes = { height: 40 };
                        var configHallazgos = { height: 280 };
                        var configComentario = { height: 280 };
                        var configImpresion = { height: 100 };

                        config.toolbarGroups = [
                            { name: 'invoxmd_group' },
                            '/',
                            { name: 'basicstyles', groups: ['basicstyles'] },
                            { name: 'list', groups: ['NumberedList', "BulletedList"] },
                            { name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            { name: 'styles' },
                            { name: 'colors' },
                            { name: 'undo' },
                            { name: 'insert', groups: ["Table", "HorizontalRule"] },
                            { name: 'texttransform' }
                        ];

                        configTitulo.toolbarGroups = [
                            { name: 'invoxmd_group' },
                            '/',
                            { name: 'basicstyles', groups: ['basicstyles'] },
                            { name: 'list', groups: ['NumberedList', "BulletedList"] },
                            { name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            { name: 'styles' },
                            { name: 'colors' },
                            { name: 'undo' },
                            { name: 'insert', groups: ["Table", "HorizontalRule"] },
                            { name: 'texttransform' }
                        ];

                        configTecnica.toolbarGroups = [
                            //{ name: 'invoxmd_group' },
                            //'/',
                            //{ name: 'basicstyles', groups: ['basicstyles'] },
                            //{ name: 'list', groups: ['NumberedList', "BulletedList"] },
                            //{ name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            //{ name: 'styles' },
                            //{ name: 'colors' },
                            //{ name: 'undo' },
                            //{ name: 'insert', groups: ["Table", "HorizontalRule"] },
                            //{ name: 'texttransform' }
                        ];

                        configAntecedentes.toolbarGroups = [
                            //{ name: 'invoxmd_group' },
                            //'/',
                            //{ name: 'basicstyles', groups: ['basicstyles'] },
                            //{ name: 'list', groups: ['NumberedList', "BulletedList"] },
                            //{ name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            //{ name: 'styles' },
                            //{ name: 'colors' },
                            //{ name: 'undo' },
                            //{ name: 'insert', groups: ["Table", "HorizontalRule"] },
                            //{ name: 'texttransform' }
                        ];

                        configHallazgos.toolbarGroups = [
                            //{ name: 'invoxmd_group' },
                            //'/',
                            //{ name: 'basicstyles', groups: ['basicstyles'] },
                            //{ name: 'list', groups: ['NumberedList', "BulletedList"] },
                            //{ name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            //{ name: 'styles' },
                            //{ name: 'colors' },
                            //{ name: 'undo' },
                            //{ name: 'insert', groups: ["Table", "HorizontalRule"] },
                            //{ name: 'texttransform' }
                        ];

                        configComentario.toolbarGroups = [
                            //{ name: 'invoxmd_group' },
                            //'/',
                            //{ name: 'basicstyles', groups: ['basicstyles'] },
                            //{ name: 'list', groups: ['NumberedList', "BulletedList"] },
                            //{ name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            //{ name: 'styles' },
                            //{ name: 'colors' },
                            //{ name: 'undo' },
                            //{ name: 'insert', groups: ["Table", "HorizontalRule"] },
                            //{ name: 'texttransform' }
                        ];

                        configImpresion.toolbarGroups = [
                            //{ name: 'invoxmd_group' },
                            //'/',
                            //{ name: 'basicstyles', groups: ['basicstyles'] },
                            //{ name: 'list', groups: ['NumberedList', "BulletedList"] },
                            //{ name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                            //{ name: 'styles' },
                            //{ name: 'colors' },
                            //{ name: 'undo' },
                            //{ name: 'insert', groups: ["Table", "HorizontalRule"] },
                            //{ name: 'texttransform' }
                        ];

                        //var editors = [/*{ id: 'ctl00_ContentPlaceHolder1_txtVocali', config: config },*/ { id: 'ctl00_ContentPlaceHolder1_txtTitulo', config: configTitulo }, { id: 'ctl00_ContentPlaceHolder1_txtHallazgos', config: configHallazgos }, { id: 'ctl00_ContentPlaceHolder1_txtAntecedentesClinicos', config: configAntecedentes }, 'ctl00_ContentPlaceHolder1_txtImpresion', { id: 'ctl00_ContentPlaceHolder1_txtTecnica', config: configTecnica }];
                        var editors = [{ id: 'txtTecnica', config: configTecnica }, { id: 'txtTitulo', config: configTitulo }, { id: 'txtImpresion', config: configImpresion }, { id: 'txtHallazgos', config: configHallazgos }, { id: 'txtAntecedentesClinicos', config: configAntecedentes }, { id: 'lblComentarioTM', config: configComentario }];

                        //INVOX.Internal(editors, myUser, myPassword, myHostServer, myPort, useAgent);
                    }
                }
            }
        },
        error: function () {

        }
    });
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

//function ObtenerTodosInformesPrevios(id_paciente, id_institucion, urlInforme, identificador) {

//    iframeInformeVacio();

//    var data = '{id_paciente:"' + id_paciente + '", id_institucion:' + id_institucion + ', codexamen:"' + coodigo_examen + '"}';

//    $.ajax({
//        type: "POST",
//        url: "Informar.aspx/ObtenerInformesPrevios",
//        contentType: "application/json; charset=utf-8",
//        datatype: "json",
//        data: data,
//        success: function (arg) {

//            var objeto = arg.d;

//            var htmlTabla = objeto;

//            var htmlTabla = htmlTabla;

//            $("#tablaInformesPrevios").children("table").remove();
//            $("#tablaInformesPrevios").append(htmlTabla);

//            cargarInforme(urlInforme, identificador);
//        },
//        error: function () {

//        }
//    });

//    CargaDatosInactivo();
//}

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

function guardarPlantilla(cod_examen) {

    var tecnica = $("#txtTecnica").val();
    var hallazgos = $("#txtHallazgos").val();
    var impresion = $("#txtImpresion").val();
    var titulo = $("#txtTitulo").val();
    var nombre_plantilla = $("#txtNombrePlantilla").val();

    var data = '{tecnica:"' + tecnica + '", hallazgos:"' + hallazgos + '", nombre_plantilla:"' + nombre_plantilla + '", impresion:"' + impresion + '", titulo:"' + titulo + '", cod_examen: "' + cod_examen + '"}';

    $.ajax({
        type: "POST",
        url: "Informar.aspx/guardarPlantilla",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            $("#txtNombrePlantilla").val("");
        },
        error: function () {

        }
    });
}


$(document).ready(function () {
    validarVocali();
    actualizarBloqueoExamen();
    
    var data = '{ codExamen :"' + $("#hddCod").val() + '"}';
    

    $.ajax({
        type: "POST",
        url: "Informar.aspx/ObtenerDatos",
        contentType: "application/json; charset=utf-8",
        data: data,
        datatype: "json",
        async: false,
        success: function (arg) {
            var objeto = arg.d;
            console.log(objeto);
            ObtenerEstudiosRelacionados(objeto[0].codexamen, objeto[0].id_institucion);
        },
        error: function () {


        }
    });

    CargaDatosInactivo();
});


function VerInformes() {

    if (idPacienteInforme == '') {
        return;
    }
    window.open(urlInforme + idPacienteInforme + ' &idInstitucion=' + idInstitucionAddendumInforme + '&codExamen=' + codExamenAddendumInforme, '_blank')
}

/*
 Inicio Seccion de manejo de opciones de informe patologia grave
*/

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

/*
Fin Seccion de manejo de opciones de informe patologia grave
*/





/* new vocali*/
function Control1Vocali() {
    const editorInstance = document.getElementById('txtTitulo');
    ChangeFocusToTextArea(editorInstance);
}

function Control2Vocali() {
    const editorInstance = document.getElementById('txtTecnica');
    ChangeFocusToTextArea(editorInstance);
}

function Control3Vocali() {
    const editorInstance = document.getElementById('txtAntecedentesClinicos');
    ChangeFocusToTextArea(editorInstance);
}

function Control4Vocali() {
    const editorInstance = document.getElementById('txtHallagos');
    ChangeFocusToTextArea(editorInstance);
}

function Control5Vocali() {
    const editorInstance = document.getElementById('txtImpresion');
    ChangeFocusToTextArea(editorInstance);
}


function CargarPlantillaSelected(value) {
    alert(value);
}

function GetInforme(cargaInicial) {

    var data = '{codExamen:"' + $("#hddCod").val() + '", idInstitucion:' + $("#hddInstitucion").val() + ', idInforme:' + $("#hddIdInforme").val() +'}';
   
    $.ajax({
        type: "POST",
        url: "Informar.aspx/GetInforme",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {
            var informe = data.d.Data;
            if (data.d.Ejecutado) {
                invoxCKEditor.editor.setData(informe.Titulo);
                invoxCKEditor2.editor.setData(informe.Tecnica);
                invoxCKEditor3.editor.setData(informe.AntecedentesClinicos);
                invoxCKEditor4.editor.setData(informe.Hallazgos);
                invoxCKEditor5.editor.setData(informe.Impresion);

                if (informe.SeleccionPatologiaCritica == 1) {
                    SelectedCriticaSi();
                    $("#ddlSeleccionePatologia").val(informe.IdPatologiaCritica);
                }
                else {
                    SelectedCriticaNo();
                }
               
                if (informe.Estado != 2 && !cargaInicial && informe.Estado != 1 ) {
                    $('#bBack').trigger('click');
                }                  
            }

            CargarTagsUsuario();
            CargarTagsExamen();
        }
    });
}

function Validar() {

    if (!ValidarCamposInforme(true))
        return;

    var objInforme = new Object();
    objInforme.Titulo = invoxCKEditor.editor.getData();
    objInforme.AntecedentesClinicos = invoxCKEditor3.editor.getData();;
    objInforme.Hallazgos = invoxCKEditor4.editor.getData();
    objInforme.Impresion = invoxCKEditor5.editor.getData();
    objInforme.Tecnica = invoxCKEditor2.editor.getData();
    objInforme.SeleccionPatologiaCritica = selectedPatologiaCritica;
    objInforme.IdPatologiaCritica = $("#ddlSeleccionePatologia").val() == null ? 0 : $("#ddlSeleccionePatologia").val();
    objInforme.PatologiaCritica = $("#ddlSeleccionePatologia").text();
    objInforme.IdTags = GetTagsSelected();
    objInforme.CodExamen = $("#hddCod").val();
    objInforme.IdInforme = $("#hddIdInforme").val();
    objInforme.IdInstitucion = $("#hddInstitucion").val();
    objInforme.IdPrestaciones = $("#hddIdPrestacion").val();
   
    $.ajax({
        type: "POST",
        url: "Informar.aspx/ValidarInforme",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ informe: objInforme }),
        datatype: "json",
        success: function (data) {

            if (data.d.Data.Result > 2) {
                window.location.href = "ListaExamen.aspx";
            } else {
                GetInforme(false);
                ModalInformacion(data.d.Mensaje);
            }
        }
    });
}

function Informar(validar) {

    if (!ValidarCamposInforme(validar)) return;

    var objInforme = new Object();
    objInforme.Titulo = invoxCKEditor.editor.getData();
    objInforme.AntecedentesClinicos = invoxCKEditor3.editor.getData();;
    objInforme.Hallazgos = invoxCKEditor4.editor.getData();
    objInforme.Impresion = invoxCKEditor5.editor.getData();
    objInforme.Tecnica = invoxCKEditor2.editor.getData();
    objInforme.SeleccionPatologiaCritica = selectedPatologiaCritica;
    objInforme.IdPatologiaCritica = $("#ddlSeleccionePatologia").val() == null ? 0 : $("#ddlSeleccionePatologia").val();
    objInforme.PatologiaCritica = $("#ddlSeleccionePatologia").text();
    objInforme.IdTags = GetTagsSelected();
    objInforme.CodExamen = $("#hddCod").val();
    objInforme.IdInforme = $("#hddIdInforme").val();
    objInforme.IdInstitucion = $("#hddInstitucion").val();
    objInforme.IdPrestaciones = $("#hddIdPrestacion").val();

    $.ajax({ 
        type: "POST",
        url: "Informar.aspx/InformarInforme",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ informe: objInforme }),
        datatype: "json",
        success: function (data) {

            if (data.d.Data > 2) {
                GetInforme(false);
            }

            $('#btnPendiente').attr('style', 'visibility: hidden; width: 130px !important;');

            ModalInformacion(data.d.Mensaje);
        }
    });
}

function VerInforme(idInforme, aetitle) {
    var url = 'https://riscloud.clinicatarapaca.cl/Web/Examen/VerInforme.aspx?idinforme=' + idInforme + '&aetitle=' + aetitle;
    window.open(url, "_blank");
}

function ValidarCamposInforme(valida) {
    debugger;
    if (valida == false)
        return true;

    var titulo = invoxCKEditor.editor.getData();
    var patologia = $("#ddlSeleccionePatologia").val();

    if (titulo == '') {
        ModalInformacion('Titulo del informe es obligatorio.');
        return false;
    }

    if (selectedPatologiaCritica == 1 && patologia == 0) {
        ModalInformacion('Debe Seleccionar una Patología Crítica.');
        return false;
    }

    if (selectedPatologiaCritica == -2) {
        ModalInformacion('Debe Seleccionar opcion si informes corresponde a patologia critica.');
        return false;
    }

    if (selectedPatologiaCritica == 1 && $("#ddlSeleccionePatologia").val() == -1) {
        ModalInformacion('Institucion no posee patologias configuradas, no puede selecionar patologia critica para este informe');
        return false;
    }

    return true;
}

/* fin funciones Informar */


/* funciones Patologias Criticas */

function CargarControlPatologias() {

    var data = '{idInstitucion:' + $("#hddInstitucion").val() + '}';

    $.ajax({
        type: "POST",
        url: "Informar.aspx/CargarPatologias",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
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

function ValidarUsuarioBecadoForaneo() {   
    $.ajax({
        type: "GET",
        url: "Informar.aspx/ValidarUsuarioBecado",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
            
            if (data.d.Data) {
                $("#btnInformar").hide();
            }
            else {
                $("#btnInformar").show();
            }
        }
    });
}
/* Auto Guardado Informe */

function CerrarModalAutoGuardarNoDataInforme() {
    $("#modalAutoGuardarNoDataInforme").modal('hide');
}

function CerrarModalAutoGuardarDataInforme() {
    $("#modalAutoGuardarDataInforme").modal('hide');
}

function AbrirModalAutoGuardarInforme() {
    if (EsExamenNuevo() == true && PoseeDataInformar() == true) {
        $("#modalAutoGuardarDataInforme").modal('show');
    }
}

function EsExamenNuevo() {
    var result = false;
    var data = '{ codExamen:"' + $("#hddCod").val() + '"}';
    $.ajax({
        type: "POST",
        url: "Informar.aspx/ExamenNuevo",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {
            result = data.d.Data;
        }
    });
    
    return result;
}

function PoseeDataInformar() {
    
    var titulo = invoxCKEditor.editor.getData();
    var antecedentesClinicos = invoxCKEditor3.editor.getData();;
    var hallazgos = invoxCKEditor4.editor.getData();
    var impresion = invoxCKEditor5.editor.getData();
    var tecnica = invoxCKEditor2.editor.getData();
    selectedPatologiaCritica //-2

    var bandera = 0;

    if (titulo != '')
        bandera = 1;
    if (antecedentesClinicos != '')
        bandera = 1;
    if (hallazgos != '')
        bandera = 1;
    if (impresion != '')
        bandera = 1;
    if (tecnica != '')
        bandera = 1;
    if (selectedPatologiaCritica != -2)
        bandera = 1;

    return bandera == 1 ? true : false;
}


function GuardaProvisorio(swProvisorio) {

    if (swProvisorio) {
        if (!ValidarCamposInforme(true)) return;
    }

    var objInforme = new Object();

    objInforme.Titulo = invoxCKEditor.editor.getData();
    objInforme.AntecedentesClinicos = invoxCKEditor3.editor.getData();
    objInforme.Hallazgos = invoxCKEditor4.editor.getData();
    objInforme.Impresion = invoxCKEditor5.editor.getData();
    objInforme.Tecnica = invoxCKEditor2.editor.getData();
    objInforme.SeleccionPatologiaCritica = selectedPatologiaCritica;
    objInforme.IdPatologiaCritica = $("#ddlSeleccionePatologia").val() == null ? 0 : $("#ddlSeleccionePatologia").val();
    objInforme.PatologiaCritica = $("#ddlSeleccionePatologia").text();
    objInforme.IdTags = GetTagsSelected();
    objInforme.Estado = 1;
    objInforme.CodExamen = $("#hddCod").val();
    objInforme.IdInforme = $("#hddIdInforme").val();
    objInforme.IdInstitucion = $("#hddInstitucion").val();
    objInforme.IdPrestaciones = $("#hddIdPrestacion").val();

    $.ajax({
        type: "POST",
        url: "Informar.aspx/InformarInforme",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ informe: objInforme }),
        datatype: "json",
        success: function (data) {

            if (data.d.Data > 2) {
                GetInforme(false);
            }

            if (swProvisorio) ModalInformacion(data.d.Mensaje);
        }
    });
}

/* Fin Auto Guardado Informe */