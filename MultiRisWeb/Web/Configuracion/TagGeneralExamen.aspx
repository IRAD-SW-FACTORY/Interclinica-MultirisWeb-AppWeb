<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="TagGeneralExamen.aspx.cs" Inherits="MultiRisWeb.Web.Configuracion.TagGeneralExamen1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Master.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/Usuarios.js"></script>
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <style type="text/css">
        .form-control {
            height: 30px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-5">
        <div class="col-md-12">
            <div class="panel panel-primary">
            </div>
        </div>
    </div>
    <div class="row pt-4">
        <div class="col-md-10 col-12 text-left">
            <h2 class="col-12" style="position: absolute; margin-left: 1%;" id="tituloDocumentosLegales">TAG General </h2>
        </div>
        <div class="col-12">
            <div class="row">
                <div class="col-6">
                    </div>
                <div class="col-3">
                    <label id="lblFiltro">Nombre Tag Examen : </label>
                    <input type="text" class="form-control" id="txtFiltroTagExamen" maxlength="25" />
                </div>
                <div class="col-3 pt-4">
                    <input type="button" value="BUSCAR TAG EXAMEN" class="btn btn-primary" style="min-width: 150px !important" onclick="BuscarTag()" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <input type="button" value="Nuevo Tag Examen" style="min-width: 150px" onclick="AbrirAgregarTag(0)" data-toggle="modal" data-target="#modalUsuario" class="btn btn-filter" />
        </div>
    </div>
    <div class="row">
        <div class="col-2 pt-3">
            &nbsp;
        </div>
        <div class="col-8 pt-3">
            <table style="width: 100% !important; overflow-y: scroll" class="table table-striped table">
                <thead>
                    <tr>
                        <th style="width: 10%" class="text-left">#
                                        </th>
                        <th style="width: 30%" class="text-left">Tag Examen
                                        </th>
                        <th style="width: 15%" class="text-left">Fecha Creacion
                                        </th>
                        <th style="width: 20%" class="text-left">Usuario Creacion
                                        </th>
                        <th style="width: 15%" class="text-left oculta-columna">Estado
                                        </th>
                        <th style="width: 10%" class="text-center">&nbsp;
                                        </th>
                    </tr>
                </thead>
                <tbody id="tbDespliegueTag">
                </tbody>
            </table>
        </div>
        <div class="col-2 pt-3">
            &nbsp;
        </div>
    </div>

    <div class="modal fade" id="modalAgregarTag">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Agregar Tag Examen</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <b>
                                <label class="col-12">Nombre Tag Examen</label></b>
                            <input type="text" id="txtNombreTag" class="form-control" />
                        </div>
                        <div class="col-md-2">
                            <b>
                                <label class="col-12">Estado</label></b>
                            <select id="ddlVigente" class="form-control">
                                <option value="1">Vigente</option>
                                <option value="0">No Vigente</option>
                            </select>
                        </div>
                        <div class="col-md-2 pt-4">
                            <input type="button" value="ACEPTAR" id="btnAceptaTag" class="btn btn-filter" onclick="" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    &nbsp;
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

    <script type="text/javascript">
        $(document).ready(function () {
            BuscarTag();
        });

        function AbrirAgregarTag(id) {
            $("#txtNombreTag").val("");
            $("#ddlVigente").val("1");
            $("#modalAgregarTag").modal("show");

            if (id == 0)
                $("#btnAceptaTag").attr("onclick", "Insertar()");
            else {
                GetTag(id);
                $("#btnAceptaTag").attr("onclick", "Editar(" + id + ")");
            }
        }

        function Insertar() {

            var nombreTag = $("#txtNombreTag").val();
            var vigenciaTag = $("#ddlVigente").val();

            var jsdata = '{ nombre :"' + nombreTag + '", vigente :' + vigenciaTag + ' }';

            $.ajax({
                type: "POST",
                url: "../Configuracion/TagGeneralExamen.aspx/Insertar",
                contentType: "application/json; charset=utf-8",
                data: jsdata,
                datatype: "json",
                async: false,
                success: function (data) {
                    $("#modalAgregarTag").modal('hide');
                    AbrirMensajeTagExamen(data.d.Mensaje);
                    BuscarTag();
                },
                error: function () {

                }
            });

        }

        function BuscarTag() {

            var nombreTag = $("#txtFiltroTagExamen").val();
            $("#tbDespliegueTag").html('');

            var html = '';

            $.ajax({
                type: "GET",
                url: "../Configuracion/TagGeneralExamen.aspx/Listar",
                contentType: "application/json; charset=utf-8",
                data: { 'nombre': nombreTag },
                datatype: "json",
                async: false,
                success: function (data) {

                    if (data.d.Ejecutado) {
                        $.each(data.d.Data, function (id, value) {
                            html += '<tr>' +
                                '<td>' + value.Id + '</td>' +
                                '<td>' + value.Nombre + '</td>' +
                                '<td>' + value.FechaCreacionText + '</td>' +
                                '<td>' + value.UsuarioCreacion + '</td>' +
                                '<td class="oculta-columna">' + value.VigenteText + '</td>' +
                                '<td class="text-center">' +
                                '<a href="javascript:AbrirAgregarTag(' + value.Id + ')">' +
                                '<img src="../icon/guardar.png" title="Modificar Tag" style="max-width: 25px" />' +
                                '</a>' +
                                '</td>' +
                                '</tr>';
                        });
                    }
                    else {
                        html += '<tr>' +
                            '<td colspan="6" class="text-center"><label>No existen Tag Examenes</label></td>' +
                            '</tr>';
                    }
                    $("#tbDespliegueTag").html(html);

                },
                error: function () {

                }
            });
        }

        function GetTag(id) {           

            $.ajax({
                type: "GET",
                url: "../Configuracion/TagGeneralExamen.aspx/Get",
                contentType: "application/json; charset=utf-8",
                data: { 'id': id },
                datatype: "json",
                async: false,
                success: function (data) {

                    if (data.d.Ejecutado) {
                        $("#txtNombreTag").val(data.d.Data.Nombre);
                        $("#ddlVigente").val(data.d.Data.Vigente);
                    }
                    else {
                        $("#modalAgregarTag").modal('hide');
                        AbrirMensajeTagExamen("Hubo un problema al cargar tag examen");
                    }
  
                },
                error: function () {

                }
            });
        }

        function Editar(idTag) {

            var nombreTag = $("#txtNombreTag").val();
            var vigenciaTag = $("#ddlVigente").val();

            var jsdata = '{ nombre :"' + nombreTag + '", vigente :' + vigenciaTag + ', id :' + idTag + ' }';

            $.ajax({
                type: "POST",
                url: "../Configuracion/TagGeneralExamen.aspx/Update",
                contentType: "application/json; charset=utf-8",
                data: jsdata,
                datatype: "json",
                async: false,
                success: function (data) {
                    $("#modalAgregarTag").modal('hide');
                    AbrirMensajeTagExamen(data.d.Mensaje);
                    BuscarTag();
                },
                error: function () {

                }
            });

        }

        function AbrirMensajeTagExamen(mensaje) {
            $("#modalMensajeInfoTag").modal("show");
            $("#lblMensajeInfoTag").text(mensaje);
        }

        function CerrarMensajeagExamen() {
            $("#modalMensajeInfoTag").modal("hide");
        }
    </script>
</asp:Content>
