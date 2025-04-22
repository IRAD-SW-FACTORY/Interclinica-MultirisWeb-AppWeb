$(document).ready(function () {
    validarVocali();
}); 

function validarVocali() {
    $.ajax({
        type: "POST",
        url: "EditarPlantilla.aspx/obtenerCredenciales",
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
                        var editors = [{ id: 'txtTecnica', config: configTecnica }, { id: 'txtTitulo', config: configTitulo }, { id: 'txtImpresion', config: configImpresion }, { id: 'txtHallazgos', config: configHallazgos }, { id: 'txtAntecedentesClinicos', config: configAntecedentes }];

                        INVOX.Internal(editors, myUser, myPassword, myHostServer, myPort, useAgent);
                    }
                }
            }
        },
        error: function () {

        }
    });
}