<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informar.aspx.cs" Inherits="MultiRisWeb.Web.Examen.Informar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiRisWeb</title>
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />

    <link href="../Complementos/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>

    <link href="../font/Avenir-Roman/style.css" rel="stylesheet" />
    <link href="../css/Master.css" rel="stylesheet" />

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

    <script src="../js/Validaciones.js"></script>

    <link href="../css/Master.css" rel="stylesheet" />
    <link href="../css/Informar?v1.css" rel="stylesheet" />

    <link href="../css/MasterMenu.css" rel="stylesheet" />

    <link href="../css/normalize/5.0.0/normalize.min.css" rel="stylesheet" />
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans' />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.min.css' />
    <link href="../css/chatIrad.css" rel="stylesheet" />

    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />

    <script type="text/javascript" src="../js/notify.js" charset="UTF-8"></script>

    <script>
        function CargaDatosActivoSitio() { $('#.modalCargando').modal('show'); }
    </script>

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
            padding: 0px 10px 5px 10px !important;
        }

            .btn-gris:hover {
                background-color: #5E5E62;
            }

        .btn-verde {
            border-radius: 5px;
            background-color: #148F77;
            border-color: #148F77;
            color: #ffffff;
            border: 1px solid transparent;
            height: 30px;
            letter-spacing: 0px;
            font-family: 'Avenir' !important;
            vertical-align: middle !important;
            padding: 0px 10px 5px 10px !important;
        }

            .btn-verde:hover {
                background-color: #116756;
            }
    </style>
