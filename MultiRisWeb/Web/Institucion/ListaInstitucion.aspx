<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="ListaInstitucion.aspx.cs" Inherits="MultiRisWeb.Web.Institucion.ListaInstitucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ListarInstitucion.js"></script>
    <style>
        .form-control{
            height: 30px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-md-3">
            <button class="btn btn-primary" id="btnNuevo" style="width: 136px" onclick="nuevaInstitucion(); return false;" data-toggle="modal" data-target="#modalInstitucion">Nueva Institución</button>
            <br />
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView runat="server" ID="gvDatos" CssClass="table table-striped table-dark table-hover" AllowPaging="True" AllowSorting="true" OnSorting="gvDatos_Sorting" PageSize="50" EmptyDataText="Sin Registros" Width="100%" Visible="true" AutoGenerateColumns="false">
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
                <PagerStyle BackColor="#D15137" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#D15137" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>

    <div class="modal fade" id="modalInstitucion">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b>EDITAR INSTITUCIÓN</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important;">
                            <table style="width:100%;" Class="table table-striped table-dark">
                                <tr>
                                    <td style="width: 20%">
                                        <b><label>Nombre Institución</label></b>
                                    </td>
                                    <td style="width: 80%">
                                        <input type="text" style="width:100%" id="txtNombreInstitucion" class="form-control" maxlength="90"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Descripción</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtDescripcion" class="form-control" maxlength="240"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Estado</label></b>
                                    </td>
                                    <td>
                                        <label><input type="radio" name="estado" id="rbtnEstado1" value="1"> Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label><input type="radio" name="estado" id="rbtnEstado0" value="0"> Inactivo</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>URL Pagina</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtURLPagina" class="form-control" maxlength="240"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Aetitle</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtAetitle" class="form-control" maxlength="24"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>URL Descarga</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtURLDescarga" class="form-control"maxlength="240"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url Informe</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtURLInforme" class="form-control" maxlength="240"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url Base</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtURLBase" class="form-control" maxlength="240"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Tipo de Conexión</label></b>
                                    </td>
                                    <td>
                                        <label><input type="radio" name="tipoConexion" id="rbtnTipoConexion1" value="1"> Api Rest</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label><input type="radio" name="tipoConexion" id="rbtnTipoConexion2" value="2"> Web Services</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Addendum</label></b>
                                    </td>
                                    <td>
                                        <label><input type="radio" name="addendum" id="rbtnAddendum1" value="1"> SI</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label><input type="radio" name="addendum" id="rbtnAddendum0" value="0"> NO</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Formulario Unico</label></b>
                                    </td>
                                    <td>
                                        <label><input type="radio" name="formularioUnico" id="rbtnFormularioUnico1" value="1"> SI</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label><input type="radio" name="formularioUnico" id="rbtnFormularioUnico0" value="0"> NO</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b><label>Url Informe OIT</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width:100%" id="txtUrlInformeOIT" class="form-control" maxlength="240"/>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" id="btnGuardar" style="width: 136px">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

            $(function () {
                $("table tr").dblclick(function () {
                    var id_institucion = $(this).find("td:eq(0)").text();

                    $('#modalInstitucion').modal('show');

                    cargarInstitucion(id_institucion);
                });
            });
        });
    </script>
</asp:Content>
