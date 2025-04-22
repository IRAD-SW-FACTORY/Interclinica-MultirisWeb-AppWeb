<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="MonitoreoDeTiempo.aspx.cs" Inherits="MultiRisWeb.Web.Gestion.MonitoreoDeTiempo" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <link href="../css/ListaExamen.css" rel="stylesheet" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="row">
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row" style="float: left; margin-top: 175px">
                <div class="col-md-12" style="font-weight: bold !important;">
                    <div style="margin-top: 10px; overflow-x: auto">
                        <br />
                        <asp:GridView runat="server" Width="100%" ID="gvDatos" AutoGenerateColumns="false" CssClass="table table-striped table-dark table-hover" EmptyDataText="Sin Resultados" AllowPaging="false" AllowSorting="true" OnSorting="gvDatos_Sorting" PageSize="50"
                            OnPageIndexChanging="gvDatos_PageIndexChanging" OnRowDataBound="gvDatos_RowDataBound">
                            <HeaderStyle Height="5px" />
                            <Columns>                        
                                <asp:BoundField DataField="Porcentaje" HeaderText="R" SortExpression="Porcentaje" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver"  HeaderStyle-Width="1%"/>
                                <asp:TemplateField HeaderText="ATENC." SortExpression="nombre_tipo_urgencia" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <ItemTemplate>
                                        <%# String.Format(Eval("antecedentes_clinicos").ToString() != "" ? "<img src='../img/comentarioTM.png' width='23px' data-toggle='tooltip' data-placement='top' title='{0}'/>": "", Eval("antecedentes_clinicos") )%>
                                        <%# String.Format(Eval("nombre_tipo_urgencia").ToString() == "Urgencia" ? "<span style='color: red'>{0}</span>" : "<span>{0}</span>", Eval("nombre_tipo_urgencia")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               
                                <asp:BoundField DataField="institucion" HeaderText="INSTITUCIÓN" SortExpression="institucion" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                                <asp:BoundField DataField="usernameRadiologo" HeaderText="MÉDICO" SortExpression="usernameRadiologo" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
  
                                <asp:TemplateField HeaderText="DESCRIPCIÓN" SortExpression="DESCRIPCIÓN" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <ItemTemplate>
                                        <%# String.Format(Eval("descripcion").ToString().ToUpper(), Eval("descripcion") )%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TIEMPO" HeaderText="TIEMPO" SortExpression="TIEMPO" ItemStyle-HorizontalAlign="center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" HeaderStyle-Width="7%"/>
                                <asp:TemplateField HeaderText="FECHA EXAMEN" SortExpression="fechaexamen" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("fechaexamen")).ToString("dd-MM-yyyy HH:mm") %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FECHA ASIGNACIÓN" SortExpression="fechaasignacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("fechaasignacion")).ToString("dd-MM-yyyy HH:mm") %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="160px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FECHA VALIDACION" SortExpression="fechavalidacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("fechavalidacion")).ToString("dd-MM-yyyy HH:mm") %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" />
                                </asp:TemplateField>
                               <%-- FECHA VALIDACION --%>
                                <%--<asp:BoundField DataField="fecha_validacion" HeaderText="FECHA VALIDACION" SortExpression="fecha_validacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" HeaderStyle-Width="160px"/>--%>

                                <asp:BoundField DataField="numeroacceso" HeaderText="#ACC" SortExpression="numeroacceso" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />

                                <asp:BoundField DataField="idpaciente" HeaderText="PACIENTE" SortExpression="idpaciente" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <HeaderStyle Width="120px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="NOMBRE PACIENTE" SortExpression="nombreFull" ControlStyle-Font-Bold="true" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver">
                                    <ItemTemplate>
                                        <%# Eval("nombreFull").ToString().Replace("^", " ") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="edad" HeaderText="EDAD" SortExpression="edad" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                                
                                <asp:BoundField DataField="modalidad" HeaderText="MOD." SortExpression="modalidad" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                                
                                <asp:BoundField DataField="nombre_estado_examen" HeaderText="ESTADO" SortExpression="nombre_estado_examen" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                                <asp:TemplateField HeaderText="Asignar" Visible="true">
                                    <HeaderTemplate>
                                        <%--acaaaaaaaaa--%>
                                        <ul class="nav navbar-nav">
                                            <li class="dropdown" id="pruba3">
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">                                          
                                                    <asp:Label runat="server" style="color:Silver; margin-top:1%;" CssClass="pagination-ys" Height="1%"><img src='../img/menuBar.png' style='width: 15px' /></asp:Label>
                                                </a>
                                                <ul class="dropdown-menu" style="background-color:#676C6F !important; border-color: white; color: white;" width: 150px; background-size: 80px;">
                                                    <li style=" width: 150px;">
                                                        <a data-toggle='modal' title='Seleccionar Todo' onclick="SeleccionarTodo();" style="color:white; font-size: 12px;" data-target='#' href='#' CssClass="form-control-ddl">&nbsp;&nbsp;<img style='width: 12px' src="../img/circulo.png" />&nbsp;Seleccionar Todo</a>
                                                        <br />
                                                        <a data-toggle='modal' title='Deseleccionar Todo' onclick="DeseleccionarTodo();" style="color:white; font-size: 12px;" data-target='#' href='#' CssClass="form-control-ddl">&nbsp;&nbsp;<img style='width: 12px' src="../img/circulo.png" />&nbsp;Deseleccionar Todo</a>
                                                        <br />
                                                        <a data-toggle='modal' title='Asignar' style="color:white; font-size: 12px;" onclick="EstudiosAsignados(); " data-target="#modalAsignar" href='#' CssClass="form-control-ddl">&nbsp;&nbsp;<img style='width: 12px' src="../img/circulo.png" />&nbsp;Asignar</a>
                                                    </li>
                                                </ul>
                                            </li>
                                        </ul>
                                       <%-- <%# String.Format("<a href='#' onclick='SeleccionarTodo();' class='btn btn-filter' title='Seleccionar Todo' />Sel. Todo</a>")%>
                                        <%# String.Format("<a href='#' onclick='DeseleccionarTodo();' class='btn btn-filter' 'Deseleccionar Todo' />Des. Todo</a>")%>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# string.Format("<input type='checkbox' class='chkGridView' name='chkGridView' id='chk{0}'>", Eval("id_ris_examen")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                            <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                            <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 0px; float: left; height: 115px; position: fixed; background-color: #404848">
                <div style="width: 99%; margin-left: 1%; margin-top: 60px; height: 1px; background-color: #404848;"></div>
                <div class="col-md-12" style="background-color: #404848">
                    <div style="width: 86%; float: left">
                        <h8 style="margin-left:9px; color:#F39555;">Gestión>Monitoreo de Tiempo</h8>
                        <br />
                        <div style="width: 100%; float: left">
                            <table style="margin-top: 5px; float: left; width: 1400px;">
                                <tr>
                                    <td style="text-align: center">INSTITUCIÓN</td>
                                    <td></td>
                                    <td style="text-align: center" colspan="2" id="FechasExamenInforme" runat="server"></td>
                                    <td></td>
                                    <td style="text-align: center">PERIODO</td>
                                    <td></td>
                                    <td style="text-align: center">MODALIDAD</td>
                                    <td></td>
                                    <td style="text-align: center">ATENCIÓN</td>
                                    <td></td>
                                    <td style="text-align: center">MÉDICO</td>
                                    <td></td>
                                    <td style="text-align: center">ESTADO EXAMEN</td>
                                    <%--<td style="text-align: center">ESTADO INFORME(*)</td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ListBox runat="server" ID="Institucion" Width="130px" SelectionMode="Multiple" CssClass="form-control-ddl" DataTextField="nombre" DataValueField="id_institucion" Font-Size="12px" Font-Bold="true" AppendDataBoundItems="true"></asp:ListBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <div class="input-group date">
                                            <b>
                                                <asp:TextBox runat="server" ID="txtFechaDesde" autocomplete="ÑÖcompletes" CssClass="form-control fecha" Width="90px" Font-Size="12px" Font-Bold="true"></asp:TextBox>
                                            </b>
                                        </div>
                                        <script type="text/javascript">
                                            $(function () {
                                                var fecha = new Date();
                                                $("#txtFechaDesde").datepicker({
                                                    autoclose: true,
                                                    format: 'dd/mm/yyyy',
                                                    firstDay: 1
                                                });
                                            });
                                        </script>
                                    </td>
                                    <td>
                                        <div class="input-group date">
                                            <asp:TextBox runat="server" ID="txtFechaHasta" autocomplete="ÑÖcompletes" CssClass="form-control fecha" Width="90px" Font-Size="12px" Font-Bold="true"></asp:TextBox>
                                        </div>
                                        <script type="text/javascript">
                                            $(function () {
                                                var fecha = new Date();
                                                $("#txtFechaHasta").datepicker({
                                                    autoclose: true,
                                                    format: 'dd/mm/yyyy',
                                                    firstDay: 1
                                                });
                                            });
                                        </script>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Button runat="server" CssClass="btn btn-primary btn-day" Text="1D" Font-Bold="true" ID="btn1Day" OnClick="btn1Day_Click" OnClientClick="CargaDatosActivo();" />
                                        <asp:Button runat="server" CssClass="btn btn-primary btn-day" Text="3D" Font-Bold="true" ID="btn3Days" OnClick="btn3Days_Click" OnClientClick="CargaDatosActivo();"/>
                                        <asp:Button runat="server" CssClass="btn btn-primary btn-day" Text="1S" Font-Bold="true" ID="btn1Week" OnClick="btn1Week_Click" OnClientClick="CargaDatosActivo();" />
                                        <asp:Button runat="server" CssClass="btn btn-primary btn-day" Text="1M" Font-Bold="true" ID="btn1Month" OnClick="btn1Month_Click" OnClientClick="CargaDatosActivo();"/>
                                        <asp:Button runat="server" CssClass="btn btn-primary btn-day" Text="1A" Font-Bold="true" ID="btn1Year" OnClick="btn1Year_Click" OnClientClick="CargaDatosActivo();"/>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:ListBox runat="server" ID="Modalidad" SelectionMode="Multiple" Width="80px" CssClass="form-control-ddl" DataTextField="nombre" DataValueField="id_modalidad" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true"></asp:ListBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:ListBox runat="server" ID="TipoUrgencia" Width="80px" SelectionMode="Multiple" CssClass="form-control-ddl" DataTextField="nombre" DataValueField="id_tipo_urgencia" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true"></asp:ListBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:ListBox runat="server" ID="Medico" Width="200px" SelectionMode="Multiple" CssClass="form-control-ddl" AppendDataBoundItems="true" DataValueField="id_usuario" DataTextField="nombre_completo" Font-Size="14px" Font-Bold="true"></asp:ListBox>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:ListBox runat="server" ID="Estado" SelectionMode="Multiple" Width="80px" CssClass="form-control-ddl" DataTextField="nombre" DataValueField="id_estado_examen" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true"></asp:ListBox>
                                    </td>
                                  <%--  <td>
                                        <asp:ListBox runat="server" ID="EstadoInforme" SelectionMode="Multiple" Width="80px" CssClass="form-control-ddl" DataTextField="nombre" DataValueField="id_estado_informe" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="EstadoInforme_SelectedIndexChanged"></asp:ListBox>
                                    </td>--%>
                                    <td></td>
