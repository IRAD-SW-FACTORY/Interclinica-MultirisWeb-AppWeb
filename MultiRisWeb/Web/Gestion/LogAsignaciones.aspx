<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="LogAsignaciones.aspx.cs" Inherits="MultiRisWeb.Web.LogAsignaciones" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="//cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables.css" rel="stylesheet" />
    <link href="../Content/DataTablesDateTime.css" rel="stylesheet" />
    <link href="../Content/font-awesome.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
            </div>
        </div>
    </div>
    <section class="main full" >
        <div id="datosBuscar" style="width:100%">
            <br />
            <br />
            <br />
            <h8 style="margin-left:9px; color:#F39555;">Log Asignacion</h8>

            <%--<h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Producción</h2> --%>
            
            <article style="text-align:left; float:right; margin-left:10px; margin-right:10px;">
                <label id="lblFechaTermino"> Fecha Final: </label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control fecha" ID="txtFechaInicio"></asp:TextBox>
            </article>
            <article style="text-align:left; float:right;">
                <label id="lblFechaInicio">Fecha Inicio: </label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control fecha" ID="txtFechaTermino"></asp:TextBox>
            </article>
                <br />
                <br />
                <br />
            <article>
                <asp:Button runat="server" CssClass="btn btn-clear" Width="60px" OnClick="Unnamed_Click" Text="LIMPIAR"  style="float:right; margin-right:10px;" />
                <asp:Button runat="server" CssClass="btn btn-filter" OnClick="Unnamed_Click1" Text="BUSCAR" style="float:right; margin-right:10px;"/>
            </article>
            <br />
            <br />
        </div>
        <article style="margin: 1% 1% 1% 1%; /* 10px arriba, 3px derecha, 30px abajo, 5px izquierda ">
            <asp:GridView runat="server" Width="100%" ID="gvDatos" AutoGenerateColumns="false" CssClass="table table-striped table-dark table-hover" EmptyDataText="Sin Resultados" AllowPaging="false" AllowSorting="true" OnSorting="gvDatos_Sorting" PageSize="22"
                OnPageIndexChanging="gvDatos_PageIndexChanging">
                <HeaderStyle Height="5px"/>
                <Columns>
                    <asp:BoundField DataField="nombreInstitucion" HeaderText="Nombre Institucion" SortExpression="nombreInstitucion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre Usuario" SortExpression="nombreUsuario" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="observacion" HeaderText="Observacion" SortExpression="observacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />               
                </Columns>
                <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
            </asp:GridView>         
        </article>
    </section>

    <article style="width:49%; float: left; margin-left:1%;">
        <asp:Label runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Text="Pagina: "> </asp:Label><asp:Label id="lblNumeroPagina" runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" ></asp:Label>
        <br />
        <%--<asp:Label runat="server" style="color:Silver; margin-top:1%;" CssClass="pagination-ys" Height="1%" Text="Cantidad de Registros:"></asp:Label> <asp:Label ID="lblCantidadRegistros" runat="server" style="color:Silver; margin-top:1%;" CssClass="pagination-ys" Height="1%"></asp:Label>&nbsp;--%><asp:Label runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Height="1%" Text=" Total de registros: "></asp:Label> <asp:Label ID="lblTotalRegistros" runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Height="1%"></asp:Label> 
    </article>

    <article style="width:49%; float: right; margin-right:1%">
        <asp:LinkButton runat="server" ID="btnSiguiente" OnClick="btnSiguiente_Click" class="pagination-ys" style="margin-bottom:10px; float:right; color:Silver; margin-bottom:1%;"><i class="fa"></i>Siguiente</asp:LinkButton>
        <asp:LinkButton runat="server" ID="btnAtras" OnClick="btnAtras_Click" class="pagination-ys" style="margin-bottom:10px; float:right; color:Silver; margin-right:1%; margin-bottom:1%;"><i class="fa"></i>Atras</asp:LinkButton>    
    </article>

     <%--MODAL POPUP--%>
    <div runat="server" class="modal fade" id="modalInicioPopUpHabil">
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
    </div>

            <%--MODAL POPUP--%>
    <div runat="server" class="modal fade" id="modalInicioPopUpNoHabil">
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
    </div>

    <script type="text/javascript">
        $(document).ready(function () {

            var height = $(window).height();

            $('#divPricipal').height(height);
        });
    </script>
</asp:Content>