<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Instituciones.aspx.cs" Inherits="MultiRisWeb.Web.Configuracion.Instituciones" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/Master.css" rel="stylesheet" />
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<%--    <link href="../css/Informar.css" rel="stylesheet" />--%>
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
            <h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Instituciones</h2> 
            
            <article style="text-align:left; float:right; margin-left:10px; margin-right:10px;">
                <label id="lblFiltro">Nombre Institución : </label>
                <asp:TextBox runat="server" CssClass="form-control fecha" ID="txtFiltro"></asp:TextBox>
            </article>
                <br />
                <br />
                <br />
            <article>
                <%--<asp:Button runat="server" CssClass="btn btn-clear" ID="btnCrearPrestacion" OnClick="btnCrearPrestacion_Click" data-target="#modalCrearPrestacion" Text="Crear Prestacion" style="float:left; margin-left:1%;"/>--%>
                <%--<a href="#" id="btnAsignar" class="btn btn-clear" style="float:left; margin-left:1%;" onclick="EstudiosAsignados();" data-toggle="modal" data-target="#modalAgregarInstitucion" title="Asignar">Crear Institución </a>--%>

                <asp:Button runat="server" CssClass="btn btn-filter" ID="btnFiltrar" OnClick="btnFiltrar_Click" Text="BUSCAR" style="float:right; margin-right:10px;"/>
            </article>
            <br />
            <br />
        </div>

        <div class="col-md-3">
<%--            <button class="btn btn-primary" id="btnNuevo"  style="width: 136px" onclick="nuevoUsuario();" data-toggle="modal" data-target="#modalUsuario">Nuevo Usuario</button>--%>
            <input id="Button1" type="button" value="Nueva Institución" style="width: 136px" onclick="nuevaInstitucion();" data-toggle="modal" data-target="#modalUsuario"  class="btn btn-primary" />
        </div>
        <article style="margin: 1% 1% 1% 1%; /* 10px arriba, 3px derecha, 30px abajo, 5px izquierda ">
            <asp:GridView runat="server" Width="100%" ID="gvDatos" AutoGenerateColumns="false" CssClass="table table-striped table-dark table-hover"
                EmptyDataText="Sin Resultados" AllowPaging="true" AllowSorting="true" OnSorting="gvDatos_Sorting" PageSize="10"
                OnPageIndexChanging="gvDatos_PageIndexChanging">
                <HeaderStyle Height="5px"/>
                <Columns>
                    <asp:BoundField DataField="id_institucion" HeaderText="R" SortExpression="id_institucion" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="aetitle" HeaderText="Aetitle" SortExpression="aetitle" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Estado" SortExpression="estado" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("estado").ToString() == "1" ? "Activo" : "Inactivo" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
            </asp:GridView>
        </article>
    </section>

    <div class="modal fade" id="modalAgregarInstitucion">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Crear Institución</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important;">
                            <table style="width:100%;" Class="table">
                                <tr>
                                    <td style="width: 20%">
                                        <b><label>Nombre Institución</label></b>
                                    </td>
                                    <td style="width: 80%">
                                        <asp:TextBox id="txtNombreInstitucion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" runat="server" style="width:100%" id="txtNombreInstitucionAgregar" class="form-control" maxlength="90"/>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Descripción</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtdescripcion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" style="width:100%" runat="server" id="txtdescripcionAgregar" class="form-control" maxlength="240"/>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Estado</label></b>
                                    </td>
                                    <td>
<%--                                        <asp:RadioButton id="rbActivo" Text="Activo" GroupName="RadioGroup1" runat="server" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton id="rbInactivo" Text="Inactivo" GroupName="RadioGroup1" runat="server" />--%>
                                        <label>
                                            <input type="radio" name="estado" id="rbtnEstado1" value="1">
                                            Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="estado" id="rbtnEstado0" value="0">
                                            Inactivo</label>

                                        <%--<label><input type="radio" name="estado" runat="server" id="rbtnEstado1Agregar" value="1"> Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label><input type="radio" name="estado" runat="server" id="rbtnEstado0Agregar" value="0"> Inactivo</label>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>URL Pagina</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtUrlPagina" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Aetitle</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtAetitle" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>URL Descarga</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtUrlDescarga" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url Informe</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtUrlInforme" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url Base</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtUrlBase" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url Informe OIT</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtUrlInformeOIT" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url WS Institución</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtUrlWSInstitucion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Tipo de Conexión</label></b>
                                    </td>
                                    <td>
