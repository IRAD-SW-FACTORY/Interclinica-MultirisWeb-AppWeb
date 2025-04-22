function ChangeCategoria(categoria) {
    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/CargaCategoria",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (arg) {
            var objeto = arg.d.Data;

            categoria.append('<option value="0">Seleccione..</option>');

            $.each(objeto, function (i, item) {
                categoria.append('<option value="' + objeto[i].ID_CATEGORIA + '">' + objeto[i].DESCRIPCION + '</option>');
            })

            categoria.multiselect('refresh');
        },
        error: function (msg) {
            alert("Error:" + msg.responseText);
        },
        failure: function (fail) {
            alert("Error:" + fail);
        }
    });
}

function listMessage(risExamen, content, boton) {
    var data = '{ "risExamen":' + risExamen + '}';

    var thtml = "";

    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/CargaChat",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
            $.each(arg.d.Data.Data, function (i, item) {
                if (item['tipoMensajeId'].toString() == 1) {
                    thtml += '<div class="message message-personal">';
                    thtml += '<figure class="avatar">';
                    thtml += '<img src="../img/pregunta.png" />';
                    thtml += '</figure>';
                    thtml += '<span>' + item['mensaje'].toString() + '</span>';
                    thtml += '<div class="timestamp">' + item['nombreusuario'].toString() + ' ' + item['fechaHoraEnvio'].toString() + '</div>';
                    thtml += '</div>';
                } else {
                    thtml += '<div class="message new">';
                    thtml += '<figure class="avatar"><img src="../img/respuesta.png" /></figure>';
                    thtml += item['mensaje'].toString();
                    thtml += '<div class="timestamp">' + item['nombreusuario'].toString() + ' ' + item['fechaHoraEnvio'].toString() + '</div>';
                    thtml += '</div>'
                }
            })

            content.append(thtml);
        },
        error: function (msg) {
            alert("Error:" + msg.responseText);
        },
        failure: function (fail) {
            alert("Error:" + fail);
        }
    });
}

function listFile(risExamen, content) {
    var data = '{ "risExamen":' + risExamen + '}';

    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/ListaArchivo",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
            var thtml = "";

            $.each(arg.d.Data, function (i, item) {
                var idAsignado = item['id_ris_examen_canal'].toString() + ',' + item['id_archivo'].toString() + ',' + item['usuarioEnvio'].toString();
                var check = item['id_ris_examen_canal'].toString() + '-' + item['id_archivo'].toString();
                var marca = item['usuarioLectura'].toString() != '0' ? '' : 'ajunta-no-visible';

                thtml += '<div class="message message-file">';
                thtml += '<a id="' + idAsignado + '" class="openFile"> <span><img src="../img/archivo_chat.png" style="cursor:pointer" />' + item['nombre'].toString() + '</span></a> ';
                thtml += '<div class="timestamp">' + item['nombreUsuarioEnvio'].toString() + ' ' + item['fechaEnvio'].toString() + ' <img src="../img/doble-verificacion.png" class="' + check + ' ' + marca + '" /> </div>';
                thtml += '</div>';
            })

            content.append(thtml);

            content.on('click', '.openFile', function () {
                var array = $(this).attr('id').split(',');

                descargoFile(array[0], array[1], array[2], $(this).text(), array[0]+'-'+array[1]);
            });
        },
        error: function (msg) {
            alert("Error:" + msg.responseText);
        },
        failure: function (fail) {
            alert("Error:" + fail);
        }
    });
}

function insertMessage(ris, ctg, msg, content, boton, input, usuario, tipo, desCtg) {
    if (ctg == "0") { alert("Debe seleccionar una categoria"); return false; }

    if ($.trim(msg) == "") { alert("No ha ingresado un mensaje"); return false; }

    var thtml = "";
    var thour = new Date();
    var forDate = pad(thour.getDate(), 2) + '/' + pad(thour.getMonth() + 1, 2) + '/' + thour.getFullYear() + ' ' + thour.getHours() + ':' + thour.getMinutes() + ":00.000";

    if (insertMessageSend(ris, ctg, forDate, msg, tipo)) {
        if (tipo == 1) {
            thtml += '<div class="message message-personal">';
            thtml += '<figure class="avatar"><img src="../img/pregunta.png" /></figure>';
            thtml += '<span>' + msg + '</span>';
            SendMail(ris, tipo, msg, desCtg);
        } else {
            thtml += '<div class="message new">';
            thtml += '<figure class="avatar"><img src="../img/respuesta.png" /></figure>';
            thtml += msg;
        }

        thtml += '<div class="timestamp">' + usuario + ' ' + thour.getHours() + ':' + thour.getMinutes() + '</div>';
        thtml += '</div>'

        content.append(thtml);

        boton.removeClass('ajunta-no-visible');
    } else { alert("Ha ocurrido un error al intentar crear el chat"); }

    input.val('');
}

