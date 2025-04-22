<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="AddendumOld.aspx.cs" Inherits="MultiRisWeb.Web.Examen.Addendum" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
        <!-- INVOX Medical SDK -->
    <script type="text/javascript" src="../../vocali/libs/invox.min.js" charset="UTF-8"></script>

    <!-- Common resources -->
    <script type="text/javascript" src="../../vocali/common/default-connection-info.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../vocali/common/home.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../vocali/common/common.js" charset="UTF-8"></script>
    <link rel="stylesheet" href="../../vocali/common/common.css" />
    <script src="../../vocali/common/custom-elements/loginForm.js"></script>

    <!-- Page resources -->
    <link rel="stylesheet" href="../../vocali/css/style.css" />

    <!-- CKEditor 4 -->
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-ckeditor4/ckeditor/ckeditor.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-ckeditor4/textwriter.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-ckeditor4/main.js" charset="UTF-8"></script>
    <link rel="stylesheet" href="../../vocali/libs/integrations/invox-ckeditor4/style.css" />

    <!-- INVOX Medical - Quick Integrations -->
    <link rel="stylesheet" href="../../vocali/libs/integrations/invox-bar/invox-bar-component.css" />
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-bar/invox-bar-component.min.js" charset="UTF-8"></script>

    <link rel="stylesheet" href="../../vocali/libs/integrations/invox-dialogs/invox-dictionary-component.css" />
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-dialogs/invox-dictionary-component.min.js" charset="UTF-8"></script>

    <link rel="stylesheet" href="../../vocali/libs/integrations/invox-dialogs/invox-templates-component.css" />
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-dialogs/invox-templates-component.min.js" charset="UTF-8"></script>

    <link rel="stylesheet" href="../../vocali/libs/integrations/invox-dialogs/invox-transformations-component.css" />
    <script type="text/javascript" src="../../vocali/libs/integrations/invox-dialogs/invox-transformations-component.min.js" charset="UTF-8"></script>
    <link href="../css/Addendum.css" rel="stylesheet" />
    <style>
        .fontSizeGeneral {
            font-size: 13px !important;
        }

        .btn-filter {
            width: 60px !important;
            border-radius: 4px 4px 4px 4px !important;
            font-weight: bold;
            padding-top: 1px;
            font-size: 10px;
            color: white;
            background-color: #F39555 !important;
            height: 28px !important;
            float: left;
            margin-left: 5px;
        }

            .btn-filter:hover {
                color: white !important;
                background-color: #FF8C3F;
            }

        .imgvisor {
            width: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ValidateRequest="false">
    <input id="val_actual" type="hidden" runat="server" />    
    <div class="row pt-5">
        <div class="col-md-4">&nbsp;</div>
        <div class="col-md-7 ml-5 mr-5">
            <header class="d-flex flex-column justify-content-center align-items-center">
                <invox-login-form style="display: none"></invox-login-form>
                <input type="button" class="btn btn-primary" id="btnLogin" value="Login" onclick="Login(new Object(), new Object());" style="display: none" />
                <div id="invox-bar"></div>
            </header>
        </div>
    </div>

    <div class="row" style="height: 100%; margin-top: 50px;">
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12" style="padding-left: 0px;">
                    <label class="texto1 titulo1"><b style="color: #E67C00; font-size: 13px !important">ADDENDUM DEL EXÁMEN</b></label>
                    <table style="margin-top: 10px">
                        <tr>
                            <td>
                                <label class="texto1"><b>CENTRO:</b></label></td>
                            <td colspan="3"><b>
                                <asp:Label runat="server" CssClass="lbl" ID="lblCentro"></asp:Label></b></td>
                        </tr>
                        <tr>
                            <td><b>
                                <label class="texto1">IDPACIENTE: </label>
                            </b></td>
                            <td colspan="3">
                                <b>
                                    <asp:Label runat="server" ID="lblIdPaciente" CssClass="lbl"></asp:Label></b></td>
                        </tr>
                        <tr>
                            <td><b>
                                <label class="texto1">NOMBRE: </label>
                            </b></td>
                            <td colspan="3">
                                <b>
                                    <asp:Label runat="server" ID="lblNombre" CssClass="lbl"></asp:Label></b></td>
                        </tr>
                        <tr>
                            <td style="width: 40%">
                                <b>
                                    <label class="texto1">
                                        #ACC:
                                    </label>
                                    <b>
                                        <asp:Label runat="server" ID="lblAcc" CssClass="lbl"></asp:Label></b>
                                </b>
                            </td>
                            <td style="width: 30%">
                                <b>
                                    <label class="texto1">
                                        SEXO:
                                    </label>
                                    <asp:Label runat="server" ID="lblSexo" CssClass="lbl"></asp:Label>
                                </b>
                            </td>
                            <td style="width: 30%">
                                <b>
                                    <label class="texto1">
                                        EDAD:
                                    </label>
                                    <asp:Label runat="server" ID="lblEdad" CssClass="lbl"></asp:Label>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>
                                    <label class="texto1">MODALIDAD: </label>
                                </b>
                                <asp:Label runat="server" ID="lblModalidad" CssClass="lbl"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>
                                    <label class="texto1">IMÁGENES DEL ESTUDIO:</label></b>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblVisores"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <b>
                                    <label class="texto1">INFORMES:</label></b>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblInformes"></asp:Label></td>
                        </tr>
                    </table>

                    <div class="row" style="margin-top: 10px;">
                        <div class="col-md-12" style="padding-left: 0px;">
                            <label class="texto1 titulo1"><b>ESTUDIOS E INFORMES RELACIONADOS</b></label>&nbsp;&nbsp;<img src="../icon/recargar.png" style="width: 20px; cursor: pointer" id="btnRecargarEstudiosAnteriores" title="Recargar estudios relacionados." />
                        </div>
                        <div class="col-md-12" style="padding-left: 0px;">
                            <div id="divEstudiosRelacionados"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="padding-left: 0px;">
                            <br />
                            <label class="texto1 titulo1"><b>DOCUMENTOS DEL EXÁMEN</b></label>
                        </div>
                        <div class="col-md-12" style="padding-left: 0px;">
                            <asp:GridView runat="server" ID="gvDocumentosRelacionados" Width="100%" AutoGenerateColumns="false" EmptyDataText="No existen registros a visualizar">
                                <Columns>
                                    <asp:BoundField DataField="descripcion" HeaderText="Documento" SortExpression="descripcion" />
                                    <asp:TemplateField HeaderText="Doc.">
                                        <ItemTemplate>
                                            <%# Eval("archivo").ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="padding-left: 0px;">
                            <br />
                            <label class="texto1 titulo1"><b>COMENTARIO DEL TECNÓLOGO</b></label>
                        </div>
                        <div class="col-md-12" style="padding-left: 0px;">
                            <%--<asp:TextBox runat="server" ID="lblComentarioTM" CssClass="form-control" Enabled="false" TextMode="MultiLine" Height="150px"></asp:TextBox>--%>
                            <asp:TextBox runat="server" name="titulo" CssClass="form-control border" ID="lblComentarioTM" autocomplete="ÑÖcompletes" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <table>
                        <tr>
                            <td colspan="4">
                                <br />
                                <b>
                                    <%--<label class="texto1">
                                        SOLICITUD DE ADDENDUM PENDIENTE:</label></b>
                                <br />--%>
                                    <br />
                                    <asp:Label runat="server" ID="lblSolicitudAddendum"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trEstadoAddendum" runat="server" visible="false">
                            <td colspan="4">
                                <br />
                                <b>
                                    <asp:Label runat="server" ID="lblResolucion" Text="ESTADO DE RESOLUCIÓN:"></asp:Label>
                                </b>
                                <br />
                                <br />
                                <asp:DropDownList runat="server" CssClass="form-control-ddl" ID="ddlEstadoAddendum" DataTextField="nombre" DataValueField="id_estado_addendum"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>


                </div>







            </div>
        </div>
        <div class="col-md-8">
            <%--<div class="row" style="height: 100%;">--%>
            <label class="texto1 titulo1" style="margin-top: 10px;"><b>ADDENDUM</b></label>
            <br />
            <asp:TextBox runat="server" ID="txtAddendum" class="form-control invox-textarea shadow-none" Style="height: 50px !important; color: #000000 !important" onfocus="OnClickTextArea(id)"></asp:TextBox>           
            <%--</div>--%>

            <%--<div> CAMBIO--%>
            <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important">
                <div class="row" style="margin-top: 5px; background-color: #352D5C; padding-left: 10px !important; height: 90px; padding-right: 10px !important; text-align: center">
                    <br />
                    <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important">
                        <b>
                            <asp:Label runat="server" ID="lblPatologia" CssClass="texto1 titulo1 notificar">¿ NOTIFICAR PATOLOGÍA GRAVE ?*</asp:Label></b>
                    </div>
                    <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important; text-align: center;">
                        <div style="width: 120px; margin: 0 auto;">
                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbtnPatologiaGrave" AutoPostBack="true" OnSelectedIndexChanged="rbtnPatologiaGrave_SelectedIndexChanged">
                                <asp:ListItem Value="1">&nbsp;SI&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                <asp:ListItem Value="0">&nbsp;NO&nbsp;</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important">
                        <asp:DropDownList runat="server" Visible="false" ID="ddlSeleccionePatologia" Width="100%" DataTextField="nombre" DataValueField="nombre" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
                        </asp:DropDownList>

                        <b>
                            <asp:Label runat="server" ID="lblMensajeError"></asp:Label></b>
                        <br />
                    </div>
                </div>
            </div>
            <%--</div> CAMBIO--%>
            <label class="texto1 titulo1" style="margin-top: 10px;"><b>MOTIVO RECHAZO ADDENDUM</b></label>
            <br />
            <asp:TextBox runat="server" CssClass="fontSizeGeneral" ID="txtComentarioRechazo" TextMode="MultiLine" Width="100%" Height="50px" placeholder="En caso de rechazar addendum, ingrese comentario"></asp:TextBox>

            <%--</div>--%>
            <div class="col-md-12" style="padding-left: 0px; padding-right: 0px;">
                <br />
                <asp:Button runat="server" ID="btnRechazo" Text="Rechazar" OnClick="btnRechazo_Click" OnClientClick="rechazoAddRadiologo();" CssClass="btn btn-filter" Width="90px" />
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn btn-filter" Width="66px" />
                <asp:Button runat="server" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn btn-filter" Width="66px" />
            </div>

        </div>

        <br />
        <br />


    </div>






    <div class="modal fade" id="modalVerInforme" style="height: 100% !important;">
        <div class="modal-dialog modal-xl" style="background-color: #404848; height: 90% !important;">
            <div class="modal-content" style="background-color: #404848; height: 100%">
                <div class="modal-body" style="height: 90% !important; float: left;">
                    <div class="row" style="height: 100% !important;">
                        <div class="col-md-3" style="text-align: center; height: 100% !important;">
                            <label class="texto1 titulo1" style="margin-left: -17px !important"><b style="color: white !important;">INFORMES ANTERIORES RELACIONADOS</b></label>
                            <br />
                            <div id="tablaInformesPrevios"></div>
                        </div>
                        <div class="col-md-9" style="height: 100% !important;">
                            <iframe style="width: 100%; height: 100%; visibility: visible" frameborder="0" id="iframeInforme" src="../Control/Vacio.html"></iframe>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="height: 10% !important; float: left;">
                    <a href="#" class="btn btn-primary btn-clear" style="width: 130px; border-color: #636D6F !important" data-dismiss="modal">
                        <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cerrar</label></a>
                </div>
            </div>
            <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
        </div>
    </div>

    <script type="text/javascript" src="../../vocali/js/mainAddendum.js" charset="UTF-8"></script>
    <link href="../css/Master.css" rel="stylesheet" />
    <script src="../js/Addendum.js"></script>

    <script>
        $(document).ready(function () {
            validarVocali();
        });
    </script>
</asp:Content>