<%--                                        <asp:RadioButton id="rbApiRest" Text="Api Rest" GroupName="RadioGroup2" runat="server" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton id="rbWebServices" Text="Web Services" GroupName="RadioGroup2" runat="server" />--%>


                                        <label>
                                            <input type="radio" name="RadioGroup2" id="rbApiRest" value="1">
                                            Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="RadioGroup2" id="rbWebServices" value="2">
                                            Inactivo</label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Addendum</label></b>
                                    </td>
                                    <td>
<%--                                        <asp:RadioButton id="rbSiAddendum" Text="Si" GroupName="RadioGroup3" runat="server" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton id="rbNoAddendum" Text="No" GroupName="RadioGroup3" runat="server" />--%>

                                                                                <label>
                                            <input type="radio" name="RadioGroup3" id="rbSiAddendum" value="1">
                                            Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="RadioGroup3" id="rbNoAddendum" value="0">
                                            Inactivo</label>
                                   </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Formulario Unico</label></b>
                                    </td>
                                    <td>
<%--                                        <asp:RadioButton id="rbFormularioSi" Text="Si" GroupName="RadioGroup4" runat="server" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton id="rbFormularioNo" Text="No" GroupName="RadioGroup4" runat="server" />--%>

                                                                                                                        <label>
                                            <input type="radio" name="RadioGroup4" id="rbFormularioSi" value="1">
                                            Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="RadioGroup4" id="rbFormularioNo" value="0">
                                            Inactivo</label>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <b><label>Institución Padre</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtInstitucionPadre" runat="server" Text="" CssClass="form-control"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Logo</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtLogo" runat="server" Text="" CssClass="form-control"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <b><label>Estructura HTML</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtEstruturaHTML" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <b><label>Margen Superior</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtMargenSuperior" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Margen Inferior</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtMargenInferior" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>

                               <tr>
                                    <td>
                                        <b><label>Margen Izquierda</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtMargenIzquierda" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                               <tr>
                                    <td>
                                        <b><label>Margen Derecha</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtMargenDerecha" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>

                               <tr>
                                    <td>
                                        <b><label>Codigo QR</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtCodigoQA" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" style="width:100%" runat="server" id="txtUrlInformeOITAgregar" class="form-control" maxlength="240"/>--%>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <b><label>Tipo Becado</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtTipoBecado" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" style="width:100%" runat="server" id="txtUrlInformeOITAgregar" class="form-control" maxlength="240"/>--%>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <b><label>Grupo</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtGrupo" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" style="width:100%" runat="server" id="txtUrlInformeOITAgregar" class="form-control" maxlength="240"/>--%>
                                    </td>
                                </tr>

                                 <tr>
                                    <td>
                                        <b><label>Correo Patologia</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtCorreoPatologia" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" style="width:100%" runat="server" id="txtUrlInformeOITAgregar" class="form-control" maxlength="240"/>--%>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <b><label>Correo Patologia CC</label></b>
                                    </td>
                                    <td>
                                        <asp:TextBox id="txtCorreoPatologiaCC" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" style="width:100%" runat="server" id="txtUrlInformeOITAgregar" class="form-control" maxlength="240"/>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<button class="btn btn-primary" id="btnGuardarAgregar" style="width: 136px">Crear Institución</button>--%>
<%--                    <asp:LinkButton runat="server" ID="LinkButton2" OnClick="LinkButton2_Click" class="btn btn-primary" style="margin-bottom:10px; float:right" ToolTip="">Crear Institucion</asp:LinkButton>  --%>

                   <button class="btn btn-primary" id="btnGuardar" style="width: 136px">Guardar</button>
                </div>
            </div>
        </div>
    </div>


    <script src="../js/Prestaciones.js"></script>
    <script src="../js/evitarReenvio.js"></script>
        <script src="../js/Instituciones.js"></script>

    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

            $(function () {
                $("table tr").dblclick(function () {
                    var id_institucion = $(this).find("td:eq(0)").text();

                    $('#modalAgregarInstitucion').modal('show');

                    cargarInstitucion(id_institucion);
                });
            });
        });
    </script>
</asp:Content>