<%--                                    <td>
                                        <a href="#" class="btn btn-filter" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 6px;" data-toggle="modal" data-target="#modalAgregarFiltro" onclick="limpiarNombreFiltro(); return false;" title="Crear Filtro">+ FILTRO</a>
                                    </td>--%>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 100%; float: left">
                            <table style="margin-top: 5px; width: 1250px;">
                                <tr>
                                    <td style="text-align: center; width: 20%;">ID PACIENTE</td>
                                    <td style="text-align: center; width: 20%;">NOMBRE</td>
                                    <td style="text-align: center; width: 20%">#ACC</td>
                                    <td style="text-align: center; width: 20%">TIPO EXAMEN</td>
                                    <td style="text-align: center; width: 20%;"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtIdPaciente" autocomplete="ÑÖcompletes" CssClass="form-control form-control-1" MaxLength="15" placeholder="" Font-Size="14px" Font-Bold="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNombre" autocomplete="ÑÖcompletes" CssClass="form-control  form-control-150" MaxLength="20" placeholder="" Font-Size="14px" Font-Bold="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNumeroAcceso" autocomplete="ÑÖcompletes" CssClass="form-control form-control-150" MaxLength="15" placeholder="" Font-Size="14px" Font-Bold="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDescripcion" autocomplete="ÑÖcompletes" CssClass="form-control form-control-150" MaxLength="30" placeholder="" Font-Size="14px" Font-Bold="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:Button runat="server" CssClass="btn btn-filter" OnClick="Unnamed_Click" Text="BUSCAR" OnClientClick="CargaDatosActivo();" />
                                            <asp:Button runat="server" CssClass="btn btn-clear" Width="60px" OnClick="Unnamed_Click1" Text="LIMPIAR" OnClientClick="CargaDatosActivo();" />
