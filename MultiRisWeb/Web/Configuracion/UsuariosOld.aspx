<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="UsuariosOld.aspx.cs" Inherits="MultiRisWeb.Web.Configuracion.UsuariosOld" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <link href="../css/Master.css" rel="stylesheet" />


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
    <%--           <br />
            <br />
            <br />
    <h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Usuarios</h2>
            <br />
            <br />--%>

            <div id="datosBuscar" style="width:100%">
            <br />
            <br />
            <br />
            <h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Usuarios</h2> 
            
            <article style="text-align:left; float:right; margin-left:10px; margin-right:10px;">
                <label id="lblFiltro">Nombre Usuario : </label>
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

    <div class="row">

        <div class="col-md-3">
            


<%--            <button class="btn btn-primary" id="btnNuevo"  style="width: 136px" onclick="nuevoUsuario();" data-toggle="modal" data-target="#modalUsuario">Nuevo Usuario</button>--%>
            <input id="Button1" type="button" value="Nuevo Usuario" style="width: 136px" onclick="nuevoUsuario();" data-toggle="modal" data-target="#modalUsuario"  class="btn btn-primary" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView runat="server" ID="gvDatos" CssClass="table table-striped table-dark table-hover" AllowPaging="True" AllowSorting="true"
                OnSorting="gvDatos_Sorting" PageSize="10"
                EmptyDataText="Sin Registros" Width="100%" Visible="true" AutoGenerateColumns="false"
                OnPageIndexChanging="gvDatos_PageIndexChanging"
                >
                <Columns>
                    <asp:BoundField DataField="id_usuario" HeaderText="R" SortExpression="id_usuario" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# Eval("nombre").ToString() + " " + Eval("apellido_paterno").ToString() + " " + Eval("apellido_materno").ToString() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nombre_perfil" HeaderText="Perfil" SortExpression="nombre_perfil" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Estado" SortExpression="estado" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("estado").ToString() == "1" ? "Activo" : "Inactivo" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
<%--                <PagerStyle BackColor="#D15137" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#D15137" ForeColor="White" HorizontalAlign="Center" />--%>

                                            <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                            <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />

            </asp:GridView>
        </div>
    </div>

    <div class="modal fade" id="modalUsuario">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b>EDITAR USUARIO</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important;">
                            <table style="width: 100%;" class="table table-striped table-dark">
                                <tr>
                                    <td style="width: 20%">
                                        <b>
                                            <label>Nombre</label></b>
                                    </td>
                                    <td style="width: 80%">
                                        <input type="text" style="width: 100%" id="txtNombre" class="form-control" onkeypress="return palabras(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Apellido Paterno</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtApellidoPaterno" class="form-control" onkeypress="return palabras(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Apellido Materno</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtApellidoMaterno" class="form-control" onkeypress="return palabras(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Estado</label></b>
                                    </td>
                                    <td>
                                        <label>
                                            <input type="radio" name="estado" id="rbtnEstado1" value="1">
                                            Activo</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="estado" id="rbtnEstado0" value="0">
                                            Inactivo</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Username</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%; float: left" id="txtUsername" class="form-control" onkeypress="return username(event)" maxlength="90" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Password</label></b>
                                    </td>
                                    <td>
                                        <input type="password" style="width: 90%; float: left" id="txtPassword" class="form-control" maxlength="90" />
                                        <input type="button" style="width: 10%; float: left; color: white !important;" id="btnShow" onclick="show(); return false;" value="show" class="form-control btn" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Perfil</label></b>
                                    </td>
                                    <td>
                                        <div id="tablaPerfiles"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Rut</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtRut" class="form-control" onkeypress="return rut(event)" maxlength="40" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Email Principal</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtEmailPrincipal" class="form-control" onkeypress="return email(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Email Secundario</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtEmailSecundario" class="form-control" onkeypress="return email(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Telefono Principal</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtTelefonoPrincipal" class="form-control" onkeypress="return telefono(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Telefono Secundario</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtTelefonoSecundario" class="form-control" onkeypress="return telefono(event)" maxlength="90" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Dias Exámenes</label></b>
                                    </td>
                                    <td>
                                        <input type="text" style="width: 100%" id="txtDiasExamenes" class="form-control" onkeypress="return numeros(event)" maxlength="4" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Activar Vocali</label></b>
                                    </td>
                                    <td>
                                        <label>
                                            <input type="radio" name="activarVocali" id="rbtnVocali1" value="1">
                                            SI</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="activarVocali" id="rbtnVocali0" value="0">
                                            NO</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Activar Agente Vocali</label></b>
                                    </td>
                                    <td>
                                        <label>
                                            <input type="radio" name="activarAgenteVocali" id="rbtnAgenteVocali1" value="1">
                                            SI</label>
                                        &nbsp;&nbsp;&nbsp;
                                        <label>
                                            <input type="radio" name="activarAgenteVocali" id="rbtnAgenteVocali0" value="0">
                                            NO</label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        <b>
                                            <label>Visor</label></b>
                                    </td>
                                    <td>
                                        <div id="tablaVisores"></div>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <b>
                                            <label>Instituciones</label></b>
                                    </td>
                                    <td>
                                        <div id="tablaInstituciones"></div>
                                    </td>
                                </tr>
                                  <tr id="trRadiologos" style="display:none;">
                                    <td>
                                        <b>
                                            <label>Radiologos</label></b>
                                    </td>
                                    <td>
                                       
                                        <div id="tablaRadiologos"></div>
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" id="btnGuardar" style="width: 136px">Guardar</button>

<%--                    <asp:Button runat="server" CssClass="btn btn-filter" OnClientClick="CargaDatosActivo();" OnClick="btnBuscar_Click" Text="BUSCAR" />--%>
                </div>
            </div>
        </div>
    </div>


    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
            $(function () {
                $("table tr").dblclick(function () {
                    var id_usuario = $(this).find("td:eq(0)").text();

                    $('#modalUsuario').modal('show');

                    cargarUsuario(id_usuario);

                    $("#btnGuardar").on("click", function () {
                        // lo que queramos realizar
                        guardarUsuario(id_usuario);
                    });
                });
            });




            //$(function () {
            //    $("table tr").dblclick(function () {
            //        var id_usuario = $(this).find("td:eq(0)").text();

            //        //$('#modalUsuario').modal('show');

            //        guardarUsuario(id_usuario);
            //    });
            //});
        });
    </script>
</asp:Content>
