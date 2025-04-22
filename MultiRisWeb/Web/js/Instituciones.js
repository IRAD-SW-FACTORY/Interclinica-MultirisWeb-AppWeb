function cargarInstitucion(id_institucion) {
    var data = '{id_institucion:' + id_institucion + '}';



    $("#txtNombreInstitucion").val('');
    $("#txtdescripcionr").val('');
    $("#txtUrlPagina").val('');
    $("#txtUrlDescarga").val('');
    $("#txtUrlInforme").val('');
    $("#txtUrlBase").val('');
    $("#txtAetitle").val('');

    $("#txtUrlWSInstitucion").val('');


    $("#txtInstitucionPadre").val('');
    $("#txtEstruturaHTML").val('');
    $("#txtLogo").val('');
    $("#txtMargenSuperior").val('');
    $("#txtMargenInferior").val('');
    $("#txtMargenIzquierda").val('');
    $("#txtMargenDerecha").val('');

    $("#txtCodigoQA").val('');
    $("#txtTipoBecado").val('');
    $("#txtGrupo").val('');
    $("#txtCorreoPatologia").val('');
    $("#txtCorreoPatologiaCC").val('');


    document.getElementById('rbtnEstado1').checked = true;
    document.getElementById('rbApiRest').checked = true;
    document.getElementById('rbSiAddendum').checked = true;
    document.getElementById('rbFormularioSi').checked = true;


    $.ajax({
        type: "POST",
        url: "Instituciones.aspx/cargarInstitucion",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {
            var objeto = arg.d;

            for (var i = 0; i < objeto.length; i++) {

                $("#txtNombreInstitucion").val(objeto[i].nombre);
                $("#txtdescripcion").val(objeto[i].descripcion);

                if (objeto[i].estado == '1') {
                    document.getElementById('rbtnEstado1').checked = true;
                }
                else {
                    document.getElementById('rbtnEstado0').checked = true;
                }

                if (objeto[i].id_tipo_conexion == '1') {
                    document.getElementById('rbApiRest').checked = true;
                }
                else {
                    document.getElementById('rbWebServices').checked = true;
                }

                if (objeto[i].addendum == '1') {
                    document.getElementById('rbSiAddendum').checked = true;
                }
                else {
                    document.getElementById('rbNoAddendum').checked = true;
                }

                if (objeto[i].formulario_unico == '1') {
                    document.getElementById('rbFormularioSi').checked = true;
                }
                else {
                    document.getElementById('rbFormularioNo').checked = true;
                }

                $("#txtAetitle").val(objeto[i].aetitle);
                

                $("#txtUrlPagina").val(objeto[i].urlPagina);
                $("#txtUrlDescarga").val(objeto[i].urlDescarga);
                $("#txtUrlInforme").val(objeto[i].urlInforme);
                $("#txtURLBase").val(objeto[i].urlBase);
                $("#txtUrlWSInstitucion").val(objeto[i].url_wsInstitucion);

                
                $("#txtInstitucionPadre").val(objeto[i].id_institucion_padre);
                $("#txtEstruturaHTML").val(objeto[i].estrutura);
                $("#txtLogo").val(objeto[i].logo);
                $("#txtMargenSuperior").val(objeto[i].margen_superior);
                $("#txtMargenInferior").val(objeto[i].margen_inferior);
                $("#txtMargenIzquierda").val(objeto[i].margen_izquierda);
                $("#txtMargenDerecha").val(objeto[i].margen_derecha);

                $("#txtCodigoQA").val(objeto[i].codigo_qr);
                $("#txtTipoBecado").val(objeto[i].id_tipo_becado);
                $("#txtGrupo").val(objeto[i].id_grupo);
                $("#txtCorreoPatologia").val(objeto[i].correo_patologia_critica);
                $("#txtCorreoPatologiaCC").val(objeto[i].correo_cc_patologia_critica);

                //$("#btnGuardarAgregar").attr("onclick", "crearInstitucion(" + id_institucion + "); return false;");
                //$("#btnGuardarModificar").attr("onclick", "guardarInstitucion(" + id_institucion + "); return false;");

                $("#btnGuardar").attr("onclick", "guardarInstitucion(" + id_institucion  + "); return false;");

            }
        },
        error: function () {

        }
    });
}

