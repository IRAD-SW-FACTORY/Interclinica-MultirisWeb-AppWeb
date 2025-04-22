<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="ControlMenuAcceso.aspx.cs" Inherits="MultiRisWeb.Web.Configuracion.ControlMenuAcceso" ClientIDMode="Static"%>
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

    <script src="../js/ControlMenuAcceso.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="row">
          <br />
         
        <div class="col-md-12">
            <div class="panel panel-primary">
            </div>
        </div>
    </div>

    <section class="main full" >
          <br /><br />
        <h8 style="margin-left:9px; color:#F39555;">Configuración>Control de Menu</h8>
        <div id="datosBuscar" style="width:100%">
              <br />
            <h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Control Menú Acceso</h2> 
            
           <br />
        </div>
        <article style="margin: 1% 1% 1% 1%; /* 10px arriba, 3px derecha, 30px abajo, 5px izquierda ">
            

          <div class="modal-body">      
                    <div class="form-group col-xs-3">
                        <label>Perfil</label>
                          <br />                                       
                          <asp:DropDownList runat="server" Height="35px" Width="300px"  CssClass="form-control" ID="ddrPerfil"   ForeColor="Gray" BackColor="#FF8C3F"/>
                    
                    </div>
               <br />  
                    <div class="form-group col-xs-3">
                        <label CssClass="lbl" >Menu<br />
                        </label>
                        &nbsp;<div id="tablaMenu"></div>
                        <%--MODAL UPDATE PRESTACÍON--%>

                    </div>
                <br />
                   <div class="form-group col-xs-3">
                        <label CssClass="lbl">Sub Menu - Gestión<br />
                        </label>
                        &nbsp;<div id="tablaSubMenu1"></div>
                    </div>
                <br />
                    <div class="form-group col-xs-3">
                        <label CssClass="lbl">Sub Menu - Configuración<br />
                        </label>
                        &nbsp;<div id="tablaSubMenu2"></div>
                    </div>
              <br /><br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
              <input id="btnGuardar" type="button" value="Guardar" style="width: 136px" onclick="guardarControlMenuAcceso();" data-toggle="modal" data-target="#modalUsuario"  class="btn btn-primary" />&nbsp;&nbsp;
               <%--<input id="btnRegresar" type="button" value="Regresar" style="width: 136px"   data-toggle="modal" onclick="VolverSitio();"  data-target="#modalUsuario"  class="btn btn-primary" />--%>
              <asp:Button runat="server" ID="Button1" Text="Regresar" PostBackUrl="~/Web/Examen/ListaExamen.aspx" OnClientClick="CargaDatosActivo();" OnClick="btnRegresar_Click"  CssClass="btn btn-filter" Width="60px" />       
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
            </div>


        </article>
    </section>

    <div class="modal fade" id="modalCrearAccesoControl">
        <div class="modal-dialog modal-s" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Crear Acceso Control</b></label>
                    <%--                        <asp:TextBox id="txtIdPrestacionRemotaAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>--%>
                </div>
                <div class="modal-body">      
                    <div class="form-group col-xs-3">
                        <label>Perfil</label>
<%-- <asp:TextBox id="txtNombrePrestacionAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>--%>
                        <div id="tablaPerfiles"></div>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Estado Perfil</label>
                        <label>
                               <input type="radio" name="estado" id="rbtnEstado" value="1">
                               Activo</label>
                          &nbsp;&nbsp;&nbsp;
                        <label>
                               <input type="radio" name="estado" id="rbtnEstado" value="0">
                             Inactivo</label>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Menu</label>
                        <div id="tablaMenu"></div>
                        <%--<asp:LinkButton runat="server" ID="LinkButton1" OnClick="LinkButton1_Click" class="btn btn-danger" ToolTip="">Modificar Prestacíon</asp:LinkButton>--%>

                    </div>

                    <div class="form-group col-xs-3">
                        <label>Estado Menu</label>
                                                <label>
                               <input type="radio" name="estado" id="rbtnEstadoMenu" value="1">
                               Activo</label>
                          &nbsp;&nbsp;&nbsp;
                        <label>
                               <input type="radio" name="estado" id="rbtnEstadoMenu1" value="0">
                             Inactivo</label>
                    </div>
                   <div class="form-group col-xs-3">
                        <label>Sub Menu</label>
                        <div id="tablaSubMenu"></div>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Estado Sub Menu</label>
                                                <label>
                               <input type="radio" name="estado" id="rbtnEstadoSubMenu" value="1">
                               Activo</label>
                          &nbsp;&nbsp;&nbsp;
                        <label>
                               <input type="radio" name="estado" id="rbtnEstadoSubMenu" value="0">
                             Inactivo</label>
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
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">Modificar Acceso Control</b></label>
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                </div>
                <div class="modal-body">
                    <div class="form-group col-xs-3">
                        <label>Perfil</label>
<%--                        <asp:TextBox id="txtIdPrestacionRemotaAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>--%>
                        <div id="tablaPerfiles"></div>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Estado Perfil</label>
                        <label>
                               <input type="radio" name="estado" id="rbtnEstadoModificar" value="1">
                               Activo</label>
                          &nbsp;&nbsp;&nbsp;
                        <label>
                               <input type="radio" name="estado" id="rbtnEstadoModificar" value="0">
                             Inactivo</label>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Menu</label>
                        <div id="tablaMenu"></div>
                       <%-- <asp:TextBox id="txtNombrePrestacionAgregar" runat="server" Text="" CssClass="form-control"></asp:TextBox>--%>

                    </div>

                    <div class="form-group col-xs-3">
                        <label>Estado Menu</label>
                                                <label>
                               <input type="radio" name="estado" id="rbtnEstadoModificarMenu" value="1">
                               Activo</label>
                          &nbsp;&nbsp;&nbsp;
                        <label>
                               <input type="radio" name="estado" id="rbtnEstadoModificarMenu1" value="0">
                             Inactivo</label>
                    </div>
                   <div class="form-group col-xs-3">
                        <label>Sub Menu</label>
                        <div id="tablaSubMenuMenu"></div>
                    </div>

                    <div class="form-group col-xs-3">
                        <label>Estado Sub Menu</label>
                                                <label>
                               <input type="radio" name="estado" id="rbtnEstadoModificarSubMenu" value="1">
                               Activo</label>
                          &nbsp;&nbsp;&nbsp;
                        <label>
                               <input type="radio" name="estado" id="rbtnEstadoModificarSubMenu" value="0">
                             Inactivo</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<asp:LinkButton runat="server" ID="LinkButton1" OnClick="LinkButton1_Click" class="btn btn-danger" ToolTip="">Modificar Prestacíon</asp:LinkButton>--%>

                    <a href="#" id="aCancelarComentario" class="btn btn-primary btn-clear" style="width: 130px; border-color: rgb(101, 96, 95)" data-dismiss="modal">
                        <label style="margin-left: 10px; cursor: pointer; margin-top: 4px" class="lblbtn">Cancelar</label></a>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>
     <script src="../js/ControlMenuAcceso.js"></script>

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