<%--                                        <a href="#" id="btnAsignar" class="btn btn-filter" style="visibility: hidden; width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 6px;" onclick="EstudiosAsignados();" data-toggle="modal" data-target="#modalAsignar" title="Asignar">ASIGNAR</a>--%>
                                        </div>
                                    </td>

                                    <td>   
                                      
                                        <%# String.Format(Eval("patologia").ToString() != "" ? "<img src='../icon/alerta.png' width='23px' data-toggle='tooltip' data-placement='top' title='{0}'/>": "", Eval("patologia") )%><%--<asp:BoundField DataField="comentarios" HeaderText="#COM" SortExpression="comentarios" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />--%>  
                                       
                                        <%--<asp:DropDownList runat="server" Height="35px" Width="65px"   ID="dropCantidad"  ForeColor="Gray" BackColor="#FF8C3F" CssClass="form-control" >
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>60</asp:ListItem>
                                            <asp:ListItem>80</asp:ListItem>
                                            <asp:ListItem>100</asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <%--<div class="contenedor" style="width: 14%; text-align: center; float: right; height: 114px;">
                        <div style="width: 100%;">
                            <label style="color: white !important; font-size: 14px !important;" onclick="cargarTablaFiltros(); return false;" data-toggle="modal" data-target="#modalMisFiltros">MIS FILTROS:</label>
                        </div>
                        <div style="width: 100%; height: 90px; overflow: scroll; overflow-x: hidden">
                            <div id="tabla2Filtros" style="float: left"></div>
                        </div>
                    </div>--%>
                </div>
                <div style="width: 99%; margin-left: 1%; margin-top: 4px; height: 1px; background-color: #352D5C;"></div>
            </div>

        </div>
    </div>

    <div class="modal fade" id="modalAsignar">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 14px;"><b>ASIGNAR ESTUDIOS SELECCIONADOS</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <b>
                                <label style="font-size: 13px">Seleccione al Radiologo que desea asignar los estudios seleccionados.</label></b>
                        </div>
                        <div class="col-md-12">
                            <div id="divMedicoRadiologo"></div>
                        </div>
                        <div class="col-md-12">
                            <label style="font-size: 16px; margin-top: 14px;" id="lblCantidadSeleccionados"></label>
                        </div>
                        <div class="col-md-12">
                            <label id="lblMensaje" style="font-size: 16px; color: red; margin-top: 14px;"></label>
                        </div>
                        <div class="col-md-12">
                            <a href="#" class="btn btn-filter" id="btnGuardarAsignacion" style="width: 60px !important; border-radius: 4px 4px 4px 4px !important; padding-top: 6px;" onclick="Asignar();" title="Asignar">ASIGNAR</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalOpciones">
        <div class="modal-dialog modal-xl" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 20px;" class="texto1"><b>DATOS DEL EXAMEN</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <label class="texto1 titulo1"><b>VISUALIZAR DOCUMENTOS</b></label>
                            <br />
                            <img src="../img/SinDocumento.jpg" style="width: 100%;" id="imgOrdenMedica" />
                        </div>
                        <div class="col-md-3">
                            <label class="texto1 titulo1"><b>DATOS DEL PACIENTE</b></label>
                            <table>
                                <tr>
                                    <td><b class="texto1">Nombre Paciente: </b></td>
                                    <td>
                                        <label id="lblModalNombrePaciente"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Id Paciente: </b></td>
                                    <td>
                                        <label id="lblModalIdPaciente"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Institución: </b></td>
                                    <td>
                                        <label id="lblModalInstitucion"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Fecha Examen: </b></td>
                                    <td>
                                        <label id="lblModalFechaExamen"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Descripción: </b></td>
                                    <td>
                                        <label id="lblModalDescripcion"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Medico: </b></td>
                                    <td>
                                        <label id="lblModalMedico"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">Estado: </b></td>
                                    <td>
                                        <label id="lblModalEstado"></label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b class="texto1">EstadoInforme: </b></td>
                                    <td>
                                        <label id="lblModalEstadoInforme"></label>
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-top: 7px; width: 100%; background-color: white; height: 1px;"></div>
                            <label><b class="texto1 titulo1">COMENTARIOS</b></label>
                            <div id="tablaComentarios"></div>
                            <div style="margin-top: 7px; width: 100%; background-color: white; height: 1px;"></div>
                            <label style="margin-top: 10px;"><b class="texto1 titulo1">DOCUMENTOS</b></label>
                            <div id="tablaDocumentos"></div>
                            <div style="margin-top: 7px; width: 100%; background-color: white; height: 1px;"></div>
                        </div>
                        <div class="col-md-3">
                            <label><b class="texto1 titulo1">DESCARGAS</b></label>
                            <table>
                                <tr>
                                    <td><a href="#" id="linkVerImagenes" target="_blank" title="Ver">
                                        <img src="../icon/visor.sl.png" border="0" alt="Radiant" /></a>
                                        <a href="#" id="linkModalRadiant">
                                            <img src="../icon/radiant.png" border="0" alt="Radiant" title="Abrir en Radiant" /></a>
                                        <a href="#" id="linkModalOsirix" title="Abrir en Osrix">
                                            <img src="../icon/osirix.png" border="0" alt="Osirix" /></a>
                                        <a href="#" id="linkModalDescargarExamen" title="Descargar Exámen">
                                            <img src="../icon/zip.png" border="0" alt="Descargar Examen" /></a>
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-top: 15px; width: 100%; background-color: white; height: 1px;"></div>
                            <label style="margin-top: 10px;" class="texto1 titulo1" id="lblPrestaciones"><b>PRESTACIONES EN UN SOLO INFORME</b></label>
                            <div id="dlgPrestacion">
                                <div id="tablaPrestaciones"></div>
                                <div style="width: 100%; text-align: center; margin-top: 10px;">
                                    <input type="button" class="btn btn-primary" style="cursor: pointer;" value="Informar" onclick="informar(); return false;" id="btnInformar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalReabrir">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header">
                    <label style="width: 100%; font-size: 20px;"><b>REABRIR INFORME</b></label>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalInformarResumido">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px">INFORMAR</b></label>
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                </div>
                <div class="modal-body">
                    <div class="row" id="dvInformarResumidoResultado">
                        <div class="col-md-12">
                            <div id="dlgInformesResumido">
                                <div id="tablaInformesResumido"></div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="col-md-12">
                            <div id="dlgPrestacionResumido">
                                <div id="tablaPrestacionesResumido"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="dvInformarResumidoCargando">
                        <div class="col-md-12" style="text-align: center;">
                            <img src="../img/cargando.gif" class="imgGifCargando" />
                        </div>
                    </div>
                    <div class="row" id="dvInformarResumidoError">
                        <div class="col-md-12" style="text-align: center;">
                            <img src="../img/error1.png" class="imgError1" />
                        </div>
                    </div>
                    <div class="row" id="dvImagenes">
                        <div class="col-md-12">
                            <div id="dlgImagenes">
                                <div id="tablaImagenes"></div>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <a href="#" id="aCancelarComentario" class="btn btn-primary btn-clear" style="width: 130px; border-color: rgb(101, 96, 95)" data-dismiss="modal">
                        <label style="margin-left: 10px; cursor: pointer; margin-top: 4px" class="lblbtn">Cancelar</label></a>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <div class="modal fade" id="modalAgregarFiltro">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="width: 100%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1"><b style="font-size: 14px !important; color: white">AGREGAR FILTRO</b></label>
                </div>
                <div class="modal-body">
                    <div class="row" style="text-align: left;">
                        <div class="col-md-12">
                        </div>
                        <div class="col-md-6">
                            <b>
                                <label class="texto1 titulo1" style="color: white">NOMBRE DEL FILTRO</label>
                            </b>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" CssClass="form-control text-control color" MaxLength="15" ID="txtFiltroNombre" placeholder=""></asp:TextBox>
                        </div>
                        <div class="col-md-12" style="font-size: 12px; margin-left: 11px; margin-top: 4px;">
                            <p style="margin-top: 5px;">1.- El filtro se creará en base a las selecciones realizadas. </p>
                            <p style="margin-top: -15px;">2.- Se omiten los siguientes campos: fechas, IdPaciente, Nombre, #Acc, Descripción.</p>
                            <p style="margin-top: -15px;">3.- Maximo de caracteres para el nombre: 15</p>
                        </div>
                        <div class="col-md-12" style="text-align: center;">
                            <asp:Button runat="server" CssClass="btn btn-filter guardarFilter" Width="95px" Text="GUARDAR" ID="btnGuardarFiltro" OnClick="btnGuardarFiltro_Click" />
                        </div>

                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalMisFiltros">
        <div class="modal-dialog modal-s" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div style="width: 100%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1"><b style="color: white; font-size: 14px;">MIS FILTROS</b></label>
                </div>
                <div style="width: 100%; height: 1px; background-color: #FF7500; margin-top: 20px"></div>
                <div class="modal-body">
                    <div class="row" style="text-align: center;">
                        <div class="col-md-12">
                            <div id="dlgFiltros">
                                <div id="tablaFiltros"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <div class="modal fade" id="modalAddendum">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div style="width: 100%; text-align: center;">
                    <label style="width: 100%; font-size: 20px; margin-top: 20px" class="texto1 titulo1"><b style="color: white; font-size: 14px;">ADDENDUMS PENDIENTES</b></label>
                </div>
                <div style="width: 100%; height: 1px; background-color: #FF7500; margin-top: 20px"></div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div id="divAddendums"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

   <article style="width:49%; float: left; margin-left:1%;">
        <asp:Label runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Text="Pagina: "> </asp:Label><asp:Label id="lblNumeroPagina" runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" ></asp:Label> De <asp:Label id="lblCantidadPaginas" runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" ></asp:Label>
        <br />
        <asp:Label runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Height="1%" Text="Cantidad de Registros:"></asp:Label> <asp:Label ID="lblCantidadRegistros" runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Height="1%"></asp:Label>&nbsp;<asp:Label runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Height="1%" Text="De "></asp:Label> <asp:Label ID="lblTotalRegistros" runat="server" style="color:white; margin-top:1%;" CssClass="pagination-ys" Height="1%"></asp:Label> 
    </article>

    <article style="width:49%; float: right; margin-right:1%">
        <asp:LinkButton runat="server" ID="btnSiguiente" OnClick="btnSiguiente_Click" class="pagination-ys" style="margin-bottom:10px; float:right; color:white; margin-bottom:1%;"><i class="fa"></i>Siguiente</asp:LinkButton>
        <asp:LinkButton runat="server" ID="btnAtras" OnClick="btnAtras_Click" class="pagination-ys" style="margin-bottom:10px; float:right; color:white; margin-right:1%; margin-bottom:1%;"><i class="fa"></i>Atras</asp:LinkButton>    
    </article>

        <div class="modal fade" id="modalComentarios">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">COMENTARIOS DEL EXÁMEN</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div id="dglComentarios">
                                <div id="tablacomentarios"></div>
                            </div>
                        </div>