function nuevaInstitucion() {

    $('#modalAgregarInstitucion').modal('show');

    $("#txtNombreInstitucion").val('');
    $("#txtdescripcionr").val('');
    $("#txtUrlPagina").val('');
    $("#txtUrlDescarga").val('');
    $("#txtUrlInforme").val('');
    $("#txtUrlBase").val('');
    $("#txtAetitle").val('');

    $("#txtUrlWSInstitucion").val('');


    $("#txtInstitucionPadre").val('');
    $("#txtEstruturaHTML").val('');
    $("#txtLogo").val('');
    $("#txtMargenSuperior").val('');
    $("#txtMargenInferior").val('');
    $("#txtMargenIzquierda").val('');
    $("#txtMargenDerecha").val('');

    $("#txtCodigoQA").val('');
    $("#txtTipoBecado").val('');
    $("#txtGrupo").val('');
    $("#txtCorreoPatologia").val('');
    $("#txtCorreoPatologiaCC").val('');


    document.getElementById('rbtnEstado1').checked = true;
    document.getElementById('rbApiRest').checked = true;
    document.getElementById('rbSiAddendum').checked = true;
    document.getElementById('rbFormularioSi').checked = true;

    //$("#btnGuardar").attr("onclick", "guardarInstitucion(0); return false;");

    $("#btnGuardar").attr("onclick", "guardarInstitucion(0); return false;");
}

function guardarInstitucion(id_institucion) {

    var valorHTML = $("#txtEstruturaHTML").val().replaceAll(String.fromCharCode(34), "'");

    var data = '{id_institucion:' + id_institucion
        + ', nombre:"' + $("#txtNombreInstitucion").val()
        + '", descripcion:"' + $("#txtdescripcion").val()
        + '", estado:' + $('input:radio[name=estado]:checked').val()
        + ', url_pagina:"' + $("#txtUrlPagina").val()
        + '", aetitle:"' + $("#txtAetitle").val()
        + '", url_descarga:"' + $("#txtUrlDescarga").val()
        + '", url_informe:"' + $("#txtUrlInforme").val()
        + '", url_base:"' + $("#txtUrlBase").val()
        + '", id_tipo_conexion:' + $('input:radio[name=RadioGroup2]:checked').val()
        + ', addendum:' + $('input:radio[name=RadioGroup3]:checked').val()
        + ', formulario_unico:' + $('input:radio[name=RadioGroup4]:checked').val()
        + ', contingencia:' + 0
        + ', url_informe_oit: "' + $("#txtUrlInformeOIT").val()
        + '", id_institucion_padre: ' + $("#txtInstitucionPadre").val()
        + ', logo: "' + $("#txtLogo").val()
        + '", estrutura: "' + valorHTML
        + '", margen_superior: ' + $("#txtMargenSuperior").val()
        + ', margen_inferior: ' + $("#txtMargenInferior").val()
        + ', margen_izquierda: ' + $("#txtMargenIzquierda").val()
        + ', margen_derecha: ' + $("#txtMargenDerecha").val()
        + ', codigo_qr: "' + $("#txtCodigoQA").val()
        + '", id_tipo_becado: ' + $("#txtTipoBecado").val()
        + ', id_grupo: ' + $("#txtGrupo").val()
        + ', correo_patologia_critica: "' + $("#txtCorreoPatologia").val()
        + '", correo_patologia_criticaCC: "' + $("#txtCorreoPatologiaCC").val()
        + '", url_wsInstitucion:"' + $("#txtUrlWSInstitucion").val()
        + '"}';

    $.ajax({
        type: "POST",
        url: "Instituciones.aspx/guardarInstitucion",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        success: function (arg) {

            var objeto = arg.d;
            var aplicado = objeto;

            if (aplicado == -2) {
                alert('Debe Ingresar los datos minimos para crear la Institución.');
            }
            else if (aplicado == -1) {
                alert('La Institución ya fue creado con ese Aetitle.');
            }
            else {
                if (id_institucion == 0)
                    alert('La Institución fue creada existosamente.');
                else
                    alert('La Institución fue modificada existosamente.');

                location.href = "Instituciones.aspx";
            }

            
        },
        error: function () {

        }
    });

}