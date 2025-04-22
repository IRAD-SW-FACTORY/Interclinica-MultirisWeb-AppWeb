<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="MultiRisWeb.Web.MaestroFiltro.Buscador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/jquery-ui.css">
    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>  
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
    <script src="../js/FiltroBuscador.js"></script>
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
    <fieldset>
        <legend class="pl-3">Buscador Filtros Listar Examen Profesionales</legend>
        <div class="row">
            <div class="col-md-2 col-12">
                <label class="col-12 p-0">Profesional</label>
                <select class="form-control" id="ddlProfesional"></select>
            </div>
            <div class="col-md-1 col-12">
                <label class="col-12 p-0">Estado</label>
                <select class="form-control" id="ddlEstado">
                    <option value="-1">TODOS</option>
                    <option value="1">VIGENTES</option>
                    <option value="0">NO VIGENTES</option>
                </select>
            </div>
            <div class="col-2 p-4">
                <input type="button" class="btn btn-filter m-2" style="min-width: 100px !important" value="BUSCAR FILTRO" onclick="Listar()" />
                <asp:Button ID="btnCrearFiltro" runat="server" CssClass="btn btn-filter m-2" style="min-width: 100px !important" Text="CREAR FILTRO" OnClick="btnCrearFiltro_Click" />                
            </div>
        </div>
    </fieldset>
    <fieldset>
        <legend class="pl-3">Listado Filtros Profesionales</legend>
        <div class="row">
            <div class="col-12">
                <table style="width: 100% !important; overflow-y: scroll" class="table table-striped table-dark table-hover">
                    <thead>
                        <tr>
                            <th style="width: 30%; background-color: #352D5C !important" class="text-center">Filtro</th>                             
                            <th style="width: 10%; background-color: #352D5C !important" class="text-center">Estado</th>
                            <th style="width: 10%; background-color: #352D5C !important" class="text-center">Cantidad Uso</th>
                            <th style="width: 20%; background-color: #352D5C !important" class="text-center">Fecha Ult. Acceso</th>
                            <th style="width: 10%; background-color: #352D5C !important" class="text-center">N° Profesionales</th>
                            <th style="width: 20%; background-color: #352D5C !important" class="text-center">Acciones</th>
                        </tr>
                    </thead>
                    <tbody id="tbFiltros">
                    </tbody>
                </table>
            </div>
        </div>
    </fieldset>
</asp:Content>
