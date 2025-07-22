<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="ListaExamen.aspx.cs" Inherits="MultiRisWeb.Web.Examen.ListaExamen" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />

    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/ListaExamen.js"></script>
    <script src="../js/PrestacionExamen.js?v2"></script>
   
    <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link href="../css/jquery-ui.css" rel="stylesheet">
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
    <link href="../css/DataTables/datatables.min.css" rel="stylesheet">
    <link href="../css/tooltipster/tooltipster.bundle.min.css" rel="stylesheet" />
	
    <link href="../css/normalize/5.0.0/normalize.min.css" rel="stylesheet" />
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans' />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.min.css' />

    <link href="../css/chatIrad.css" rel="stylesheet" />

    <script src='https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.concat.min.js'></script>
    <script src="../js/chatIrad.js"></script>

    <script type="text/javascript" src="../js/notify.js" charset="UTF-8"></script>

    <style>
        .dataTables_scrollBody {
            min-height: 250px !important;
        }

        .oculta_btn {
            visibility: hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <scrip t src="../js/multiselect/jquery.multiselect.es.js"></scrip>
    <script src="../js/multiselect/jquery.multiselect.filter.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.min.js"></script>
    <script src="../js/multiselect/jquery.multiselect.min.js"></script>
    <script src="../js/DataTables/datatables.min.js"></script>
    <script src="../Complementos/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.27.0/moment.min.js"></script>
    <script type="text/javascript" src="../js/tooltipster/tooltipster.bundle.min.js"></script>

	<script src='https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.concat.min.js'></script>
    
    <script src="../js/chatIrad.js"></script>

    <script>
        $(document).ready(function () {
            var perfil = $("#hddPerfil").val();
            var user = $("#hddUser").val();
            var visualiza = $("#hddVisualiza").val();
            var name = $("#hddName").val();
            var vPeriodo = "";
            var cantidad = 30;
            var totalR = "";
            var paginas = 0;
            var vAsync = true;
            var swSaveAs = false;
            var diasFiltro = 0;

            if (perfil == 4 || perfil == 8) {
                $("#divAsigEliminar").css('display', 'none');
            }

            var inactivityTime = 30;
            var redirectUrl = '../../Default.aspx';

            var arrayPrestacion;

            $('#mAdjunto').modal('hide');

            function redirectUser() {
                clearTimeout(timer);
                $('#modalSessionCaducada').modal('show');
            }

            function resetTimer() {
                clearTimeout(timer);
                timer = setTimeout(redirectUser, inactivityTime * 60000);
            }

            document.addEventListener('mousemove', resetTimer);
            document.addEventListener('keypress', resetTimer);

            var timer = setTimeout(redirectUser, inactivityTime * 60000);

            $('#modalCargando').modal('hide');

            $('#hddPageInfo').val(1);
            $('#hddTotalRegister').val(0);
            $('#swPagina').val('');
            $('#rowComentario').val('');

            $('#vNombreUsuario').text($('#usuarioNombre').val());
            $('#vPerfilNombre').text($('#perfilNombre').val());

            if ($("#returnPage").val() == '1') vAsync = false;

            $.ajaxSetup({ cache: false });

            $("#hddfilter").val('0');

            if (perfil == 1) $("#divPrestacionesMantenedor").css("display", "inline");

            $('#bSession').on('click', function () {
                window.location.href = redirectUrl;
            });

            enabledClose($('#hddPerfil'), $('.close-chat'));

            $("#Categoria").multiselect({
                multiple: false,
                selectedList: 1,
                minWidth: 80,
                noneSelectedText: '&nbsp;&nbsp;Seleccione..',
                header: false,
                height: 'auto',
                width: 200,
            });

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

            var data = '{ "usuario":"' + user.toString() + '"}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/CargaInstitucion",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: data,
                async: vAsync,
                success: function (arg) {
                    var objeto = jQuery.parseJSON(arg.d);
                    var objInst = jQuery.parseJSON(objeto.JData)

                    $.each(objInst, function (i, item) {
                        $('#Institucion').append('<option value="' + objInst[i].id_institucion + '">' + objInst[i].nombre + '</option>');
                    })

                    $('#Institucion').multiselect('refresh');
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

            $("#FechaHasta").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", new Date());

            $("#FechaHasta").datepicker('refresh');

            $.each(["1D", "3D", "1S", "1M", "6M"], function (index, value) {
                var boton = $('<button/>', {
                    'type': 'button',
                    'class': 'btn btn-primary btn-day',
                    'id': 'btn-' + value + '',
                    'html': '<b>' + value + '</b>'
                });

                $('#divPeriodos').append(boton.prop('outerHTML'));
            });

            $('.btn-nodetype button').click(function () {
                var indice = 0;
                vPeriodo = this.id.split("-")[1];
                var dias = [1, 3, 7, 30, 183];

                $.each(["1D", "3D", "1S", "1M", "6M"], function (index, value) {
                    $("#btn-" + value).removeClass("css-btn-on");
                    $("#btn-" + value).addClass("css-btn-off");

                    if (value == vPeriodo) indice = index;
                });

                var IDate = new Date();

                var output1 = ((IDate.getDate() < 10 ? '0' : '') + IDate.getDate() + '/' +
                    (IDate.getMonth() < 10 ? '0' : '') + (IDate.getMonth() + 1) + '/' +
                    IDate.getFullYear()).toString();

                $("#" + this.id).removeClass("css-btn-off");
                $("#" + this.id).addClass("css-btn-on");

                $("#FechaHasta").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", output1);
                $("#FechaHasta").datepicker('refresh');

                $("#FechaDesde").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", calcular($('#FechaHasta').val(), 'resta', dias[indice]));

                $("#FechaDesde").datepicker('refresh');

                $("#bBuscar").trigger("click");
            });

            function calcular(fecha, operacion, dias) {
                var date = fecha.split("/"),
                    hoy = new Date(date[2], date[1], date[0]),
                    dias = parseInt(dias),
                    calculado = new Date(),
                    dateResul = operacion == "sumar" ? hoy.getDate() + dias : hoy.getDate() - dias;
                calculado.setDate(dateResul);

                return calculado.getDate() + "/" + (calculado.getMonth() + 1) + "/" + calculado.getFullYear();
            }

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

            var dataM = '{estado:1}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/CargaModalidad",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataM,
                async: vAsync,
                success: function (arg) {
                    var objeto = jQuery.parseJSON(arg.d);
                    var objMod = jQuery.parseJSON(objeto.JData)

                    $.each(objMod, function (i, item) {
                        $('#Modalidad').append('<option value="' + objMod[i].id_modalidad + '">' + objMod[i].nombre + '</option>');
                    })

                    $('#Modalidad').multiselect('refresh');
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

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

            var dataA = '{estado:1}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/CargaAtencion",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataA,
                async: vAsync,
                success: function (arg) {
                    var objeto = jQuery.parseJSON(arg.d);
                    var objMod = jQuery.parseJSON(objeto.JData)

                    $.each(objMod, function (i, item) {
                        $('#Atencion').append('<option value="' + objMod[i].id_tipo_urgencia + '">' + objMod[i].nombre_corto + '-' + objMod[i].nombre + '</option>');
                    })

                    $('#Atencion').multiselect('refresh');
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

            $("#Medico").multiselect({
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

            var dataP = '{visualiza:"' + visualiza + '", userId:"' + user + '", perfil:' + perfil + ', username:"' + name + '"}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/CargaMedico",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataP,
                async: vAsync,
                success: function (arg) {
                    var objMod = arg.d.Data;

                    if (arg.d.Data.Ejecutado)
                        $.each(arg.d.Data.Data, function (i, item) {
                            $('#Medico').append('<option value="' + arg.d.Data.Data[i].id_usuario + '">' + arg.d.Data.Data[i].nombre_completo + '</option>');
                        })

                    $('#Medico').multiselect('refresh');
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

            $("#Pendiente").multiselect({
                multiple: false,
                selectedList: 1,
                minWidth: 80,
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                header: false,
                height: 'auto',
                width: 200,
            });

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/CargaEstadoPendiente",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: vAsync,
                success: function (arg) {
                    if (arg.d.Data.Ejecutado) {
                        $('#Pendiente').append('<option value="-1" selected>TODOS</option>');

                        $.each(arg.d.Data.Data, function (i, item) {
                            $('#Pendiente').append('<option value="' + item["id"].toString() + '">' + item["descripcion"].toString() + '</option>');
                        })
                    }

                    $('#Pendiente').multiselect('refresh');
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

            $("#Estado").multiselect({
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
                url: "../Examen/ListaExamen.aspx/CargaEstado",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: vAsync,
                success: function (arg) {
                    var objMod = arg.d.Data;

                    var objeto = jQuery.parseJSON(arg.d);
                    var objMod = jQuery.parseJSON(objeto.JData)

                    $.each(objMod, function (i, item) {
                        $('#Estado').append('<option value="' + objMod[i].id_estado_examen + '">' + objMod[i].nombre + '</option>');
                    })

                    $('#Estado').multiselect('refresh');
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

            $.each(["TODOS", "Menor 18 años", "Mayor 18 años"], function (index, value) {
                var vSel = "";

                if (index == 0) vSel = 'selected';

                $('#Edad').append('<option style="text-align: center; font-weight: bold;" value="' + index + '"' + vSel + '> ' + value + '</option>');
            });

            $("#filtros").multiselect({
                selectedList: 1,
                minWidth: 300,
                header: false,
                height: 'auto',
                width: 300
            });

            var dataF = '{user:"' + user + '"}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/CargaFiltros",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataF,
                async: true,
                success: function (arg) {
                    if (arg.d.Data.Ejecutado) {
                        var vSel = '<option value="0" >&nbsp;Ninguno</option>';

                        $.each(arg.d.Data.Data, function (i, item) {

                            var prefijo = item.tipo_filtro != '' ? item.tipo_filtro.substring(0, 1) + ' - ' : '';


                            if ($("#selFiltroReturn").val() == item.id_filtro.toString())
                                $('#sel-filtro').append('<option value="' + item.id_filtro + '" style="font-weight: bold;" selected >&nbsp;' + prefijo + item.nombre + '</option>');
                            else
                                $('#sel-filtro').append('<option value="' + item.id_filtro + '" style="font-weight: bold;">&nbsp;' + prefijo + item.nombre + '</option>');
                        })
                    }
                },
                error: function (msg) {
                    alert("Error:" + msg.responseText);
                },
                failure: function (fail) {
                    alert("Error:" + fail);
                }
            });

            initTable();

            $('#gData_length').addClass('col-12');

            $('#gData_Length').remove();

            var i = 1;

            $(".fg-toolbar").each(function () {
                if (i == 2) { $(this).addClass('div-' + i); $(this).hide() }

                i++;
            });

            $.each(["10", "20", "30", "40", "50", "60", "70"], function (index, value) {
                var vSel = "";

                if (index == 2) vSel = 'selected';

                $('#Cantidad').append('<option style="text-align: center; font-weight: bold;" value="' + value + '"' + vSel + '> ' + value + '</option>');
            });

            $('#gData').on('dblclick', 'tr', function () {
                $('#risExamen').val('');

                var table = new DataTable('#gData');
                $('#rowId').val(table.row(this).index());

                if (table.rows().count()) {
                    var numacceso = $(this).find("td:eq(4)").text();
                    var risexamen = $(this).find("td:eq(0)").find('b').attr('id').split('-')[1];
                    var risbloqueo = $(this).find("td:eq(3)").find('b').attr('id').split('-')[1];

                    if (risexamen != "") {
                        $('#modalCargando').modal('hide');
                        $("#dvInformarResumidoError").hide();
                        $("#dvInformarResumidoResultado").hide();
                        $("#dvInformarResumidoCargando").hide();
                        $("#tablaImagenes").children("div").remove();

                        $('#messRsmCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messRsmTxt').text('Espere mientras se cargan los datos');

                        $("#modalInformarResumido").modal('show');

                        saveSession();

                        var data = '{"id_ris_examen":' + $.trim(risexamen) + '}'; //, "numeroacceso":"' + numacceso + '"}';   //, ' + saveSession() + '}';

                        $('#risExamen').val(risexamen);

                        $.ajax({
                            type: "GET",
                            url: "../Examen/ListaExamen.aspx/InformarResumido",
                            contentType: "application/json; charset=utf-8",
                            datatype: "json",
                            data: { "id_ris_examen": $.trim(risexamen).split("-")[0], "numeroacceso": JSON.stringify($.trim(numacceso)) },
                            async: true,
                            beforeSend: function () {
                                $("#tablaInformesResumido").children("table").remove();
                                $("#tablaInformesResumido").children("b").remove();
                                $("#tablaPrestacionesResumido").children("table").remove();
                                $("#tablaImagenes").children("div").remove();
                            },
                            success: function (arg) {
                                var objeto = arg.d;

                                if (objeto[0].estadoExamen != 3 && (perfil == 4 || perfil == 8 || perfil == 2)) {
                                    $("#lblMensajeAlerta").text('- Examen no se encuentra en estado Validado para acceder con su perfil');
                                    $("#modalInformarResumido").modal('hide');
                                    $("#modalMensajeAlerta").modal('show');
                                    return;
                                }


                                $('#messRsmCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");

                                for (var i = 0; i < objeto.length; i++) {

                                    if (objeto[i].urlPrestacion != "" && risbloqueo != '1') {
                                        $('#modalInformarResumido').modal('hide');
                                        $('#modalCargando').modal('show');
                                        document.location.href = objeto[i].urlPrestacion;
                                    } else {
                                        $("#dvInformarResumidoCargando").show();
                                        var htmlTablaInformes = objeto[i].tablaInformes;

                                        $("#tablaInformesResumido").append(htmlTablaInformes);

                                        var htmlTablaPrestaciones = objeto[i].tablaPrestaciones;
                                        $("#tablaPrestacionesResumido").append(htmlTablaPrestaciones);

                                        var htmlTablaImagenes = objeto[i].imagenes;

                                        if (htmlTablaPrestaciones.includes("Sin Prestaciones")) {
                                            var obj = CompruebaExistenciaCanal($('#risExamen').val());

                                            if (obj.id_ris_examen_canal == 0)
                                                $('#bNotificar').removeClass('oculta_btn');
                                            else
                                                $('#bNotificar').addClass('oculta_btn');
                                        } else {
                                            $('#bNotificar').addClass('oculta_btn');
                                        }

                                        $("#tablaImagenes").append(htmlTablaImagenes);
                                    }
                                }

                                $("#dvInformarResumidoError").hide();
                                $("#dvInformarResumidoResultado").show();
                            },
                            error: function (arg) {
                                $('#messRsmCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                                $('#messRsmTxt').text('Error en la carga de datos.');
                            }
                        }).done(function (arg) {
                            $('#messRsmCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                            $('#messRsmTxt').text('');
                        });
                    }
                }
            });

            function preparaData() {
                var oRequest = new Object();
                var oInstitucion = [];
                var oModalidad = [];
                var oMedico = [];
                var oEstado = [];
                var oAtencion = [];

                oRequest.pagina = $('#hddPageInfo').val();
                oRequest.usuario = $('#hddUser').val();
                oRequest.visualiza = $('#hddVisualiza').val();
                oRequest.perfil = $('#hddPerfil').val();
                oRequest.numeroAcceso = $('#NumeroAcceso').val();
                oRequest.paciente = $('#Paciente').val();
                oRequest.nombre = $('#Nombre').val();
                oRequest.rangoEtario = $("#Edad option:selected").val();
                oRequest.fechaDesde = $('#FechaDesde').val();
                oRequest.fechaHasta = $('#FechaHasta').val();
                oRequest.descripcion = $('#Descripcion').val();
                oRequest.periodo = vPeriodo;
                oRequest.cantidad = $('#Cantidad  option:selected').val();
                oRequest.opfiltro = $('#sel-filtro option:selected').val();
                oRequest.pendiente = ($('#Pendiente option:selected').val() == undefined) ? -1 : $('#Pendiente option:selected').val();

                $('#Institucion > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oInstitucion.push(data);
                });

                $('#Modalidad > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oModalidad.push(data);
                });

                $('#Medico > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oMedico.push(data);
                });

                $('#Atencion > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oAtencion.push(data);
                });

                $('#Estado > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oEstado.push(data);
                });

                oRequest.institucion = oInstitucion;
                oRequest.modalidad = oModalidad;
                oRequest.medico = oMedico;
                oRequest.atencion = oAtencion;
                oRequest.estado = oEstado;

                return "{ simpleFilter: " + JSON.stringify(oRequest) + "}";
            }

            function cargaExamenGrilla(oData, table, typeCall) {
                var swTotal = 0;

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/ConsultaExamenes",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: oData,
                    beforeSend: function () {
                        $('#bBuscar').addClass('css-button-disableb');
                        $('#anterior').addClass('css-button-disableb');
                        $('#siguiente').addClass('css-button-disableb');
                        $('#sel-filtro').addClass('css-button-disableb');

                        $('#gData_processing').removeClass('css-loading-off');
                        $('#gData_processing').addClass('css-loading-on');
                        $('.dataTables_empty').attr('style', 'display:none')
                        $('#info span').text('');
                    },
                    async: true,
                    success: function (arg) {
                        $('#gData_processing').removeClass('css-loading-on');
                        $('#gData_processing').addClass('css-loading-off');

                        if (arg.d.Data.Ejecutado) {
                            swTotal = arg.d.Data.Data.length;

                            $.each(arg.d.Data.Data, function (i, item) {
                                table.row.add(
                                    ["",
                                        item['id_ris_examen'].toString(),
                                        item['patologia'].toString(),
                                        item['tipo_patologia'].toString(),
                                        '',
                                        item['instancias'].toString(),
                                        item['addsol'].toString(),
                                        item['bloqueado'].toString(),
                                        item['comentarios'].toString(),
                                        item['acciones'].toString(),
                                        '..!!,' + item['id_ris_examen'].toString() + ',' + item['idInstitucion'].toString(),
                                        item['numeroacceso'].toString(),
                                        item['nombreEstadoExamen'].toString(),
                                        item['institucion'].toString(),
                                        item['nombreTipoUrgencia'].toString(),
                                        item['antecedenteClinico'].toString(),
                                        item['fechaExamen'].toString(),
                                        item['fechaAsignacion'].toString(),
                                        item['fechaCierre'].toString(),
                                        item['fechaValidacion'].toString(),
                                        item['tiempo'].toString(),
                                        item['idpaciente'].toString(),
                                        item['nombreFull'].toString(),
                                        item['edad'].toString(),
                                        item['descripcion'].toString(),
                                        item['modalidad'].toString(),
                                        item['responsables'].toString(),
                                        item['ejecutante'].toString(),
                                        item['tipoConexion'].toString(),
                                        item['metodo'].toString(),
                                        item['urlMetodo'].toString(),
                                        item['swComentario'].toString(),
                                        item['tiempoBloqueo'].toString(),
                                        item['swInstitucion'].toString(),
                                        item['codExamen'].toString(),
                                        item['idEstadoExamen'].toString(),
                                        item['id_estado_pendiente'].toString()
                                    ]).draw(false);
                            });
                        }

                        $('#bBuscar').removeClass('css-button-disableb');
                    },
                    error: function (msg) {
                        $('#gData_processing').removeClass('css-loading-on');
                        $('#gData_processing').addClass('css-loading-off');
                        $('#sel-filtro').removeClass('css-button-disableb');
                        $('#bBuscar').removeClass('css-button-disableb');
                    },
                    failure: function (fail) {
                        $('#gData_processing').removeClass('css-loading-on');
                        $('#gData_processing').addClass('css-loading-off');
                        $('#sel-filtro').removeClass('css-button-disableb');

                        $('#bBuscar').removeClass('css-button-disableb');
                    }
                }).done(function () {
                    $('#gData_paginate a').remove();
                    $('#gData_paginate span').remove();
                    $('#sel-filtro').removeClass('css-button-disableb');

                    if (swTotal > 0) {
                        $('.dataTables_info').text('Calculando totales de la consulta');

                        var page = parseInt($('#hddPageInfo').val());
                        var totalRegistro = parseInt($('#hddTotalRegister').val())
                        var solicitado = $('#Cantidad  option:selected').val();

                        if (typeCall == 2) {
                            page = page - 1;

                            $('#siguiente').removeClass('css-button-disableb');

                            if (page == 1) $('#anterior').addClass('css-button-disableb'); else $('#anterior').removeClass('css-button-disableb');
                        }

                        if (typeCall == 3) {
                            if ((totalRegistro - (page * solicitado)) <= solicitado)
                                $('#siguiente').addClass('css-button-disableb');
                            else
                                $('#siguiente').removeClass('css-button-disableb');

                            $('#anterior').removeClass('css-button-disableb');
                        }

                        if (typeCall != 1) $('.data_info_n').text('Página ' + page + ' con ' + solicitado + ' registro(s) de un total de ' + totalRegistro + ' registros');

                        totalRegister(totalR, typeCall);
                        myComment();
                    } else {
                        $('.data_info_n').text('Sin registros para la consulta');
                    }

                    $('#bBuscar').removeClass('css-button-disableb');
                });
            }

            $("#bBuscar").on("click", function () {
                let fechaDesde = parsearFecha($("#FechaDesde").val()); // Convertir a Date
                let fechaHasta = parsearFecha($("#FechaHasta").val()); // Convertir a Date

                let diferenciaDias = (fechaHasta - fechaDesde) / (1000 * 60 * 60 * 24);

                if (diferenciaDias > 183) {
                    alert("El rango de fechas no debe superar los 6 meses.");
                    return false;
                }

                var table = initTable();

                $('#gData_length').addClass('col-12');

                table.clear().draw();

                totalR = "";

                if ($("#returnPage").val() != '1') {
                    $('#hddPageInfo').val('1');
                    $('#hddTotalRegister').val('0');
                    $('#anterior').addClass('css-button-disableb');
                    $('#siguiente').addClass('css-button-disableb');
                } else $("#returnPage").val('0');

                $('#gData_processing').removeClass('css-loading-off');
                $('#gData_processing').addClass('css-loading-on');
                $('.dataTables_empty').attr('style', 'display:none')
                $('.dataTables_info').text('Calculando totales de la consulta');

                var oData = preparaData();

                totalR = oData;

                cargaExamenGrilla(oData, table, 1)
            });

            $("#bclear").on("click", function () {
                var table = initTable();

                table.clear().draw();

                $('#checkAll').prop('checked', false);

                $('#Institucion > option:selected').prop('selected', false);
                $('#Institucion').multiselect('refresh');

                $('#Modalidad > option:selected').prop('selected', false);
                $('#Modalidad').multiselect('refresh');

                $('#Medico > option:selected').prop('selected', false);
                $('#Medico').multiselect('refresh');

                $('#Atencion > option:selected').prop('selected', false);
                $('#Atencion').multiselect('refresh');

                $('#Estado > option:selected').prop('selected', false);
                $('#Estado').multiselect('refresh');

                $('#Paciente').text('');
                $('#Nombre').text('');
                $('#NumeroAcceso').text('');
                $('#Descripcion').text('');
                $('#hddfilter').val('0');

                $("#sel-filtro option[value=0]").prop("selected", true);

                $.each(["1D", "3D", "1S", "1M", "6M"], function (index, value) {
                    $("#btn-" + value).removeClass("css-btn-on");
                    $("#btn-" + value).addClass("css-btn-off");
                });

                $("#FechaHasta").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", new Date());

                $("#FechaHasta").datepicker('refresh');

                var IDate = new Date();

                IDate.setDate(IDate.getDate() - diasFiltro);

                var output = ((IDate.getDate() < 10 ? '0' : '') + IDate.getDate() + '/' +
                    (IDate.getMonth() < 10 ? '0' : '') + (IDate.getMonth() + 1) + '/' +
                    IDate.getFullYear()).toString();

                $("#FechaDesde").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", output);

                $("#FechaDesde").datepicker('refresh');

                clearPaciente();

                $("#bBuscar").trigger("click");
            });

            $("#creaFiltro").on("click", function () {
                swSaveAs = false;

                if ($('#hddfilter').val() != '0') {
                    $("#filtroNombre").val($("#sel-filtro").find("option:selected").text());
                    $("#filtroNombre").prop("disabled", true);
                    $("#saveAs").removeClass('oculta-columna');
                } else {
                    if ($("#sel-filtro").find("option:selected").val() != '0') $('#hddfilter').val($("#sel-filtro").find("option:selected").val());

                    if ($('#hddfilter').val() != '0') {
                        $("#filtroNombre").val($("#sel-filtro").find("option:selected").text());
                        $("#filtroNombre").prop("disabled", true);
                        $("#saveAs").removeClass('oculta-columna');
                    } else {
                        $("#filtroNombre").val('');
                        $("#filtroNombre").prop("disabled", false);
                        $("#saveAs").addClass('oculta-columna');
                    }
                }
            });

            $("#eliminaFiltro").on("click", function () {
                var user = $('#hddUser').val();
                var listaF = '{usuario:"' + user + '"}'

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/ObtieneMisFiltros",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: listaF,
                    async: true,
                    success: function (arg) {
                        var objeto = arg.d.Data;

                        var tabla = "<table style='width: 100%; text-align: left;'>";

                        if (objeto.Ejecutado) {
                            if (objeto.Data.length > 0) {
                                $.each(arg.d.Data.Data, function (i, item) {
                                    tabla += "<tr class='css-filtro-cut hover-naranjo'><td style='border: 1px solid;height: 30px;'>";
                                    tabla += "<span href='#' title='Filtro: " + item.nombre + "'>&nbsp;&nbsp;" + item.id_filtro + '-' + item.nombre + "</span>";
                                    tabla += "</td><td style='border: 1px solid;height: 30px;'>";
                                    tabla += "<center>&nbsp;<img id='D-" + item.id_filtro + "' src='../icon/eliminar.png' style='width: 17px; height: 17px;' alt='Eliminar " + item.nombre + "' /></center>";
                                    tabla += "</td></tr>";
                                });
                            } else {
                                tabla += "<tr> <td>";
                                tabla += "<b><label>Sin Filtros Creados</label></b>";
                                tabla += "</td> </tr>";
                            }
                        }

                        tabla += "</table>";

                        $("#tablaFiltros").children("table").remove();
                        $("#tablaFiltros").append(tabla);
                    },
                    error: function (msg) {
                        alert("Error:" + msg.responseText);
                    },
                    failure: function (fail) {
                        alert("Error:" + fail);
                    }
                });
            });

            $('#tablaFiltros').on('click', 'img', function () {
                var iFiltro = $(this).attr("id").toString().split("-")[1];
                var eFiltro = '{filtroId:' + iFiltro + ', usuario:"' + $("#hddUser").val() + '"}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/EliminaFiltro",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: eFiltro,
                    async: true,
                    error: function (msg) {
                        alert("Error:" + msg.responseText);
                    },
                    failure: function (fail) {
                        alert("Error:" + fail);
                    }
                }).done(function (arg) {
                    $('#sel-filtro option[value="' + iFiltro + '"]').remove();

                    $("#eliminaFiltro").trigger("click");

                    $("#bclear").trigger("click");
                });

            });

            $("#checkAll").on('click', function () {
                var val = $('#checkAll').is(":checked");

                $("#gData tbody tr").each(function (index) {
                    var ris = $(this).find("td").eq(0).find("b").attr('id').split('-')[1];
                    $("#chk" + ris).prop("checked", val);
                });
            });

            function saveSession() {
                var oRequest = new Object();
                var oRequestComplex = new Object();
                var oInstitucion = [];
                var oModalidad = [];
                var oMedico = [];
                var oEstado = [];
                var oAtencion = [];

                oRequest.pagina = $('#hddPageInfo').val();
                oRequest.usuario = $('#hddUser').val();
                oRequest.visualiza = $('#hddVisualiza').val();
                oRequest.perfil = $('#hddPerfil').val();
                oRequest.numeroAcceso = $('#NumeroAcceso').val();
                oRequest.paciente = $('#Paciente').val();
                oRequest.nombre = $('#Nombre').val();
                oRequest.rangoEtario = $("#Edad option:selected").val();
                oRequest.fechaDesde = $('#FechaDesde').val();
                oRequest.fechaHasta = $('#FechaHasta').val();
                oRequest.descripcion = $('#Descripcion').val();
                oRequest.periodo = vPeriodo;
                oRequest.cantidad = $('#Cantidad  option:selected').val();
                oRequest.opfiltro = $('#sel-filtro option:selected').val();

                $('#Institucion > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oInstitucion.push(data);
                });

                $('#Modalidad > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oModalidad.push(data);
                });

                $('#Medico > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oMedico.push(data);
                });

                $('#Atencion > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oAtencion.push(data);
                });

                $('#Estado > option:selected').each(function () {
                    var data = new Object();

                    data.id = $(this).val();

                    oEstado.push(data);
                });

                oRequest.institucion = oInstitucion;
                oRequest.modalidad = oModalidad;
                oRequest.medico = oMedico;
                oRequest.atencion = oAtencion;
                oRequest.estado = oEstado;

                var dataS = '{ "request":' + JSON.stringify(oRequest) + '}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/SetSession",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: dataS,
                    async: true,
                    success: function (arg) { }
                }).done({
                });
            }

            function myComment() {
                $("#gData tbody tr").each(function (index) {
                    var usuario = $("#hddUser").val();
                    var examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];
                    var codigo = $(this).find("td").eq(4).text();
                    var row = $(this);

                    if (examen != '')
                        methodComment(row, examen, codigo, usuario).then(function () {
                            $('#img' + examen).remove();
                        }).catch(function (error) {
                            $('#img' + examen).remove();
                            console.log("Error:", error);
                        });
                });
            }

            async function methodComment(row, examen, eCodigo, eUsuario) {
                var codExamen = $('#cdE-' + examen).text();
                var numAcceso = eCodigo;
                var tipService = $('#cmm-' + examen).text().split(',')[0];
                var swInstituc = $('#cmm-' + examen).text().split(',')[5];

                if (tipService == '1') {
                    var urlService = $('#cmm-' + examen).text().split(',')[2];
                    var apiMetodo = $('#cmm-' + examen).text().split(',')[1];

                    return new Promise((resolve, reject) => {
                        $.ajax({
                            type: "GET",
                            url: "../Examen/ListaExamen.aspx/AsyncConsultaComentariosAPI",
                            contentType: "application/json; charset=utf-8",
                            data: { 'codExamen': JSON.stringify(codExamen), 'numAcceso': JSON.stringify(numAcceso), 'url': JSON.stringify(urlService), 'metodo': JSON.stringify(apiMetodo), 'institucion': JSON.stringify(swInstituc) },
                            async: true,
                            error: function (xhr, status, error) {
                                $('#img' + examen).remove();

                                console.error("control", xhr);
                            }
                        }).done(function (arg) {
                            var image = '';

                            $('#img' + examen).remove();

                            if (arg.d.Result.Data.Ejecutado) {
                                var marca = 0;

                                if (arg.d.Result.Data.Data.comentario != '0') marca = 1;

                                image += '<span id="oCm' + examen + '" style="display:none">' + marca + '</span>';
                                image += '&nbsp; <span id="I-' + examen + '-' + eCodigo + '"data-toggle="modal" class="comentarioImg">';

                                if (arg.d.Result.Data.Data.comentario != '0') image += '<img src="../img/tieneComentario.png" class="css-col-com" />';

                                image += '</span>'

                                row.find("td").eq(3).append(image);

                                resolve("OK");
                            } else reject("KO");
                        });
                    });
                } else {
                    var idInstitucion = $('#cmm-' + examen).text().split(',')[6];
                    var swComment = $('#cmm-' + examen).text().split(',')[3];

                    if (swComment == '0') {
                        return new Promise((resolve, reject) => {
                            $.ajax({
                                type: "GET",
                                url: "../Examen/ListaExamen.aspx/AsyncConsultaComentariosWS",
                                contentType: "application/json; charset=utf-8",
                                data: { 'codExamen': JSON.stringify(codExamen), 'numAcceso': JSON.stringify(numAcceso), 'institucion': JSON.stringify(idInstitucion) },
                                async: true,
                                error: function (xhr, status, error) {
                                    $('#img' + examen).remove();
                                    console.error("control", xhr);
                                }
                            }).done(function (arg) {
                                var image = '';

                                $('#img' + examen).remove();

                                if (arg.d.Result.Data.Ejecutado) {
                                    var marca = 0;

                                    if (arg.d.Result.Data.Data.comentario != '0') marca = 1;

                                    image += '<span id="oCm' + examen + '" style="display:none">' + marca + '</span>';
                                    image += '&nbsp; <span id="I-' + examen + '-' + eCodigo + '"data-toggle="modal" class="comentarioImg">';

                                    if (arg.d.Result.Data.Data.comentario != '0') image += '<img src="../img/tieneComentario.png" class="css-col-com" />';

                                    image += '</span>'

                                    row.find("td").eq(3).append(image);

                                    resolve("OK");
                                } else reject("KO");
                            });
                        });
                    }
                }
            }

            function totalRegister(dTotal, sw) {
                if (sw == 1)
                    $.ajax({
                        type: "POST",
                        url: "../Examen/ListaExamen.aspx/ConsultaTotalRegistros",
                        contentType: "application/json; charset=utf-8",
                        data: dTotal,
                        async: true,
                        beforeSend: function () {
                            $('.data_info_n').text('Calculado totales de la consulta');
                            $('#loaderFiltro').removeClass('img-hide');
                            $('#loaderFiltro').addClass('img-show');
                        },
                        error: function (msg) {
                            $('#info span').text('');
                            $('#loaderFiltro').removeClass('img-show');
                            $('#loaderFiltro').addClass('img-hide');
                            alert("Error:" + msg.responseText);
                        },
                        failure: function (fail) {
                            $('#info span').text('');
                            $('#loaderFiltro').removeClass('img-show');
                            $('#loaderFiltro').addClass('img-hide');
                            alert("Error:" + fail);
                        }
                    }).done(function (arg) {
                        if (arg.d.Data.Ejecutado) {
                            paginas = arg.d.Data.Data / $('#Cantidad  option:selected').val();

                            if (paginas != 0) {
                                if (paginas > 1) $('#siguiente').removeClass('css-button-disableb');

                                if (parseInt($('#Cantidad  option:selected').val()) <= parseInt(arg.d.Data.Data))
                                    $('.data_info_n').text('Página ' + $('#hddPageInfo').val() + ' con ' + $('#Cantidad  option:selected').val() + ' registro(s) de un total de ' + arg.d.Data.Data + ' registros');
                                else
                                    $('.data_info_n').text('Página ' + $('#hddPageInfo').val() + ' con ' + arg.d.Data.Data + ' registro(s) de un total de ' + arg.d.Data.Data + ' registros');

                            } else {
                                $('..data_info_n').text('Sin registros para la consulta');
                            }

                            $('#hddTotalRegister').val(arg.d.Data.Data);

                            var table = $('#gData').DataTable();
                        } else {
                            alert(arg.d.Data.Mensaje)
                        };

                        $('#loaderFiltro').removeClass('img-show');
                        $('#loaderFiltro').addClass('img-hide');
                    });
            }

            function initTable() {
                var calculo = parseInt($(window).height() * 0.65);

                var cal_width = parseInt($(window).width() * 0.51) - 60;

                $('#gData tbody').attr('style', 'max-height: ' + calculo + 'px !important');

                if ($('#Cantidad  option:selected').val() != undefined) cantidad = $('#Cantidad  option:selected').val();

                return new DataTable('#gData', {
                    searching: false
                    , fixedHeader: true
                    , autoWidth: false
                    , autoheight: true
                    , scrollY: calculo
                    , scrollX: false
                    , scrollCollapse: true
                    , pageLength: cantidad
                    , lengthChange: true
                    , responsive: false
                    , info: false
                    , select: true
                    , processing: true
                    , columnDefs: [
                        { targets: [1], visible: false },
                        { targets: [2], visible: false },
                        { targets: [3], visible: false },
                        { targets: [6], visible: false },
                        { targets: [7], visible: false },
                        { targets: [8], visible: false },
                        { targets: [9], visible: false },
                        { targets: [14], visible: false }
                    ]
                    , columns: [
                        {
                            orderable: false,
                            width: "40px",
                            render: function (data, type, row, meta) {
                                var idperfil = $("#hddPerfil").val();
                                var dropdown = '';
                                var rowI = row[10].split(',')[2];

                                if (row[1] != "") {
                                    dropdown += '<b id="ris-' + row[1] + '"></b>';
                                    dropdown += '<ul class="nav navbar-nav">';
                                    dropdown += '<li class="dropdown">';
                                    dropdown += '<a href="#" class="dropdown-toggle" data-toggle="dropdown">';
                                    dropdown += '<span id="lista" Style="color: Silver; margin-top: 1%; margin-bottom: -10px" CssClass="pagination-ys" Height="1%">';
                                    dropdown += '<img src="../img/menuBar.png" style="width: 15px; cursor: pointer;" /> ';
                                    dropdown += '</span>';
                                    dropdown += '</a>';
                                    dropdown += '<ul class="dropdown-menu" style="width: 250px; background-color: #676C6F !important; border-color: white; color: white; padding: 2px 0 0 0; ">';
                                    dropdown += '<li>';
                                    dropdown += '<a data-toggle="modal" title="Descargar" data-target="#" style= "color:white; font-size: 12px; text-decoration: none !important; " CssClass="nav-link nav-examenes" >';
                                    dropdown += '<img style="width: 12px; margin: -10px 0 -5px 10px" src="../img/circulo.png" />';
                                    dropdown += '<span class="descargar" id="' + row[1] + '-' + row[11] + '" style="margin: -5px 0 -5px 5px ">Descargar Examen</span>';
                                    dropdown += '</a>';
                                    dropdown += '</li>';
                                    if (idperfil != 8) {
                                        dropdown += '<li>';
                                        dropdown += '<a data-toggle="modal" title="Comentarios" data-target="" style="color:white; font-size: 12px; text-decoration: none !important; " href="#" CssClass="form-control-ddl">';
                                        dropdown += '<img style="width: 12px; margin: -10px 0 -5px 10px" src="../img/circulo.png" />';
                                        dropdown += '<span class="comentario css-disabled-span" id="' + row[1] + '-' + row[11] + '"style="margin: -5px 0 -5px 5px">Comentarios</span>';
                                        dropdown += '</a>';
                                        dropdown += '</li>';
                                        dropdown += '<li>';
                                        dropdown += '<a data-toggle="modal" title="Modificacion Titulo - Paciente Informe" style="color: white; font-size: 12px; text-decoration: none!important;" href="#" CssClass="form-control-ddl">';
                                        dropdown += '<img style="width: 12px; margin: -10px 0 -5px 10px" src="../img/circulo.png" />';
                                        dropdown += '<span class="pacienteInf" id="' + row[1] + '" style="margin: -5px 0 -5px 5px">Modificación Titulo - Paciente Informe</span>';
                                        dropdown += '</a>';
                                        dropdown += '</li>';
                                        dropdown += '<li>';
                                        dropdown += '<a data-toggle="modal" title="Mantenedor Prestaciones Examen" style="color:white; font-size: 12px; text-decoration: none !important;" href="#" CssClass="form-control-ddl">';
                                        dropdown += '<img style="width: 12px; margin: -10px 0 -5px 10px" src="../img/circulo.png" />';
                                        dropdown += '<span class="prestacion" id="M-' + row[1] + '-' + rowI + '-' + row[35] + '" style="margin: -5px 0 -5px 5px">Modificación Prestaciones Examen</span>';
                                        dropdown += '</a>';
                                        dropdown += '</li>';
                                    }
                                    if (row[12] == "Validado") {
                                        dropdown += '<li>';
                                        dropdown += '<a data-toggle="modal" title="Solicitar Addemdum" data-target="#modalSolicitudAddemdum" style="color:white; font-size: 12px; text-decoration: none !important;" href="#" CssClass="form-control-ddl">';
                                        dropdown += '<img style="width: 12px; margin: -10px 0 -5px 10px" src="../img/circulo.png" />';
                                        dropdown += '<span class="aAddemdum" id="' + row[1] + '-' + row[11] + '" style="margin: -5px 0 -5px 5px">Solicitar Evaluación del Examen</span>';
                                        dropdown += '</a>';
                                        dropdown += '</li>';
                                    }
                                    dropdown += '</ul>';
                                    dropdown += '</li>';
                                    dropdown += '</ul>';
                                }

                                return dropdown;
                            }
                        },
                        { orderable: false, width: "60px" },
                        { orderable: false, width: "35px" },
                        { orderable: false, width: "35px" },
                        {
                            orderable: false,
                            width: "35px",
                            render: function (data, type, row, meta) {
                                var image = '';

                                if (row[2] == '' && row[3] == '')
                                    return image;

                                if (row[2] != '' && row[3] == 'C')
                                    image += '<img src="../icon/alerta.png" class="css-col-com" data-toggle="tooltip" data-placement="top" title="' + row[2] + '"/>';
                                else if (row[2] != '' && row[3] == 'G')
                                    image += '<img src="../icon/alerta2.png" class="css-col-com" data-toggle="tooltip" data-placement="top" title="' + row[2] + '"/>';
                                else if ((row[2] + '-' + row[3]) == '') {
                                    if (row[3] == 'C')
                                        image += "CRITICA";
                                    else
                                        image += "GRAVE";
                                }

                                return image;
                            }
                        },
                        { orderable: false, width: "40px" },
                        { orderable: false, width: "30px" },
                        { orderable: false, width: "30px" },
                        { orderable: false, width: "30px" },
                        { orderable: false, width: "30px" },
                        {
                            orderable: false,
                            width: "100px",
                            render: function (data, type, row, meta) {
                                var image = ''

                                if (row[6] == "" && row[9] == "")
                                    return image;

                                image += '<img id="img' + row[1] + '" src="../img/cargando.gif" class="css-col-com" />';

                                if (row[6] == '1')
                                    image += '<img src="../icon/solNuevo.png" class="css-col-com" title="Solicitud Addendum creada nueva"/>';
                                else if (row[6] == '2')
                                    image += '<img src="../icon/solEnProceso.png" class="css-col-com" title="Solicitud Addendum en proceso"/>';
                                else if (row[6] == '3')
                                    image += '<img src="../icon/solFinalizado.png" class="css-col-com" title="Solicitud Addendum Finalizada"/>';
                                else if (row[6] == '4')
                                    image += '<img src="../icon/solRechazado.png" class="css-col-com" title="Solicitud Addendum rechazada"/>';

                                if (row[9] != '0') {
                                    image += '&nbsp; <span id="I-' + row[1] + '-' + row[11] + '" data-toggle="modal" class="accion" >';
                                    image += '<img src="../img/tieneComentarioOLD.png" class="css-col-com" title="Ver Acciones"/>';
                                    image += '</span>';
                                }
                                if (row[7] != '0') {
                                    image += '&nbsp; <span id="I-' + row[1] + '-' + row[11] + '" data-toggle="modal" class="bloqueo" >';
                                    image += '<img src="../img/iconoCandadoBloqueado.png" class="css-col-com" title="Bloqueado"/>';
                                    image += '</span>';
                                }

                                if (row[36] != '0') {
                                    image += '&nbsp; <span id="P-' + row[1] + '-' + row[11] + '" data-toggle="modal" class="pendiente" >';

                                    if (row[36] == '1') image += '<img id="iPend-' + row[1] + '" src="../img/pendiente.png" class="css-col-com" style="cursor:pointer" title="Pendiente"/>';
                                    if (row[36] == '2') image += '<img id="iPend-' + row[1] + '" src="../img/campana.png" class="css-col-com" style="cursor:pointer" title="Pendiente"/>';
                                    if (row[36] == '3') image += '<img id="iPend-' + row[1] + '" src="../img/correcto.png" class="css-col-com" style="cursor:pointer" title="Pendiente"/>';

                                    image += '</span>';
                                }

                                image += '<b id="blq-' + row[7] + '"></b>';
                                return image;
                            }
                        },
                        { orderable: false, width: "60px" },
                        { orderable: false, width: "100px" },
                        { orderable: false, width: "50px" },
                        { orderable: false, width: "80px" },
                        {
                            orderable: false,
                            width: "90px",
                            render: function (data, type, row, meta) {
                                var vtext = '';

                                if (data != '') vtext += '<img src="../img/comentarioTM.png" class="css-col-com" data-toggle="tooltip" data-placement="top" title="{ 0 }"/>';

                                if (row[14] != "")
                                    if (row[14] == 'URG')
                                        vtext += '<span style="color: red">' + row[14] + '</span>'
                                    else
                                        vtext += '<span>' + row[14] + '</span>'

                                return vtext;
                            }
                        },
                        {
                            orderable: false,
                            width: "90px",
                            render: function (data, type, row, meta) {
                                if (data == "") return "";

                                var vtext = moment(data, 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY HH:mm');

                                return vtext;
                            }
                        },
                        {
                            orderable: false,
                            width: "90px",
                            render: function (data, type, row, meta) {
                                if (data == "") return "";

                                var vtext = moment(data, 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY HH:mm');

                                return vtext;
                            }
                        },
                        {
                            orderable: false,
                            width: "90px",
                            render: function (data, type, row, meta) {
                                if (data == "") return moment(row[17], 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY HH:mm');

                                var vtext = moment(row[17], 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY HH:mm');

                                if (!data.includes('1900'))
                                    vtext = moment(data, 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY HH:mm');

                                return vtext;
                            }
                        },
                        {
                            orderable: false,
                            width: "90px",
                            render: function (data, type, row, meta) {
                                if (data == "") return "";

                                var vtext = '-';

                                if (!data.includes('1900'))
                                    vtext = moment(data, 'DD/MM/YYYY HH:mm').format('DD/MM/YYYY HH:mm');

                                return vtext;
                            }
                        },
                        {
                            orderable: false,
                            width: "110px",
                            render: function (data, type, row, meta) {
                                return data.indexOf('-') >= 0 ? "<p style='color:red'>" + data.replaceAll("-", "") + "</p>" : data;
                            }
                        },
                        { orderable: false, width: "130px" },
                        { orderable: false, width: "170px" },
                        { orderable: false, width: "040px" },
                        {
                            orderable: false,
                            width: "250px",
                            render: function (data, type, row, meta) {
                                return '<span data-toggle="tooltip" title="' + data + '">' + data.substring(0, 19) + '</span>';
                            }
                        },
                        { orderable: false, width: "50px" },
                        { orderable: false, width: "100px" },
                        {
                            orderable: false,
                            width: "100px",
                            render: function (data, type, row, meta) {
                                return '<span data-toggle="tooltip" title="' + data + '">' + data.substring(0, 10) + '</span>';
                            }
                        },
                        {
                            orderable: false,
                            width: "40px",
                            render: function (data, type, row, meta) {
                                var chkb = "";

                                if (row[1] == "") return chkb;

                                chkb += "<input id='chk" + row[1] + "' type='checkbox' class='chkGridView' name='checkbox'/>";
                                chkb += "<p id='cmm-" + row[1] + "' style='display:none' >" + row[28] + "," + row[29] + "," + row[30] + "," + row[31] + "," + row[32] + "," + row[33] + "," + row[10].split(',')[2] + "</p>";
                                chkb += "<p id='cdE-" + row[1] + "' style='display:none' >" + row[34] + "</p> ";

                                return chkb;
                            }
                        }
                    ]
                    , scrollX: true
                    , language: {
                        lengthMenu: 'Cantidad de registros para búsqueda &nbsp; &nbsp; <select name="Cantidad" id="Cantidad" CssClass="form-control-ddl" style="font-size:10px; font-weight: bold; width:65px; height: 25px; background-color:#FF8C3F; color:white;" />&nbsp; &nbsp;<span style="color:#676c6f; width:50px; display:-webkit-inline-box;">.</span><span class="data_info_n" style="width:270px" >Calculando totales de la consulta</span><span style="color:#676c6f; width:' + cal_width + 'px; display:-webkit-inline-box;">.</span><span style="width:60px; display:-webkit-inline-box;"><img id="loaderFiltro" class="img-hide" src="../img/cargando.gif"/></span><span id="anterior" class="fg-button ui-button ui-state-default previous prev-icon css-button-disableb" style="color: #484f4f !important;padding: 2px 10px 2px 10px;margin: 0 0 0 0;border-radius: 4px 4px 4px 4px;height: 25px;text-align: right;">Anterior</span>&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<span id="siguiente" class= "fg-button ui-button ui-state-default previous next-icon css-button-disableb" style="color:#484f4f !important;padding: 2px 10px 2px 10px;margin: 0 0 0 0;border-radius: 4px 4px 4px 4px;height: 25px;text-align: right;" > Siguiente</span>',
                        processing: "<span id='loading' style='visible:none; margin-top: 10px; '>...</span>"
                    }
                    , oLanguage: {
                        sEmptyTable: "."
                    }
                    , retrieve: true
                });
            }

            function aperturaInforme(informe) {
                var jsdata = '{ idInforme :' + informe + '}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/AperturarInforme",
                    data: jsdata,
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: false,
                    success: function (data) {
                        $('#cierraPaciente').trigger('click');

                        $("#messagePrestacion").text(data.d.Mensaje);
                        $("#modalMessageBox").modal("show");
                    },
                    error: function (result) {
                        $("#messagePrestacion").text('Ha ocurrido un error en la apertura de informe paciente');
                        $("#modalMessageBox").modal("show");
                    }
                });
            }

            function CargaPrestacion(idExamen, Estado) {
                $('#hEliminaPrestacion').val(idExamen);
                $('#hEliminaPrestacionArray').val('');
                $('#hEliminaPrestacionAccion').val('');
                $('#hEliminaPrestacionId').val('');


                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/GetMantedorPrestacion",
                    data: '{ "idExamen":' + idExamen + ' }',
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    datatype: "json",
                    beforeSend: function () {
                        $('#messMpeCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messMpeTxt').text('Espere mientras se cargan los datos');
                    },
                    success: function (data) {
                        var html = '';
                        $("#tbPrestacionesExamen").html('');
                        $("#ddlPrestacionesMantenedor").empty();

                        $("#lblRutPrestacion").text(data.d.Data.MantendorPrestacion.Rut);
                        $("#lblNombrePrestacion").text(data.d.Data.MantendorPrestacion.Nombre);
                        $("#lblEdadPrestacion").text(data.d.Data.MantendorPrestacion.Edad);
                        $("#lblInstitucionPrestacion").text(data.d.Data.MantendorPrestacion.Institucion);
                        $("#lblFechaExamenPrestacion").text(data.d.Data.MantendorPrestacion.FechaExamenText);
                        $("#lblMedicoPrestacion").text(data.d.Data.MantendorPrestacion.Radiologo);
                        $("#lblEstadoPrestacion").text(data.d.Data.MantendorPrestacion.Estado);

                        $.each(data.d.Data.Prestaciones, function (id, value) {
                            $("#ddlPrestacionesMantenedor").append('<option value="' + value.Value + '">' + value.Text + '</option>');
                        });

                        var rowF = 0;

                        $.each(data.d.Data.PrestacionesExamen, function (id, value) {
                            var disponible = "";

                            rowF++;

                            if (Estado != "3") {
                                disponible = '<a href="javascript:EliminarPrestacionExamen(' + value.IdPrestacion + ', 0,' + value.IdExamenPrestacion + ')" >' +
                                    '<img src="../icon/eliminar.png" title="Eliminar Prestacion" style="max-width: 13px !important" />' +
                                    '</a>';
                            }

                            html += '<tr style="height: 25px;" id="pFila' + value.IdPrestacion + '" class="id-' + value.IdExamenPrestacion + '" >' +
                                '<td>' + value.CodigoPrestacion + '</td>' +
                                '<td>' + value.NombrePrestacion + '</td>' +
                                '<td class="text-center">' +
                                disponible +
                                '</td>' +
                                '</tr>';
                        });

                        $("#tbPrestacionesExamen").append(html);
                    },
                    error: function (result) {
                        $('#messMpeCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                        $('#messMpeTxt').text('Ha ocurrido un error al momento de cargar prestaciones');
                    }
                }).done(function (arg) {
                    $('#messMpeCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                    $('#messMpeTxt').text('');
                });
            }

            function clearPaciente() {
                $('#Paciente').val('');
                $('#Nombre').val('');
                $('#NumeroAcceso').val('');
                $('#Descripcion').val('');
                $("#Edad option[value=0]").prop("selected", true);
            }

            $('#sel-filtro').change(function () {
                $('#hddfilter').val($(this).val());

                $('#loaderFiltro').removeClass('img-hide');
                $('#loaderFiltro').addClass('img-show');

                clearPaciente();

                if ($(this).val() != "0") {
                    var fdata = '{userId:"' + $("#hddUser").val() + '", filtroId:"' + $(this).val() + '"}';
                    $('#filtroNombre').text($(this).text());

                    $.ajax({
                        type: "POST",
                        url: "../Examen/ListaExamen.aspx/SeleccionFiltro",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        data: fdata,
                        async: true,
                        error: function (arg) {
                            $('#loaderFiltro').removeClass('img-show');
                            $('#loaderFiltro').addClass('img-hide');
                        },
                        success: function (arg) {
                            if (arg.d.Data.Ejecutado) {
                                var reqInst = arg.d.Data.Data.institucion;
                                $('#Institucion > option:selected').prop('selected', false);
                                $.each(reqInst, function (i, item) {
                                    $('#Institucion > option').each(function () {
                                        if ($(this).val() == item.id) $("#Institucion option[value=" + $(this).val() + "]").prop("selected", true);
                                    });
                                });
                                $('#Institucion').multiselect('refresh');

                                var reqMod = arg.d.Data.Data.modalidad;
                                $('#Modalidad > option:selected').prop('selected', false);
                                $.each(reqMod, function (i, item) {
                                    $('#Modalidad > option').each(function () {
                                        if ($(this).val() == item.id) $("#Modalidad option[value=" + $(this).val() + "]").prop("selected", true);
                                    });
                                });
                                $('#Modalidad').multiselect('refresh');

                                var reqMed = arg.d.Data.Data.medico;
                                $('#Medico > option:selected').prop('selected', false);
                                $.each(reqMed, function (i, item) {
                                    $('#Medico > option').each(function () {
                                        if ($(this).val() == item.id) $("#Medico option[value=" + $(this).val() + "]").prop("selected", true);
                                    });
                                });
                                $('#Medico').multiselect('refresh');

                                var reqAte = arg.d.Data.Data.atencion;
                                $('#Atencion > option:selected').prop('selected', false);
                                $.each(reqAte, function (i, item) {
                                    $('#Atencion > option').each(function () {
                                        if ($(this).val() == item.id) $("#Atencion option[value=" + $(this).val() + "]").prop("selected", true);
                                    });
                                });
                                $('#Atencion').multiselect('refresh');

                                var reqEst = arg.d.Data.Data.estado;
                                $('#Estado > option:selected').prop('selected', false);
                                $.each(reqEst, function (i, item) {
                                    $('#Estado > option').each(function () {
                                        if ($(this).val() == item.id) $("#Estado option[value=" + $(this).val() + "]").prop("selected", true);
                                    });
                                });
                                $('#Estado').multiselect('refresh');

                                $("#bBuscar").trigger("click");
                            } else {
                                alert(arg.d.Data.Mensaje);
                            }

                            $('#loaderFiltro').removeClass('img-show');
                            $('#loaderFiltro').addClass('img-hide');
                        }
                    });
                } else {
                    $("#Institucion > option").attr("selected", false);
                    $('#Institucion').multiselect('refresh');

                    $("#Modalidad > option").attr("selected", false);
                    $('#Modalidad').multiselect('refresh');

                    $("#Medico > option").attr("selected", false);
                    $('#Medico').multiselect('refresh');

                    $("#Atencion > option").attr("selected", false);
                    $('#Atencion').multiselect('refresh');

                    $("#Estado > option").attr("selected", false);
                    $('#Estado').multiselect('refresh');

                    $('#loaderFiltro').removeClass('img-show');
                    $('#loaderFiltro').addClass('img-hide');

                    $("#bBuscar").trigger("click");
                }
            });

            $('#guardarFiltro').on('click', function () {
                if ($('#filtroNombre').val() != '') {
                    var swVal = false;

                    $("#sel-filtro option").each(function () {
                        if ($(this).text().trim().toUpperCase() == $('#filtroNombre').val().trim().toUpperCase()) swVal = true;
                    });

                    $('#filtroNombre').val($('#filtroNombre').val().trim().toUpperCase());

                    if ($('#filtroNombre').val().includes('G - ')) {
                        alert('Filtro General no puede ser modificado por Ud.');
                        return false;
                    }




                    if (swVal && swSaveAs) {
                        alert('El nombre ingresado ya existe en la lista de filtros');
                        $('#filtroNombre').focus();
                        return false;
                    }

                    var sw = 0;
                    var oRequest = new Object();
                    var oInstitucion = [];
                    var oModalidad = [];
                    var oMedico = [];
                    var oEstado = [];
                    var oAtencion = [];

                    $('#Institucion > option:selected').each(function () {
                        var data = new Object();

                        data.id = $(this).val();

                        oInstitucion.push(data);

                        sw = 1;
                    });

                    $('#Modalidad > option:selected').each(function () {
                        var data = new Object();

                        data.id = $(this).val();

                        oModalidad.push(data);

                        sw = 1;
                    });

                    $('#Medico > option:selected').each(function () {
                        var data = new Object();

                        data.id = $(this).val();

                        oMedico.push(data);

                        sw = 1;
                    });

                    $('#Atencion > option:selected').each(function () {
                        var data = new Object();

                        data.id = $(this).val();

                        oAtencion.push(data);

                        sw = 1;
                    });

                    $('#Estado > option:selected').each(function () {
                        var data = new Object();

                        data.id = $(this).val();

                        oEstado.push(data);

                        sw = 1;
                    });

                    if (sw != 0) {
                        oRequest.usuario = $('#hddUser').val();
                        oRequest.filtroId = $('#hddfilter').val() == '' ? '0' : $('#hddfilter').val();
                        oRequest.nombre = $('#filtroNombre').val().toUpperCase();
                        oRequest.institucion = oInstitucion;
                        oRequest.modalidad = oModalidad;
                        oRequest.medico = oMedico;
                        oRequest.atencion = oAtencion;
                        oRequest.estado = oEstado;
                        oRequest.opfiltro = 0;

                        var filterD = "{ filters: " + JSON.stringify(oRequest) + "}";
                        var nombreFiltro = 'P - ' + $('#filtroNombre').val().toUpperCase();

                        $.ajax({
                            type: "POST",
                            url: "../Examen/ListaExamen.aspx/GuardaFiltro",
                            contentType: "application/json; charset=utf-8",
                            datatype: "json",
                            data: filterD,
                            async: true,
                            success: function (arg) {
                                if (!arg.d.Data.Ejecutado)
                                    alert("Error:" + arg.d.Data.Mensaje);
                                else {
                                    if ($('#hddfilter').val() != arg.d.Data.Data) {
                                        $('#sel-filtro').append('<option value="' + arg.d.Data.Data + '" style="font-weight: bold;" selected>&nbsp;' + nombreFiltro + '</option>');
                                        $('#filtros').multiselect('refresh');
                                    }
                                    $('#hddfilter').val(arg.d.Data.Data);
                                }

                                swSaveAs = false;

                                $("#modalAgregarFiltro").modal("toggle");
                            },
                            error: function (msg) {
                                alert("Error:" + msg.responseText);
                            },
                            failure: function (fail) {
                                alert("Error:" + fail);
                            }
                        });
                    } else {
                        alert("No realizo seleccion de filtros para grabar");

                        $('#modalAgregarFiltro').modal('hide');
                    }
                } else {
                    alert("Debe ingresar un nombre al fltro");
                }
            });

            $("#mAsignaEstudio").on('click', function () {
                var cantidad = 0;
                var id_asignacion = '';

                $("#lblMensaje").text("");

                $("#gData tbody tr").each(function (index) {
                    var examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];

                    if ($("#chk" + examen).is(':checked')) cantidad++;
                });

                $("#lblCantidadSeleccionados").text("Cantidad de Estudios Seleccionados: " + cantidad);

                if (cantidad == 0) {
                    $("#lblMensaje").text("No hay estudios seleccionados.");
                    $("#lblMensaje").css("color", "red");
                    $("#btnGuardarAsignacion").css("visibility", "hidden");
                }
                else {
                    $("#btnGuardarAsignacion").css("visibility", "visible");
                }
            });

            $.getJSON("../Examen/JsonGetDropdown.aspx", function (data) {
                if (data.out == 'ok') {

                    $("#divMedicoRadiologo").children("select").remove();
                    $("#divMedicoRadiologo").append(data.usuario_asignar);

                    if (data.asignar == '1') {
                        $("#btnAsignar").css("visibility", "visible");
                    }
                    else {
                        $("#btnAsignar").css("visibility", "hidden");
                    }
                }
            });

            $('#btnGuardarAsignacion').on('click', function () {
                if ($("#ddlUsuarioAsignacion").val() != "0") {
                    var asignados = "";

                    $("#gData tbody tr").each(function (index) {
                        var examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];

                        if ($("#chk" + examen).is(':checked')) {
                            asignados = (asignados == "" ? asignados += "" : asignados += ",");

                            asignados += examen;
                        }
                    });

                    $.getJSON("../Examen/JsonSaveAsignacion.aspx?id_asignacion='" + asignados + "'&id_radiologo=" + $("#ddlUsuarioAsignacion").val(), function (data) {
                        if (data.out == 'ok') {
                            $("#lblMensaje").css("color", "white");
                            $("#lblMensaje").text(data.mensaje);

                            alert("Estudios Asignados Existosamente.");

                            $("#bBuscar").trigger("click");

                            $('#modalAsignar').modal('hide');
                        }
                        else {
                            $("#lblMensaje").css("color", "red");
                            $("#lblMensaje").text(data.mensaje);
                        }
                    });
                }
                else {
                    $("#lblMensaje").text("");
                    $("#lblMensaje").css("color", "white");
                }
            });

            $('#mEliminaEstudio').on('click', function () {
                var cantidad = 0;
                var id_asignacionEliminar = '';

                $("#lblMensajeEliminar").text("");

                $("#gData tbody tr").each(function (index) {
                    var examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];

                    if ($("#chk" + examen).is(':checked')) cantidad++;
                });

                $("#lblCantidadSeleccionadosEliminar").text("Cantidad de Estudios Seleccionados: " + cantidad);

                if (cantidad == 0) {
                    $("#lblMensaje").text("No hay estudios seleccionados.");
                    $("#lblMensaje").css("color", "red");
                    $("#btnGuardarAsignacionEliminar").css("visibility", "hidden");
                } else {
                    $("#btnGuardarAsignacionEliminar").css("visibility", "visible");
                }
            });

            $('#btnGuardarAsignacionEliminar').on('click', function () {
                var asignados = "";

                $("#gData tbody tr").each(function (index) {
                    var examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];

                    if ($("#chk" + examen).is(':checked')) {
                        asignados = (asignados == "" ? asignados += "" : asignados += ",");

                        asignados += examen;
                    }
                });

                $.getJSON("../Examen/JsonDeleteExamen.aspx?id_asignacion='" + asignados + "'&id_radiologo=" + $("#ddlUsuarioAsignacion").val(), function (data) {
                    if (data.out == 'ok') {
                        $("#lblMensajeEliminado").css("color", "white");
                        $("#lblMensajeEliminado").text(data.mensaje);

                        $("#bBuscar").trigger("click");

                        $('#modalAsignarEliminar').modal('hide');
                    } else {
                        $("#lblMensajeEliminado").css("color", "red");
                        $("#lblMensajeEliminado").text(data.mensaje);
                    }
                });
            });

            $('#mDescargaEstudio').on('click', function () {
                var cantidad = 0;
                var id_asignacionDescargar = '';

                $("#lblMensajeDescargar").text("");

                $("#gData tbody tr").each(function (index) {
                    var examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];

                    if ($("#chk" + examen).is(':checked')) cantidad++;
                });

                $("#lblCantidadSeleccionadosDescargar").text("Cantidad de Estudios Seleccionados: " + cantidad);

                if (cantidad > 30) {
                    alert("Favor seleccione solamente hasta 30 registros.");
                    $("#btnGuardarAsignacionDescargar").css("visibility", "hidden");
                } else {
                    if (cantidad == 0) {
                        $("#lblMensaje").text("No hay estudios seleccionados.");
                        $("#lblMensaje").css("color", "red");
                        $("#btnGuardarAsignacionDescargar").css("visibility", "hidden");
                    } else {
                        $("#btnGuardarAsignacionDescargar").css("visibility", "visible");
                    }
                }
            });

            $('#btnGuardarAsignacionDescargar').on('click', function () {
                let asignados = [];

                $("#gData tbody tr").each(function (index) {
                    let examen = $(this).find("td").eq(0).find('b').attr('id').split('-')[1];

                    if ($("#chk" + examen).is(':checked')) asignados.push(examen);
                });

                if (asignados.length > 0) {
                    $.ajax({
                        type: "POST",
                        url: "../Examen/JsonGetDownloadExamen.aspx/EnviarCorreo",
                        data: JSON.stringify({ id_ris_examen: asignados.join(',') }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: true,
                        success: function (response) {
                            response.d.forEach(url => { window.open(url, '_blank') });

                            $("#modalAsignarDescargar").modal('hide');
                        },
                        error: function (xhr, status, error) {
                            alert("ERROR ${xhr.status} ${xhr.statusText}: ${error}");
                        }
                    });
                } else {
                    alert("No hay exámenes seleccionados para descargar.");
                }
            });

            $('#bAddPrestacion').on('click', function () {
                var idPrestacion = $("#ddlPrestacionesMantenedor").val();
                var txtPrestacion = $("#ddlPrestacionesMantenedor option:selected").text().split('-')[0];
                var codPrestacion = $("#ddlPrestacionesMantenedor option:selected").text().split('-')[1];

                codPrestacion = codPrestacion == undefined ? '-' : codPrestacion;

                var valor = $('#hEliminaPrestacionArray').val();
                var accc = $('#hEliminaPrestacionAccion').val();
                var idps = $('#hEliminaPrestacionId').val();

                if (valor != '') { valor += ','; accc += ','; idps += ','; }

                valor += idPrestacion;
                accc += '1';
                idps += '0';

                $('#hEliminaPrestacionArray').val(valor);
                $('#hEliminaPrestacionAccion').val(accc);
                $('#hEliminaPrestacionId').val(idps);

                var html = '';

                html += '<tr style="height: 25px;" id="pFila' + idPrestacion + '" class="id-0" >' +
                    '<td>' + codPrestacion + '</td>' +
                    '<td>' + txtPrestacion + '</td>' +
                    '<td class="text-center">' +
                    '<a href="javascript:EliminarPrestacionExamen(' + idPrestacion + ', 0, 0)">' +
                    '<img src="../icon/eliminar.png" title="Eliminar Prestacion" style="max-width: 13px !important" />' +
                    '</a>' +
                    '</td>' +
                    '</tr>';

                $("#tbPrestacionesExamen").append(html);
            });

            $('#gData tbody').on('click', '.descargar', function () {
                var risExamen = $(this).attr('id').split('-')[0];
                var numAcceso = $(this).attr('id').split('-')[1];

                var data = '{id_ris_examen:' + risExamen + ', numeroacceso:"' + numAcceso + '"}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/VisorDescarga",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    success: function (arg) {
                        if (arg.d.includes("https://demo.irad.cl/MultiRisWeb_DownLoad/Download.aspx?codexamen")) {
                            alert('Las imagenes se bajaran en modo normal.');
                            window.open(arg.d);
                        }
                        else {
                            alert('Las imagenes se bajaran en modo contingencia.');
                            window.open(arg.d);
                        }
                    },
                    error: function (msg) {
                        alert("Error:" + msg.responseText);
                    },
                    failure: function (fail) {
                        alert("Error:" + fail);
                    }
                });
            });

            $('#gData tbody').on('click', '.aAddemdum', function () {
                var risExamen = $(this).attr('id').split('-')[0];
                var data = '{idExamen:' + risExamen + ', usuario:"' + $('#hddUser').val() + '"}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/SolicitudAddendum",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    async: true,
                    beforeSend: function () {
                        $('#messageCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messageTxt').text('Espere mientras se cargan los datos');
                        $('#crearAdd').prop('disabled', true)
                        $("#detalleAddemdum").prop('disabled', true)
                    },
                    success: function (data) {
                        var row = data.d.Data;

                        $("#hddIdExamenAddendum").val(row.Id);
                        $("#lblFechaIngresoAddemdum").text(row.FechaIngreso);
                        $("#lblUsuarioIngresoAddemdum").text(row.Usuario);
                        $("#lblMailIngresoAddemdum").text(row.Mail);
                        $("#lblInstitucionAddemdum").text(row.Institucion);
                        $("#lblTipoAtencionExamenAddemdum").text(row.TipoAtencion);
                        $("#lblModalidadExamenAddemdum").text(row.Modalidad);
                        $("#lblFechaExamenAddemdum").text(row.FechaExamen);
                        $("#lblRutPacienteExamenAddemdum").text(row.IdPaciente);
                        $("#lblNombrePacienteExamenAddemdum").text(row.Paciente);
                        $("#lblMedicoSolicitanteExamenAddemdum").text(row.Medico);
                        $("#detalleAddemdum").val("");

                        if (row.Estado < 3) {
                            $('#crearAdd').prop('disabled', true);
                            $("#messageTxt").text("El Exámen debe estar VALIDADO para poder generar esta solicitud");
                            $('#messageCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                        };
                        if (row.Perfil != 8 && row.Perfil != 1 && row.Perfil != 2) {
                            $('#crearAdd').prop('disabled', true)
                            $("#messageTxt").text("Usted NO tiene perfil para crear esta solicitud");
                            $('#messageCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                        };
                    },
                    error: function (result) {
                        $('#messageTxt').text('Ha ocurrido un error en la carga de datos');
                        $('#messageCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                    }
                }).done(function (arg) {
                    if ($("#messageTxt").text().includes('Espere')) {
                        $('#crearAdd').prop('disabled', false);
                        $("#detalleAddemdum").prop('disabled', false)

                        $('#messageTxt').text('');
                        $('#messageCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                    }
                });
            });

            $('#gData tbody').on('click', '.comentario', function () {
                var risExamen = 0;
                var codExamen = 0;

                risExamen = $(this).attr('id').split('-')[0];
                codExamen = $(this).attr('id').split('-')[1];

                $('.tituloComentario').text(risExamen);

                var data = '{codExamen:"' + risExamen + '"}';
                var eComentario = $('#oCm' + risExamen).text() == '' ? '0' : $('#oCm' + risExamen).text();

                if (eComentario == '0') {
                    $("#messagePrestacion").text("Este registro no contiene comentarios");
                    $("#modalMessageBox").modal("show");
                    return false;
                }

                $(this).removeClass('css-disabled-span');

                $("#modalComentarios").modal("show");

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/obtenerComentarios",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    async: true,
                    beforeSend: function () {
                        $('#messCmmCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messCmmTxt').text('Espere mientras se cargan los datos');
                    },
                    success: function (data) {
                        var obj = data.d;
                        var htmlTabla = obj;

                        $("#tablacomentarios").children("table").remove();
                        $("#tablacomentarios").append(htmlTabla);
                    },
                    error: function (msg) {
                        alert("Error:" + msg.responseText);
                    }
                }).done(function (arg) {
                    $('#messCmmCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                    $('#messCmmTxt').text('');
                });
            });

            $('#gData tbody').on('click', '.comentarioImg', function () {
                var risExamen = $(this).attr('id').split('-')[1];
                var codExamen = $(this).attr('id').split('-')[2];

                var data = '{codExamen:"' + risExamen + '"}';

                $('.tituloComentario').text(risExamen);
                $("#modalComentarios").modal("show");
                $(this).removeClass('css-disabled-span');

                $("#modalComentarios").modal("show");

                $('#messCmmCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/obtenerComentarios",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    async: true,
                    beforeSend: function () {
                        $("#tablacomentarios").children("table").remove();
                        $('#messCmmCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messCmmTxt').text('Espere mientras se cargan los datos');
                    },
                    success: function (data) {
                        var obj = data.d;
                        var htmlTabla = obj;

                        //$("#tablacomentarios").children("table").remove();
                        $("#tablacomentarios").append(htmlTabla);
                    },
                    error: function (msg) {
                        alert("Error:" + msg.responseText);
                    }
                }).done(function (arg) {
                    $('#messCmmCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                    $('#messCmmTxt').text('');
                });
            });

            $('#gData tbody').on('click', '.pacienteInf', function () {
                var perfil = $("#hddPerfil").val();

                if (perfil != "1" && perfil != "6") {
                    $("#messagePrestacion").text('Ud. No posee perfil de Administrador para acceder a esta opcion de menu y/o no posee Informe, por este motivo no puede ser modificado');
                    $("#modalMessageBox").modal("show");
                    return false;
                }

                var risExamen = $(this).attr('id').split('-')[0];

                $('#hdExamenPaciente').val(risExamen);

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/GetInfoTituloPaciente",
                    data: '{ "idExamen":' + risExamen + '}',
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: true,
                    beforeSend: function () {
                        $('#messTpaCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messTpaTxt').text('Espere mientras se cargan los datos');
                    },
                    success: function (data) {
                        if (data.d.Ejecutado) {
                            var html = '';
                            var contador = 0;
                            var row = data.d.Data[0];

                            $("#lblInstitucionModTitulo").text(row.Institucion);
                            $("#lblFechaExamenModTitulo").text(row.FechaExamenText);
                            $("#lblMedicoModTitulo").text(row.Radiologo);
                            $("#lblEstadoModTitulo").text(row.EstadoExamen);
                            $("#txtRutInformeMod").val(row.Rut);
                            $("#txtNombreInformeMod").val(row.Nombre);
                            $("#txtPaternoInformeMod").val(row.ApellidoPaterno);
                            $("#txtMaternoInformeMod").val(row.ApellidoMaterno);
                            $("#ddlGeneroInfomrmeMod").val(row.Genero);

                            $("#divTitulos").html('');

                            $.each(data.d.Data, function (id, value) {
                                contador++;
                                var idControl = 'id="txtTitulo' + value.IdInforme + '"';

                                html += '<div class="col-8">' +
                                    '<label class="col-12 css-txt-addemdum" >INFORME ' + contador + ' </label >' +
                                    '<input type="text" ' + idControl + ' value="' + value.TituloInforme + '" class="col-12 form-control" style="font-size: 12px" />' +
                                    '</div>' +
                                    '<div class="col-2 pt-4">' +
                                    '<input type="button" class="btn btn-filter" style="min-width: 110px !important" value="MODIFICAR TITULO" onclick="UpdateTitleInforme(' + value.IdInforme + ')" />' +
                                    '</div>';
                                if (value.IdEstadoInforme == 3) {
                                    html += '<div class="col-2 pt-4">' +
                                        '<input type="button" class="btn btn-danger" style="min-width: 110px !important" value="RE APERTURAR" onclick="AperturaInforme(' + value.IdInforme + ')" />' +
                                        '</div>';
                                }
                            });
                            $("#divTitulos").html(html);

                            $('#messTpaTxt').text('');
                            $('#messTpaCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");

                            $("#modalUpdateTituloPaciente").modal('show');
                        } else {
                            $("#modalUpdateTituloPaciente").modal('hide');
                            $("#messagePrestacion").text(data.d.Mensaje);
                            $("#modalMessageBox").modal("show");
                        }
                    },
                    error: function (result) {
                        $('#messTpaTxt').text('Ha ocurrido un error en la carga de datos');
                        $('#messTpaCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                    }
                }).done(function (arg) {
                    if ($("#messTpaTxt").text().includes('Espere')) {
                        $('#messTpaTxt').text('');
                        $('#messTpaCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                    }
                });
            });

            $('#gData tbody').on('click', '.prestacion', function () {
                var perfil = $("#hddPerfil").val();
                var risExamen = $(this).attr('id').split('-')[1];
                var risInstit = $(this).attr('id').split('-')[2];
                var risEstado = $(this).attr('id').split('-')[3];

                arrayPrestacion = {
                    risExamen: risExamen,
                    prestacion: []
                };

                $('#hdMantenedorExamen').val('');
                $('#hdMantenedorInstit').val('');
                $('#hdMantenedorEstado').val('');

                if (perfil != "1" && perfil != "6") {
                    $("#messagePrestacion").text('Ud. No posee perfil de Administrador para acceder a esta opcion de menu');
                    $("#modalMessageBox").modal("show");
                    return false;
                }

                if (risEstado == "3") {
                    $('#bAddPrestacion').prop("disabled", true); $('#btnInsertOrUpdatePrestacion').prop("disabled", true);
                }
                else {
                    $('#bAddPrestacion').prop("disabled", false); $('#btnInsertOrUpdatePrestacion').prop("disabled", false);
                }

                $('#hdMantenedorExamen').val(risExamen);
                $('#hdMantenedorInstit').val(risInstit);
                $('#hdMantenedorEstado').val(risEstado);


                $("#modalMantenedorPrestacion").modal('show');

                CargaPrestacion(risExamen, risEstado);
            });

            $('#gData tbody').on('click', '.accion', function () {
                var risExamen = $(this).attr('id').split('-')[1];

                var data = '{id_ris_examen:"' + risExamen + '"}';

                $("#modalAcciones").modal('show');

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/obtenerAcciones",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    async: true,
                    beforeSend: function () {
                        $('#messAccCss').removeClass("css-msg-addemdum").addClass("css-prc-addemdum");
                        $('#messAccTxt').text('Espere mientras se cargan los datos');
                    },
                    success: function (arg) {
                        var objeto = arg.d;

                        var htmlTabla = objeto;

                        var htmlTabla = htmlTabla;
                        $("#tablaAcciones").children("table").remove();
                        $("#tablaAcciones").append(htmlTabla);
                    },
                    error: function (result) {
                        $('#messAccTxt').text('Ha ocurrido un error en la carga de datos');
                        $('#messAccCss').removeClass("css-prc-addemdum").addClass("css-msg-addemdum");
                    }
                }).done(function (arg) {
                    if ($("#messAccTxt").text().includes('Espere')) {
                        $('#messAccTxt').text('');
                        $('#messAccCss').removeClass("css-prc-addemdum").removeClass("css-msg-addemdum");
                    }
                });
            });

            $('#gData thead').on('click', '.css-thead-table', function () {
                alert('cabecera');
            });

            $('#anterior').on('click', function () {
                var table = initTable();
                var page = parseInt($('#hddPageInfo').val()) - 1;

                table.clear().draw();

                $('#hddPageInfo').val(page);

                var oData = preparaData();

                cargaExamenGrilla(oData, table, 2)
            });

            $('#siguiente').on('click', function () {
                var table = initTable();
                var page = parseInt($('#hddPageInfo').val());

                table.clear().draw();

                page += 1;

                $('#hddPageInfo').val(page);

                var oData = preparaData();

                cargaExamenGrilla(oData, table, 2)
            });

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/TipoSolicitudAddendum",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                beforeSend: function () {
                    $("#ddlTipoSolAddendum").empty();
                },
                success: function (data) {
                    $.each(data.d, function (id, value) {
                        $("#ddlTipoSolAddendum").append('<option value="' + value.Value + '">' + value.Text + '</option>');
                    });
                },
                error: function (result) {
                    alert("ERROR " + result.status + ' ' + result.statusText);
                }
            });

            $('#cerrarAdd').on('click', function () {
                $("#hddIdExamenAddendum").val('');
                $("#lblFechaIngresoAddemdum").text('');
                $("#lblUsuarioIngresoAddemdum").text('');
                $("#lblMailIngresoAddemdum").text('');
                $("#lblInstitucionAddemdum").text('');
                $("#lblTipoAtencionExamenAddemdum").text('');
                $("#lblModalidadExamenAddemdum").text('');
                $("#lblFechaExamenAddemdum").text('');
                $("#lblRutPacienteExamenAddemdum").text('');
                $("#lblNombrePacienteExamenAddemdum").text('');
                $("#lblMedicoSolicitanteExamenAddemdum").text('');
                $("#txtDetalleSolicitudAddemdum").val('');
                $("#modalSolicitudAddemdum").modal('hide');
            });

            $('#crearAdd').on('click', function () {
                if ($("#detalleAddemdum").val() == "") {
                    $("#messagePrestacion").text('Detalle de la solicitud Addendum es obligatorio');
                    $("#modalMessageBox").modal("show");
                    return false;
                }

                var adjunto = "Sin Adjunto";
                var examen = $("#hddIdExamenAddendum").val();
                var tSolicitud = $("#ddlTipoSolAddendum").val();
                var detalle = $("#detalleAddemdum").val().replaceAll(String.fromCharCode(34), "'");
                var jsdata = '{ idExamen :' + examen + ', detalle :"' + detalle + '", tipoSolicitud : ' + tSolicitud + ', adjunto :"' + adjunto + '"}';

                $('#crearAdd').prop('disabled', true);

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/InsertarSolicitudAdeendum",
                    contentType: "application/json; charset=utf-8",
                    data: jsdata,
                    datatype: "json",
                    async: false,
                    success: function (data) {
                        $("#modalSolicitudAddemdum").modal('hide');
                        $("#messagePrestacion").text(data.d.Mensaje);
                        $("#modalMessageBox").modal("show");
                    },
                    error: function (result) {
                        alert("ERROR " + result.status + ' ' + result.statusText);
                    }
                });
            });

            $('#cierraPaciente').on('click', function () {
                $('#hdExamenPaciente').val('');
                $("#lblInstitucionModTitulo").text('');
                $("#lblFechaExamenModTitulo").text('');
                $("#lblMedicoModTitulo").text('');
                $("#lblEstadoModTitulo").text('');
                $("#txtRutInformeMod").val('');
                $("#txtNombreInformeMod").val('');
                $("#txtPaternoInformeMod").val('');
                $("#txtMaternoInformeMod").val('');
                $("#ddlGeneroInfomrmeMod").val('');
                $("#modalUpdateTituloPaciente").modal('hide');
            });

            $('#cierreModal').on('click', function () {
                $("#messagePrestacion").text('');
                $("#modalMessageBox").modal('hide');
            });

            $('#updatePacienteInforme').on('click', function () {
                var message = '';
                var idPaciente = $("#txtRutInformeMod").val();
                var nombre = $("#txtNombreInformeMod").val();
                var paterno = $("#txtPaternoInformeMod").val();
                var materno = $("#txtMaternoInformeMod").val();
                var genero = $('#ddlGeneroInfomrmeMod option:selected').val();
                var idExamen = $("#hdExamenPaciente").val();

                if (idPaciente == '') {
                    message = "Rut del Paciente es obligatorio.";
                }
                else if (nombre == '') {
                    message = "Rut del Paciente es obligatorio.";
                }

                if (message != '') {
                    $("#messagePrestacion").text(swv);
                    $("#modalMessageBox").modal("show");
                    return false;
                }

                var jsdata = { "idExamen": idExamen, "idPaciente": idPaciente, "nombre": nombre, "paterno": paterno, "materno": materno, "genero": genero };

                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/UpdatePacienteInforme",
                    data: JSON.stringify(jsdata),
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: false,
                    success: function (data) {
                        if (!data.d.Ejecutado)
                            $('#cierraPaciente').trigger('click');

                        $("#messagePrestacion").text(data.d.Mensaje);
                        $("#modalMessageBox").modal("show");
                    },
                    error: function (result) {
                        $("#messagePrestacion").text('Ha ocurrido un error en la actualización del informe de paciente');
                        $("#modalMessageBox").modal("show");
                    }
                });
            });

            $('#saveAs').on('click', function () {
                $('#hddfilter').val('');
                $("#filtroNombre").val('');
                $("#filtroNombre").prop("disabled", false);
                $("#saveAs").addClass('oculta-columna');
                $("#filtroNombre").focus();

                swSaveAs = true;
            });

            $('#cerrarMantenedorPrestacion').on('click', function () {
                $('#lblRutPrestacion').text('');
                $('#lblNombrePrestacion').text('');
                $('#lblEdadPrestacion').text('');
                $('#lblInstitucionPrestacion').text('');
                $('#lblFechaExamenPrestacion').text('');
                $('#lblMedicoPrestacion').text('');
                $('#lblEstadoPrestacion').text('');

                $("#modalMantenedorPrestacion").modal('hide');
            })

            $('#btnInsertOrUpdatePrestacion').on('click', function () {
                var prestacion = $('#hEliminaPrestacionArray').val();
                var accion = $('#hEliminaPrestacionAccion').val();
                var risExamen = $('#hEliminaPrestacion').val();
                var estado = $('#hdMantenedorEstado').val();
                var idps = $('#hEliminaPrestacionId').val();

                if (prestacion != '') {
                    var jsdata = '{ prestacion:"' + prestacion + '", accion:"' + accion + '", risExamen:"' + risExamen + '", estado:"' + estado + '", usuario:"' + $("#hddName").val() + '", id:"' + idps + '" }';

                    $.ajax({
                        type: "POST",
                        url: "../Examen/ListaExamen.aspx/ModificaPrestacion",
                        data: jsdata,
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        async: false,
                        success: function (data) {
                            var dato = data.d.Data;
                            if (!dato.Ejecutado) {
                                $("#messagePrestacion").text('Ha ocurrido un error en la actualizacion de prestaciones');
                                $("#modalMessageBox").modal("show");
                            } else {

                                if (dato.Mensaje != "OK") {
                                    $("#messagePrestacion").text(dato.Mensaje);
                                    $("#modalMessageBox").modal("show");
                                } else {
                                    $('#modalMantenedorPrestacion').modal('hide');

                                    if (estado != '0') $("#bBuscar").trigger("click");
                                }
                            }
                        },
                        error: function (result) {
                            $("#messagePrestacion").text('Ha ocurrido un error en la actualizacion de prestaciones');
                            $("#modalMessageBox").modal("show");
                        }
                    });
                } else {
                    $("#messagePrestacion").text('No se visualizan cambios.');
                    $("#modalMessageBox").modal("show");
                }
            });

            var dataU = '{user:"' + user + '"}';

            $('#gData_paginate').css("display", "none");

            if ($("#returnPage").val() == '1') {
                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/GetSession",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: false,
                    success: function (arg) {
                        if (arg.d.Data.Ejecutado) {
                            var reqInst = arg.d.Data.Data.institucion;

                            $('#Institucion > option:selected').prop('selected', false);
                            $.each(reqInst, function (i, item) {
                                $('#Institucion > option').each(function () {
                                    if ($(this).val() == item.id) $("#Institucion option[value=" + $(this).val() + "]").prop("selected", true);
                                });
                            });
                            $('#Institucion').multiselect('refresh');

                            var reqMod = arg.d.Data.Data.modalidad;
                            $('#Modalidad > option:selected').prop('selected', false);
                            $.each(reqMod, function (i, item) {
                                $('#Modalidad > option').each(function () {
                                    if ($(this).val() == item.id) $("#Modalidad option[value=" + $(this).val() + "]").prop("selected", true);
                                });
                            });
                            $('#Modalidad').multiselect('refresh');

                            var reqMed = arg.d.Data.Data.medico;
                            $('#Medico > option:selected').prop('selected', false);
                            $.each(reqMed, function (i, item) {
                                $('#Medico > option').each(function () {
                                    if ($(this).val() == item.id) $("#Medico option[value=" + $(this).val() + "]").prop("selected", true);
                                });
                            });
                            $('#Medico').multiselect('refresh');

                            var reqAte = arg.d.Data.Data.atencion;
                            $('#Atencion > option:selected').prop('selected', false);
                            $.each(reqAte, function (i, item) {
                                $('#Atencion > option').each(function () {
                                    if ($(this).val() == item.id) $("#Atencion option[value=" + $(this).val() + "]").prop("selected", true);
                                });
                            });
                            $('#Atencion').multiselect('refresh');

                            var reqEst = arg.d.Data.Data.estado;
                            $('#Estado > option:selected').prop('selected', false);
                            $.each(reqEst, function (i, item) {
                                $('#Estado > option').each(function () {
                                    if ($(this).val() == item.id) $("#Estado option[value=" + $(this).val() + "]").prop("selected", true);
                                });
                            });
                            $('#Estado').multiselect('refresh');

                            var simple = arg.d.Data.Data;

                            $("#FechaDesde").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", simple.fechaDesde);
                            $("#FechaDesde").datepicker('refresh');

                            $("#FechaHasta").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", simple.fechaHasta);
                            $("#FechaHasta").datepicker('refresh');

                            $("#Paciente").val(simple.paciente);
                            $("#Nombre").val(simple.nombre);
                            $("#NumeroAcceso").val(simple.numeroAcceso);
                            $("#Descripcion").val(simple.descripcion);
                            $("#Edad option[value=" + simple.rangoEtario + "]").prop("selected", true);
                            $("#Cantidad option[value=" + simple.cantidad + "]").prop("selected", true);

                            $("#filtros option[value=" + simple.opfiltro + "]").attr("selected", true);

                            $('#hddPageInfo').val(simple.pagina);
                        } else {
                            alert(arg.d.Data.Mensaje);
                        }

                        $("#bBuscar").trigger("click");
                    }
                });
            } else {
                $.ajax({
                    type: "POST",
                    url: "../Examen/ListaExamen.aspx/ExtraeDiasExamen",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: dataU,
                    async: true,
                    success: function (arg) {
                        var objeto = jQuery.parseJSON(arg.d);
                        var IDate = new Date();

                        diasFiltro = objeto.JData;

                        IDate.setDate(IDate.getDate() - objeto.JData);

                        var output = ((IDate.getDate() < 10 ? '0' : '') + IDate.getDate() + '/' +
                            (IDate.getMonth() < 10 ? '0' : '') + (IDate.getMonth() + 1) + '/' +
                            IDate.getFullYear()).toString();

                        $("#FechaDesde").datepicker({ autoclose: true, format: 'dd/mm/yyyy', firstDay: 1 }).datepicker("setDate", output);

                        $("#FechaDesde").datepicker('refresh');

                        $("#bBuscar").trigger("click");
                    },
                    error: function (msg) {
                        alert("Error:" + msg.responseText);
                    },
                    failure: function (fail) {
                        alert("Error:" + fail);
                    }
                });
            }

            $('#gData tbody').on('click', '.pendiente', function () {
                $('#risExamen').val('');

                $('#rowId').val($(this).index());

                var risExamen = $(this).attr("id").split('-')[1];

                $('#closeId').val($(this).attr("id"))

                $('#risExamen').val(risExamen);
                $('#Categoria option').remove();
                $('.messages-content').html('');
                $('.messages-content-file').html('');

                ChangeCategoria($('#Categoria'));

                var obj = CompruebaExistenciaCanal(risExamen);

                $("#Categoria option[value=" + obj.id_categoria + "]").attr("selected", true);
                $("#Categoria").multiselect("disable");
                $("#Categoria").multiselect('refresh');
                $("#comunica").val(obj.comunicate);

                listMessage(risExamen, $('.messages-content'), $('#bAdjuntar'));

                listFile($('#risExamen').val(), $('.messages-content-file'));

                $(".close-chat").removeClass('oculta_btn');

                $('#mNotifica').modal('show');
            });

            $('.message-submit').on('click', function () {
                $('.message-input').val($('.message-input').val().replace('"', ''));
                insertMessage($('#risExamen').val(), $('#Categoria > option:selected').val(), $('.message-input').val(), $('.messages-content'), $('#bAdjuntar'), $('.message-input'), $('#usuarioNombre').val(), $("#comunica").val(), $('#Categoria > option:selected').text());

                var table = $('#gData').DataTable();
                var rowIndex = $('#rowId').val();

                var vExists = $("#iPend-" + $('#risExamen').val()).length;

                if (vExists == 0) {
                    var image;

                    if ($('#comunica').val() == '1') image += '<img id="iPend-' + row[1] + '" src="../img/pendiente.png" class="css-col-com" style="cursor:pointer" title="Pendiente"/>';
                    if ($('#comunica').val() == '2') image += '<img id="iPend-' + row[1] + '" src="../img/campana.png" class="css-col-com" style="cursor:pointer" title="Pendiente"/>';
                    if ($('#comunica').val() == '3') image += '<img id="iPend-' + row[1] + '" src="../img/correcto.png" class="css-col-com" style="cursor:pointer" title="Pendiente"/>';

                    table.cell(rowIndex, 4).data(image).draw();
                }
            });

            $('.close-chat').on('click', function () {
                closeNotifyPending($('#risExamen').val());

                $('#' + $('#closeId').val()).remove();

                $('#mNotifica').modal('hide');
            });

            $('#adjuntoEnvio').on('click', function () {
                var filename = $('input[type=file]').val().split('\\').pop();
                var file = $("#file-chat")[0].files[0];

                $('#mAdjunto').modal('hide');

                if (!filename || !file) { alert("No se ha seleccionado ningun archivo"); return false; }

                adjuntoFile($('#risExamen').val(), filename, file, $('#usuarioNombre').val(), $('.messages-content-file'));
            });

            $('#bAdjuntar').on('click', function () {
                $('.custom-file-upload').text('Seleccione Archivo');

                $('#mAdjunto').modal('show');

                //if ($.trim($('.message-input').val()) == "") { alert("Para ingresar un archivo debe haber enviado un mensaje"); return false; }
            });

            $('#file-chat').on('change', function () {
                var filename = $('input[type=file]').val().split('\\').pop();

                $('.custom-file-upload').text(filename);
            });

            $('#bNotificar').on('click', function () {
                $("#modalInformarResumido").modal('hide');

                var obj = CompruebaExistenciaCanal($('#risExamen').val());

                $('#Categoria option').remove();
                $('.messages-content').html('');
                $('.messages-content-file').html('');
                $("#comunica").val(obj.comunicate);

                ChangeCategoria($('#Categoria'));

                $(".close-chat").addClass('oculta_btn');

                $('#mNotifica').modal('show');
            });

            $("#returnPage").val('0')

            $(window).resize(function () {
                var alto = $(window).height();

                if (alto > 500) {
                    var calculo = parseInt(alto * 0.65);

                    $('#gData tbody').attr('style', 'height: ' + calculo + 'px !important');
                }
            })

            $('#gData').on('draw.dt', function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        });

        function UpdateTitleInforme(informe) {
            var titulo = $("#txtTitulo" + informe).val();

            if (titulo == '') {
                $("#messagePrestacion").text('Titulo de informe a modificar es obligatorio');
                $("#modalMessageBox").modal("show");
                return;
            }

            var jsdata = '{ idInforme :' + informe + ', titulo :"' + titulo + '"}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/UpdateTituloInforme",
                data: jsdata,
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: false,
                success: function (data) {
                    if (!data.d.Ejecutado)
                        $('#cierraPaciente').trigger('click');

                    $("#messagePrestacion").text(data.d.Mensaje);
                    $("#modalMessageBox").modal("show");
                },
                error: function (result) {
                    $("#messagePrestacion").text('Ha ocurrido un error en la actualizacion del titulo de informe');
                    $("#modalMessageBox").modal("show");
                }
            });
        }

        function DesbloquearExamen(idExamen) {

            var jsdata = '{ idExamen :' + idExamen + '}';

            $.ajax({
                type: "POST",
                url: "../Examen/ListaExamen.aspx/DesbloqueoExamen",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: jsdata,
                async: false,
                success: function (data) {

                    $("#modalInformarResumido").modal('hide');
                    if (data.d) {
                        $("#lblMensajeAlerta").text('Examen de desbloqueo correctamente en el sistema.');
                        $("#modalMensajeAlerta").modal('show');
                        $("#bBuscar").trigger("click");
                    }
                    else {
                        $("#lblMensajeAlerta").text('Hubo un problema al desbloquear el examen en el sistema.');
                        $("#modalMensajeAlerta").modal('show');
                    }

                }
            });
        }

        function parsearFecha(fechaStr) {
            let partes = fechaStr.split("/"); 
            let dia = parseInt(partes[0], 10);
            let mes = parseInt(partes[1], 10) - 1;
            let anio = parseInt(partes[2], 10);
            return new Date(anio, mes, dia);
        }

    </script>
    
    <asp:HiddenField runat="server" Value="" ID="returnPage" />
    <asp:HiddenField runat="server" Value="" ID="hddPerfil" />
    <asp:HiddenField runat="server" Value="" ID="hddUser" />
    <asp:HiddenField runat="server" Value="" ID="hddVisualiza" />
    <asp:HiddenField runat="server" Value="" ID="hddName" />
    <asp:HiddenField runat="server" Value="" ID="hddfilter" />
    <asp:HiddenField runat="server" Value="" ID="hddPageInfo" />
    <asp:HiddenField runat="server" Value="" ID="hddTotalRegister" />
    <asp:HiddenField runat="server" Value="" ID="swPagina" />
    <asp:HiddenField runat="server" Value="" ID="rowComentario" />
    <asp:HiddenField runat="server" Value="" ID="selFiltroReturn" />
    <asp:HiddenField runat="server" Value="" ID="timerID" />
    <asp:HiddenField runat="server" Value="" ID="hEliminaPrestacion" />
    <asp:HiddenField runat="server" Value="" ID="hEliminaPrestacionArray" />
    <asp:HiddenField runat="server" Value="" ID="hEliminaPrestacionId" />
    <asp:HiddenField runat="server" Value="" ID="hEliminaPrestacionAccion" />
	
	<input id="usuarioNombre" type="hidden" runat="server" />
    <input id="perfilNombre" type="hidden" runat="server" />
    <input id="risExamen" type="hidden" runat="server" />
    <input id="comunica" type="hidden" runat="server" />
    <input id="closeId" type="hidden" />
	<input id="rowId" type="hidden" />

    <div class="row" />

    <div class="row" style="margin-top: 0px; height: 150px; width:100% ; background-color: #404848">
        <div style="width: 99%; margin-left: 1%; margin-top: 60px; height: 1px; background-color: #404848;"></div>
        
        <div class="col-md-12" style="background-color: #404848">
            <div style="width: 100%;">
                <h8 style="margin-left: 9px; color: #F39555;">Exámenes>Exámenes</h8><br />
                <link href="../css/Master.css" rel="stylesheet" />

                <div class="css-div-filtros" >
                    <table class="css-table-filtros css-table-filtros-sup css-table-out">
                        <tr>
                            <td style="text-align: left; margin-left: 5px; width:225px" class="css-celda-out">INSTITUCIÓN</td>
                            <td></td>
                            <td style="text-align: left; margin-left: -5px; width:200px" >INICIO - TÉRMINO INFORME</td>
                            <td></td>
                            <td ><p style="text-align: left; width:200px; margin-left:20%; margin-top:15px;">PERIODO</p></td>
                            <td></td>
                            <td style="text-align: left; width:120px; margin-left: 8px;">MODALIDAD</td>
                            <td style="text-align: left; width:20px;"></td>
                            <td style="text-align: left; width:130px; margin-left: 15px;">ATENCIÓN</td>
                            <td style="text-align: left; width:20px;"></td>
                            <td style="text-align: left; width:220px; margin-left: 15px;">MÉDICO</td>
                            <td style="text-align: left; width:10px;"></td>
                            <td style="text-align: left; width:120px; margin-left: 8px;">ESTADO EXAMEN</td>
                            <td style="text-align: left; width:20px;"></td>
                            <td style="text-align: left; width:300px;" id="tPendiente" >PENDIENTES </td>
                        </tr>
                        <tr>
                            <td class="css-celda-out">
                                <select name="Institucion" id="Institucion" CssClass="form-control-ddl" style="font-size:12px; font-weight: bold; width:200px" multiple="multiple" />
                            </td>
                            <td class="css-celda-out"></td>
                            <td class="css-celda-out" style="width:200px">
                                <div class="row">
                                    <div>
                                        <b><input id="FechaDesde" Class="form-control fecha" style="width:90px !important; font-weight:bold; font-size: 12px; color: white !important; " /></b>
                                    </div>
                                    
                                    <div style="margin-left:20px" >
                                        <b><input id="FechaHasta" Class="form-control fecha" style="width:90px !important; font-weight:bold; font-size: 12px; color: white !important;" /></b>
                                    </div>
                                </div>
                            </td>
                            <td class="css-celda-out"></td>
                            <td style="text-align: center; width:150px !important;" class="css-celda-out">
                                <div id="divPeriodos" class="btn-group btn-nodetype" style="text-align: left; margin-left:10px" />
                            </td>
                            <td class="css-celda-out"></td>
                            <td class="css-celda-out">
                                <select name="Modalidad" id="Modalidad" CssClass="form-control-ddl" style="font-size:12px; font-weight: bold; width:150px; margin-left: 10px"  multiple="multiple"/>
                            </td>
                            <td class="css-celda-out"></td>
                            <td class="css-celda-out">
                                <select name="Atencion" id="Atencion" CssClass="form-control-ddl" style="font-size:12px; font-weight: bold; width:130px" multiple="multiple" /> <!--TipoUrgencia-->
                            </td>
                            <td class="css-celda-out"></td>
                            <td class="css-celda-out">
                               <select name="Medico" id="Medico" CssClass="form-control-ddl" style="font-size:12px; font-weight: bold; width:210px" multiple="multiple" />
                            </td>
                            <td class="css-celda-out"></td>
                            <td class="css-celda-out">
                                <select name="Estado" id="Estado" Class="form-control-ddl" style="font-size:12px; font-weight: bold; width:130px" multiple="multiple" />
                            </td>
                            <td class="css-celda-out">
                                <!--<select name="EstadoInforme" id="EstadoInforme" Class="form-control-ddl" style="font-size:12px; font-weight: bold; width:80px;" />-->
                            </td>
                            <td class="css-celda-out">
                                <select name="Pendiente" id="Pendiente" Class="form-control-ddl" style="font-size:12px; font-weight: bold; width:130px" multiple="multiple" ></select>
                            </td>
                        </tr>
                    </table>

                    <div style="width:100%; height:30px"><br></div>

                    <table class="css-table-filtros">
                        <tr>
                            <td style="text-align: left; width: 100px; margin-left:10px"> ID PACIENTE</td>
                            <td style="text-align: left; width: 350px; margin-left:10px">NOMBRE</td>
                            <td style="text-align: left; width: 80px; margin-left:10px">#ACC</td>
                            <td style="text-align: left; width: 150px; margin-left:10px">TIPO EXAMEN</td>
                            <td style="text-align: center; width: 130px">EDAD</td>
                            <td style="text-align: left; width: 80px"></td>
                            <td style="text-align: center; width: 13%;"></td>
                            <td style="text-align: center; width: 15%">FILTROS</td>
                            <td style="text-align: center; width: 60px"></td>
                            <td style="text-align: center; width: 60px"></td>
                        </tr>
                        <tr>
                            <td>
                                <input id="Paciente" name="Paciente" Class="form-control form-control-1" type="text"  maxlength="15" style="font-size:12px; font-weight:bold; border-radius: 5px 5px 0 5px" />
                            </td>
                            <td>
                                <input id="Nombre" name="Nombre" Class="form-control  form-control-150" type="text"  maxlength="50" style="font-size:12px; font-weight:bold; border-radius: 5px 5px 0 0" />
                            </td>
                            <td>
                                <input id="NumeroAcceso" name="NumeroAcceso" Class="form-control  form-control-150" type="text"  maxlength="20" style="font-size:12px; font-weight:bold; border-radius: 5px 5px 0 0" />
                            </td>
                            <td>
                                <input id="Descripcion" name="Descripcion" Class="form-control  form-control-150" type="text"  maxlength="50" style="font-size:12px; font-weight:bold; border-radius: 5px 5px 0 0" />
                            </td>
                            <td>
                                <select name="Edad" id="Edad" Class="form-control form-control-150" style="font-size:12px; width:130px; text-align: left; color: white !important;" />
                            </td>
                            <td></td>
                            <td>
                                <div>
                                    <ipput id="bBuscar" Class="btn btn-filter"><p style="text-align:center; margin-top:4px; height: 28px">BUSCAR</p></ipput> 
                                    <ipput id="bclear" Class="btn btn-clear" style="Width:60px" "><p style="text-align:center; margin-top:4px">LIMPIAR</p></ipput>
                                </div>
                            </td>
                            <td>
                                <select id="sel-filtro" class="css-dropdown-filter" style="border-radius: 5px; color:white;" />
                            </td>
                            <td>
                                <a id="creaFiltro" href="#" class="btn btn-filter" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 4px;" data-toggle="modal" data-target="#modalAgregarFiltro" title="Crear Filtro">+ FILTRO</a>
                            </td>
                            <td>
                                <a id="eliminaFiltro" href="#" class="btn btn-filter" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 4px;" data-toggle="modal" data-target="#modalMisFiltros" title="Eliminar Filtro">- FILTRO</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
        </div>
    
        <div class="col-12 text-right">
            <script src="../js/SolicitudAddemdum.js"></script>
            <span style="font-size:12px">A = Asignado &nbsp; &nbsp; I = Informador &nbsp; &nbsp;   V = Validador &nbsp; &nbsp;</span>
            <ul class="nav navbar-nav" style="margin-top:-25px;margin-right: 0px;">
                <li class="dropdown" id="selectorDoc">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <span runat="server" Style="color: Silver; margin-top: 1%; margin-right:-10px" CssClass="pagination-ys" Height="1%">
                            <img src='../img/menuBar.png' style='width: 15px' />
                        </span>
                    </a>
                    <ul class="dropdown-menu" style="background-color: #676C6F !important; border-color: white; color: white;" width="150px" background-size="80px">
                        <li style="width: 150px;">
                            <div id="divAsigEliminar">
                                <a id="mAsignaEstudio" data-toggle='modal' title='Asignar Estudios' style="color: white; font-size: 12px; text-decoration: none !important;" data-target="#modalAsignar" href='#' cssclass="form-control-ddl">&nbsp;&nbsp;<img style='width: 12px' src="../img/circulo.png" />&nbsp;Asignar</a>
                                <br />
                                <a id="mEliminaEstudio" data-toggle='modal' title='Eliminar Estudios' style="color: white; font-size: 12px; text-decoration: none !important;" data-target="#modalAsignarEliminar" href='#' cssclass="form-control-ddl">&nbsp;&nbsp;<img style='width: 12px' src="../img/circulo.png" />&nbsp;Eliminar</a>
                                <br />
                            </div>
                            <a id="mDescargaEstudio" data-toggle='modal' title='Descargar Estudios (Maximo 30)' style="color: white; font-size: 12px; text-decoration: none !important;" data-target="#modalAsignarDescargar" href='#' cssclass="form-control-ddl">&nbsp;&nbsp;<img style='width: 12px' src="../img/circulo.png" />&nbsp;Descargar</a>
                            <br />
                        </li>
                    </ul>
                </li>
            </ul>
        </div> 
    </div> 
   
    <div class="row" style="margin-top:100px; margin-left:10px; width: 100%">
        <div class="col-md-12" >
            <table id="gData" class="table table-striped css-table_dark table table-striped table-dark table-hover display nowrap" style="width:100%; background-color: #404848 !important; font-size: 12px">
                <thead>
                    <tr>
                        <th class="css-thead-table css-thead-table-center">-</th>
                        <th class="css-thead-table">R</th>
                        <th class="css-thead-table"></th>
                        <th class="css-thead-table"></th>
                        <th class="css-thead-table">N.</th>
                        <th class="css-thead-table">#I</th>
                        <th class="css-thead-table">ADD</th>
                        <th class="css-thead-table">RO</th>
                        <th class="css-thead-table">CO</th>
                        <th class="css-thead-table">AC</th>
                        <th class="css-thead-table">#COM</th>
                        <th class="css-thead-table">#ACC</th>
                        <th class="css-thead-table">ESTADO</th>
                        <th class="css-thead-table">INSTITUCIÓN</th>
                        <th class="css-thead-table">NTU</th>
                        <th class="css-thead-table">ATENCIÓN</th>
                        <th class="css-thead-table css-thead-table-center">FECHA EXÁMEN</th>
                        <th class="css-thead-table css-thead-table-center">FECHA ASIGNACIÓN</th>
                        <th class="css-thead-table css-thead-table-center">FECHA T0</th>
                        <th class="css-thead-table css-thead-table-center">FECHA VALIDACIÓN</th>
                        <th class="css-thead-table">TIEMPO RESTANTE</th>
                        <th class="css-thead-table">PACIENTE</th>
                        <th class="css-thead-table">NOMBRE PACIENTE</th>
                        <th class="css-thead-table">EDAD</th>
                        <th class="css-thead-table">DESCRIPCIÓN</th>
                        <th class="css-thead-table">MOD.</th>
                        <th class="css-thead-table">MÉDICO</th>
                        <th class="css-thead-table">EJEC.ECO.</th>
                        <th class="css-thead-table">
                            <input id="checkAll" type='checkbox' class='chkGridView' name='checkbox' style="margin-left:5px">
                        </th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <div class="modal fade" id="modalAgregarFiltro">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="width: 100%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1">
                        <b style="font-size: 14px !important; color: white">AGREGAR FILTRO</b>
                    </label>
                </div>
                <div class="modal-body">
                    <div class="row" style="text-align: left;">
                        <div class="col-md-12"></div>
                        <div class="col-md-6">
                            <b>
                                <label class="texto1 titulo1" style="color: white">NOMBRE DEL FILTRO</label>
                            </b>
                        </div>
                        <div class="col-md-6">
                            <input CssClass="form-control text-control color" MaxLength="15" ID="filtroNombre" style="font-size:12px; color:gray;" placeholder="nombre para filtro" />
                            <img id="saveAs" class="imgvisor" src="../icon/GuardarComo.png" style="cursor:pointer" alt="Guardar Como" title="Guardar Como" >
                        </div>
                        <div class="col-md-12" style="font-size: 12px; margin-left: 11px; margin-top: 4px;">
                            <p style="margin-top: 5px;">1.- El filtro se creará en base a las selecciones realizadas. </p>
                            <p style="margin-top: -15px;">2.- Se omiten los siguientes campos: Fechas, IdPaciente, Nombre, #Acc, Descripción, Edad.</p>
                            <p style="margin-top: -15px;">3.- Maximo de caracteres para el nombre: 15</p>
                        </div>
                        <div class="col-md-12" style="text-align: center;">
                            <a id="guardarFiltro" href="#" class="btn btn-filter guardarFilter" style="width: 95px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 4px;" title="Guardar Filtro">GUARDAR</a>
                        </div>

                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div> 

    <div class="modal fade" id="modalMisFiltros">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div style="width: 98%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1"><b style="color: white; font-size: 14px;">MIS FILTROS</b></label>
                </div>
                <div style="width: 98%; height: 1px; background-color: #FF7500; margin-top: 20px"></div>
                <div class="modal-body">
                    <div class="row" style="text-align: center;">
                        <div class="col-md-12">
                            <div id="dlgFiltros">
                                <div id="tablaFiltros"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>


    
    <div class="modal fade" id="modalMensajeAlerta">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div style="width: 98%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1"><b style="color: white; font-size: 14px;">INFORMACIÓN</b></label>
                </div>
                <div style="width: 98%; height: 1px; background-color: #FF7500; margin-top: 20px"></div>
                <div class="modal-body">
                    <div class="row" style="text-align: center;">
                        <div class="col-md-12">
                            <label id="lblMensajeAlerta" style="font-size:medium"></label>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>
    
    <div class="modal fade" id="modalAsignar">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 14px;"><b>ASIGNAR ESTUDIOS SELECCIONADOS</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <b>
                                <label style="font-size: 13px">Seleccione al Radiologo que desea asignar los estudios seleccionados.</label></b>
                        </div>
                        <div class="col-md-12">
                            <div id="divMedicoRadiologo"></div>
                        </div>
                        <div class="col-md-12">
                            <label style="font-size: 14px; margin-top: 14px;" id="lblCantidadSeleccionados"></label>
                        </div>
                        <div class="col-md-12">
                            <label id="lblMensaje" style="font-size: 14px; color: red; margin-top: 14px;"></label>
                        </div>
                        <div class="col-md-12">
                            <a href="#" class="btn btn-filter" id="btnGuardarAsignacion" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 4px;" title="Asignar">ASIGNAR</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalAsignarEliminar">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 14px;"><b>ELIMINAR ESTUDIOS SELECCIONADOS</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <b>
                                <label style="font-size: 13px">Se eliminaran los estudios seleccionados.</label></b>
                        </div>
                        <div class="col-md-12">
                            <label style="font-size: 14px; margin-top: 14px;" id="lblCantidadSeleccionadosEliminar"></label>
                        </div>
                        <div class="col-md-12">
                            <label id="lblMensajeEliminado" style="font-size: 14px; color: red; margin-top: 14px;"></label>
                        </div>
                        <div class="col-md-12">
                            <a href="#" class="btn btn-filter" id="btnGuardarAsignacionEliminar" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 4px;" title="Eliminar">Eliminar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> 

    <div class="modal fade" id="modalAsignarDescargar">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 14px;"><b>DESCARGAR ESTUDIOS SELECCIONADOS</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row"><a href="../js/DataTables/" style="font-size: 14px;" >../js/DataTables/</a>
                        <div class="col-md-12">
                            <b>
                                <label style="font-size: 13px">Se descargaran los estudios seleccionados.</label></b>
                        </div>
                        <div class="col-md-12">
                            <label style="font-size: 14px; margin-top: 14px;" id="lblCantidadSeleccionadosDescargar"></label>
                        </div>
                        <div class="col-md-12">
                            <label id="lblMensajeDescargar" style="font-size: 14px; color: red; margin-top: 14px;"></label>
                        </div>
                        <div class="col-md-12">
                            <a href="#" class="btn btn-filter" id="btnGuardarAsignacionDescargar" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 4px;" title="Descargar">Descargar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalSolicitudAddemdum" data-keyboard="false">
        <div class="modal-dialog modal-lg css-modal-addemdum">
            <div class="modal-content css-modal-addemdum">
                <div class="modal-header" style="text-align: center;">
                    <label class="texto1 titulo1">
                        <b style="color: white; font-size: 14px !important">SOLICITUD DE EVALUACIÓN DEL EXAMEN</b>
                    </label>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="hddIdExamenAddendum" />
                    <div class="row pt-3 pb-1">
                        <div class="col-12" id="messageCss" >
                            <span id="messageTxt" style="width:98%" ><img src="../img/cargando.gif" height="11" width="11" /></span> 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">FECHA INGRESO</label>
                            <label class="col-12 css-bg-addemdum" id="lblFechaIngresoAddemdum" />
                            <label class="col-12" id="lblIdExamen" visible="false" />
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">USUARIO</label>
                            <label class="col-12 css-bg-addemdum" id="lblUsuarioIngresoAddemdum" />
                        </div>
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">MAIL</label>
                            <label class="col-12 css-bg-addemdum" id="lblMailIngresoAddemdum" />
                        </div>
                        <div class="col-2">
                            <label class="col-12 css-txt-addemdum">INSTITUCION</label>
                            <label class="col-12 css-bg-addemdum" id="lblInstitucionAddemdum" />
                        </div>
                    </div>
                    <div class="row pt-3 pb-3">
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">TIPO SOLICITUD</label>
                            <select id="ddlTipoSolAddendum" class="form-control css-bg-addemdum" style="height: 25px !important; padding-top: 2px;"></select>
                        </div>
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">TIPO ATENCION</label>
                            <label class="col-12 css-bg-addemdum" id="lblTipoAtencionExamenAddemdum"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">MODALIDAD</label>
                            <label class="col-12 css-bg-addemdum" id="lblModalidadExamenAddemdum"></label>
                        </div>
                    </div>
                    <div class="row pt-3 pb-3">
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">FECHA EXAMEN</label>
                            <label class="col-12 css-bg-addemdum" id="lblFechaExamenAddemdum"></label>
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">RUT</label>
                            <label class="col-12 css-bg-addemdum" id="lblRutPacienteExamenAddemdum"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">NOMBRE</label>
                            <label class="col-12 css-bg-addemdum" id="lblNombrePacienteExamenAddemdum"></label>
                        </div>
                        <div class="col-2">
                            <label class="col-12 css-txt-addemdum">SOLICITANTE</label>
                            <label class="col-12 css-bg-addemdum" id="lblMedicoSolicitanteExamenAddemdum"></label>
                        </div>
                    </div> 
                    <div class="row pt-2 pb-3">
                        <div class="col-12">
                            <label class="col-12 css-txt-addemdum">DETALLE SOLICITUD ADDENDUM</label>
                            <textarea class="col-12 css-tar-addemdum" rows="5" id="detalleAddemdum" maxlength="4000"></textarea>
                        </div>
                    </div>
                    <div class="row pt-2">
                        <div class="col-12">
                            <input id="crearAdd" type="button" class="btn btn-filter" style="min-width: 150px !important" value="CREAR SOLICITUD" />
                            <input id="cerrarAdd" type="button" class="btn btn-clear" style="min-width: 150px !important" value="CERRAR" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <div class="modal fade" id="modalUpdateTituloPaciente">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <input type="hidden" id="hdExamenPaciente" />
                <div class="modal-header" style="text-align: center;">
                    <label class="texto1 titulo1">
                        <b style="color: white; font-size: 14px !important">MODIFICACIÓN TITULO PACIENTE INFORME</b>
                    </label>
                </div>
                <div class="modal-body">
                    <div class="row pt-3 pb-1">
                        <div class="col-12" id="messTpaCss" >
                            <span id="messTpaTxt" style="width:98%" ><img src="../img/cargando.gif" height="11" width="11" /></span> 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">INSTITUCION</label>
                            <label class="col-12 css-bg-addemdum" id="lblInstitucionModTitulo" />
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">F. EXAMEN</label>
                            <label class="col-12 css-bg-addemdum" id="lblFechaExamenModTitulo" />
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">MEDICO</label>
                            <label class="col-12 css-bg-addemdum" id="lblMedicoModTitulo" />
                        </div>
                        <div class="col-2">
                            <label class="col-12 css-txt-addemdum">ESTADO</label>
                            <label class="col-12 css-bg-addemdum" id="lblEstadoModTitulo" />
                        </div>
                    </div>
                    <div class="row pt-2">
                        <div class="col-4">
                            <label class="col-4 css-txt-addemdum">RUT</label>
                            <input id="txtRutInformeMod" type="text" class="col-12 form-control" style="font-size: 12px" />
                        </div>
                    </div>
                    <div class="row pt-2">
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">NOMBRE</label>
                            <input id="txtNombreInformeMod" type="text" class="col-12 form-control" style="font-size: 12px" />
                        </div>
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">AP. PATERNO</label>
                            <input id="txtPaternoInformeMod" type="text" class="col-12 form-control" style="font-size: 12px" />
                        </div>
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum" >AP. MATERNO</label>
                            <input id="txtMaternoInformeMod" type="text" class="col-12 form-control" style="font-size: 12px"/>
                        </div>
                    </div>
                    <div class="row pt-2">
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">GENERO</label>
                            <select id="ddlGeneroInfomrmeMod" class="form-control" style="font-size: 12px" >
                                <option value="F">Femenino</option>
                                <option value="M">Masculino</option>
                            </select>
                        </div>
                        <div class="col-4 pt-4">
                            <input id="updatePacienteInforme" type="button" class="btn btn-filter" style="min-width: 150px !important" value="MODIFICAR PACIENTE" />
                        </div>
                    </div>
                    <div class="row pt-4" id="divTitulos"></div>
                    <div class="row pt-4">
                        <div class="col-12">
                            <input id="cierraPaciente" type="button" class="btn btn-clear" style="min-width: 150px !important" value="CERRAR" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalMantenedorPrestacion">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <input type="hidden" id="hdMantenedorExamen" />
                <input type="hidden" id="hdMantenedorInstit" />
				<input type="hidden" id="hdMantenedorEstado" />											   
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%;" class="texto1 titulo1">
                        <b style="color:white; font-size:14px !important">MANTENEDOR PRESTACIONES EXÁMEN</b>
                    </label>
                </div>
                <div class="modal-body">
                    <div class="row pt-3 pb-1">
                        <div class="col-12 " id="messMpeCss" >
                            <span id="messMpeTxt" style="width:98%" ><img src="../img/cargando.gif" height="11" width="11" /></span> 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">RUT</label>
                            <label id="lblRutPrestacion" class="col-12 css-bg-addemdum"></label>
                        </div>
                        <div class="col-6">
                            <label class="col-12 css-txt-addemdum">NOMBRE</label>
                            <label class="col-12 css-bg-addemdum" id="lblNombrePrestacion"></label>
                        </div>
                        <div class="col-2">
                            <label class="col-12 css-txt-addemdum">EDAD</label>
                            <label class="col-12 css-bg-addemdum" id="lblEdadPrestacion"></label>
                        </div>
                    </div>
                    <div class="row pt-4 pb-3">
                        <div class="col-4">
                            <label class="col-12 css-txt-addemdum">INSTITUCION</label>
                            <label class="col-12 css-bg-addemdum" id="lblInstitucionPrestacion"></label>
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">F. EXAMEN</label>
                            <label class="col-12 css-bg-addemdum" id="lblFechaExamenPrestacion"></label>
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-txt-addemdum">MEDICO</label>
                            <label class="col-12 css-bg-addemdum" id="lblMedicoPrestacion"></label>
                        </div>
                        <div class="col-2">
                            <label class="col-12 css-txt-addemdum">ESTADO</label>
                            <label class="col-12 css-bg-addemdum" id="lblEstadoPrestacion"></label>
                        </div>
                    </div>
                    <div class="row pt-3 pb-3">
                        <div class="col-8">
                            <label class="col-12 css-txt-addemdum">PRESTACION</label>
                            <select id="ddlPrestacionesMantenedor" class="form-control"></select>
                        </div>
                        <div class="col-4 pt-4 text-center">
                            <input id="bAddPrestacion" type="button" class="btn btn-filter" style="min-width: 150px !important;" value="AGREGAR PRESTACION" />
                        </div>
                    </div>
                    <div class="row pt-3">
                        <div class="col-12 dataTables_scrollBody" style="position: relative; overflow: auto; width: 100%; max-height: 350px;">
                            <table style="width: 100% !important;" class="table table-striped table">
                                <thead>
                                    <tr>
                                        <th style="width: 25%" class="css-txt-addemdum">CODIGO
                                        </th>
                                        <th style="width: 55%" class="css-txt-addemdum">NOMBRE
                                        </th>
                                        <th style="width: 20%" class="text-center">&nbsp;</th>
                                    </tr>
                                </thead>
                                <tbody id="tbPrestacionesExamen">
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="row pt-4">
                        <div class="col-12">
                            <input type="button" class="btn btn-filter" style="min-width: 100px !important" id="btnInsertOrUpdatePrestacion" value="ACEPTAR" />
                            <input id="cerrarMantenedorPrestacion" type="button" class="btn btn-clear" style="min-width: 100px !important" value="CERRAR" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <div class="modal fade" id="modalAcciones">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%;" class="texto1 titulo1">
                        <b style="color: white; font-size: 14px !important">REGISTRO DE INFORME</b>
                    </label>
                </div>
                <div class="modal-body">
                     <div class="row pt-3 pb-1">
                        <div class="col-12 " id="messAccCss" >
                            <span id="messAccTxt" style="width:98%" ><img src="../img/cargando.gif" height="11" width="11" /></span> 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div id="dglAcciones">
                                <div id="tablaAcciones"></div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <a href="#" id="aCancelarAcciones" class="btn btn-primary btn-clear" style="width: 130px; border-color: #636D6F" data-dismiss="modal">
                                <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cancelar</label></a>
                        </div>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalInformarResumido">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%;" class="texto1 titulo1">
                        <b style="color: white; font-size: 12px">INFORMAR</b>
                    </label>
                </div>
                <div class="modal-body">
                    <div class="row pt-2 pb-1">
                        <div class="col-12 " id="messRsmCss" >
                            <span id="messRsmTxt" style="width:98%" ><img src="../img/cargando.gif" height="11" width="11" /></span>
                        </div>
                    </div>
                    <div class="row" id="dvInformarResumidoResultado">
                        <div class="col-md-12">
                            <div id="dlgInformesResumido">
                                <div id="tablaInformesResumido"></div>                                
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-12">
                            <div id="dlgPrestacionResumido">
                                <div id="tablaPrestacionesResumido"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="dvInformarResumidoError">
                        <div class="col-md-12" style="text-align: center;">
                            <img src="../img/error1.png" class="imgError1" />
                        </div>
                    </div>
                    <div class="row" id="dvImagenes">
                        <div class="col-md-12">
                            <div id="dlgImagenes">
                                <div id="tablaImagenes"></div>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <a href="#" id="bNotificar" class="btn btn-primary btn-clear oculta_btn" style="width: 130px !important;">
                        <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">Pendiente</label>
                    </a>
                    <a href="#" id="aCancelarComentario" class="btn btn-primary btn-clear" style="width: 130px; border-color: rgb(101, 96, 95)" data-dismiss="modal">
                        <label style="margin-left: 10px; cursor: pointer; margin-top: 4px" class="lblbtn">Cancelar</label>
                    </a>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <div class="modal fade" id="modalComentarios">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%;" class="texto1 titulo1">
                        <b style="color: white; font-size: 14px !important">COMENTARIOS DEL EXÁMEN </b> <b class="tituloComentario"></b></label>
                </div>
                <div class="modal-body">
                     <div class="row pt-3 pb-1">
                        <div class="col-12" id="messCmmCss" >
                            <span id="messCmmTxt" style="width:98%" ><img src="../img/cargando.gif" height="11" width="11" /></span> 
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div id="dglComentarios">
                                <div id="tablacomentarios"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalProcesarSolicitudAddemdum">
        <div class="modal-dialog modal-lg" style="background-color: #404848; max-width:1100px !important">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1">
                        <b style="color: white; font-size: 14px !important">SOLICITUDES DE EVALUACIÓN DEL EXAMEN</b>
                    </label>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="hddIdSolicitudAddendum" />
                    <input type="hidden" id="hddIdEstadoSolicitudAddendum" />
                    <div class="row">
                        <div class="col-4">
                            <label class="col-12 css-celda-out" style="text-align: left; margin-left: 5px;">INSTITUCION</label>
                            <select id="ddlInstitucionAddemdum" class="form-control"></select>
                        </div>
                        <div class="col-3">
                            <label class="col-12 css-celda-out" style="text-align: left; margin-left: 5px;">ESTADO</label>
                            <select id="ddlEstadosSolicitudAddemdum" class="form-control">
                                <% if (hddPerfil.Value != "8" && hddPerfil.Value != "4")
                                    {%>
                                    <option value = "0" selected > -Todas -</ option >
                                <%}%>                
                                <option value="1">Nueva</option>
                                <option value="2">Procesada</option>
                                <option value="3">Finalizada</option>
                                <option value="4">Rechazada</option>
                            </select>
                        </div>
                         <% if (hddPerfil.Value != "8" && hddPerfil.Value != "4")
                             {%>
                         <div class="col-3">
                            <label class="col-12 css-celda-out" style="text-align: left; margin-left: 5px;">MEDICO INFORMADOR</label>
                            <select id="ddlMedicoInformadorAddemdum" class="form-control"></select>
                        </div>
                         <%}%>   
                        <div class="col-2" style=" padding-top: 25px;">
                            <input type="button" value="BUSCAR" onclick="CargarSolicitudesAdd()" class="btn btn-filter" style="min-width: 150px !important" />
                        </div>
                    </div>
                    
                    <div class="row pt-3">
                        <div class="col-12" style="overflow: auto">
                            <table style="width: 100% !important; overflow-y: scroll" class="table table-striped table">
                                <thead>
                                    <tr>
                                        <th style="width: 5%" class="text-center">Id</th>
                                        <th style="width: 10%" class="text-center">Fecha Ing</th>
                                        <th style="width: 10%" class="text-center">Estado</th>
                                        <th style="width: 15%" class="text-center">Institución</th>
                                        <th style="width: 25%" class="text-center">Paciente</th>
                                        <% if (hddPerfil.Value != "8" && hddPerfil.Value != "4")
                                            {%>
                                        <th style="width: 10%" class="text-center">M. Informador</th>
                                        <th style="width: 10%" class="text-center">M. Validador</th>
                                        <th style="width: 10%" class="text-center">M. Addendum</th>
                                         <%}%>   
                                        <th style="width: 5%" class="text-center">&nbsp;
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="tbDespliegueAddendum">
                                </tbody>

                            </table>

                        </div>
                    </div>
                    <div class="row pt-4">

                        <div class="col-6">
                            <input type="button" onclick="CloseProcesarAddemdum()" value="CERRAR" class="btn btn-filter" style="min-width: 150px !important" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

     <div class="modal fade" id="modalSolicitudDetalleAddemdum">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">SOLICITUD DE EVALUACIÓN DEL EXAMEN</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-3">
                            <label class="col-12" style="font-size: small; color: orange">FECHA INGRESO</label>
                            <label class="col-12" style="font-size: small" id="lblFechaIngresoAddemdumDetalle"></label>
                        </div>
                        <div class="col-3">
                            <label class="col-12" style="font-size: small; color: orange">USUARIO</label>
                            <label class="col-12" style="font-size: small" id="lblUsuarioIngresoAddemdumDetalle"></label>
                        </div>
                        <div class="col-3">
                            <label class="col-12" style="font-size: small; color: orange">MAIL</label>
                            <label class="col-12" style="font-size: small" id="lblMailIngresoAddemdumDetalle"></label>
                        </div>
                        <div class="col-3">
                            <label class="col-12" style="font-size: small; color: orange">INSTITUCION</label>
                            <label class="col-12" style="font-size: small" id="lblInstitucionAddemdumDetalle"></label>
                        </div>
                    </div>
                    <div class="row pt-4 pb-3">
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">TIPO SOLICITUD</label>
                            <label class="col-12" style="font-size: small" id="lblTipoSolicitudExamenAddemdumDetalle"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">TIPO ATENCION</label>
                            <label class="col-12" style="font-size: small" id="lblTipoAtencionExamenAddemdumDetalle"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">MODALIDAD</label>
                            <label class="col-12" style="font-size: small" id="lblModalidadExamenAddemdumDetalle"></label>
                        </div>
                    </div>
                    <div class="row pt-4 pb-3">
                        <div class="col-2">
                            <label class="col-12" style="font-size: small; color: orange">FECHA EXAMEN</label>
                            <label class="col-12" style="font-size: small" id="lblFechaExamenAddemdumDetalle"></label>
                        </div>
                        <div class="col-2">
                            <label class="col-12" style="font-size: small; color: orange">RUT</label>
                            <label class="col-12" style="font-size: small" id="lblRutPacienteExamenAddemdumDetalle"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">NOMBRE</label>
                            <label class="col-12" style="font-size: small" id="lblNombrePacienteExamenAddemdumDetalle"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">M. SOLICITANTE</label>
                            <label class="col-12" style="font-size: small" id="lblMedicoSolicitanteExamenAddemdumDetalle"></label>
                        </div>
                    </div>
                     <% if (hddPerfil.Value != "8" && hddPerfil.Value != "4")
                         {%>
                    <div class="row pt-4 pb-3">
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">M. INFORMANTE</label>
                            <label class="col-12" style="font-size: small" id="lblMedicoInformadorAddemdumDetalle"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">M. VALIDADOR</label>
                            <label class="col-12" style="font-size: small" id="lblMedicoValidadorExamenAddemdumDetalle"></label>
                        </div>
                        <div class="col-4">
                            <label class="col-12" style="font-size: small; color: orange">M. ADDENDUM</label>
                            <label class="col-12" style="font-size: small" id="lblMedicoAddendumExamenAddemdumDetalle"></label>
                        </div>                        
                    </div>
                     <%}%>   
                    <div class="row pt-4 pb-3">
                        <div class="col-12">
                            <label class="col-12" style="font-size: small; color: orange">DETALLE SOLICITUD ADDENDUM</label>
                            <textarea class="col-12" rows="5" style="font-size: small" id="lblDetalleSolicitudAddemdumDetalle" readonly></textarea>
                            <label class="col-12" style="font-size: small; font-palette: dark; color: red" id="lblMensajeDeshabilita2"></label>
                        </div>
                    </div>
                    <div class="row pt-4 pb-3">
                        <div class="col-12">
                            <label class="col-12" style="font-size: small; color: orange">COMENTARIO EN CASO DE RECHAZO</label>
                            <textarea class="col-12" rows="3" style="font-size: small" id="txtComentarioRechazo"></textarea>
                        </div>
                    </div>
                    <div class="row pt-4 pb-3">
                        <div class="col-3 text-center">
                            <input type="button" class="btn btn-filter" style="min-width: 100px !important" value="PROCESAR" onclick="UpdateAddendum(2)" id="btnProcesarAdd" />
                        </div>
                        <div class="col-3 text-center">
                            <input type="button" class="btn btn-filter" style="min-width: 100px !important" value="RECHAZAR" onclick="UpdateAddendum(4)" id="btnFinalizarAdd" />
                        </div>
                        <div class="col-3 text-center">
                            <input type="button" class="btn btn-filter" style="min-width: 100px !important" value="ELIMINAR" onclick="DeleteSolAddendum()" id="btnEliminarAdd" />
                        </div>

                        <div class="col-3  text-center">
                            <input type="button" value="REALIZAR ADDENDUM" onclick="CargarInformesAdd()" class="btn btn-filter" style="min-width: 150px !important" id="btnAddendar" />
                        </div>

                        <div class="pt-3 col-3 text-center">
                            <input type="button" class="btn btn-clear" style="min-width: 100px !important" value="CERRAR" onclick="CerrarPopUpMantenedorSolicituAddemdumDetalle()" />
                        </div>
                    </div>          
                    <div>
                        <label style="font-size: small">Id Examen : </label>
                        <label style="font-size: small" id="lblIdExamen2"></label>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalSolicitudInformes">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">INFORMES DEL EXÁMEN</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <div class="row css-div-addem" style="padding: 5px 5px 5px 5px"><b style="color: white; font-size: 14px !important;">LISTADO DE INFORMES</b></div>
                            <br /> <br />
                            <div class="row" id="divInformes" style="border: 1px solid"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

     <div class="modal fade" id="modalSessionCaducada">
        <div class="modal-dialog modal-md" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">Session de usuario</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <div class="row css-div-addem" style="padding: 5px 5px 5px 5px">
                                <p><b style="color: white; font-size: 14px !important;">Señor usuario su session a caducado, ud debe reconectarse.</b>
                            </div>
                            <br /> <br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 center" style="text-align: center;">
                            <a href="#" id="bSession" class="btn btn-primary btn-clear" style="width: 130px; border-color: rgb(101, 96, 95)" data-dismiss="modal">
                                <label style="margin-left: 10px; cursor: pointer; margin-top: 4px" class="lblbtn">Aceptar</label>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

	<div class="modal" id="mNotifica">
        <div class="chat">
            <div class="chat-title">
                <h1 id="vNombreUsuario"></h1>
                <h2 id="vPerfilNombre"></h2>
                <figure class="avatar">
                    <img src="../img/servicio-al-cliente.png"/>
                </figure>
                <button type="button" class="close-chat no-visible">Finalizar Caso</button>
            </div>
            <div class="message-box" style="font-size: 12px; background-color: #545454; padding: 5px !important;">
                <span style="padding-right: 15px;">CATEGORIA</span>
                <select id="Categoria" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 130px"></select>
            </div>
            <div class="row messages">
                    <div class="col-sm-8">
                        <div class="messages-content barra-scroll"></div>
                    </div>
                    <div class="col-sm-4">
                        <div class="messages-content-file barra-scroll"></div>
                    </div>
                </div>
            <div class="message-box">
                <textarea type="text" class="message-input" placeholder="Escriba Mensaje..."></textarea>
                <img src="../img/adjuntar-archivo.png" class="adjuntar-ris no-visible" id="bAdjuntar" />
                <button type="button" class="message-submit">Enviar</button>
            </div>
        </div>
        <div class="bg"></div>
		</div>
	
    <div class="modal" id="mAdjunto">
			<div class="chat-adjunto">
				<div class="message-box">
					<label for="file-chat" class="custom-file-upload">Seleccione Archivo</label>
					<input type="file" id="file-chat" accept=".pdf,image/png,image/jpg,.doc,.docx, application/octet-stream" />
					<button type="button" class="message-adjunta" id="adjuntoEnvio">Adjuntar</button>
				</div>
			</div>
		</div>
		
    <div runat="server" class="modal fade" id="modalMessageBox" style="padding-top: 250px !important">
        <div class="modal-dialog" style="background-color: #7C7F7F">
            <div class="modal-content" style="background-color: #7C7F7F">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">INFORMACIÓN</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12" style="text-align: center !important;">
                            <label style="font-size: 14px !important;" id="messagePrestacion" />
                        </div>
                    </div>
                    <div class="row pt-4">
                        <div class="col-12" style="padding-left: 35%;"> 
                                <input id="cierreModal" type="button" class="btn btn-clear" style="min-width: 100px !important;" value="CERRAR" />
                        </div>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 5px; width: 100%;"></div>
            </div>
        </div>
    </div>

    <!--<div class="modal fade" id="modalReprocesarInforme">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 14px;"><b>RENVIO DE INFORME SELECCIONADOS</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <b>
                                <label style="font-size: 13px">Se reprocesan solo los informes con estado Validado.</label></b>
                        </div>
                        <div class="col-md-12">
                            <label style="font-size: 16px; margin-top: 14px;" id="lblCantidadSeleccionadosReproceso"></label>
                        </div>
                        <div class="col-md-12">
                            <label id="lblMensajeDescargar" style="font-size: 16px; color: red; margin-top: 14px;"></label>
                        </div>
                        <div class="col-md-12">
                            <a href="#" class="btn btn-filter" id="btnReprocesarInforme" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 6px;" onclick="ReprocesarInforme();" title="Descargar">Reenvio...</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> -->

    <!--<div class="modal fade" id="modalOpciones">
        <div class="modal-dialog modal-xl" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 20px;" class="texto1"><b>DATOS DEL EXAMEN</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <label class="texto1 titulo1"><b>VISUALIZAR DOCUMENTOS</b></label>
                            <br />
                            <img src="../img/SinDocumento.jpg" style="width: 100%;" id="imgOrdenMedica" />
                        </div>
                        <div class="col-md-3">
                            <label class="texto1 titulo1"><b>DATOS DEL PACIENTE</b></label>
                            <table>
                                <tr>
                                    <td><b class="texto1">Nombre Paciente: </b></td>
                                    <td>
                                        <label id="lblModalNombrePaciente"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Id Paciente: </b></td>
                                    <td>
                                        <label id="lblModalIdPaciente"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Institución: </b></td>
                                    <td>
                                        <label id="lblModalInstitucion"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Fecha Examen: </b></td>
                                    <td>
                                        <label id="lblModalFechaExamen"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Descripción: </b></td>
                                    <td>
                                        <label id="lblModalDescripcion"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Medico: </b></td>
                                    <td>
                                        <label id="lblModalMedico"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Estado: </b></td>
                                    <td>
                                        <label id="lblModalEstado"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">EstadoInforme: </b></td>
                                    <td>
                                        <label id="lblModalEstadoInforme"></label>
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-top: 7px; width: 100%; background-color: white; height: 1px;"></div>
                            <label><b class="texto1 titulo1">COMENTARIOS</b></label>
                            <div id="tablaComentarios"></div>
                            <div style="margin-top: 7px; width: 100%; background-color: white; height: 1px;"></div>
                            <label style="margin-top: 10px;"><b class="texto1 titulo1">DOCUMENTOS</b></label>
                            <div id="tablaDocumentos"></div>
                            <div style="margin-top: 7px; width: 100%; background-color: white; height: 1px;"></div>
                        </div>
                        <div class="col-md-3">
                            <label><b class="texto1 titulo1">DESCARGAS</b></label>
                            <table>
                                <tr>
                                    <td><a href="#" id="linkVerImagenes" target="_blank" title="Ver">
                                        <img src="../icon/visor.sl.png" border="0" alt="Radiant" /></a>
                                        <a href="#" id="linkModalRadiant">
                                            <img src="../icon/radiant.png" border="0" alt="Radiant" title="Abrir en Radiant" /></a>
                                        <a href="#" id="linkModalOsirix" title="Abrir en Osrix">
                                            <img src="../icon/osirix.png" border="0" alt="Osirix" /></a>
                                        <a href="#" id="linkModalDescargarExamen" title="Descargar Exámen">
                                            <img src="../icon/zip.png" border="0" alt="Descargar Examen" /></a>
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-top: 15px; width: 100%; background-color: white; height: 1px;"></div>
                            <label style="margin-top: 10px;" class="texto1 titulo1" id="lblPrestaciones"><b>PRESTACIONES EN UN SOLO INFORME</b></label>
                            <div id="dlgPrestacion">
                                <div id="tablaPrestaciones"></div>
                                <div style="width: 100%; text-align: center; margin-top: 10px;">
                                    <input type="button" class="btn btn-primary" style="cursor: pointer;" value="Informar" onclick="informar(); return false;" id="btnInformar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> -->

    <!--<div class="modal fade" id="modalReabrir">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 20px;"><b>REABRIR INFORME</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                    </div>
                </div>
            </div>
        </div>
    </div>-->

    <!--<div class="modal fade" id="modalAddendum">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div style="width: 100%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1"><b style="color: white; font-size: 14px;">ADDENDUMS PENDIENTES</b></label>
                </div>
                <div style="width: 100%; height: 1px; background-color: #FF7500; margin-top: 20px"></div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div id="divAddendums"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div> -->

    <%--INICIO MODAL POP SOLICITUD ADDEMDUM DETALLE--%>
    <%--   <a href="../Firmas/">../Firmas/</a>--%>

    <%--MODAL POPUP--%>
    <!--<div runat="server" class="modal fade" id="modalInicioPopUpHabil">
        <a href="../QR/">../QR/</a>
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-body">
                    <div class="row">
                        <img src="../img/habil.png" />
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>-->

    <%--MODAL POPUP--%>
    <!--<div runat="server" class="modal fade" id="modalInicioPopUpNoHabil">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-body">
                    <div class="row">
                        <img src="../img/noHabil.png" />
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>--> 

    <script>
        function doClick() {
            //var el = document.getElementById("fileElem");
            //if (el) {
            //    el.click();
            //}
        }
    </script>
  
    <!--<script src="../js/evitarReenvio.js"></script>-->
    <script>
        async function uploadFile() {
            //let formData = new FormData();

            //formData.append("file", fileupload.files[0]);
            //await fetch('C:\Irad', {
            //    method: "POST",
            //    body: formData
            //});
            //alert('');
        }
    </script>
</asp:Content>