<%--                        <div class="col-md-12">
                            <br />
                            <textarea class="form-control" placeholder="comentario" id="txtComentario"></textarea>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <a id="aGuardarComentario" class="btn btn-primary btn-filter" style="width: 130px;">
                                <label style="margin-left: 7px; margin-top: 2px" class="lblbtn">Guardar</label></a>

                            <a href="#" id="aCancelarComentario" class="btn btn-primary btn-clear" style="width: 130px; border-color: #636D6F" data-dismiss="modal">
                                <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cancelar</label></a>
                        </div>--%>
                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>

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


    <script src="../js/multiselect/jquery.multiselect.es.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.min.js"></script>
    <script src="../js/multiselect/jquery.multiselect.min.js"></script>
    <script src="../Complementos/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script>

        $(document).ready(function () {

            $('[data-toggle="tooltip"]').tooltip();

            //$(function () {
            //    $("table tr").dblclick(function () {
            //        var numero_acceso = $(this).find("td:eq(10)").text();
            //        var id_ris_examen = $(this).find("td:eq(11)").text();

            //        //$('#modalInformarResumido').modal('show');

            //        informarResumido(id_ris_examen, numero_acceso);
            //    });
            //});

            cargarTablaFiltrosPrincipales();

            $("#Institucion").multiselect({
                selectedList: 1,
                allSelectedText: '&nbsp;&nbsp;TODOS',
                minWidth: 70,
                checkAllText: 'Todo',
                uncheckAllText: 'Nada',
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                selectedText: '&nbsp;&nbsp;# Seleccionados',
                header: true,
                height: 'auto',
                width: 130
            });

            $("#Modalidad").multiselect({
                selectedList: 1,
                allSelectedText: '&nbsp;&nbsp;TODOS',
                minWidth: 70,
                checkAllText: 'Todo',
                uncheckAllText: 'Nada',
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                selectedText: '&nbsp;&nbsp;# Seleccionados',
                header: true,
                height: 'auto',
                width: 130
            });

            $("#TipoUrgencia").multiselect({
                selectedList: 1,
                allSelectedText: '&nbsp;&nbsp;TODOS',
                minWidth: 70,
                checkAllText: 'Todo',
                uncheckAllText: 'Nada',
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                selectedText: '&nbsp;&nbsp;# Seleccionados',
                header: true,
                height: 'auto',
                width: 130
            });

            $("#Estado").multiselect({
                selectedList: 1,
                allSelectedText: '&nbsp;&nbsp;TODOS',
                minWidth: 70,
                checkAllText: 'Todo',
                uncheckAllText: 'Nada',
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                selectedText: '&nbsp;&nbsp;# Seleccionados',
                header: true,
                height: 'auto',
                width: 130
            });

            $("#EstadoInforme").multiselect({
                selectedList: 1,
                allSelectedText: '&nbsp;&nbsp;TODOS',
                minWidth: 70,
                checkAllText: 'Todo',
                uncheckAllText: 'Nada',
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                selectedText: '&nbsp;&nbsp;# Seleccionados',
                header: true,
                height: 'auto',
                width: 130
            });

            $("#Medico").multiselect({
                selectedList: 1,
                allSelectedText: '&nbsp;&nbsp;TODOS',
                minWidth: 70,
                checkAllText: 'Todo',
                uncheckAllText: 'Nada',
                noneSelectedText: '&nbsp;&nbsp;TODOS',
                selectedText: '&nbsp;&nbsp;# Seleccionados',
                header: true,
                height: 'auto',
                width: 130
            });
        });
    </script>
    <%--<script src="../Complementos/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>--%>
    <script src="../js/MonitoreoDeTiempo.js"></script>
</asp:Content>