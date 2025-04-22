<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="InformaOIT.aspx.cs" Inherits="MultiRisWeb.Web.Examen.WebForm1" %> <%--MasterPageFile="~/Web/Control/Master.Master"--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiRisWeb</title>
    
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>
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

    <link href="../css/normalize/5.0.0/normalize.min.css" rel="stylesheet" />
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans' />
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.3/jquery.mCustomScrollbar.min.css' />
    <link href="../css/chatIrad.css" rel="stylesheet" />

    <link href="../css/jquery-ui.css" rel="stylesheet"/>
    <link href="../css/InformarOIT.css" rel="stylesheet" />
    <link href="../css/Master.css" rel="stylesheet" />
    <link href="../css/Informar.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
    
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />

    <link href="../css/DataTables/datatables.min.css" rel="stylesheet"/>
    <script src="../js/DataTables/datatables.min.js"></script>

    <script type="text/javascript" src="../js/notify.js" charset="UTF-8"></script>
<%--</asp:Content>--%>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">--%>
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

        .ui-widget.ui-widget-content {
            border: 1px solid #c5c5c5;
            min-width: 300px;
        }

        .modal[aria-hidden="true"] {
            display: none;
            pointer-events: none;
            visibility: hidden;
        }

        @media (max-width: 576px) {
            .col-extra-small {
                flex: 0 0 auto;
                width: 20%; /* Personaliza según lo que necesites */
            }
        }
    </style>
    </head>
