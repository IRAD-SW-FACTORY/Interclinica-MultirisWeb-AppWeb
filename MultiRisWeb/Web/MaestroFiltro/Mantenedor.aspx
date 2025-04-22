<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Mantenedor.aspx.cs" Inherits="MultiRisWeb.Web.MaestroFiltro.Mantenedor" %>
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
    <script src="../js/FiltroMantenedor.js?v7"></script>
    <style>
        .ui-widget {
            width: 240px !important;
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
    <div class="row pt-5">
        <div class="col-12">
            &nbsp;
        </div>
    </div>
    <div class="css-div-filtros pt-3">
        <table class="css-table-filtros css-table-filtros-sup css-table-out">
            <tr>
                <td style="text-align: left; margin-left: 5px; width: 200px" class="css-celda-out">NOMBRE FILTRO</td>
                <td style="text-align: left; margin-left: 5px; width: 200px" class="css-celda-out">INSTITUCIÓN</td>
                <td style="text-align: left; width: 150px; margin-left: 8px;">MODALIDAD</td>
                <td style="text-align: left; width: 130px; margin-left: 15px;">ATENCIÓN</td>
                <td style="text-align: left; width: 120px; margin-left: 8px;">ESTADO EXAMEN</td>
            </tr>
            <tr>
                <td class="css-celda-out">
                    <input type="text" id="filtro" class="form-control" style="width: 250px" />
                </td>
                <td class="css-celda-out">
                    <select name="Institucion" id="Institucion" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 200px" multiple="multiple" />
                </td>
                <td class="css-celda-out">
                    <select name="Modalidad" id="Modalidad" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 150px; margin-left: 10px" multiple="multiple" />
                </td>
                <td class="css-celda-out">
                    <select name="Atencion" id="Atencion" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 130px" multiple="multiple" />
                </td>
                <td class="css-celda-out">
                    <select name="EstadoExamen" id="EstadoExamen" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 130px" multiple="multiple" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; margin-left: 5px; width: 200px" class="css-celda-out">USUARIOS FILTRO</td>
                <td style="text-align: left; margin-left: 5px; width: 200px" class="css-celda-out">ESTADO FILTRO</td>
                <td style="text-align: left; width: 150px; margin-left: 8px;"></td>
                <td style="text-align: left; width: 130px; margin-left: 15px;"></td>
                <td style="text-align: left; width: 120px; margin-left: 8px;"></td>
            </tr>
            <tr>
                <td class="css-celda-out">
                    <select name="Usuario" id="Usuario" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 200px" multiple="multiple" />
                </td>
                <td class="css-celda-out">
                    <select name="EstadoFiltro" id="EstadoFiltro" class="form-control" style="font-size: 12px; font-weight: bold; width: 200px">
                        <option value="1">VIGENTE</option>
                        <option value="0">NO VIGENTE</option>
                    </select>
                </td>
                <td style="text-align: left; width: 150px; margin-left: 8px;">
                    <input type="button" class="btn btn-filter m-2" style="min-width: 100px !important" value="ACEPTAR" onclick="InsertOrUpdate()" />
                    <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-filter m-2" Style="min-width: 100px !important" Text="REGRESAR" OnClick="btnRegresar_Click" />
                </td>
                <td style="text-align: left; width: 150px; margin-left: 8px;"></td>
                <td style="text-align: left; width: 150px; margin-left: 8px;"></td>
            </tr>
        </table>       
    </div>  
       <div class="modal fade" id="modalValidador">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">INFORMACIÓN</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12" style="text-align: center !important;">
                            <label style="font-size: 14px !important;" id="lblMensaje" />
                        </div>
                    </div>
                    <div class="row pt-4">
                        <div class="col-12 text-right"> 
                                <input id="cierreModal" type="button" class="btn btn-clear" style="min-width: 100px !important;" value="CERRAR" onclick="CerrarModalValidar()" />
                        </div>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 5px; width: 100%;"></div>
            </div>
        </div>
    </div>
</asp:Content>
