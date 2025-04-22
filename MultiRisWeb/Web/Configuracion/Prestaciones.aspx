<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Prestaciones.aspx.cs" Inherits="MultiRisWeb.Web.Configuracion.Prestaciones" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Master.css" rel="stylesheet" />
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />

        <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
            <h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Prestacíones</h2> 
            
            <article style="text-align:left; float:right; margin-left:10px; margin-right:10px;">
                <label id="lblFiltro"> Filtro: </label>
                <asp:TextBox runat="server" CssClass="form-control fecha" ID="txtFiltro"></asp:TextBox>
            </article>
                <br />
                <br />
                <br />
            <article>
                <%--<asp:Button runat="server" CssClass="btn btn-clear" ID="btnCrearPrestacion" OnClick="btnCrearPrestacion_Click" data-target="#modalCrearPrestacion" Text="Crear Prestacion" style="float:left; margin-left:1%;"/>--%>
                <a href="#" id="btnAsignar" class="btn btn-clear" style="float:left; margin-left:1%;" onclick="EstudiosAsignados();" data-toggle="modal" data-target="#modalCrearPrestacion" title="Asignar">Crear Tiempo Institucion </a>

                <asp:Button runat="server" CssClass="btn btn-filter" ID="btnFiltrar" OnClick="btnFiltrar_Click" Text="BUSCAR" style="float:right; margin-right:10px;"/>
            </article>
            <br />
            <br />
        </div>
        <article style="margin: 1% 1% 1% 1%; /* 10px arriba, 3px derecha, 30px abajo, 5px izquierda ">
            <asp:GridView runat="server" Width="100%" ID="gvDatos" AutoGenerateColumns="false" CssClass="table table-striped table-dark table-hover" EmptyDataText="Sin Resultados" AllowPaging="True" AllowSorting="true" OnSorting="gvDatos_Sorting" PageSize="22"
                OnPageIndexChanging="gvDatos_PageIndexChanging">
                <HeaderStyle Height="5px"/>
                <Columns>
                    <asp:BoundField DataField="id_prestacion" HeaderText="ID Prestacíon" SortExpression="idPrestacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="id_prestacion_remoto" HeaderText="ID Prestacíon Remoto" SortExpression="id_prestacion_remoto" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField visible="false" DataField="aetitle" HeaderText="Aetitle" SortExpression="aetitle" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="nombreInstitucion" HeaderText="Nombre Institucion" SortExpression="nombreInstitucion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="nombrePrestacion" HeaderText="Nombre Prestacíon" SortExpression="nombrePrestacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField visible="false" DataField="oit" HeaderText="Oit" SortExpression="oit" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="codigo" HeaderText="Codigo" SortExpression="codigo" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />                    
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <%# String.Format("<a data-toggle='modal' title='Ver Datos del Examen' data-target='#modalInformarResumido' href='#' onClick=''><img src='../icon/informarA.png' style='width: 23px' /></a>", Eval("id_prestacion"), Eval("id_prestacion_remoto"), Eval("nombreInstitucion"), Eval("nombrePrestacion"), Eval("oit"), Eval("codigo"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
            </asp:GridView>
        </article>
    </section>

    <%--MODAL CREAR PRESTACÍON--%>
    <div class="modal fade" id="modalCrearPrestacion">
        <div class="modal-dialog modal-s" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Crear Prestacíon</b></label>
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                </div>
                <div class="modal-body">      
                    <div class="form-group col-xs-3">
                        <label>Id Prestacion Remota</label>
                        <asp:TextBox id="txtIdPrestacionRemotaAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Nombre Institucion</label>
                        <asp:DropDownList ID="lblNombreInstitucionAgregar" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Nombre Prestacíon</label>
                        <asp:TextBox id="txtNombrePrestacionAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Codigo</label>
                        <asp:TextBox id="txtcodigoAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
<%--                    <asp:LinkButton runat="server" ID="LinkButton2" OnClick="LinkButton2_Click" class="btn btn-primary" ToolTip="">Crear Prestacíon</asp:LinkButton>--%>

                    <a href="#" id="aCancelarComentario2" class="btn btn-primary btn-clear" style="width: 130px; border-color: rgb(101, 96, 95)" data-dismiss="modal">
                    <label style="margin-left: 10px; cursor: pointer; margin-top: 4px" class="lblbtn">Cancelar</label></a>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <%--MODAL UPDATE PRESTACÍON--%>
    <div class="modal fade" id="modalModificarPrestacion">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Modificacion Prestacíon</b></label>
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                </div>
                <div class="modal-body">
                    <div class="form-group col-xs-3">
                        <label>ID Prestaciíon</label>
                        <asp:TextBox id="txtIDPrestacionBloqueadoModificar" runat="server" tabindex="1"  ReadOnly="true" CssClass="form-control" style="position:absolute; width:94%;"></asp:TextBox>
                        <asp:TextBox id="txtIDPrestacionModificar" runat="server" Text="" tabindex="-1" CssClass="form-control"></asp:TextBox>
                    </div>
                    
                    <div class="form-group col-xs-3">
                        <label>Id Prestacion Remota</label>
                        <asp:TextBox id="txtIdPrestacionRemotaModificar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Nombre Institucion</label>
                        <asp:DropDownList ID="lblNombreInstitucionModificar" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Nombre Prestacíon</label>
                        <asp:TextBox id="txtNombrePrestacionModificar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Codigo</label>
                        <asp:TextBox id="txtCodigoModificar" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" ID="LinkButton1" OnClick="LinkButton1_Click" class="btn btn-danger" ToolTip="">Modificar Prestacíon</asp:LinkButton>

                    <a href="#" id="aCancelarComentario" class="btn btn-primary btn-clear" style="width: 130px; border-color: rgb(101, 96, 95)" data-dismiss="modal">
                        <label style="margin-left: 10px; cursor: pointer; margin-top: 4px" class="lblbtn">Cancelar</label></a>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>
    <script src="../js/Prestaciones.js"></script>
    <script src="../js/evitarReenvio.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

            $(function () {
                $("table tr").dblclick(function () {
                    var idPrestacion = $(this).find("td:eq(0)").text();
                    var idPrestacionRemota = $(this).find("td:eq(1)").text();
                    var nombreInstitucion = $(this).find("td:eq(2)").text();
                    var nombrePrestacion = $(this).find("td:eq(3)").text();
                    var Codigo = $(this).find("td:eq(4)").text();

                    $('#txtIDPrestacionModificar').val(idPrestacion)
                    $('#txtIDPrestacionBloqueadoModificar').val(idPrestacion)
                    $('#txtIdPrestacionRemotaModificar').val(idPrestacionRemota)
                    $('#lblNombreInstitucionModificar').val(nombreInstitucion)
                    $('#txtNombrePrestacionModificar').val(nombrePrestacion)
                    $('#txtCodigoModificar').val(Codigo)

                    $('#modalModificarPrestacion').modal('show');

                    editarPrestaciones(idPrestacion, idPrestacionRemota, nombreInstitucion, nombrePrestacion, Codigo);
                });
            });
        });
    </script>

</asp:Content>