<body>

    <input id="risExamen" type="hidden" runat="server" />
    <input id="codExamen" type="hidden" runat="server" />
    <input id="prestacion" type="hidden" runat="server" />
    <input id="contenido" type="hidden" runat="server" />
    <input id="institucion" type="hidden" runat="server" />
    <input id="informe" type="hidden" runat="server" />
    <input id="comunica" type="hidden" runat="server" />
    <input id="usuarioNombre" type="hidden" runat="server" />
    <input id="perfilNombre" type="hidden" runat="server" />

    <div class="row pt-3 pb-3">
        <div class="col-md-4">&nbsp;</div>
        <div class="col-md-7 ml-0 mr-5">
            <header class="d-flex flex-column justify-content-center align-items-center">
                <invox-login-form style="display: none"></invox-login-form>
                <input type="button" class="btn btn-primary" id="btnLogin" value="Login" onclick="Login(new Object(), new Object());" style="display: none" />
                <div id="invox-bar"></div>
            </header>
        </div>
    </div>

    <form runat="server">
        <div class="container" style="padding-top: 0px; margin-left: 15px; max-width: 98%;">
            <div class="row">
                <div class="col-lg-4 col-md-12 col-sm-12">
                    <label style="padding-left: 5px"><b>EXÁMEN</b></label>
                    <br />
                    <div class="row css-div-filtros">
                        <div class="col-md-12">
                            <table>
                                <tr>
                                    <td>
                                        <label class="texto1"><b>CENTRO:</b></label></td>
                                    <td colspan="5"><b>
                                        <label class="lbl" id="lCentro"></label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td><b>
                                        <label class="texto1">IDPACIENTE: </label>
                                    </b></td>
                                    <td colspan="5"><b>
                                        <label class="lbl" id="lIdPaciente"></label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td><b>
                                        <label class="texto1">NOMBRE: </label>
                                    </b></td>
                                    <td colspan="5"><b>
                                        <label class="lbl" id="lnombre"></label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td><b>
                                        <label class="texto1">#ACC:  &nbsp;</label></td>
                                    <td><b>
                                        <label class="lbl" id="lnumeroacceso"></label>
                                        &nbsp;</b></td>
                                    <td><b>
                                        <label class="texto1">SEXO:&nbsp;</label></b></td>
                                    <td><b>
                                        <label class="lbl" id="lsexo"></label>
                                        &nbsp;</b></td>
                                    <td><b>
                                        <label class="texto1">EDAD:&nbsp;</label></b></td>
                                    <td><b>
                                        <label class="lbl" id="ledad"></label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td colspan="3"><b>
                                        <label class="texto1">IMÁGENES DEL ESTUDIO:</label></b></td>
                                    <td colspan="3">
                                        <label id="lVisores"></label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />

                    <label style="padding-left: 5px; padding-top: 10px"><b>PRESTACIONES</b></label>
                    <br />
                    <div class="col-md-12 css-div-filtros">
                        <table id="gPrestacion" class="table table-striped css-table_dark table table-striped table-dark table-hover display nowrap" style="width: 100%; background-color: #404848 !important; font-size: 12px">
                            <thead>
                                <tr>
                                    <th class="css-thead-table">NOMBRE PRESTACIÓN</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <br />

                    <label style="padding-left: 5px; padding-top: 10px">
                        <b>ESTUDIOS E INFORMES RELACIONADOS</b>&nbsp;
                        <img src="../icon/recargar.png" style="width: 19px; cursor: pointer; padding-right: 8px;" id="bRecarga" title="Recargar estudios relacionados." />
                    </label>
                    <br />
                    <div class="col-md-12 css-div-filtros" style="min-height: 200px">
                        <div id="divEstudiosRelacionados">
                        </div>
                    </div>
                    <br />

                    <label style="padding-left: 5px; padding-top: 10px"><b>DOCUMENTOS DEL EXÁMEN</b></label>
                    <br />
                    <div class="col-md-12 css-div-filtros" style="min-height: 160px">
                        <table id="gDocumentos" class="table table-striped css-table_dark table table-striped table-dark table-hover display nowrap" style="width: 100%; background-color: #404848 !important; font-size: 12px">
                            <thead>
                                <tr>
                                    <th class="css-thead-table">DESCRIPCIÓN</th>
                                    <th class="css-thead-table">DOC.</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                    <label style="padding-left: 5px; padding-top: 10px"><b>ANTECEDENTES CLINICOS INSTITUCIÓN</b></label>
                    <br />

                    <div class="col-md-12 css-div-filtros" style="min-height: 114px">
                        <textbox id="antecedenteClinico" class="form-control border" readonly="true" style="min-height: 100px !important; margin-top: 5px; background-color: #7e8484 !important;" textmode="MultiLine"></textbox>
                    </div>

                    <label style="padding-left: 5px; padding-top: 10px"><b>COMENTARIO DEL TECNÓLOGO</b></label>
                    <br />
                    <div class="col-md-12 css-div-filtros" style="min-height: 114px">
                        <textbox id="comentarioTM" class="form-control border" readonly="true" style="min-height: 100px !important; margin-top: 5px; background-color: #7e8484 !important;" textmode="MultiLine"></textbox>
                    </div>
                </div>
                <div class="col-lg-8 col-md-12 col-sm-12">
                    <label style="text-align: center; width: 100%;"><b style="font-size: 15px;">INTERPRETACIÓN RADIOLOGIA</b></label>
                    <div class="row">
                        <div class="col-lg-12 css-div-form" style="min-height: 800px; border-color: white; box-shadow: 10px 10px 20px rgba(0,0,0,0.5); padding-left: 0px; padding-right: 0px;">
                            <div class="row">
                                <div class="col-md-6" style="padding-left: px">
                                    <b>
                                        <label class="lblInformeOIT">NOMBRE PACIENTE</label></b>
                                    <input id="tNombrePaciente" style="width: 95%; font-weight: bold;" class="campos-texto" disabled />
                                </div>
                                <div class="col-md-3">
                                    <b>
                                        <label class="lblInformeOIT">NÚMERO IDENTIFICADOR&nbsp;&nbsp;</label></b>
                                    <input id="tIdentificador" width="100%" class="campos-texto" style="text-align: right; font-weight: bold;" disabled />
                                </div>
                                <div class="col-md-3">
                                    <b>
                                        <label class="lblInformeOIT" style="margin-right: 15px;">FECHA RADIOGRAFIA&nbsp;&nbsp;</label>&nbsp;&nbsp</b>
                                    <input id="tFechaRadiografia" width="100%" class="campos-texto" style="text-align: center; font-weight: bold;" disabled />
                                </div>
                                <div class="col-md-12" style="max-height: 7px !important;">&nbsp;</div>
                                <div class="col-md-2">
                                    <label class="lblInformeOIT">N° RADIOGRAFIA</label>
                                    <input id="tNumeroRadiografia" style="width: 95%; text-align: right; background-color: lightgrey;" class="campos-texto" />
                                </div>
                                <div class="col-md-2">
                                    <label class="lblInformeOIT">RAD.DIGITAL</label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mRadDigSI">
                                                <b class="size-check">SI </b>
                                                <input type="radio" name="mRadDigital" value="1" checked /></label></li>
                                        <li>
                                            <label for="mRadDigNO">
                                                <b class="size-check">NO </b>
                                                <input type="radio" name="mRadDigital" value="0" /></label></li>
                                    </ul>
                                </div>
                                <div class="col-md-3">
                                    <label class="lblInformeOIT">MÉDICO</label>
                                    <input id="tMedico" style="width: 95%; font-weight: bold;" class="campos-texto" runat="server" disabled />
                                </div>
                                <div class="col-md-3">
                                    <label class="lblInformeOIT">TECNÓLOGO</label>
                                    <input id="tTencologo" style="width: 95%; font-weight: bold;" class="campos-texto" runat="server" disabled />
                                </div>
                                <div class="col-md-2">
                                    <label class="lblInformeOIT">LECTURA NEGATOSCOPIO</label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mNegatoSI">
                                                <b class="size-check">SI </b>
                                                <input type="radio" name="rNegatoscopio" value="1" /></label>
                                        </li>
                                        <li>
                                            <label for="mNegatoNO">
                                                <b class="size-check">NO </b>
                                                <input type="radio" name="rNegatoscopio" value="0" checked /></label>
                                        </li>
                                    </ul>
                                </div>
                                <div class="col-md-12" style="max-height: 10px !important;">&nbsp;</div>
                            </div>
                            <div class="row" style="padding-top: 2px; border-top: 1px solid; padding-bottom: 10px;">
                                <div class="col-md-6 aling-radio-line" style="padding-top: 5px;">
                                    <label class="css-seccion">1A</label>&nbsp;
                                    <label class="lblInformeOIT">CALIDAD </label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mCalidad1">
                                                <b class="size-check-num"></b>
                                                <input type="radio" name="rCalidad" value="1" checked />
                                                1</label></li>
                                        <li>
                                            <label for="mCalidad2">
                                                <b class="size-check-num"></b>
                                                <input type="radio" name="rCalidad" value="2" />
                                                2</label></li>
                                        <li>
                                            <label for="mCalidad3">
                                                <b class="size-check-num"></b>
                                                <input type="radio" name="rCalidad" value="3" />
                                                3</label></li>
                                        <li>
                                            <label for="mCalidad4">
                                                <b class="size-check-num"></b>
                                                <input type="radio" name="rCalidad" value="4" />
                                                4</label></li>
                                    </ul>
                                </div>
                                <div class="col-md-6 aling-radio-line">
                                    <label class="css-seccion">1B</label>&nbsp;
                                    <label class="lblInformeOIT">RADIOGRAFIA NORMAL </label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mRadioNormalSI">
                                                <b class="size-check">SI </b>
                                                <input type="radio" name="rRadioNormal" value="1" checked /></label></li>
                                        <li>
                                            <label for="mRadioNormalNO">
                                                <b class="size-check">NO </b>
                                                <input type="radio" name="rRadioNormal" value="2" /></label></li>

                                    </ul>
                                </div>
                                <div class="col-md-6">
                                    <label class="lblInformeOIT">COMENTARIO:&nbsp;</label>
                                    <input id="tComentario" style="width: 95%; background-color: lightgrey;" class="campos-texto" />
                                </div>
                            </div>
                            <div class="row" style="padding-top: 8px; border-top: 1px solid;">
                                <div class="col-md-12 aling-radio-line" style="padding-top: 4px; padding-left: 15px !important;">
                                    <label class="css-seccion">2A</label>&nbsp;
                                    <label class="lblInformeOIT">ALGUNA ANORMALIDAD PARENQUIMATOSA CONSISTENTE CON NEUMOCONIOSIS:</label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mParenquiatosa">
                                                <b class="size-check-num">SI (Completar 2B y 2C) </b>
                                                <input type="radio" name="rParenquiatosa" value="SI" /></label></li>
                                        <li>
                                            <label for="mParenquiatosa">
                                                <b class="size-check-num">NO (pasar por sección 3) </b>
                                                <input type="radio" name="rParenquiatosa" value="NO" checked /></label></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="seccion2A" class="row" style="padding-top: 10px; padding-bottom: 10px;">
                                <div class="col-md-9" style="padding-left: 15px !important;">
                                    <label class="css-seccion">2B</label>&nbsp;
                                    <label class="lblInformeOIT" style="padding-top: 4px">OPACIDADES PEQUEÑAS</label>
                                </div>
                                <div class="col-md-3">
                                    <label class="css-seccion">2C</label>&nbsp;
                                    <label class="lblInformeOIT" style="padding-top: 4px">OPACIDADES GRANDES</label>
                                </div>
                                <div class="col-md-3" style="padding-left: 40px !important">
                                    <label class="lblInformeOIT">a) Forma / Tamaño</label>
                                    <table class="lblInformeOIT">
                                        <thead>
                                            <tr>
                                                <th colspan="2">Primaria</th>
                                                <th colspan="2">Secundaria</th>
                                            </tr>
                                        </thead>
                                        <tbody class="css-cuaro-externo">
                                            <tr>
                                                <td class="tdStyle">
                                                    <label for="mprimaria">
                                                        <input type="radio" name="r2Bprimaria1" value="p" /><b class="size-check-num">&nbsp; p</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid gray;">
                                                    <label for="mprimaria">
                                                        <input type="radio" name="r2Bprimaria2" value="s" /><b class="size-check-num">&nbsp; s</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid #c7c8ca;">
                                                    <label for="mprimaria">
                                                        <input type="radio" name="r2Bsecundaria1" value="p" /><b class="size-check-num">&nbsp; p</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid gray;">
                                                    <label for="msecundaria">&nbsp;<input type="radio" name="r2Bsecundaria2" value="s" /><b class="size-check-num">&nbsp; s</b></label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdStyle">
                                                    <label for="mprimaria2">
                                                        <input type="radio" name="r2Bprimaria1" value="q" /><b class="size-check-num">&nbsp; q</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid gray;">
                                                    <label for="mprimaria2">
                                                        <input type="radio" name="r2Bprimaria2" value="t" /><b class="size-check-num">&nbsp; t</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid #c7c8ca;">
                                                    <label for="msecundaria2">
                                                        <input type="radio" name="r2Bsecundaria1" value="q" /><b class="size-check-num">&nbsp; q</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid gray;">
                                                    <label for="mprimaria2">
                                                        <input type="radio" name="r2Bsecundaria2" value="t" /><b class="size-check-num">&nbsp; t</b></label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdStyle">
                                                    <label for="mprimaria3">
                                                        <input type="radio" name="r2Bprimaria1" value="r" /><b class="size-check-num">&nbsp; r</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid gray;">
                                                    <label for="mprimaria3">
                                                        <input type="radio" name="r2Bprimaria2" value="u" /><b class="size-check-num">&nbsp; u</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid #c7c8ca;">
                                                    <label for="msecundaria3">
                                                        <input type="radio" name="r2Bsecundaria1" value="r" /><b class="size-check-num">&nbsp; r</b></label>
                                                </td>
                                                <td class="tdStyle" style="border-left: 1px solid gray;">
                                                    <label for="msecundaria3">
                                                        <input type="radio" name="r2Bsecundaria2" value="u" /><b class="size-check-num">&nbsp; u</b></label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="col-md-3">
                                    <label class="lblInformeOIT">b) Zonas</label>
                                    <table class="lblInformeOIT">
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas"><b class="size-check-num">&nbsp; D</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas"><b class="size-check-num">&nbsp; I &nbsp;</b></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas">&nbsp;<input type="radio" name="r2BzonasD1" value="1" /></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas">&nbsp;<input type="radio" name="r2BzonasI1" value="1" /></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas">&nbsp;<input type="radio" name="r2BzonasD2" value="1" /></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas">&nbsp;<input type="radio" name="r2BzonasI2" value="1" /></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas">&nbsp;<input type="radio" name="r2BzonasD3" value="1" /></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <label for="mzonas">&nbsp;<input type="radio" name="r2BzonasI3" value="1" /></label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-3">
                                    <label class="lblInformeOIT">c) Profusión</label>
                                    <table class="lblInformeOIT css-cuaro-externo">
                                        <tr>
                                            <td class="tdStyle">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mprofusion1">
                                                            <input type="radio" name="r2Bprofusion" value="0/-" class="input-disabled" style="background-color: #404848;" disabled /><b class="size-check-num" style="color: gray">&nbsp; 0/-</b></label></li>
                                                    <li>
                                                        <label for="mprofusion1">
                                                            <input type="radio" name="r2Bprofusion" value="0/0" /><b class="size-check-num">&nbsp; 0/0</b></label></li>
                                                    <li>
                                                        <label for="mprofusion1">
                                                            <input type="radio" name="r2Bprofusion" value="0/1" /><b class="size-check-num">&nbsp; 0/1</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mprofusion2">
                                                            <input type="radio" name="r2Bprofusion" value="1/0" /><b class="size-check-num">&nbsp; 1/0</b></label></li>
                                                    <li>
                                                        <label for="mprofusion2">
                                                            <input type="radio" name="r2Bprofusion" value="1/1" /><b class="size-check-num">&nbsp; 1/1</b></label></li>
                                                    <li>
                                                        <label for="mprofusion2">
                                                            <input type="radio" name="r2Bprofusion" value="1/2" /><b class="size-check-num">&nbsp; 1/2</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mprofusion3">
                                                            <input type="radio" name="r2Bprofusion" value="2/1" /><b class="size-check-num">&nbsp; 2/1</b></label></li>
                                                    <li>
                                                        <label for="mprofusion3">
                                                            <input type="radio" name="r2Bprofusion" value="2/2" /><b class="size-check-num">&nbsp; 2/2</b></label></li>
                                                    <li>
                                                        <label for="mprofusion3">
                                                            <input type="radio" name="r2Bprofusion" value="2/3" /><b class="size-check-num">&nbsp; 2/3</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mprofusion4">
                                                            <input type="radio" name="r2Bprofusion" value="3/2" /><b class="size-check-num">&nbsp; 3/2</b></label></li>
                                                    <li>
                                                        <label for="mprofusion4">
                                                            <input type="radio" name="r2Bprofusion" value="3/3" /><b class="size-check-num">&nbsp; 3/3</b></label></li>
                                                    <li>
                                                        <label for="mprofusion4">
                                                            <input type="radio" name="r2Bprofusion" value="3/+" class="input-disabled" style="background-color: #404848;" disabled /><b class="size-check-num" style="color: gray">&nbsp; 3/+</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-3" style="padding-left: 30px !important;">
                                    <table class="lblInformeOIT css-cuaro-externo">
                                        <tr>
                                            <td class="tdStyle">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r2BOpGrandes" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r2BOpGrandes" value="A" /><b class="size-check-num">&nbsp; A</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r2BOpGrandes" value="C" /><b class="size-check-num">&nbsp; C</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r2BOpGrandes" value="B" /><b class="size-check-num">&nbsp; B</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 8px; border-top: 1px solid; padding-bottom: 10px;">
                                <div class="col-md-12 aling-radio-line" style="padding-top: 4px; padding-left: 15px !important">
                                    <label class="css-seccion">3A</label>&nbsp;
                                    <label class="lblInformeOIT">ALGUNA ANORMALIDAD PLEURAL CONSISTENTE CON NEUMOCONIOSIS:</label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mAnormalidadPleural">
                                                <b class="size-check-num">SI (Completar 3B, 3C, y 3D) </b>
                                                <input type="radio" name="rAnormalidadPleural" value="SI" /></label></li>
                                        <li>
                                            <label for="mAnormalidadPleural">
                                                <b class="size-check-num">NO (pasar por sección 4) </b>
                                                <input type="radio" name="rAnormalidadPleural" value="NO" checked /></label></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="seccion3B" class="row" style="padding-top: 8px; border-top: 1px solid; padding-bottom: 10px;">
                                <div class="col-md-4 aling-radio-line" style="padding-top: 5px; padding-left: 15px !important">
                                    <label class="css-seccion">3B</label>
                                    <label class="lblInformeOIT">PLACAS PLEURALES: </label>
                                    <ul class="radio-list">
                                        <li>
                                            <label><b class="size-check-num">SI</b><input type="radio" name="rPlacasPleurales" value="SI" /></label></li>
                                        <li>
                                            <label><b class="size-check-num">NO</b><input type="radio" name="rPlacasPleurales" value="NO" checked /></label></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="seccion3F" class="row" style="padding-top: 8px">
                                <div id="seccion3FM" class="col-md-4">
                                    <table class="lblInformeOIT">
                                        <tr>
                                            <td class="tdStyle">
                                                <label for="mprofusion1">&nbsp;</label>
                                            </td>
                                            <td style="text-align: center;">
                                                <br />
                                                <label for="mprofusion1">&nbsp;<b>SITIO</b></label>
                                            </td>
                                            <td style="text-align: center;">
                                                <br />
                                                <label for="mprofusion1">&nbsp;<b>CALCIFICACIÓN</b></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <label class="lblInformeOIT"><b class="size-check-num">&nbsp;Perfil&nbsp;</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralPerSitio" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralPerSitio" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralPerSitio" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label>
                                                            <input type="radio" name="placaPerCalsificacion" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label>
                                                            <input type="radio" name="placaPerCalsificacion" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label>
                                                            <input type="radio" name="placaPerCalsificacion" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <label class="lblInformeOIT"><b class="size-check-num">&nbsp;Frente&nbsp;</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralFreSitio" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralFreSitio" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralFreSitio" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralFreCalsificacion" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralFreCalsificacion" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralFreCalsificacion" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <label class="lblInformeOIT"><b class="size-check-num">&nbsp;Diagrama&nbsp;</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralDiaSitio" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralDiaSitio" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralDiaSitio" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralDiaCalsificacion" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralDiaCalsificacion" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralDiaCalsificacion" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <label class="lblInformeOIT"><b class="size-check-num">&nbsp;Otro Sitio&nbsp;</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralOtroSitio" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralOtroSitio" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="ppleuralOtroSitio" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralOtroCalsificacion" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralOtroCalsificacion" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="ppleuralOtroCalsificacion" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-4">
                                    <table class="lblInformeOIT">
                                        <tr>
                                            <td>
                                                <label class="lblInformeOIT">
                                                    EXTENSIÓN: PARED<br />
                                                    (Combinado de Perfil y Frente)</label></td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared1" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared1" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared1S" value="1" /><b class="size-check-num">&nbsp; 1</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared1S" value="2" /><b class="size-check-num">&nbsp; 2</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared1S" value="3" /><b class="size-check-num">&nbsp; 3</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared2" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared2" value="I" /><b class="size-check-num">&nbsp;&nbsp; I&nbsp;</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared2S" value="1" /><b class="size-check-num">&nbsp; 1</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared2S" value="2" /><b class="size-check-num">&nbsp; 2</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3FExtenconPared2S" value="3" /><b class="size-check-num">&nbsp; 3</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                    <p class="lblInformeOIT" style="font-weight: normal; text-align: justify;">
                                        Para 1/4 de la pared lateral = 1
                                        <br />
                                        1/4 a 1/2 de pared lateral = 2
                                        <br />
                                        > 1/2 de pared lateral = 3
                                    </p>
                                </div>
                                <div class="col-md-4">
                                    <table>
                                        <tr>
                                            <td>
                                                <label class="lblInformeOIT">
                                                    ANCHO (OPCIONAL)<br />
                                                    (solo en perfil, 3mm grosor minimo)</label></td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho1" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho1S" value="a" /><b class="size-check-num">&nbsp; a</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho1S" value="b" /><b class="size-check-num">&nbsp; b</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho1S" value="c" /><b class="size-check-num">&nbsp; c</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho2" value="I" /><b class="size-check-num">&nbsp; I&nbsp;&nbsp;</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho2S" value="a" /><b class="size-check-num">&nbsp; a</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho2S" value="b" /><b class="size-check-num">&nbsp; b</b></label></li>
                                                    <li>
                                                        <label for="mOpacidadesPequeñas">
                                                            <input type="radio" name="r3BPleuralAncho2S" value="c" /><b class="size-check-num">&nbsp; c</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                    <p class="lblInformeOIT" style="font-weight: normal; text-align: justify;">
                                        1 a 5mm = a<br />
                                        3 a 10mm = b<br />
                                        > 10mm = c<br />
                                    </p>
                                </div>
                            </div>
                            <div id="seccion3C" class="row" style="padding-top: 8px;">
                                <div class="col-md-12 aling-radio-line" style="padding-top: 4px; padding-left: 15px !important">
                                    <label class="css-seccion">3C</label>&nbsp;
                                    <label for="mParenquiatosa" class="lblInformeOIT"><b class="size-check-num">OBLITERACIÓN ANGULO COSTOFRENICO:</b></label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mParenquiatosa">
                                                <input type="radio" name="r3CObliteracion" value="O" /><b class="size-check-num">&nbsp;O</b></label></li>
                                        <li>
                                            <label for="mParenquiatosa">
                                                <input type="radio" name="r3CObliteracion" value="D" /><b class="size-check-num">&nbsp;D</b></label></li>
                                        <li>
                                            <label for="mParenquiatosa">
                                                <input type="radio" name="r3CObliteracion" value="I" /><b class="size-check-num">&nbsp;I</b></label></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="seccion3D" class="row" style="padding-top: 8px">
                                <div class="col-md-4 aling-radio-line" style="padding-top: 4px; padding-left: 15px !important;">
                                    <label class="css-seccion">3D</label>&nbsp;
                                    <label class="lblInformeOIT">ENGROSAMIENTO PLEURAL DIFUSO:&nbsp;</label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mEngrosamientoPleuralDifuso">
                                                <b class="size-check">SI </b>
                                                <input type="radio" name="rEngrosamientoPleuralDifuso" value="SI" /></label></li>
                                        <li>
                                            <label for="mEngrosamientoPleuralDifuso">
                                                <b class="size-check">NO </b>
                                                <input type="radio" name="rEngrosamientoPleuralDifuso" value="NO" /></label></li>
                                    </ul>
                                </div>
                            </div>
                            <div id="seccion3DM" class="row" style="padding-top: 8px">
                                <div id="seccion3DM1" class="col-md-4">
                                    <table class="lblInformeOIT">
                                        <tr>
                                            <td class="tdStyle">
                                                <label for="mprofusion1">&nbsp;&nbsp;</label>
                                            </td>
                                            <td style="text-align: center;">
                                                <label for="mprofusion1">
                                                    &nbsp;<br />
                                                    <b>SITIO</b></label>
                                            </td>
                                            <td style="text-align: center;">
                                                <label for="mprofusion1">
                                                    &nbsp;<br />
                                                    <b>CALCIFICACIÓN</b></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <label class="lblInformeOIT"><b class="size-check-num">&nbsp;Perfil&nbsp;</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="r3DMDifusoSitioPerfil" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="r3DMDifusoSitioPerfil" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="r3DMDifusoSitioPerfil" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="r3DMDifusoCalsiPerfil" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="r3DMDifusoCalsiPerfil" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="r3DMDifusoCalsiPerfil" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle">
                                                <label class="lblInformeOIT"><b class="size-check-num">&nbsp;Frente&nbsp;</b></label>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="r3DMSitioFrente" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="r3DMSitioFrente" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralSitio">
                                                            <input type="radio" name="r3DMSitioFrente" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="r3DMCalsiFrente" value="O" /><b class="size-check-num">&nbsp; O</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="r3DMCalsiFrente" value="D" /><b class="size-check-num">&nbsp; D</b></label></li>
                                                    <li>
                                                        <label for="placaPeuralCalsifica">
                                                            <input type="radio" name="r3DMCalsiFrente" value="I" /><b class="size-check-num">&nbsp; I</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-md-4">
                                    <div class="col-sm-8" style="padding-left: 5px">
                                        <label class="lblInformeOIT">EXTENSIÓN: PARED (Combinado de Perfil y Frente)</label>
                                    </div>
                                    <table>
                                        <tr>
                                            <td class="css-cuaro-externo">
                                                <ul class="radio-list" style="padding: 3px 3px 3px 3px;">
                                                    <li>
                                                        <label for="m3DM2ExtencionPared1">
                                                            <input type="radio" name="r3DM1EngExtencionPared1" value="O" /><b class="size-check-num">&nbsp;O</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared">
                                                            <input type="radio" name="r3DM1EngExtencionPared1" value="D" /><b class="size-check-num">&nbsp;D</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared1">
                                                            <input type="radio" name="r3DM1EngExtencionPared1S" value="1" /><b class="size-check-num">&nbsp;1</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared1">
                                                            <input type="radio" name="r3DM1EngExtencionPared1S" value="2" /><b class="size-check-num">&nbsp;2</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared1">
                                                            <input type="radio" name="r3DM1EngExtencionPared1S" value="3" /><b class="size-check-num">&nbsp;3</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="css-cuaro-externo">
                                                <ul class="radio-list" style="padding: 3px 3px 3px 3px;">
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared2">
                                                            <input type="radio" name="r3DM1EngExtencionPared2" value="O" /><b class="size-check-num">&nbsp;O</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared2">
                                                            <input type="radio" name="r3DM1EngExtencionPared2" value="I" /><b class="size-check-num">&nbsp;&nbsp;I&nbsp;</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared2">
                                                            <input type="radio" name="r3DM1EngExtencionPared2S" value="1" /><b class="size-check-num">&nbsp;1</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared2">
                                                            <input type="radio" name="r3DM1EngExtencionPared2S" value="2" /><b class="size-check-num">&nbsp;2</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoExtencionPared2">
                                                            <input type="radio" name="r3DM1EngExtencionPared2S" value="3" /><b class="size-check-num">&nbsp;3</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                    <p class="lblInformeOIT" style="font-weight: normal; text-align: justify;">
                                        Para 1/4 de la pared lateral = 1<br />
                                        1/4 a 1/2 de pared lateral = 2<br />
                                        > 1/2 de pared lateral = 3
                                    </p>
                                </div>
                                <div class="col-md-4">
                                    <div class="col-sm-9" style="padding-left: 5px;">
                                        <label class="lblInformeOIT">ANCHO (OPCIONAL) (Solo en perfil, 3mm grosor minimo)</label>
                                    </div>
                                    <table>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="mrEngrosamientoPleuralDifusoAncho1">
                                                            <input type="radio" name="r3DMAncho1" value="D" /><b class="size-check-num">&nbsp;D</b></label></li>
                                                    <li>
                                                        <label for="mrEngrosamientoPleuralDifusoAncho1">
                                                            <input type="radio" name="r3DMAncho1S" value="a" /><b class="size-check-num">&nbsp;a</b></label></li>
                                                    <li>
                                                        <label for="mrEngrosamientoPleuralDifusoAncho1">
                                                            <input type="radio" name="r3DMAncho1S" value="b" /><b class="size-check-num">&nbsp;b</b></label></li>
                                                    <li>
                                                        <label for="mrEngrosamientoPleuralDifusoAncho1">
                                                            <input type="radio" name="r3DMAncho1S" value="c" /><b class="size-check-num">&nbsp;c</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdStyle css-cuaro-externo">
                                                <ul class="radio-list">
                                                    <li>
                                                        <label for="rEngrosamientoPleuralDifusoAncho2">
                                                            <input type="radio" name="r3DMAncho2" value="I" /><b class="size-check-num">&nbsp;I&nbsp;&nbsp;</b></label></li>
                                                    <li>
                                                        <label for="rEngrosamientoPleuralDifusoAncho2">
                                                            <input type="radio" name="r3DMAncho2S" value="a" /><b class="size-check-num">&nbsp;a</b></label></li>
                                                    <li>
                                                        <label for="rEngrosamientoPleuralDifusoAncho2">
                                                            <input type="radio" name="r3DMAncho2S" value="b" /><b class="size-check-num">&nbsp;b</b></label></li>
                                                    <li>
                                                        <label for="mEngrosamientoPleuralDifusoAncho2">
                                                            <input type="radio" name="r3DMAncho2S" value="c" /><b class="size-check-num">&nbsp;c</b></label></li>
                                                </ul>
                                            </td>
                                        </tr>
                                    </table>
                                    <p class="lblInformeOIT" style="font-weight: normal; text-align: justify;">
                                        3 a 5 mm = a<br />
                                        5 a 10 mm = b<br />
                                        > 10 mm = c
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 div-espaciador"></div>
                                <div class="col-md-12 aling-radio-line" style="padding-left: 15px !important">
                                    <label class="css-seccion">4A</label>&nbsp;
                                    <label class="lblInformeOIT">OTRAS ANORMALIDADES&nbsp;</label>
                                    <ul class="radio-list">
                                        <li>
                                            <label for="mOtrasAnormalidades"><b class="size-check-num">SI&nbsp;</b><input type="radio" name="rOtrasAnormalidades" value="SI" /></label></li>
                                        <li>
                                            <label for="mOtrasAnormalidades"><b class="size-check-num">NO&nbsp;</b><input type="radio" name="rOtrasAnormalidades" value="NO" checked /></label></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="row css-disabled-div" id="simbolos">
                                <div class="col-md-12 div-espaciador"></div>
                                <div class="col-md-12 align-content-center" style="padding-top: 4px; padding-left: 15px !important">
                                    <label class="css-seccion">4B</label>
                                    &nbsp;
                                    <label class="lblInformeOIT">SÍMBOLOS: </label>
                                    <table style="text-align: center;">
                                        <tr>
                                            <th style="width: 2%">
                                                <label>aa</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>at</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>ax</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>bu</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>ca</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>cg</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>cn</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>co</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>cp</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>cv</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>di</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>ef</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>em</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>es</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>fr</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>hi</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>ho</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>id</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>ih</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>kl</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>me</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>pa</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>pb</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>pi</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>px</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>ra</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>rp</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>tb</label>
                                            </th>
                                            <th style="width: 2%">
                                                <label>od*</label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_aa" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_at" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_ax" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_bu" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_ca" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_cg" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_cn" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_co" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_cp" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_cv" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_di" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_ef" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_em" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_es" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_fr" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_hi" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_ho" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_id" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_ih" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_kl" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_me" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_pa" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_pb" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_pi" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_px" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_ra" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_rp" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_tb" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="cb_simbolo_od" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row invox-content">
                                <div class="col-md-12 div-espaciador"></div>
                            
                                <div class="col-md-12" style="padding-top: 1px; padding-left: 15px !important">
                                    <label class="css-seccion">4C</label>&nbsp;
                                    <label class="lblInformeOIT">COMENTARIO: </label>
                                    <main style="margin-top: -40px;">
                                        <div id="invox-content" class="col-md-12">
                                            <div class="d-flex justify-content-center" style="margin-top: 30px"></div>
                                            <div class="row invox-nomargin">
                                                <br />
                                                <textarea id="tcomentarioGen" type="text" style="width: 80%; height: 100px;" class="invox-textarea campos-texto" onfocus="OnClickTextArea(id)"></textarea>
                                                <br />
                                            </div>
                                        </div>
                                    </main>
                                    <label class="lblInformeOIT" style="padding-left: 20px;">FECHA DE LECTURA: </label>
                                    <br />
                                    <input id="txtFechaLectura" class="campos-texto" style="width: 180px; text-align: center; font-weight: bold; padding-left: 20px;" disabled />
                                    <br />
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-sm-2 col-extra-small">
                                            <input id="bComentario" type="button" class="btn btn-filter" style="min-width: 80px !important; margin-right: 15px;" value="Comentarios" />
                                        </div>
                                        <div class="col-sm-2 col-extra-small">
                                            <input id="bSaveInf" type="button" class="btn btn-filter" style="min-width: 80px !important; margin-right: 15px;" value="Guardar" />
                                        </div>
                                        <div class="col-sm-2 col-extra-small">
                                            <input id="bBack" type="button" class="btn btn-filter" style="min-width: 80px !important" value="Regresar" />
                                        </div>
                                        <div class="col-sm-2 col-extra-small">
                                            <input id="bNotificar" type="button" class="btn btn-filter" style="min-width: 80px !important" value="Pendiente" />
                                        </div>
                                        <div class="col-sm-3 col-extra-small">
                                            <input id="bSaveVal" type="button" class="btn btn-filter" style="float: right; min-width: 90px !important; margin-right: 5px;" value="Validar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div runat="server" class="modal fade" id="modalMessageBox" style="padding-top: 250px !important">
            <div class="modal-dialog" style="background-color: #7C7F7F">
                <div class="modal-content" style="background-color: #7C7F7F">
                    <div class="modal-header" style="text-align: center;">
                        <label style="width: 100%;" class="texto1 titulo1"><b style="color: white; font-size: 14px !important">INFORMACIÓN</b></label>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-12" style="text-align: center !important;">
                                <label style="font-size: 14px !important;" id="messagePrestacion" />
                            </div>
                        </div>
                        <div class="row pt-4">
                            <div class="col-12" style="padding-left: 35%;">
                                <input id="bCierre" type="button" class="btn btn-clear" style="min-width: 100px !important;" value="CERRAR" />
                            </div>
                        </div>
                    </div>
                    <div style="background-color: #352D5C; height: 5px; width: 100%;"></div>
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
                    <select id="Categoria" class="form-control-ddl" style="font-size: 12px; font-weight: bold; width: 250px !important">
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
    </form>

    <script type="text/javascript" src="../../vocali/js/mainOIT.js?v9" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/master.js"></script>
    <script type="text/javascript" src="../js/Informar.js?v11"></script>
    <script type="text/javascript" src="../Complementos/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/ckeditor/plugins/texttransform/plugin.js?v1"></script>
    
    <script src="../js/chatIrad.js"></script>
    
    <script src="../js/multiselect/jquery.multiselect.min.js"></script>
    <script src="../js/multiselect/jquery.multiselect.es.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.js"></script>
    <script src="../js/multiselect/jquery.multiselect.filter.min.js"></script>
    
    <script>
        $(document).ready(function () {
            var swClose = false;
            var sExtenconPared1 = "";

            validarVocaliOIT();

            var tableP = new DataTable('#gPrestacion', {
                searching: false
                , fixedHeader: true
                , autoWidth: false
                , autoheight: true
                , dom: 'rtip'
                , info: false
                , select: false
                , retrieve: true
                , paging: false
                , oLanguage: { sEmptyTable: "No se encontraron prestaciones " }
                , columns: [{ orderable: false }]
            });

            var tableD = new DataTable('#gDocumentos', {
                searching: false
                , fixedHeader: true
                , autoWidth: false
                , autoheight: true
                , dom: 'rtip'
                , info: false
                , select: false
                , retrieve: true
                , paging: false
                , oLanguage: { sEmptyTable: "No se encontraron documentos " }
                , columns: [
                    {
                        orderable: false,
                        render: function (data, type, row, meta) {
                            var data = row[1].toString();

                            return data;
                        }
                    }
                    , {
                        orderable: false,
                        render: function (data, type, row, meta) {
                            var image = '';

                            if (row[6] == 'pdf')
                                image += "<a href='#' onclick='cargarDocumentoPDF(&#34" + row[7] + row[3] + row[2] + "&#34); return false;' target='_blank' title='" + row[1] + "'><img src='../icon/visor.sl.png' /></a>";
                            else
                                image += "<a href='#' onclick='cargarDocumento(&#34" + row[7] + row[3] + row[2] + "&#34); return false;' target='_blank' title='" + row[1] + "'><img src='../icon/visor.sl.png' /></a>";

                            return image;
                        }
                    }
                ]
            });

            var dataPaciente = '{ risExamen:' + $('#risExamen').val() + '}';

            $.ajax({
                type: "POST",
                url: "../Examen/InformaOIT.aspx/DatosPaciente",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataPaciente,
                async: true,
                success: function (arg) {
                    var data = arg.d.Data;

                    if (data.Ejecutado) {
                        $('#lCentro').text(data.Data.institucion);
                        $('#lIdPaciente').text(data.Data.idpaciente);
                        $('#lnombre').text(data.Data.nombre);
                        $('#lnumeroacceso').text(data.Data.numeroacceso);
                        $('#lsexo').text(data.Data.sexo);
                        $('#ledad').text(data.Data.edad);
                        $('#tNombrePaciente').val(data.Data.nombre);
                        $('#tIdentificador').val($('#risExamen').val());
                        $('#tFechaRadiografia').val(new Date(parseInt(data.Data.fechaexamen.replace('/Date(', '').replace(')/', ''))).toLocaleDateString());
                    } else {
                        $("#messagePrestacion").text(data.Mensaje);
                        $("#modalMessageBox").modal("show");
                    }
                },
                error: function (msg) {
                    $("#messagePrestacion").text(msg.responseText);
                    $("#modalMessageBox").modal("show");
                },
                failure: function (fail) {
                    $("#messagePrestacion").text(fail);
                    $("#modalMessageBox").modal("show");
                }
            });

            $.ajax({
                type: "POST",
                url: "../Examen/InformaOIT.aspx/ObtieneComentarioTM",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataPaciente,
                async: true,
                success: function (arg) {
                    var data = arg.d.Data;

                    if (data.Ejecutado) {
                        $('#comentarioTM').text(data.Data);
                    } else {
                        $("#messagePrestacion").text(data.Mensaje);
                        $("#modalMessageBox").modal("show");
                    }
                },
                error: function (msg) {
                    $("#messagePrestacion").text(msg.responseText);
                    $("#modalMessageBox").modal("show");
                },
                failure: function (fail) {
                    $("#messagePrestacion").text(fail);
                    $("#modalMessageBox").modal("show");
                }
            });

            $.ajax({
                type: "POST",
                url: "../Examen/InformaOIT.aspx/ObtieneAntecedentes",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataPaciente,
                async: true,
                success: function (arg) {
                    var data = arg.d.Data;

                    if (data.Ejecutado) {
                        $('#antecedenteClinico').text(data.Data);
                    } else {
                        $("#messagePrestacion").text(data.Mensaje);
                        $("#modalMessageBox").modal("show");
                    }
                },
                error: function (msg) {
                    $("#messagePrestacion").text(msg.responseText);
                    $("#modalMessageBox").modal("show");
                },
                failure: function (fail) {
                    $("#messagePrestacion").text(fail);
                    $("#modalMessageBox").modal("show");
                }
            });

            var dataCodExamen = '{ codExamen:"' + $('#codExamen').val() + '"}';

            $('#vNombreUsuario').text($('#usuarioNombre').val());
            $('#vPerfilNombre').text($('#perfilNombre').val());

            $.ajax({
                type: "POST",
                url: "../Examen/InformaOIT.aspx/ObtieneVisores",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataCodExamen,
                async: true,
                success: function (arg) {
                    var data = arg.d.Data;

                    if (data.Ejecutado) {
                        $('#lVisores').append(data.Data);
                    } else {
                        $("#messagePrestacion").text(data.Mensaje);
                        $("#modalMessageBox").modal("show");
                    }
                },
                error: function (msg) {
                    $("#messagePrestacion").text(msg.responseText);
                    $("#modalMessageBox").modal("show");
                },
                failure: function (fail) {
                    $("#messagePrestacion").text(fail);
                    $("#modalMessageBox").modal("show");
                }
            });

            var arrayPres = $('#prestacion').val().toString().split(',');

            arrayPres.forEach(function (prestacion) {
                tableP.row.add([prestacion]).draw(false);
            });

            var dataRelacion = '{ codExamen:"' + $('#codExamen').val() + '"}';

            $.ajax({
                type: "POST",
                url: "../Examen/InformaOIT.aspx/ObtieneRelacionados",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataRelacion,
                beforeSend: function () {
                    $("#divEstudiosRelacionados").children("table").remove();
                    $("#divEstudiosRelacionados").children("div").remove();

                    $("#divEstudiosRelacionados").append("<div style='width: 100%; text-align: center'><img src='../icon/preloader.gif' style='width: 40px; cursor: pointer'/></div>");
                },
                async: true,
                success: function (arg) {
                    var data = arg.d.Data;

                    if (data.Ejecutado) {
                        $("#divEstudiosRelacionados").append(data.Data);
                    } else {
                        $("#messagePrestacion").text(data.Mensaje);
                        $("#modalMessageBox").modal("show");
                    }
                },
                error: function (msg) {
                    $("#messagePrestacion").text(msg.responseText);
                    $("#modalMessageBox").modal("show");
                },
                failure: function (fail) {
                    $("#messagePrestacion").text(fail);
                    $("#modalMessageBox").modal("show");
                }
            }).done(function () {
                $("#divEstudiosRelacionados").children("div").remove();
            });

            var dataDocumento = '{ risExamen:' + $('#risExamen').val() + '}';

            $.ajax({
                type: "POST",
                url: "../Examen/InformaOIT.aspx/DocumentosExamen",
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                data: dataDocumento,
                async: true,
                success: function (arg) {
                    var data = arg.d.Data;

                    if (data.Ejecutado) {
                        $.each(arg.d.Data.Data, function (i, item) {
                            tableD.row.add(item['id'].toString(), item['descripcion'].toString(), item['filename'].toString(), item['webfolder'].toString(), item['fecha'].toString(), item['size'].toString(), item['archivo'].toString(), item['url'].toString()).draw(false);
                        });
                    } else {
                        $("#messagePrestacion").text(data.Mensaje);
                        $("#modalMessageBox").modal("show");
                    }
                },
                error: function (msg) {
                    $("#messagePrestacion").text(msg.responseText);
                    $("#modalMessageBox").modal("show");
                },
                failure: function (fail) {
                    $("#messagePrestacion").text(fail);
                    $("#modalMessageBox").modal("show");
                }
            });

            $("#Categoria").multiselect({
                multiple: false,
                selectedList: 1,
                minWidth: 300,
                noneSelectedText: '&nbsp;&nbsp;Seleccione..',
                header: false,
                height: 'auto',
                width: 300,
            });

            if ($('#informe').val() != '0') {
                var datainforme = '{ codExamen:"' + $('#codExamen').val() + '", informe:' + $('#informe').val() + '}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/InformaOIT.aspx/ObtieneInforme",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: datainforme,
                    async: true,
                    success: function (arg) {
                        var data = arg.d.Data;

                        if (data.Ejecutado) {
                            AsignaValor(data.Data);
                        } else {
                            $("#messagePrestacion").text(data.Mensaje);
                            $("#modalMessageBox").modal("show");
                        }
                    },
                    error: function (msg) {
                        $("#messagePrestacion").text(msg.responseText);
                        $("#modalMessageBox").modal("show");
                    },
                    failure: function (fail) {
                        $("#messagePrestacion").text(fail);
                        $("#modalMessageBox").modal("show");
                    }
                });
            };

            $('#txtFechaLectura').val(new Date().toLocaleDateString("en-GB"));

            $('input[name="rParenquiatosa"]').change(function () {

                if ($(this).val() != 'SI') {
                    $('#seccion2A input[type="radio"]').each(function () { $(this).prop('checked', false); });
                }
            });

            $('input[name="r2Bprimaria1"]').click(function () { toggleRadioButton($(this), 'r2Bprimaria1'); });
            $('input[name="r2Bprimaria2"]').click(function () { toggleRadioButton($(this), 'r2Bprimaria2'); });
            $('input[name="r2Bsecundaria1"]').click(function () { toggleRadioButton($(this), 'r2Bsecundaria1'); });
            $('input[name="r2Bsecundaria2"]').click(function () { toggleRadioButton($(this), 'r2Bsecundaria2'); });
            $('input[name="r2BzonasD1"]').click(function () { toggleRadioButton($(this), 'r2BzonasD1'); });
            $('input[name="r2BzonasD2"]').click(function () { toggleRadioButton($(this), 'r2BzonasD2'); });
            $('input[name="r2BzonasD3"]').click(function () { toggleRadioButton($(this), 'r2BzonasD3'); });
            $('input[name="r2BzonasI1"]').click(function () { toggleRadioButton($(this), 'r2BzonasI1'); });
            $('input[name="r2BzonasI2"]').click(function () { toggleRadioButton($(this), 'r2BzonasI2'); });
            $('input[name="r2BzonasI3"]').click(function () { toggleRadioButton($(this), 'r2BzonasI3'); });
            $('input[name="r2Bprofusion"]').click(function () { toggleRadioButton($(this), 'r2Bprofusion'); });
            $('input[name="r2BOpGrandes"]').click(function () { toggleRadioButton($(this), 'r2BOpGrandes'); });
            $('input[name="r3FExtenconPared1"]').click(function () { toggleRadioButton($(this), 'r3FExtenconPared1'); });
            $('input[name="r3FExtenconPared1S"]').click(function () { toggleRadioButton($(this), 'r3FExtenconPared1S'); });
            $('input[name="r3FExtenconPared2"]').click(function () { toggleRadioButton($(this), 'r3FExtenconPared2'); });
            $('input[name="r3FExtenconPared2S"]').click(function () { toggleRadioButton($(this), 'r3FExtenconPared2S'); });
            $('input[name="r3BPleuralAncho1"]').click(function () { toggleRadioButton($(this), 'r3BPleuralAncho1'); });
            $('input[name="r3BPleuralAncho2"]').click(function () { toggleRadioButton($(this), 'r3BPleuralAncho2'); });
            $('input[name="r3CObliteracion"]').click(function () { toggleRadioButton($(this), 'r3CObliteracion'); });
            $('input[name="ppleuralPerSitio"]').click(function () { toggleRadioButton($(this), 'ppleuralPerSitio'); });
            $('input[name="placaPerCalsificacion"]').click(function () { toggleRadioButton($(this), 'placaPerCalsificacion'); });
            $('input[name="ppleuralFreSitio"]').click(function () { toggleRadioButton($(this), 'ppleuralFreSitio'); });
            $('input[name="ppleuralFreCalsificacion"]').click(function () { toggleRadioButton($(this), 'ppleuralFreCalsificacion'); });
            $('input[name="ppleuralDiaSitio"]').click(function () { toggleRadioButton($(this), 'ppleuralDiaSitio'); });
            $('input[name="ppleuralDiaCalsificacion"]').click(function () { toggleRadioButton($(this), 'ppleuralDiaCalsificacion'); });
            $('input[name="ppleuralOtroSitio"]').click(function () { toggleRadioButton($(this), 'ppleuralOtroSitio'); });
            $('input[name="ppleuralOtroCalsificacion"]').click(function () { toggleRadioButton($(this), 'ppleuralOtroCalsificacion'); });
            $('input[name="r3DMDifusoSitioPerfil"]').click(function () { toggleRadioButton($(this), 'r3DMDifusoSitioPerfil'); });
            $('input[name="r3DMDifusoCalsiPerfil"]').click(function () { toggleRadioButton($(this), 'r3DMDifusoCalsiPerfil'); });
            $('input[name="r3DMSitioFrente"]').click(function () { toggleRadioButton($(this), 'r3DMSitioFrente'); });
            $('input[name="r3DM1EngExtencionPared1"]').click(function () { toggleRadioButton($(this), 'r3DM1EngExtencionPared1'); });
            $('input[name="r3DM1EngExtencionPared1S"]').click(function () { toggleRadioButton($(this), 'r3DM1EngExtencionPared1S'); });
            $('input[name="r3DM1EngExtencionPared2"]').click(function () { toggleRadioButton($(this), 'r3DM1EngExtencionPared2'); });
            $('input[name="r3DM1EngExtencionPared2S"]').click(function () { toggleRadioButton($(this), 'r3DM1EngExtencionPared2S'); });
            $('input[name="r3DMAncho1"]').click(function () { toggleRadioButton($(this), 'r3DMAncho1'); });
            $('input[name="r3DMAncho2"]').click(function () { toggleRadioButton($(this), 'r3DMAncho2'); });

            $('input[name="r3FExtenconPared1"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3FExtenconPared1S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3FExtenconPared2"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3FExtenconPared2S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3BPleuralAncho1"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3BPleuralAncho1S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3BPleuralAncho2"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3BPleuralAncho2S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3DM1EngExtencionPared1"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3DM1EngExtencionPared1S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3DM1EngExtencionPared2"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3DM1EngExtencionPared2S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3DMAncho1"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3DMAncho1S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="r3DMAncho2"]').click(function () {
                if (!$(this).data('seleccionado'))
                    $('input[name="r3DMAncho2S').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="rAnormalidadPleural"]').change(function () {
                if ($(this).val() != 'SI') {
                    $('#seccion3B input[type="radio"]').each(function () { $(this).prop('checked', false); });
                    $('#seccion3F input[type="radio"]').each(function () { $(this).prop('checked', false); });
                    $('#seccion3C input[type="radio"]').each(function () { $(this).prop('checked', false); });
                    $('#seccion3D input[type="radio"]').each(function () { $(this).prop('checked', false); });
                }
            });

            $('input[name="rPlacasPleurales"]').change(function () {
                if ($(this).val() != 'SI') $('#seccion3FM input[type="radio"]').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="rEngrosamientoPleuralDifuso"]').change(function () {
                if ($(this).val() != 'SI') $('#seccion3DM1 input[type="radio"]').each(function () { $(this).prop('checked', false); });
            });

            $('input[name="rOtrasAnormalidades"]').change(function () {
                if ($(this).val() != 'SI') {
                    $('#simbolos input[type="checkbox"]').each(function () {
                        $(this).prop('checked', false);
                    });

                    $('#simbolos').addClass('css-disabled-div');
                } else {
                    $('#simbolos').removeClass('css-disabled-div');
                }
            });

            $('#bComentario').on('click', function () {
                ObtenerComentario($('#risExamen').val());

                $("#modalComentarios").modal("show");
            });

            $('#bSaveInf').on('click', function () {
                var oRequest = new Object();

                PreparaData(oRequest, '2');

                ControlSave(oRequest);
            });

            $('#bSaveVal').on('click', function () {
                var oRequest = new Object();

                PreparaData(oRequest, '3');

                ControlSave(oRequest);
            });

            $('#bCierre').on('click', function () {
                if (swClose) window.location.href = "ListaExamen.aspx";

                $("#modalMessageBox").modal("hide");
            });

            $('#aGuardarComentario').on('click', function () {
                var data = '{ risExamen:' + $('#risExamen').val() + ', comentario:"' + $("#txtComentario").val() + '"}';

                $.ajax({
                    type: "POST",
                    url: "InformaOIT.aspx/GuardaComentario",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    success: function (arg) {
                        ObtenerComentario($('#risExamen').val());

                        $("#txtComentario").val("");
                    },
                    error: function () {

                    }
                });

                $("#modalComentarios").modal("hide");
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

            $('#bAdjuntar').on('click', function () {
                $('.custom-file-upload').text('Seleccione Archivo');

                $('#mAdjunto').modal('show');
            });

            $('#file-chat').on('change', function () {
                var filename = $('input[type=file]').val().split('\\').pop();

                $('.custom-file-upload').text(filename);
            });

            $('#adjuntoEnvio').on('click', function () {
                var filename = $('input[type=file]').val().split('\\').pop();
                var file = $("#file-chat")[0].files[0];

                $('#mAdjunto').modal('hide');

                if (!filename || !file) { alert("No se ha seleccionado ningun archivo"); return false; }

                adjuntoFile($('#risExamen').val(), filename, file, $('#usuarioNombre').val(), $('.messages-content-file'));
            });

            function toggleRadioButton(radioButton, groupName) {
                if (radioButton.data('seleccionado')) {
                    radioButton.prop('checked', false);
                    radioButton.data('seleccionado', false);
                } else {
                    $('input[name="' + groupName + '"]').data('seleccionado', false);
                    radioButton.data('seleccionado', true);
                }
            }

            function ControlSave(oRequest) {
                var dataSave = '{ request:' + JSON.stringify(oRequest) + '}';

                $.ajax({
                    type: "POST",
                    url: "../Examen/InformaOIT.aspx/SaveInforme",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: dataSave,
                    async: true,
                    success: function (arg) {
                        var data = arg.d.Data;

                        if (data.Ejecutado) {
                            if (data.Data > 0) {
                                $("#messagePrestacion").text('Informe creado de forma exitosa');
                                $("#modalMessageBox").modal("show");

                                swClose = true;
                            } else {
                                $("#messagePrestacion").text('Error: Error al tratar de grabar infrme');
                                $("#modalMessageBox").modal("show");
                            }
                        } else {
                            $("#messagePrestacion").text(data.Mensaje);
                            $("#modalMessageBox").modal("show");
                        }
                    },
                    error: function (msg) {
                        $("#messagePrestacion").text(msg.responseText);
                        $("#modalMessageBox").modal("show");
                    },
                    failure: function (fail) {
                        $("#messagePrestacion").text(fail);
                        $("#modalMessageBox").modal("show");
                    }
                });
            }

            function PreparaData(oRequest, estado) {
                oRequest.RISEXAMEN = $('#risExamen').val();
                oRequest.RISINFORME = $('#informe').val();
                oRequest.IDESTADO = estado;
                oRequest.IDUSUARIO = '';
                oRequest.CODEXAMEN = '';
                oRequest.PRESTACION = $('#contenido').val();
                oRequest.NUMRADIOGRAFIA = $('#tNumeroRadiografia').val();
                oRequest.RADIOGRAFIADIG = $('input[name="mRadDigital"]:checked').val();
                oRequest.NEGASTOCOPIA = $('input[name="rNegatoscopio"]:checked').val();
                oRequest.CALIDAD = $('input[name="rCalidad"]:checked').val();
                oRequest.RADIOGRAFIANOR = $('input[name="rRadioNormal"]:checked').val();
                oRequest.COMENTARIO = $('#tComentario').val();
                oRequest.PARENQUIMATOSA = $('input[name="rParenquiatosa"]:checked').val();

                oRequest.OPACIPRIMARIAC1 = $('input[name="r2Bprimaria1"]:checked').val() || '0';
                oRequest.OPACIPRIMARIAC2 = $('input[name="r2Bprimaria2"]:checked').val() || '0';

                oRequest.OPACISECUNDARIAC1 = $('input[name="r2Bsecundaria1"]:checked').val() || '0';
                oRequest.OPACISECUNDARIAC2 = $('input[name="r2Bsecundaria2"]:checked').val() || '0';

                oRequest.OPACIDADZONAD1 = $('input[name="r2BzonasD1"]:checked').val() || '0';
                oRequest.OPACIDADZONAD2 = $('input[name="r2BzonasD2"]:checked').val() || '0';
                oRequest.OPACIDADZONAD3 = $('input[name="r2BzonasD3"]:checked').val() || '0';
                oRequest.OPACIDADZONAI1 = $('input[name="r2BzonasI1"]:checked').val() || '0';
                oRequest.OPACIDADZONAI2 = $('input[name="r2BzonasI2"]:checked').val() || '0';
                oRequest.OPACIDADZONAI3 = $('input[name="r2BzonasI3"]:checked').val() || '0';

                oRequest.OPACPROFUSION = $('input[name="r2Bprofusion"]:checked').val() || '0';
                oRequest.OPACIDAGRANDE = $('input[name="r2BOpGrandes"]:checked').val() || '0';
                oRequest.ANORMALPLEURAL = $('input[name="rAnormalidadPleural"]:checked').val() || '0';
                oRequest.PLACAPLEURAL = $('input[name="rPlacasPleurales"]:checked').val() || 'NO';
                oRequest.PP_SITIOPERFIL = $('input[name="ppleuralPerSitio"]:checked').val() || '0';
                oRequest.PP_SITIOFRENTE = $('input[name="ppleuralFreSitio"]:checked').val() || '0';
                oRequest.PP_SITIODIAGRAMA = $('input[name="ppleuralDiaSitio"]:checked').val() || '0';
                oRequest.PP_SITIOOTRO = $('input[name="ppleuralOtroSitio"]:checked').val() || '0';
                oRequest.PP_CALSIFICACIONPERFIL = $('input[name="placaPerCalsificacion"]:checked').val() || '0';
                oRequest.PP_CALSIFICACIONFRENTE = $('input[name="ppleuralFreCalsificacion"]:checked').val() || '0';
                oRequest.PP_CALSIFICACIONDIAGRAMA = $('input[name="ppleuralDiaCalsificacion"]:checked').val() || '0';
                oRequest.PP_CALSIFICACIONOTRO = $('input[name="ppleuralOtroCalsificacion"]:checked').val() || '0';

                oRequest.PP_EXTENSIONPAREDPERFILOP = $('input[name="r3FExtenconPared1"]:checked').val() || '0';
                oRequest.PP_EXTENSIONPAREDPERFILSE = $('input[name="r3FExtenconPared1S"]:checked').val() || '0';
                oRequest.PP_EXTENSIONPAREDFRENTEOP = $('input[name="r3FExtenconPared2"]:checked').val() || '0';
                oRequest.PP_EXTENSIONPAREDFRENTESE = $('input[name="r3FExtenconPared2S"]:checked').val() || '0';
                oRequest.PP_ANCHODERECHAOP = $('input[name="r3BPleuralAncho1"]:checked').val() || '0';
                oRequest.PP_ANCHODERECHASE = $('input[name="r3BPleuralAncho1S"]:checked').val() || '0';
                oRequest.PP_ANCHOIZQUIERDAOP = $('input[name="r3BPleuralAncho2"]:checked').val() || '0';
                oRequest.PP_ANCHOIZQUIERDASE = $('input[name="r3BPleuralAncho2S"]:checked').val() || '0';
                oRequest.OBLITERACION = $('input[name="r3CObliteracion"]:checked').val() || '0';
                oRequest.ENGROSAPLERURALDIFUSO = $('input[name="rEngrosamientoPleuralDifuso"]:checked').val() || 'NO';
                oRequest.EPD_SITIOPERFIL = $('input[name="r3DMDifusoSitioPerfil"]:checked').val() || '0';
                oRequest.EPD_SITIOFRENTE = $('input[name="r3DMSitioFrente"]:checked').val() || '0';
                oRequest.EPD_CALSIFICACIONPERFIL = $('input[name="r3DMDifusoCalsiPerfil"]:checked').val() || '0';
                oRequest.EPD_CALSIFICACIONFRENTE = $('input[name="r3DMCalsiFrente"]:checked').val() || '0';
                oRequest.EPD_EXTENSIONPAREDPERFILOP = $('input[name="r3DM1EngExtencionPared1"]:checked').val() || '0';
                oRequest.EPD_EXTENSIONPAREDPERFILSE = $('input[name="r3DM1EngExtencionPared1S"]:checked').val() || '0';
                oRequest.EPD_EXTENSIONPAREDFRENTEOP = $('input[name="r3DM1EngExtencionPared2"]:checked').val() || '0';
                oRequest.EPD_EXTENSIONPAREDFRENTESE = $('input[name="r3DM1EngExtencionPared2S"]:checked').val() || '0';
                oRequest.EPD_ANCHODERECHAOP = $('input[name="r3DMAncho1"]:checked').val() || '0';
                oRequest.EPD_ANCHODERECHASE = $('input[name="r3DMAncho1S"]:checked').val() || '0';
                oRequest.EPD_ANCHOIZQUIERDAOP = $('input[name="r3DMAncho2"]:checked').val() || '0';
                oRequest.EPD_ANCHOIZQUIERDASE = $('input[name="r3DMAncho2S"]:checked').val() || '0';
                oRequest.OTRASANORMALIDADES = $('input[name="rOtrasAnormalidades"]:checked').val() || '0';

                oRequest.SIMBOLO_AA = $('#cb_simbolo_aa').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_AT = $('#cb_simbolo_at').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_AX = $('#cb_simbolo_ax').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_BU = $('#cb_simbolo_bu').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_CA = $('#cb_simbolo_ca').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_CG = $('#cb_simbolo_cg').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_CN = $('#cb_simbolo_cn').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_CO = $('#cb_simbolo_co').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_CP = $('#cb_simbolo_cp').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_CV = $('#cb_simbolo_cv').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_DI = $('#cb_simbolo_di').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_EF = $('#cb_simbolo_ef').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_EM = $('#cb_simbolo_em').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_ES = $('#cb_simbolo_es').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_FR = $('#cb_simbolo_fr').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_HI = $('#cb_simbolo_hi').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_HO = $('#cb_simbolo_ho').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_ID = $('#cb_simbolo_id').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_IH = $('#cb_simbolo_ih').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_KL = $('#cb_simbolo_kl').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_ME = $('#cb_simbolo_me').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_PA = $('#cb_simbolo_pa').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_PB = $('#cb_simbolo_pb').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_PI = $('#cb_simbolo_pi').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_PX = $('#cb_simbolo_px').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_RA = $('#cb_simbolo_ra').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_RP = $('#cb_simbolo_rp').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_TB = $('#cb_simbolo_tb').is(':checked') ? '1' : '0';
                oRequest.SIMBOLO_OD = $('#cb_simbolo_od').is(':checked') ? '1' : '0';
                oRequest.COMENTARIOGEN = invoxCKEditor.editor.getData(); //$('#tcomentarioGen').val();
            }

            function AsignaValor(oRequest) {
                $('#tNumeroRadiografia').val(oRequest.NUMRADIOGRAFIA);

                $('input[name="mRadDigital"][value="' + oRequest.RADIOGRAFIADIG + '"]').prop('checked', true);
                $('input[name="rNegatoscopio"][value="' + oRequest.NEGASTOCOPIA + '"]').prop('checked', true);
                if (oRequest.CALIDAD != '0') $('input[name="rCalidad"][value="' + oRequest.CALIDAD + '"]').prop('checked', true);
                $('input[name="rRadioNormal"][value="' + oRequest.RADIOGRAFIANOR + '"]').prop('checked', true);

                $('#tComentario').val(oRequest.COMENTARIO);

                if (oRequest.PARENQUIMATOSA != '0') $('input[name="rParenquiatosa"][value="' + oRequest.PARENQUIMATOSA + '"]').prop('checked', true);

                if (oRequest.OPACIPRIMARIAC1 != '0') $('input[name="r2Bprimaria1"][value="' + oRequest.OPACIPRIMARIAC1 + '"]').prop('checked', true);
                if (oRequest.OPACIPRIMARIAC2 != '0') $('input[name="r2Bprimaria2"][value="' + oRequest.OPACIPRIMARIAC2 + '"]').prop('checked', true);

                if (oRequest.OPACISECUNDARIAC1 != '0') $('input[name="r2Bsecundaria1"][value="' + oRequest.OPACISECUNDARIAC1 + '"]').prop('checked', true);
                if (oRequest.OPACISECUNDARIAC2 != '0') $('input[name="r2Bsecundaria2"][value="' + oRequest.OPACISECUNDARIAC2 + '"]').prop('checked', true);

                if (oRequest.OPACIDADZONAD1 != '0') $('input[name="r2BzonasD1"][value="' + oRequest.OPACIDADZONAD1 + '"]').prop('checked', true);
                if (oRequest.OPACIDADZONAD2 != '0') $('input[name="r2BzonasD2"][value="' + oRequest.OPACIDADZONAD2 + '"]').prop('checked', true);
                if (oRequest.OPACIDADZONAD3 != '0') $('input[name="r2BzonasD3"][value="' + oRequest.OPACIDADZONAD3 + '"]').prop('checked', true);

                if (oRequest.OPACIDADZONAI1 != '0') $('input[name="r2BzonasI1"][value="' + oRequest.OPACIDADZONAI1 + '"]').prop('checked', true);
                if (oRequest.OPACIDADZONAI2 != '0') $('input[name="r2BzonasI2"][value="' + oRequest.OPACIDADZONAI2 + '"]').prop('checked', true);
                if (oRequest.OPACIDADZONAI3 != '0') $('input[name="r2BzonasI3"][value="' + oRequest.OPACIDADZONAI3 + '"]').prop('checked', true);

                if (oRequest.OPACPROFUSION != '0') $('input[name="r2Bprofusion"][value="' + oRequest.OPACPROFUSION + '"]').prop('checked', true);
                if (oRequest.OPACIDAGRANDE != '0') $('input[name="r2BOpGrandes"][value="' + oRequest.OPACIDAGRANDE + '"]').prop('checked', true);
                if (oRequest.ANORMALPLEURAL != '0') $('input[name="rAnormalidadPleural"][value="' + oRequest.ANORMALPLEURAL + '"]').prop('checked', true);

                if (oRequest.PLACAPLEURAL != '0') $('input[name="rPlacasPleurales"][value="' + oRequest.PLACAPLEURAL + '"]').prop('checked', true);

                if (oRequest.PP_SITIOPERFIL != '0') $('input[name="ppleuralPerSitio"][value="' + oRequest.PP_SITIOPERFIL + '"]').prop('checked', true);
                if (oRequest.PP_SITIOFRENTE != '0') $('input[name="ppleuralFreSitio"][value="' + oRequest.PP_SITIOFRENTE + '"]').prop('checked', true);
                if (oRequest.PP_SITIODIAGRAMA != '0') $('input[name="ppleuralDiaSitio"][value="' + oRequest.PP_SITIODIAGRAMA + '"]').prop('checked', true);
                if (oRequest.PP_SITIOOTRO != '0') $('input[name="ppleuralOtroSitio"][value="' + oRequest.PP_SITIOOTRO + '"]').prop('checked', true);
                if (oRequest.PP_CALSIFICACIONPERFIL != '0') $('input[name="placaPerCalsificacion"][value="' + oRequest.PP_CALSIFICACIONPERFIL + '"]').prop('checked', true);
                if (oRequest.PP_CALSIFICACIONFRENTE != '0') $('input[name="ppleuralFreCalsificacion"][value="' + oRequest.PP_CALSIFICACIONFRENTE + '"]').prop('checked', true);
                if (oRequest.PP_CALSIFICACIONDIAGRAMA != '0') $('input[name="ppleuralDiaCalsificacion"][value="' + oRequest.PP_CALSIFICACIONDIAGRAMA + '"]').prop('checked', true);
                if (oRequest.PP_CALSIFICACIONOTRO != '0') $('input[name="ppleuralOtroCalsificacion"][value="' + oRequest.PP_CALSIFICACIONOTRO + '"]').prop('checked', true);

                if (oRequest.PP_EXTENSIONPAREDPERFILOP != '0') $('input[name="r3FExtenconPared1"][value="' + oRequest.PP_EXTENSIONPAREDPERFILOP + '"]').prop('checked', true);
                if (oRequest.PP_EXTENSIONPAREDPERFILSE != '0') $('input[name="r3FExtenconPared1S"][value="' + oRequest.PP_EXTENSIONPAREDPERFILSE + '"]').prop('checked', true);
                if (oRequest.PP_EXTENSIONPAREDFRENTEOP != '0') $('input[name="r3FExtenconPared2"][value="' + oRequest.PP_EXTENSIONPAREDFRENTEOP + '"]').prop('checked', true);
                if (oRequest.PP_EXTENSIONPAREDFRENTESE != '0') $('input[name="r3FExtenconPared2S"][value="' + oRequest.PP_EXTENSIONPAREDFRENTESE + '"]').prop('checked', true);
                if (oRequest.PP_ANCHODERECHAOP != '0') $('input[name="r3BPleuralAncho1"][value="' + oRequest.PP_ANCHODERECHAOP + '"]').prop('checked', true);
                if (oRequest.PP_ANCHODERECHASE != '0') $('input[name="r3BPleuralAncho1S"][value="' + oRequest.PP_ANCHODERECHASE + '"]').prop('checked', true);
                if (oRequest.PP_ANCHOIZQUIERDAOP != '0') $('input[name="r3BPleuralAncho2"][value="' + oRequest.PP_ANCHOIZQUIERDAOP + '"]').prop('checked', true);
                if (oRequest.PP_ANCHOIZQUIERDASE != '0') $('input[name="r3BPleuralAncho2S"][value="' + oRequest.PP_ANCHOIZQUIERDASE + '"]').prop('checked', true);

                if (oRequest.OBLITERACION != '0') $('input[name="r3CObliteracion"][value="' + oRequest.OBLITERACION + '"]').prop('checked', true);

                $('input[name="rEngrosamientoPleuralDifuso"][value="' + oRequest.ENGROSAPLERURALDIFUSO + '"]').prop('checked', true);

                if (oRequest.EPD_SITIOPERFIL != '0') $('input[name="r3DMDifusoSitioPerfil"][value="' + oRequest.EPD_SITIOPERFIL + '"]').prop('checked', true);
                if (oRequest.EPD_SITIOFRENTE != '0') $('input[name="r3DMSitioFrente"][value="' + oRequest.EPD_SITIOFRENTE + '"]').prop('checked', true);
                if (oRequest.EPD_CALSIFICACIONPERFIL != '0') $('input[name="r3DMDifusoCalsiPerfil"][value="' + oRequest.EPD_CALSIFICACIONPERFIL + '"]').prop('checked', true);
                if (oRequest.EPD_CALSIFICACIONFRENTE != '0') $('input[name="r3DMCalsiFrente"][value="' + oRequest.EPD_CALSIFICACIONFRENTE + '"]').prop('checked', true);

                if (oRequest.EPD_EXTENSIONPAREDPERFILOP != '0') $('input[name="r3DM1EngExtencionPared1"][value="' + oRequest.EPD_EXTENSIONPAREDPERFILOP + '"]').prop('checked', true);
                if (oRequest.EPD_EXTENSIONPAREDPERFILSE != '0') $('input[name="r3DM1EngExtencionPared1S"][value="' + oRequest.EPD_EXTENSIONPAREDPERFILSE + '"]').prop('checked', true);
                if (oRequest.EPD_EXTENSIONPAREDFRENTEOP != '0') $('input[name="r3DM1EngExtencionPared2"][value="' + oRequest.EPD_EXTENSIONPAREDFRENTEOP + '"]').prop('checked', true);
                if (oRequest.EPD_EXTENSIONPAREDFRENTESE != '0') $('input[name="r3DM1EngExtencionPared2S"][value="' + oRequest.EPD_EXTENSIONPAREDFRENTESE + '"]').prop('checked', true);
                if (oRequest.EPD_ANCHODERECHAOP != '0') $('input[name="r3DMAncho1"][value="' + oRequest.EPD_ANCHODERECHAOP + '"]').prop('checked', true);
                if (oRequest.EPD_ANCHODERECHASE != '0') $('input[name="r3DMAncho1S"][value="' + oRequest.EPD_ANCHODERECHASE + '"]').prop('checked', true);
                if (oRequest.EPD_ANCHOIZQUIERDAOP != '0') $('input[name="r3DMAncho2"][value="' + oRequest.EPD_ANCHOIZQUIERDAOP + '"]').prop('checked', true);
                if (oRequest.EPD_ANCHOIZQUIERDASE != '0') $('input[name="r3DMAncho2S"][value="' + oRequest.EPD_ANCHOIZQUIERDASE + '"]').prop('checked', true);

                if (oRequest.OTRASANORMALIDADES != '0') $('input[name="rOtrasAnormalidades"][value="' + oRequest.OTRASANORMALIDADES + '"]').prop('checked', true);
                if (oRequest.OTRASANORMALIDADES == 'SI') $('#simbolos').removeClass('css-disabled-div');


                if (oRequest.SIMBOLO_AA != '0') $('#cb_simbolo_aa').prop('checked', true);
                if (oRequest.SIMBOLO_AT != '0') $('#cb_simbolo_at').prop('checked', true);
                if (oRequest.SIMBOLO_AX != '0') $('#cb_simbolo_ax').prop('checked', true);
                if (oRequest.SIMBOLO_BU != '0') $('#cb_simbolo_bu').prop('checked', true);
                if (oRequest.SIMBOLO_CA != '0') $('#cb_simbolo_ca').prop('checked', true);
                if (oRequest.SIMBOLO_CG != '0') $('#cb_simbolo_cg').prop('checked', true);
                if (oRequest.SIMBOLO_CN != '0') $('#cb_simbolo_cn').prop('checked', true);
                if (oRequest.SIMBOLO_CO != '0') $('#cb_simbolo_co').prop('checked', true);
                if (oRequest.SIMBOLO_CP != '0') $('#cb_simbolo_cp').prop('checked', true);
                if (oRequest.SIMBOLO_CV != '0') $('#cb_simbolo_cv').prop('checked', true);
                if (oRequest.SIMBOLO_DI != '0') $('#cb_simbolo_di').prop('checked', true);
                if (oRequest.SIMBOLO_EF != '0') $('#cb_simbolo_ef').prop('checked', true);
                if (oRequest.SIMBOLO_EM != '0') $('#cb_simbolo_em').prop('checked', true);
                if (oRequest.SIMBOLO_ES != '0') $('#cb_simbolo_es').prop('checked', true);
                if (oRequest.SIMBOLO_FR != '0') $('#cb_simbolo_fr').prop('checked', true);
                if (oRequest.SIMBOLO_HI != '0') $('#cb_simbolo_hi').prop('checked', true);
                if (oRequest.SIMBOLO_HO != '0') $('#cb_simbolo_hd').prop('checked', true);
                if (oRequest.SIMBOLO_ID != '0') $('#cb_simbolo_id').prop('checked', true);
                if (oRequest.SIMBOLO_IH != '0') $('#cb_simbolo_ih').prop('checked', true);
                if (oRequest.SIMBOLO_KL != '0') $('#cb_simbolo_kl').prop('checked', true);
                if (oRequest.SIMBOLO_ME != '0') $('#cb_simbolo_me').prop('checked', true);
                if (oRequest.SIMBOLO_PA != '0') $('#cb_simbolo_pa').prop('checked', true);
                if (oRequest.SIMBOLO_PB != '0') $('#cb_simbolo_pb').prop('checked', true);
                if (oRequest.SIMBOLO_PI != '0') $('#cb_simbolo_pi').prop('checked', true);
                if (oRequest.SIMBOLO_PX != '0') $('#cb_simbolo_px').prop('checked', true);
                if (oRequest.SIMBOLO_RA != '0') $('#cb_simbolo_ra').prop('checked', true);
                if (oRequest.SIMBOLO_RP != '0') $('#cb_simbolo_rp').prop('checked', true);
                if (oRequest.SIMBOLO_TB != '0') $('#cb_simbolo_tb').prop('checked', true);
                if (oRequest.SIMBOLO_OD != '0') $('#cb_simbolo_od').prop('checked', true);

                //$('#tcomentarioGen').val(oRequest.COMENTARIOGEN);
                invoxCKEditor.editor.setData(oRequest.COMENTARIOGEN);
            }

            function ObtenerComentario() {
                var data = '{risExamen:' + $('#risExamen').val() + '}';

                $.ajax({
                    type: "POST",
                    url: "InformaOIT.aspx/ObtenerComentario",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    data: data,
                    success: function (arg) {
                        var objeto = arg.d.Data;

                        var htmlTabla = objeto.Data;

                        $("#tablacomentarios").children("table").remove();
                        $("#tablacomentarios").append(htmlTabla);
                    },
                    error: function () { }
                });
            }

            function validarVocaliOIT() {
                $.ajax({
                    type: "POST",
                    url: "Informar.aspx/obtenerCredenciales",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    success: function (arg) {
                        var objeto = arg.d;
                        for (var i = 0; i < objeto.length; i++) {
                            $('#a1').attr('href', objeto[i].urlImagenes);

                            if (objeto[i].activarVocali == 1) {

                                var myUser = objeto[i].username;
                                var myPassword = objeto[i].password;
                                var myHostServer = objeto[i].host;
                                var myPort = objeto[i].port;
                                var useAgent = objeto[i].agent;

                                if (myUser === undefined || myPassword === undefined || myHostServer === undefined || myPort === undefined || useAgent === undefined) alert(msg);

                                if (location.protocol === 'file: ') {
                                    Invox.ShowLocalSampleError();
                                } else {

                                    var config = { height: 2 };
                                    var configTitulo = { height: 20 };
                                    var configTecnica = { height: 20 };
                                    var configAntecedentes = { height: 40 };
                                    var configHallazgos = { height: 280 };
                                    var configComentario = { height: 280 };
                                    var configImpresion = { height: 100 };

                                    config.toolbarGroups = [
                                        { name: 'invoxmd_group' },
                                        '/',
                                        { name: 'basicstyles', groups: ['basicstyles'] },
                                        { name: 'list', groups: ['NumberedList', "BulletedList"] },
                                        { name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                                        { name: 'styles' },
                                        { name: 'colors' },
                                        { name: 'undo' },
                                        { name: 'insert', groups: ["Table", "HorizontalRule"] },
                                        { name: 'texttransform' }
                                    ];

                                    configTitulo.toolbarGroups = [
                                        { name: 'invoxmd_group' },
                                        '/',
                                        { name: 'basicstyles', groups: ['basicstyles'] },
                                        { name: 'list', groups: ['NumberedList', "BulletedList"] },
                                        { name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
                                        { name: 'styles' },
                                        { name: 'colors' },
                                        { name: 'undo' },
                                        { name: 'insert', groups: ["Table", "HorizontalRule"] },
                                        { name: 'texttransform' }
                                    ];

                                    configTecnica.toolbarGroups = [];
                                    configAntecedentes.toolbarGroups = [];
                                    configHallazgos.toolbarGroups = [];
                                    configComentario.toolbarGroups = [];
                                    configImpresion.toolbarGroups = [];

                                    var editors = [{ id: 'txtTecnica', config: configTecnica }, { id: 'txtTitulo', config: configTitulo }, { id: 'txtImpresion', config: configImpresion }, { id: 'txtHallazgos', config: configHallazgos }, { id: 'txtAntecedentesClinicos', config: configAntecedentes }, { id: 'lblComentarioTM', config: configComentario }];
                                }
                            }
                        }
                    },
                    error: function () {

                    }
                });
            }

            //function obtenerEstudiosRelacionados(codexamen, id_institucion) {
            //    $("#divEstudiosRelacionados").children("table").remove();
            //    $("#divEstudiosRelacionados").children("div").remove();

            //    var img = "<div style='width: 100%; text-align: center'><img src='../icon/preloader.gif' style='width: 40px; cursor: pointer'/></div>";
            //    $("#divEstudiosRelacionados").append(img);

            //    $.getJSON("../Examen/JsonGetEstudiosRelacionados.aspx?codexamen=" + codexamen + "&id_institucion=" + id_institucion, function (data) {
            //        if (data.out == "ok") {
            //            $("#divEstudiosRelacionados").children("table").remove();
            //            $("#divEstudiosRelacionados").children("div").remove();
            //            $("#divEstudiosRelacionados").append(data.estudios_anteriores);
            //        }
            //    });
            //}

            //function ObtenerInformesPrevios(id_paciente, id_institucion, urlInforme, identificador) {
            //    alert('pasa');

            //    iframeInformeVacio();

            //    var data = '{id_paciente:"' + id_paciente + '", id_institucion:' + id_institucion + ', codexamen:"' + coodigo_examen + '"}';

            //    $.ajax({
            //        type: "POST",
            //        url: "Informar.aspx/ObtenerInformesPrevios",
            //        contentType: "application/json; charset=utf-8",
            //        datatype: "json",
            //        data: data,
            //        success: function (arg) {

            //            var objeto = arg.d;

            //            var htmlTabla = objeto;

            //            var htmlTabla = htmlTabla;

            //            $("#tablaInformesPrevios").children("table").remove();
            //            $("#tablaInformesPrevios").append(htmlTabla);

            //            cargarInforme(urlInforme, identificador);
            //        },
            //        error: function () {

            //        }
            //    });
            //}

            //function cargarInforme(urlInforme, identificador) {
            //    iframeInformeVacio();
            //    limpiarColoresInformesPrevios();

            //    $("#iframeInforme").attr("src", urlInforme);
            //    $("#" + identificador).css("background-color", "#FF7500");
            //    $("#" + identificador).css("color", "white");
            //}

            //function iframeInformeVacio() {
            //    $("#iframeInforme").attr("src", "../Control/Vacio.html");
            //}

            //function limpiarColoresInformesPrevios() {
            //    $(".btn_informes_previos").css("background-color", "white");
            //    $(".btn_informes_previos").css("color", "black");
            //}
        });
    </script>
<%--</asp:Content>--%>
</body>
</html>
