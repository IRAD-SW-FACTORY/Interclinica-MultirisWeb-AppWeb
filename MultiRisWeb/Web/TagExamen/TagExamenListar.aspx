<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="TagExamenListar.aspx.cs" Inherits="MultiRisWeb.Web.TagExamen.TagExamenListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/jquery-ui.css">
    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/PrestacionExamen.js?v2"></script>
    <script src="../js/SolicitudAddemdum.js"></script>
    <script src="../js/UpdateTituloPacienteExamen.js?v2"></script>
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
    <style>
        .ui-widget {
            width: 240px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-5">
        <div class="col-12">
            &nbsp;
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <h5 class="col-12">Buscador Tag Examenes Profesionales</h5>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label class="col-12">INSTITUCI&Oacute;N</label>
            <select id="ddlInstitucion" class="form-control col-12"></select>
        </div>
        <div class="col-1">
            <label class="col-12">F. INICIO</label>
            <input type="text" id="txtFechaDesde" class="form-control col-12 fecha" readonly />
        </div>
        <div class="col-1">
            <label class="col-12">F. TERMINO</label>
            <input type="text" id="txtFechaHasta" class="form-control col-12 fecha" readonly />
        </div>
        <div class="col-2">
            <label class="col-12">MODALIDAD</label>
            <select id="ddlModalidad" class="form-control col-12"></select>
        </div>
        <div class="col-2">
            <label class="col-12">ESTADO EX&Aacute;MEN</label>
            <select id="ddlEstadoExamen" class="form-control col-12"></select>
        </div>
        <div class="col-2">
            <label class="col-12">EDAD</label>
            <select id="ddlRangoEtario" class="form-control col-12">
                <option value="0">- TODOS -</option>
                <option value="1">Menor 18 años</option>
                <option value="2">Mayor 18 años</option>
            </select>
        </div>
        <div class="col-2 ocultar-div">
            <label class="col-12">TIPO ATENCI&Oacute;N</label>
            <select id="ddlTipoAtencion" class="form-control col-12"></select>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label class="col-12">ID. PACIENTE</label>
            <input type="text" id="txtIdPaciente" class="form-control col-12" />
        </div>
        <div class="col-2">
            <label class="col-12">NOMBRE</label>
            <input type="text" id="txtNombrePaciente" class="form-control col-12" />
        </div>
        <div class="col-2">
            <label class="col-12">#ACC</label>
            <input type="text" id="txtNroAcceso" class="form-control col-12" />
        </div>
        <div class="col-2">
            <label class="col-12">Tag Examen</label>
            <select id="ddlTagExamen" class="form-control col-12"></select>
        </div>
        <div class="col-2 p-4">
            <input type="button" class="btn btn-filter m-2" style="min-width: 100px !important" value="BUSCAR" onclick="BuscarTag()" />
            <input type="button" class="btn btn-primary" style="min-width: 100px !important" value="LIMPIAR" onclick="LimpiarBuscador()" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <h5 class="col-12">Listado Examenes Tags</h5>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <table style="width: 100% !important; overflow-y: scroll" class="table table-striped table-dark table-hover">
                <thead>
                    <tr>
                        <th style="width: 5%" class="text-left"># ACC.</th>
                        <th style="width: 10%" class="text-left">INSTITUCION</th>
                        <th style="width: 5%" class="text-left oculta-columna">ATENCION</th>
                        <th style="width: 10%" class="text-left">FECHA EXAMEN</th>
                        <th style="width: 10%" class="text-left oculta-columna">TIEMPO</th>
                        <th style="width: 10%" class="text-left">PACIENTE</th>
                        <th style="width: 5%" class="text-left">NOMBRE PACIENTE</th>
                        <th style="width: 5%" class="text-left">EDAD</th>
                        <th style="width: 15%" class="text-left">DESCRIPCION</th>
                        <th style="width: 5%" class="text-left">MOD.</th>
                        <th style="width: 15%" class="text-left">TAGS</th>
                        <th style="width: 5%" class="text-left">&nbsp;</th>
                    </tr>
                </thead>
                <tbody id="tbTagExamen">
                </tbody>
            </table>
        </div>
    </div>


    <div class="modal fade" id="modalListarInformes">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">INFORMES</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">

                        <div class="col-12">
                            <table style="width: 100% !important; overflow-y: scroll" class="table table-striped table-dark table-hover">
                                <thead>
                                    <tr>
                                        <th style="width: 10%" class="text-center"></th>
                                        <th style="width: 50%" class="text-center">Informe Paciente</th>
                                        <th style="width: 20%" class="text-center">Radiologo</th>
                                        <th style="width: 20%" class="text-center">Ver Informe</th>
                                    </tr>
                                </thead>
                                <tbody id="tbInformes">
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    &nbsp;
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalComentarioGeneralTag">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Comenetario General Tag</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <h5 class="col-12">Comentario</h5>
                            <textarea id="txtComentarioTag" cols="40" rows="5" class="form-control" style="height: 100px !important"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">

                    <input type="button" class="btn btn-filter" value="GUARDAR" id="btnAceptarComentarioGeneral" />

                    <input type="button" class="btn btn-primary" value="CERRAR" onclick="CerrarComentarioGeneral()" />

                </div>
            </div>
        </div>
    </div>

    
    <%--MODAL POPUP MENSAJE MANTENEDOR PRESTACION EXAMEN--%>
    <div runat="server" class="modal fade" id="modalMensajeInfoTag" style="padding-top: 250px !important">
        <div class="modal-dialog" style="background-color: #7C7F7F">
            <div class="modal-content" style="background-color: #7C7F7F">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">INFORMACIÓN</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <label style="font-size: medium !important;" id="lblMensajeInfoTag"></label>
                        </div>
                    </div>
                    <div class="row pt-4">
                        <div class="col-12">
                            <input type="button" class="btn btn-clear" style="min-width: 100px !important" value="CERRAR" onclick="CerrarMensajeagExamen()" />
                        </div>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>
    <script src="../Complementos/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $("#txtFechaDesde").datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                firstDay: 1

            });

            $("#txtFechaHasta").datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                firstDay: 1
            });

            var fecha = new Date();
            var dia = fecha.getDate().toString().length == 1 ? '0' + fecha.getDate().toString() : fecha.getDate().toString();
            var mesNum = fecha.getMonth() + 1;
            var mes = mesNum.toString().length == 1 ? '0' + mesNum.toString() : mesNum.toString();
            var anio = fecha.getFullYear().toString();

            $("#txtFechaDesde").val(dia + '-' + mes + '-' + anio);
            $("#txtFechaHasta").val(dia + '-' + mes + '-' + anio);

        });

        $(document).ready(function () {

            CargarInstitucion();
            CargarModalidad();
            CargarTipoAtencion();
            CargarEstadoExamen();
            CargarTagExamen();
        });

        function LimpiarBuscador() {
            $("#ddlInstitucion").val('0');
            $("#ddlModalidad").val('0');
            $("#ddlTipoAtencion").val('0');
            $("#ddlEstadoExamen").val('0');
            $("#ddlRangoEtario").val('0');
            $("#txtIdPaciente").val('');
            $("#txtNombrePaciente").val('');
            $("#txtNroAcceso").val('');

            var fecha = new Date();
            var dia = fecha.getDate().toString().length == 1 ? '0' + fecha.getDate().toString() : fecha.getDate().toString();
            var mesNum = fecha.getMonth() + 1;
            var mes = mesNum.toString().length == 1 ? '0' + mesNum.toString() : mesNum.toString();
            var anio = fecha.getFullYear().toString();

            $("#txtFechaDesde").val(dia + '-' + mes + '-' + anio);
            $("#txtFechaHasta").val(dia + '-' + mes + '-' + anio);
        }

        function VerInforme(id) {

            $("#tbInformes").html('');
            var html = '';

            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarTagExamenInformes",
                contentType: "application/json; charset=utf-8",
                data: { 'id': id },
                datatype: "json",
                async: false,
                success: function (data) {

                    if (data.d.Ejecutado) {
                        $.each(data.d.Data, function (id, value) {
                            html += '<tr>' +
                                '<td><img src="../icon/pdf.png" title = "Informe" style = "max-width: 25px" /></td>' +
                                '<td><h5>' + value.Descripcion + '</h5></td>' +
                                '<td><h5>' + value.Radiologo + '</h5></td>' +
                                '<td class="pt-3"><a href="../Examen/VerInforme.aspx?idinforme=' + value.IdInforme + '&aetitle=' + value.Aetitle + '" target="_blank"  </a><h6>Ver Informe</h6></td>' +
                                '</tr>';
                        });
                    }
                    else {
                        html += '<tr>' +
                            '<td colspan="4" class="text-center"><label>No existen Informes</label></td>' +
                            '</tr>';
                    }
                    $("#tbInformes").html(html);
                    $("#modalListarInformes").modal("show");


                },
                error: function () {

                }
            });
        }


        function BuscarTag() {

            var nroPagina = 1;
            var idInstitucion = $("#ddlInstitucion").val();
            var modalidad = "'" + $("#ddlModalidad").val() + "'";
            var tipoAtencion = "'" + $("#ddlTipoAtencion").val() + "'";
            var estadoExamen = "'" + $("#ddlEstadoExamen").val() + "'";
            var rangoEtario = $("#ddlRangoEtario").val();
            var idPaciente = "'" + $("#txtIdPaciente").val() + "'";
            var nombrePaciente = "'" + $("#txtNombrePaciente").val() + "'";
            var nroAcceso = "'" + $("#txtNroAcceso").val() + "'";
            var fechaInicio = $("#txtFechaDesde").val().replace('-', '').replace('-', '');
            var fechaTermino = $("#txtFechaHasta").val().replace('-', '').replace('-', '');
            var tagExamen = $("#ddlTagExamen").val();


            $("#tbTagExamen").html('');
            var html = '';

            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarExamenes",
                contentType: "application/json; charset=utf-8",
                data: { 'nroPagina': nroPagina, 'idInstitucion': idInstitucion, 'modalidad': modalidad, 'tipoAtencion': tipoAtencion, 'estadoExamen': estadoExamen, 'rangoEtario': rangoEtario, 'idPaciente': idPaciente, 'nombrePaciente': nombrePaciente, 'nroAcceso': nroAcceso, 'fechaInicio': fechaInicio, 'fechaTermino': fechaTermino, 'tagExamen': tagExamen },
                datatype: "json",
                async: false,
                success: function (data) {

                    if (data.d.Ejecutado) {
                        $.each(data.d.Data, function (id, value) {
                            if (value.ComentarioTag == '')
                                html += '<tr>';
                            else
                                html += '<tr data-toggle="tooltip" data-placement="top" title="' + value.ComentarioTag + '">';
                                html += '<td>' + value.NumeroAcceso + '</td>' +
                                    '<td>' + value.Institucion + '</td>' +
                                    '<td class="oculta-columna">' + value.TipoAtencion + '</td>' +
                                    '<td>' + value.FechaExamenText + '</td>' +
                                   '<td class="oculta-columna">' + value.TiempoText + '</td>' +
                                    '<td>' + value.Paciente + '</td>' +
                                    '<td>' + value.NombrePaciente + '</td>' +
                                    '<td>' + value.Edad + '</td>' +
                                    '<td>' + value.Descripcion + '</td>' +
                                    '<td>' + value.Modalidad + '</td>' +
                                    '<td>' + value.Tags + '</td>' +
                                    '<td class="text-center">';
                            html += '<a href="javascript:AbrirComentarioTag(' + value.Id + ')">' +
                                '<img src="../img/tieneComentario.png" title="Mantenedor Comentario General" style="max-width: 25px" />' +
                                '</a>';
                            if (value.Estado == 'Validado') {
                                html += '&nbsp;&nbsp;<a href="javascript:VerInforme(' + value.Id + ')">' +
                                    '<img src="../icon/pdf.png" title="Ver Informe" style="max-width: 25px" />' +
                                    '</a>';                               
                            }
                            html += '</td>' +
                                '</tr>';
                        });
                    }
                    else {
                        html += '<tr>' +
                            '<td colspan="17" class="text-center"><label>No existen Tag Examenes</label></td>' +
                            '</tr>';
                    }
                    $("#tbTagExamen").html(html);


                }
            });
        }

        function InsertUpdateComentarioGeneral(id) {

            var id = $("#txtNombreTag").val();
            var comentario = $("#txtComentarioTag").val();

            var jsdata = '{ id :"' + id + '", comentario :' + comentario + ' }';

            $.ajax({
                type: "POST",
                url: "../TagExamen/TagExamenProfesional.aspx/InsertOrUpdateComentario",
                contentType: "application/json; charset=utf-8",
                data: jsdata,
                datatype: "json",
                async: false,
                success: function (data) {
                    CerrarComentarioGeneral();
                    AbrirMensajeTagExamen(data.d.Mensaje);
                    BuscarTag();
                }
            });

        }

        function AbrirMensajeTagExamen(mensaje) {            
            $("#modalMensajeInfoTag").modal("show");
            $("#lblMensajeInfoTag").text(mensaje);
        }

        function AbrirComentarioTag(id) {

            $("#modalComentarioGeneralTag").modal("show");
            GetComentarioGeneral(id);
            $("#btnAceptarComentarioGeneral").attr("onclick", "InsertUpdateComentarioGeneral(" + id + ")");
        }

        function CerrarComentarioGeneral() {
            $("#modalComentarioGeneralTag").modal("hide");
        }

        function CargarInstitucion() {

            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarInstitucion",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: true,
                success: function (data) {

                    $("#ddlInstitucion").empty();
                    $("#ddlInstitucion").append('<option value="0">- TODOS -</option>');
                    $.each(data.d.Data, function (id, value) {
                        $("#ddlInstitucion").append('<option value="' + value.id_institucion + '">' + value.nombre_institucion + '</option>');
                    });

                }
            });
        }

        function GetComentarioGeneral(id) {

            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/GetComentarioGeneral",
                contentType: "application/json; charset=utf-8",
                data: { 'id': id},
                datatype: "json",
                async: true,
                success: function (data) {
                    if (data.d.Data.ComentarioGeneral != '')
                        $("#txtComentarioTag").val(data.d.Data.ComentarioGeneral);

                }
            });
        }

        function CargarModalidad() {
            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarModalidad",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: true,
                success: function (data) {
                    $("#ddlModalidad").empty();
                    $("#ddlModalidad").append('<option value="0">- TODOS -</option>');
                    $.each(data.d.Data, function (id, value) {
                        $("#ddlModalidad").append('<option value="' + value.nombre + '">' + value.nombre + '</option>');
                    });

                },
                error: function () {

                }
            });
        }

        function CargarTipoAtencion() {
            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarTipoAtencion",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: true,
                success: function (data) {
                    $("#ddlTipoAtencion").empty();
                    $("#ddlTipoAtencion").append('<option value="0">- TODOS -</option>');
                    $.each(data.d.Data, function (id, value) {
                        $("#ddlTipoAtencion").append('<option value="' + value.nombre + '">' + value.nombre + '</option>');
                    });

                },
                error: function () {

                }
            });
        }

        function CargarEstadoExamen() {
            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarEstadoExamen",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: true,
                success: function (data) {
                    $("#ddlEstadoExamen").empty();
                    $("#ddlEstadoExamen").append('<option value="0">- TODOS -</option>');
                    $.each(data.d.Data, function (id, value) {
                        $("#ddlEstadoExamen").append('<option value="' + value.nombre + '">' + value.nombre + '</option>');
                    });

                },
                error: function () {

                }
            });
        }

        function CargarTagExamen() {
            $.ajax({
                type: "GET",
                url: "../TagExamen/TagExamenListar.aspx/ListarTagExamen",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                async: true,
                success: function (data) {
                    $("#ddlTagExamen").empty();
                    $("#ddlTagExamen").append('<option value="0">- TODOS -</option>');
                    $.each(data.d.Data, function (id, value) {
                        $("#ddlTagExamen").append('<option value="' + value.Id + '">' + value.Nombre + '</option>');
                    });

                },
                error: function () {

                }
            });
        }
    </script>
</asp:Content>