</head>
<body class="container-fluid col-md-12 col-xxl-12 pull-center">
    <input id="val_actual" type="hidden" runat="server" />
    <input id="val_modalidad" type="hidden" runat="server" />
    <input id="val_estado" type="hidden" runat="server" />
    <input id="usuarioNombre" type="hidden" runat="server" />
    <input id="perfilNombre" type="hidden" runat="server" />
    <input id="risExamen" type="hidden" runat="server" />
    <input id="comunica" type="hidden" runat="server" />


    <div class="row pt-3 pb-3">
        <div class="col-md-4">&nbsp;</div>
        <div class="col-md-7 ml-5 mr-5">
            <header class="d-flex flex-column justify-content-center align-items-center">
                <invox-login-form style="display: none"></invox-login-form>
                <input type="button" class="btn btn-primary" id="btnLogin" value="Login" onclick="Login(new Object(), new Object());" style="display: none" />
                <div id="invox-bar"></div>
            </header>
        </div>
    </div>

    <form runat="server">
        <asp:HiddenField runat="server" ID="hddInstitucion" />
        <asp:HiddenField runat="server" ID="hddCod" />
        <asp:HiddenField runat="server" ID="hddIdInforme" />
        <asp:HiddenField runat="server" ID="hddIdPrestacion" />

        <div class="row" style="background-color: #404848">
            <div class="col-md-4">
                <div class="col-md-12">
                    PRESTACIONES               
                    <label class="texto1 titulo1"><b style="color: #E67C00; font-size: 13px !important">INFORMANDO EXÁMEN</b></label>

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
                                <asp:Label runat="server" ID="lblIdPaciente" CssClass="lbl"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>
                                <label class="texto1">NOMBRE: </label>
                            </b></td>
                            <td colspan="3">
                                <asp:Label runat="server" ID="lblNombre" CssClass="lbl"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 40%">
                                <b>
                                    <label class="texto1">#ACC:<asp:Label runat="server" ID="lblAcc" CssClass="lbl"></asp:Label></label></b>
                            </td>
                            <td style="width: 30%">
                                <b>
                                    <label class="texto1">SEXO:<asp:Label runat="server" ID="lblSexo" CssClass="lbl"></asp:Label></label></b>
                            </td>
                            <td style="width: 30%">
                                <b>
                                    <label class="texto1">EDAD:<asp:Label runat="server" ID="lblEdad" CssClass="lbl"></asp:Label></label></b>
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
                    </table>

                    <div class="row" style="margin-top: 10px;">
                        <div class="col-md-12" style="padding-left: 0px;">
                            <label class="texto1 titulo1"><b>PRESTACIONES</b></label>
                        </div>
                        <div class="col-md-12" style="padding-left: 0px;">
                            <asp:GridView runat="server" ID="gvPrestaciones" Width="100%" EmptyDataText="No existen registros a visualizar" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="nombrePrestacion" HeaderText="Nombre Prestación" SortExpression="nombrePrestacion" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

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
                            <label class="texto1 titulo1"><b>ANTECEDENTES CLINICOS INSTITUCI&Oacute;N</b></label>
                        </div>
                        <div class="col-md-12" style="padding-left: 0px;">
                            <asp:TextBox runat="server" name="txtAntecedentesClinicosLocal" CssClass="form-control border" ID="txtAntecedentesClinicosLocal" Style="min-height: 100px !important" Enabled="false" autocomplete="ÑÖcompletes" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:TextBox runat="server" name="titulo" CssClass="form-control border" ID="lblComentarioTM" ReadOnly="true" Style="min-height: 100px !important" autocomplete="ÑÖcompletes" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12  p-0">
                            <b>
                                <asp:Label runat="server" ID="Label1" CssClass="texto1 titulo1 col-12 p-0">TAGS EXAMEN INFORME</asp:Label></b>
                        </div>
                        <div class="col-12  p-0">
                            <div id="divTags"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-5 ml-3">
                        <label class="texto1 titulo1">PLANTILLAS</label>
                        <select id="ddlPlantilla" class="form-control2" style="min-width: 300px !important; background-color: #676C6F !important; color: #ffffff !important" onchange="SeleccionarPlantilla(this.value)"></select>
                    </div>

                    <div class="col-md-6">
                        <div style="float: left; width: 131px; margin-left: 0px;" class="pt-4">
                            <input type="button" class="btn btn-gris" style="width: 110px !important" value="Crear Plantilla" onclick="AbrirInsertOrUpdatePlantilla()" />
                        </div>
                        <div style="float: left; width: 131px; margin-left: 0px;" class="pt-4">
                            <input type="button" id="btnActualizarPlantilla" class="btn btn-clear" style="width: 110px !important; display: none" value="Actualizar Plantilla" onclick="UpdatePlantilla()" />
                        </div>
                    </div>

                    <main>
                        <div id="invox-content" class="row" style="margin-bottom: 50px; padding: 0px 30px 0px 30px;">
                            <div class="d-flex justify-content-center" style="margin-top: 30px">
                            </div>

                            <div class="row invox-nomargin">
                                <label class="texto1 titulo1">
                                    <asp:Label ID="lblTitulo" runat="server">TITULO INFORME</asp:Label></label>
                                <asp:TextBox runat="server" ID="txtTitulo" class="form-control invox-textarea shadow-none" Style="height: 50px !important; color: #000000 !important" onfocus="OnClickTextArea(id)"></asp:TextBox>
                                <label class="texto1 titulo1 pt-3">TÉCNICA</label>
                                <asp:TextBox runat="server" ID="txtTecnica" class="form-control invox-textarea shadow-none" Style="min-height: 80px !important; color: #000000 !important" onfocus="OnClickTextArea(id)" name="tecnica"></asp:TextBox>
                                <label class="texto1 titulo1 pt-3">ANTECEDENTES CLÍNICOS</label>
                                <asp:TextBox runat="server" ID="txtAntecedentesClinicos" class="form-control invox-textarea shadow-none" Style="min-height: 80px !important; color: #000000 !important" onfocus="OnClickTextArea(id)" name="antecedentes"></asp:TextBox>
                                <label class="texto1 titulo1 pt-3">HALLAZGOS</label>
                                <asp:TextBox runat="server" ID="txtHallazgos" class="form-control invox-textarea shadow-none" Style="min-height: 350px !important; color: #000000 !important" onfocus="OnClickTextArea(id)" name="hallazgos"></asp:TextBox>
                                <label class="texto1 titulo1 pt-3">IMPRESIÓN RADIÓLOGICA</label>
                                <asp:TextBox runat="server" ID="txtImpresion" class="form-control invox-textarea shadow-none" Style="min-height: 350px !important; color: #000000 !important" onfocus="OnClickTextArea(id)" name="impresion"></asp:TextBox>
                            </div>

                        </div>
                    </main>

                    <div class="row" style="margin-top: 10px; visibility: hidden; height: 0px">
                        <div class="col-md-12;">
                            <div style="float: left; width: 146px; margin-left: 15px;">
                                <a runat="server" id="aVerImagenes" class="btn btn-filter" style="width: 108px;" target="_blank">
                                    <label style="margin-left: 5px; margin-top: 3px;" class="lblbtn">Ver Imagenes</label></a>
                            </div>
                            <div style="float: left; width: 146px; margin-left: 15px; margin-top: -4px">
                                <asp:DropDownList runat="server" ID="ddlVisor" CssClass="ddlVisor" DataTextField="nombre" DataValueField="id_visor" AutoPostBack="true" OnSelectedIndexChanged="ddlVisor_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

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

                    <div class="col-md-12" style="background-color: #352D5C" runat="server" id="divMensaje" visible="false">
                        <br />
                        <b>
                            <asp:Label runat="server" ID="lblMensajeError"></asp:Label></b><br />
                        <br />
                    </div>

                    <div class="col-md-12 pt-3">
                        <div class="row">
                            <div class="col-md-2">
                                <a runat="server" data-toggle='modal' data-target='#modalComentarios' id="aComentarios" class="btn btn-gris" style="width: 130px !important;">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">Comentarios</label>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a runat="server" id="aDescargarExamen" class="btn btn-gris" style="width: 130px !important;">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn" title="Descargar en ZIP">Descargar</label>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="#" id="bNotificar" class="btn btn-gris" style="width: 130px !important;">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">Pendiente</label>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="#" id="btnPendiente" class="btn btn-gris" style="width: 130px !important;">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">
                                        <%--<img src="../img/guardar-datos.png" style="width: 18px;" />--%>&nbsp;Guardar
                                    </label>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="#" id="btnGuardar" class="btn btn-gris" style="width: 130px !important;" onclick="Informar(true);CargaDatosActivo();">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">
                                        <%--<img src="../img/informe-seo.png" style="width: 18px;" />--%>&nbsp;Informar
                                    </label>
                                </a>
                            </div>
                            <div class="col-md-2">
                                <a href="#" id="btnInformar" class="btn btn-verde" style="width: 130px !important;" onclick="Validar();CargaDatosActivo();">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">
                                        <%--<img src="../img/validacion.png" style="width: 18px;" />--%>&nbsp;Validar
                                    </label>
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 pt-3 pb-3">
                        <div class="row">
                            <div class="col-md-2">
                                <a href="#" id="bBack" class="btn btn-verde" style="width: 130px !important;">
                                    <label style="margin-left: 2px; margin-top: 3px; font-size: 13px !important" class="lblbtn">Regresar</label>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

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
                            <div class="col-md-12">
                                <br />
                                <textarea class="form-control" placeholder="comentario" id="txtComentario"></textarea>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <a id="aGuardarComentario" class="btn btn-primary btn-filter" style="width: 130px;">
                                    <label style="margin-left: 7px; margin-top: 2px" class="lblbtn">Guardar</label></a>

                                <a href="#" id="aCancelarComentario" class="btn btn-primary btn-clear" style="width: 130px; border-color: #636D6F" data-dismiss="modal">
                                    <label style="margin-left: 10px; margin-top: 2px" class="lblbtn">Cancelar</label></a>
                            </div>
                        </div>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

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

        <div class="modal fade" id="modalExamenAnterior">
            <div class="modal-dialog modal-xl" style="background-color: #404848">
                <div class="modal-content" style="background-color: #404848">
                    <div class="modal-header">
                        <h4 class="modal-title">DOCUMENTOS DEL EXAMEN</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div id="dglExamenAnterior">
                                    <div id="tablaExamenAnterior"></div>
                                </div>
                            </div>
                            <div class="col-md-6"></div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" style="background-color: #636D6F !important; border-color: #636D6F !important;">Cerrar</button>
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

        <div class="modal fade" id="modalGuardarPlantilla">
            <div class="modal-dialog modal-lg" style="background-color: #404848">
                <div class="modal-content" style="background-color: #404848">
                    <div class="modal-header" style="text-align: center">
                        <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="font-size: 14px !important; color: white">CREAR NUEVA PLANTILLA</b></label>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <input type="text" id="txtPlantilla" class="form-control" maxlength="25" />
                            </div>
                            <div class="col-md-12 pt-2 pb-2">
                                <label id="lblMensajePlantilla"></label>
                            </div>
                            <div class="col-md-12">
                                <input type="button" class="btn btn-filter" style="width: 122px !important" value="Guardar" onclick="InsertPlantilla()" />
                                <input type="button" class="btn btn-filter" style="width: 122px !important" value="Cerrar" onclick="CerrarInsertOrUpdatePlantilla()" />
                            </div>

                        </div>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

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

        <div class="modal fade" id="modalInformacion">
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
                                <input type="button" class="btn btn-filter" style="width: 122px !important" value="Cerrar" onclick="CerrarModalInformacion()" />
                            </div>

                        </div>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="modalAutoGuardarDataInforme">
            <div class="modal-dialog modal-lg" style="background-color: #404848">
                <div class="modal-content" style="background-color: #404848">
                    <div class="modal-header" style="text-align: center">
                        <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="font-size: 14px !important; color: white">INFORMACION</b></label>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12 pt-2 pb-5">
                                <h6>Estimado Doctor (a), para optimizar su flujo de trabajo en multiris por favor debe guardar  este informe (utilice botón guardar).</h6>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-8">
                                        &nbsp;
                                    </div>
                                    <div class="col-2">
                                        <input type="button" class="btn btn-gris" value="GUARDAR" style="min-width: 100px !important; font-size: 15px !important" onclick="CerrarModalAutoGuardarDataInforme();GuardaProvisorio();CargaDatosActivo();" />
                                    </div>
                                    <div class="col-2">
                                        <asp:Button runat="server" ID="Button1" Text="NO GUARDAR" Style="min-width: 100px !important;" OnClick="btnRegresar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn-gris" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="modalAutoGuardarNoDataInforme">
            <div class="modal-dialog modal-lg" style="background-color: #404848">
                <div class="modal-content" style="background-color: #404848">
                    <div class="modal-header" style="text-align: center">
                        <label style="width: 100%; font-size: 20px;" class="texto1 titulo1"><b style="font-size: 14px !important; color: white">INFORMACION</b></label>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12 pt-2 pb-5">
                                <h6>Estimado Doctor (a), este informe se encuentra sin informar aún. Necesita más tiempo ?.</h6>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-8">
                                        &nbsp;
                                    </div>
                                    <div class="col-2">
                                        <input type="button" class="btn btn-filter" value="Ok" style="min-width: 80px !important; font-size: 15px !important" onclick="CerrarModalAutoGuardarNoDataInforme()" />
                                    </div>
                                    <div class="col-2">
                                        <asp:Button runat="server" ID="Button2" Text="Cancelar" Style="min-width: 80px !important;" OnClick="btnRegresar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn-gris" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                </div>
            </div>
        </div>

        <div class="modal" id="mNotifica">
            <div class="chat">
                <div class="chat-title">
                    <h1 id="vNombreUsuario"></h1>
                    <h2 id="vPerfilNombre"></h2>
                    <figure class="avatar">
                        <img src="../img/servicio-al-cliente.png" />
                    </figure>
                </div>
                <div class="message-box" style="font-size: 12px; background-color: #545454; padding: 5px !important;">
                    <span style="padding-right: 15px;">CATEGORIA</span>
                    <select id="Categoria" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 130px">
                        <option value="0">Seleccione..</option>
                    </select>
                </div>
                <div class="row messages">
                    <div class="col-sm-8">
                        <div class="messages-content barra-scroll"></div>
                    </div>
                    <div class="col-sm-4">
                        <div class="messages-content-file barra-scroll"></div>
                    </div>
                </div>
                <div class="message-box">
                    <textarea type="text" class="message-input" placeholder="Escribe tu mensaje..."></textarea>
                    <img src="../img/adjuntar-archivo.png" class="adjuntar-ris ajunta-no-visible" id="bAdjuntar" />
                    <button type="button" class="message-submit">Enviar</button>
                </div>
            </div>
            <div class="bg"></div>
        </div>

        <div class="modal" id="mAdjunto">
            <div class="chat-adjunto">
                <div class="message-box">
                    <label for="file-chat" class="custom-file-upload">Seleccione Archivo</label>
                    <input type="file" id="file-chat" accept=".pdf,image/png,image/jpg,.doc,.docx, application/octet-stream" />
                    <button type="button" class="message-adjunta" id="adjuntoEnvio">Adjuntar</button>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript" src="../../vocali/js/main.js?v9" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/master.js"></script>
    <script type="text/javascript" src="../Complementos/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/Informar.js?v11"></script>
    <script type="text/javascript" src="../js/Plantilla.js?v3"></script>
    <script type="text/javascript" src="../js/Tags.js?v5"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/ckeditor/plugins/texttransform/plugin.js?v1"></script>

    <script src='https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.concat.min.js'></script>
    <script src="../js/chatIrad.js"></script>

    <script src="../js/multiselect/jquery.multiselect.es.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.min.js"></script>
    <script src="../js/multiselect/jquery.multiselect.min.js"></script>
    <script src="../js/InformarSession.js"></script>
    <script type="text/javascript">
        //setInterval(() => AbrirModalAutoGuardarInforme(), 300000);

        $(document).ready(function () {
            var inactivityTime = 10;

            function activityUser() {
                clearTimeout(timer);
                AbrirModalAutoGuardarInforme();
            }

            function resetTimer() {
                clearTimeout(timer);
                timer = setTimeout(activityUser, inactivityTime * 60000);
            }

            document.addEventListener('mousemove', resetTimer);
            document.addEventListener('keypress', resetTimer);

            var timer = setTimeout(activityUser, inactivityTime * 60000);

            $('#mAdjunto').modal('hide');

            $("#Categoria").multiselect({
                multiple: false,
                selectedList: 1,
                minWidth: 80,
                noneSelectedText: '&nbsp;&nbsp;Seleccione..',
                header: false,
                height: 'auto',
                width: 200,
            });

            if ($('#val_estado').val() == '0' || $('#val_estado').val() == '1') {
                $('#btnPendiente').attr('style', 'visibility: visible; width: 130px !important;');
                $('#btnPendiente').addClass('btn-gris');
                $('#vNombreUsuario').text($('#usuarioNombre').val());
                $('#vPerfilNombre').text($('#perfilNombre').val());
            }
            else
                $('#btnPendiente').attr('style', 'visibility: hidden');

            validarVocali();
            actualizarBloqueoExamen();
            CargarPlantillaSelected();
            MensajeInsertOrUpdatePlantilla('');
            ValidarUsuarioBecadoForaneo();
            CargarTagsUsuario();

            $('#btnPendiente').on('click', function () {
                GuardaProvisorio(true);
            });

            $('#bNotificar').on('click', function () {
                $('#Categoria option').remove();
                $('.messages-content').html('');
                $('.messages-content-file').html('');
                $('.message-input').val('');

                ChangeCategoria($('#Categoria'));

                var obj = CompruebaExistenciaCanal($('#risExamen').val());

                $("#comunica").val(obj.comunicate);

                if (obj.id_ris_examen_canal != 0) {
                    $("#Categoria option[value=" + obj.id_categoria + "]").attr("selected", true);
                    $("#Categoria").multiselect("disable");
                    $("#Categoria").multiselect('refresh');

                    $('#bAdjuntar').removeClass('ajunta-no-visible');

                    listMessage($('#risExamen').val(), $('.messages-content'), $('#bAdjuntar'));

                    listFile($('#risExamen').val(), $('.messages-content-file'));
                } else {
                    $("#Categoria").multiselect("enable");
                }

                $('#mNotifica').modal('show');
            });

            $('#bBack').on('click', function () {
                window.location.href = "ListaExamen.aspx";
            });

            $('.message-submit').on('click', function () {
                $('.message-input').val($('.message-input').val().replace('"', ''));

                insertMessage($('#risExamen').val(), $('#Categoria > option:selected').val(), $('.message-input').val(), $('.messages-content'), $('#bAdjuntar'), $('.message-input'), $('#usuarioNombre').val(), $("#comunica").val(), $('#Categoria > option:selected').text());
                $("#Categoria").multiselect("disable");
            });

            $('#adjuntoEnvio').on('click', function () {
                var filename = $('input[type=file]').val().split('\\').pop();
                var file = $("#file-chat")[0].files[0];

                $('#mAdjunto').modal('hide');

                if (!filename || !file) { alert("No se ha seleccionado ningun archivo"); return false; }

                adjuntoFile($('#risExamen').val(), filename, file, $('#usuarioNombre').val(), $('.messages-content-file'));
            });

            $('#bAdjuntar').on('click', function () {
                $('.custom-file-upload').text('Seleccione Archivo');

                $('#mAdjunto').modal('show');

                //if ($.trim($('.message-input').val()) == "") { alert("Para ingresar un archivo debe haber enviado un mensaje"); return false; }
            });

            $('#file-chat').on('change', function () {
                var filename = $('input[type=file]').val().split('\\').pop();

                $('.custom-file-upload').text(filename);
            });
        });
    </script>
</body>
</html>
