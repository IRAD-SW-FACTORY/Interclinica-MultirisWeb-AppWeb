<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addendum.aspx.cs" Inherits="MultiRisWeb.Web.Examen.Addendum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiRisWeb</title>
    <link href="../Complementos/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link href="../font/Avenir-Roman/style.css" rel="stylesheet" />
    <link href="../css/Master.css" rel="stylesheet" />
    <script src="../js/Validaciones.js"></script>
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
    <link href="../css/Master.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />

    <style>
        .cke_bottom {
            background-color: #A9A8A8 !important;
        }

        .cke_reset {
            background-color: #676C6F !important;
        }

        .cke_top {
            background-color: #A9A8A8 !important;
            color: #ffffff !important;
        }

        .cke_editable {
            background-color: #A9A8A8 !important;
            color: #ffffff !important;
        }

        .form-control:hover {
            background-color: #676C6F !important;
        }

        .form-control:focus {
            background-color: #676C6F !important;
        }

        .form-control:disabled {
            background-color: #676C6F !important;
            color: #ffffff !important;
        }

        .form-control[readonly] {
            background-color: #676C6F !important;
            color: #ffffff !important;
        }

        .btn-si {
            padding: 5px 50px 5px 50px;
            border-radius: 5px;
            background-color: #FF0000;
            border-color: #FF0000;
            color: #ffffff;
            border: 1px solid transparent;
            height: 28px;
            letter-spacing: 2px;
            font-family: 'Avenir' !important;
            vertical-align: middle !important;
        }

            .btn-si:hover {
                background-color: #D80909;
            }

        .btn-no:hover {
            background-color: #116756;
        }

        .btn-no {
            padding: 5px 50px 5px 50px;
            margin-right: 35px !important;
            background-color: #148F77;
            border-radius: 5px;
            border-color: #148F77;
            color: #ffffff;
            border: 1px solid transparent;
            height: 28px;
            letter-spacing: 2px;
            vertical-align: middle !important;
        }

        a:link, a:visited, a:active {
            text-decoration: none;
        }

        .btn-gris {
            border-radius: 5px;
            background-color: darkorange !important;
            border-color: #838387;
            color: #ffffff;
            border: 1px solid transparent;
            height: 30px;
            letter-spacing: 0px;
            font-family: 'Avenir' !important;
            vertical-align: middle !important;
        }

            .btn-gris:hover {
                background-color: #5E5E62;
            }

        .btn-verde {
            border-radius: 5px !important;
            background-color: #148F77 !important;
            border-color: #148F77 !important;
            color: #ffffff !important;
            border: 1px solid transparent;
            height: 30px !important;
            letter-spacing: 0px !important;
            font-family: 'Avenir' !important;
            vertical-align: middle !important;
        }

            .btn-verde:hover {
                background-color: #116756 !important;
            }

        .table {
            color: white;
        }

        .dropdown-toggle::after {
            content: none;
        }

        .btn-danger {
            /*width: 60px !important;*/
            border-radius: 4px 4px 4px 4px !important;
            font-weight: bold;
            font-size: 11px;
            color: white;
            background-color: red;
        }
    </style>