function insertMessageSend(risExamen, categoria, fecha, mensaje, tipo) {
    var result = true;

    var data = '{ "risExamen":"' + risExamen + '", "categoria":' + categoria + ', "fechaCreacion":"' + fecha + '", "mensaje":"' + mensaje + '", "tipo":' + tipo + ' }';

    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/InsertaChat",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
            result = arg.d.Ejecutado;
        },
        error: function (msg) {
            alert("Error:" + msg.responseText);
            result = false;
        },
        failure: function (fail) {
            alert("Error:" + fail);
            result = false;
        }
    });

    return result;
}

function adjuntoFile(risExamen, filename, file, usuario, content) {
    var thtml = "";
    var thour = new Date();
    var formData = new FormData();
    var maxSizeMB = 3;
    var maxSizeBytes = maxSizeMB * 1024 * 1024;
    var allowedExtensions = /(\.png|\.jpg|\.pdf|\.doc)$/i;

    if (file.size > maxSizeBytes) {
        alert("El tamaño del archivo supera el límite de " + 3 + " MB.");
        return false;
    }

    if (!allowedExtensions.exec(file.name)) {
        alert("Solo se permiten archivos con extensión .png, .jpg, .pdf, .doc");
        return false;
    }

    formData.append("risExamen", risExamen);
    formData.append("filename", filename);
    formData.append("file", file);

    $.ajax({
        url: "../Examen/informar.aspx",
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.toString().indexOf("200") >= 0) {
                thtml += '<div class="message message-file">';
                thtml += '<span><img src="../img/archivo_chat.png" />' + filename + '</span>';
                thtml += '<div class="timestamp">' + usuario + ' ' + thour.getHours() + ':' + thour.getMinutes() + '</div>';
                thtml += '</div>';
                content.append(thtml);
            } else alert(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(thrownError);
            console.log(xhr.responseText);
        }
    });
}

function descargoFile(risExamen, fileId, userId, fileName, img) {
    $.ajax({
        url: "../Examen/informar.aspx/DescargaArchivo",
        type: 'POST',
        data: JSON.stringify({
            risExamen: risExamen,
            fileId: fileId,
            userCreate: userId,
            fileName: fileName
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response.d.Ejecutado) {
                var sw = response.d.Mensaje;

                if (sw == '200') $("img."+img+".ajunta-no-visible").removeClass("ajunta-no-visible");

                if (response.d.Data) {  // Asegúrate de que response.d no esté vacío
                    let byteCharacters = atob(response.d.Data);  // Convierte los datos de base64 a binario
                    let byteNumbers = new Array(byteCharacters.length);
                    for (let i = 0; i < byteCharacters.length; i++) {
                        byteNumbers[i] = byteCharacters.charCodeAt(i);
                    }
                    let byteArray = new Uint8Array(byteNumbers);
                    let blob = new Blob([byteArray], { type: 'application/octet-stream' });
                    let link = document.createElement('a');
                    link.href = window.URL.createObjectURL(blob);
                    link.download = fileName;  // Usa el nombre del archivo recibido
                    link.click();
                } else {
                    console.log("No se recibieron datos para descargar.");
                }

            } else alert('ERROR: problemas al tratar de descargar archivo');
        },
        error: function (xhr, status, error) {
            console.log("Error en la descarga:", error);
        }
    });
}

function CompruebaExistenciaCanal(risExamen) {
    var result;

    var data = '{ "risExamen":"' + risExamen + '"}';

    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/VerificaCanal",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
            if (arg.d.Ejecutado) {
                result = arg.d.Data;
            }
        },
        error: function (msg) {
            alert("Error:" + msg.responseText);
        },
        failure: function (fail) {
            alert("Error:" + fail);
        }
    });

    return result;
}

function enabledClose(perfil, close) {
    if (perfil.val() == 1 || perfil.val() == "1") close.removeClass('no-visible');
}

function pad(str, max) {
    str = str.toString();
    return str.length < max ? pad("0" + str, max) : str;
}

function closeNotifyPending(risExamen) {
    var data = '{ "risExamen":"' + risExamen + '"}';

    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/CierraPendiente",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
            if (arg.d.Ejecutado) {
                alert('Cerrado correctamente');
            } else {
                alert(arg.d.Mensaje);
            }
        },
        error: function (msg) {
            alert("Error:" + msg.responseText);
        },
        failure: function (fail) {
            alert("Error:" + fail);
        }
    });
}

function SendMail(risExamen, tipo, msg, ctg) {
    var data = '{ "risExamen":"' + risExamen + '", "tipo":' + tipo + ', "msg":"' + msg + '", "ctg":"' + ctg + '" }';

    $.ajax({
        type: "POST",
        url: "../Examen/informar.aspx/SendMail",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: true,
        success: function (arg) {},
        error: function (msg) {},
        failure: function (fail) { }
    });
}