</head>
<body class="container-fluid col-md-12 col-xxl-12 pull-center">
    <input id="val_actual" type="hidden" runat="server" />
    <input id="val_modalidad" type="hidden" runat="server" />
    <input id="val_estado" type="hidden" runat="server" />

    <div class="row pt-3 pb-1">
        <div class="col-md-4">&nbsp;</div>
        <div class="col-md-7 ml-5 mr-5">
            <header class="d-flex flex-column justify-content-center align-items-center">
                <invox-login-form style="display: none"></invox-login-form>
                <input type="button" class="btn btn-primary" id="btnLogin" value="Login" onclick="Login(new Object(), new Object());" style="display: none" />
                <div id="invox-bar"></div>
            </header>
        </div>
    </div>
    <form id="form1" runat="server">
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
                            <div class="col-md-12 text-center p-1" style="padding-left: 0px;">
                                <input type="button" id="btnVerInformesPdf" value="Ver Informes" onclick="VerInformes();" style="width: 130px !important;" class="btn btn-verde" />
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <table cellspacing='0' rules='all' border='1' id='tableEstudiosAnteriores' style='width: 100%; border-collapse: collapse;'>
                                    <thead>
                                        <tr>
                                            <th style='width: 25%'><b>Centro</b></th>
                                            <th style='width: 25%'><b>Fecha Ex.</b></th>
                                            <th style='width: 30%'><b>Desc.</b></th>
                                            <th style='width: 5%'><b>Mod.</b></th>
                                            <th style='width: 35%'><b>Visores</b></th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbodyEstudiosAnteriores"></tbody>
                                </table>
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
                                <asp:TextBox runat="server" name="titulo" ReadOnly="true" CssClass="form-control" ID="lblComentarioTM" autocomplete="ÑÖcompletes" TextMode="MultiLine" Style="height: 100px !important; color: white !important; background-color: #676C6F !important"></asp:TextBox>
                            </div>
                        </div>
                        <table>
                            <tr>
                                <td colspan="4">
                                    <br />
                                    <b>
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
                <label class="texto1 titulo1" style="margin-top: 10px;"><b>ADDENDUM</b></label>
                <br />
                <asp:TextBox runat="server" ID="txtAddendum" class="form-control invox-textarea shadow-none" Style="height: 50px !important; color: #000000 !important" onfocus="OnClickTextArea(id)"></asp:TextBox>
                <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important">
                    <div class="row" style="margin-top: 5px; background-color: #352D5C; padding-left: 10px !important; height: 100px; padding-right: 10px !important; text-align: center">
                        <br />
                        <div class="col-md-12" style="padding-left: 0px !important; padding-right: 0px !important">
                            <b>
                                <asp:Label runat="server" ID="lblPatologia" CssClass="texto1 titulo1 notificar">¿ NOTIFICAR PATOLOGÍA CRÍTICA ?*</asp:Label></b>
                        </div>

                        <asp:Panel ID="divSi" runat="server" CssClass="col-md-6 text-right" Style="padding-left: 0px !important; padding-right: 10px !important;">
                            <a href="javascript:SelectedCriticaSi()" id="btnPatologiaSi" class="btn-si">SI
                                <img id="imgSi" src="" style="max-width: 15px" /></a>
                        </asp:Panel>

                        <asp:Panel ID="divNo" runat="server" CssClass="col-md-6 text-left" Style="padding-left: 10px !important; padding-right: 0px !important;">
                            <a href="javascript:SelectedCriticaNo()" id="btnPatologiaNo" class="btn-no">NO 
                                <img id="imgNo" src="" style="max-width: 15px" /></a>
                        </asp:Panel>

                        <div class="col-md-2">&nbsp;</div>

                        <div class="col-md-8 pt-3 pb-3" id="divSelectPatologiaGrave" style="padding-left: 0px !important; padding-right: 0px !important; display: none;">
                            <select id="ddlSeleccionePatologia" class="form-control2" style="background-color: #676C6F !important; color: #ffffff !important"></select>
                        </div>

                        <div class="col-md-2">&nbsp;</div>
                    </div>
                </div>
                <label class="texto1 titulo1" style="margin-top: 10px;"><b>MOTIVO NO MODIFICACIÓN DEL INFORME</b></label>
                <br />

                <asp:TextBox runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" ID="txtComentarioRechazo" Style="height: 100px !important; color: white !important; background-color: #676C6F !important" placeholder="En caso de rechazar addendum, ingrese comentario"></asp:TextBox>
                <div class="row pt-1 pb-1">
                    <div class="col-12 text-center">
                        <asp:Label runat="server" ID="lblMensaje" Style="color: Red"></asp:Label>
                    </div>
                </div>
                <div class="row pt-3">
                    <div class="col-2">
                        <asp:Button runat="server" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" Style="width: 130px !important;" CssClass="btn btn-clear" />
                    </div>
                    <div class="col-2">
                        <asp:Button runat="server" ID="btnRechazo" Text="Rechazar" OnClick="btnRechazo_Click" Style="width: 130px !important;" CssClass="btn btn-verde" />
                    </div>
                    <div class="col-6">&nbsp;</div>
                    <div class="col-2">
                        <input type="button" id="btnGuardar" value="Validar" onclick="Validar();" style="width: 130px !important;" class="btn btn-verde" />
                    </div>
                </div>
            </div>
        </div>
    </form>

    <div class="modal fade" id="modalSolicitudImagenes">
        <div class="modal-dialog" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center;">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">SOLICITUD DE IMAGENES GENERADA</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <p>Espere un momento por favor, mientras las imágenes son transferidas desde el Centro hacia el Multirisweb.</p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="height: 10% !important; float: left;">
                    <a href="#" class="btn btn-primary btn-clear" style="width: 130px; border-color: #636D6F !important" data-dismiss="modal">
                        <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cerrar</label></a>
                </div>
            </div>
        </div>
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

    <div class="modal fade" id="modalInformacionAddendum">
        <div class="modal-dialog modal-lg" style="background-color: #404848">
            <div class="modal-content" style="background-color: #404848">
                <div class="modal-header" style="text-align: center">
                    <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="font-size: 14px !important; color: white">INFORMACION</b></label>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 pt-2 pb-5">
                            <label id="lblMensajeModal" style="font-size: 15px !important"></label>
                        </div>
                        <div class="col-md-12 text-right">
                            <input type="button" class="btn btn-filter" style="width: 122px !important" value="Cerrar" onclick="CerrarModalInformacionAddendum()" />
                        </div>

                    </div>
                </div>
                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
            </div>
        </div>
    </div>
       <div class="modal fade" id="modalVerDocumentoPDF">
            <div class="modal-dialog modal-lg" style="background-color: #404848">
                <div class="modal-content" style="background-color: #404848">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <iframe id="iframeDocumento" style="width: 100%; height: 800px;"></iframe>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a class="btn btn-primary btn-clear" style="width: 130px;" data-dismiss="modal">
                            <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cerrar</label></a>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

    
        <div class="modal fade" id="modalVerDocumento">
            <div class="modal-dialog modal-lg" style="background-color: #404848">
                <div class="modal-content" style="background-color: #404848">
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <img style="width: 100%;" id="imgDocumento" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a class="btn btn-primary btn-clear" style="width: 130px;" data-dismiss="modal">
                            <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cerrar</label></a>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

    <script type="text/javascript" src="../js/master.js"></script>
    <script type="text/javascript" src="../Complementos/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../vocali/js/mainAddendum.js" charset="UTF-8"></script>
    <link href="../css/Master.css" rel="stylesheet" />
    <script src="../js/Addendum.js?v=4"></script>
</body>
</html>
