<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="InformarOIT.aspx.cs" Inherits="MultiRisWeb.Web.Examen.InformarOIT1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/InformarOIT.css" rel="stylesheet" />
    <script src="../js/InformarOIT.js"></script>

    <link href="../css/Master.css" rel="stylesheet" />
    <link href="../css/Informar.css" rel="stylesheet" />

    <link href="../css/MasterMenu.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="val_actual" type="hidden" runat="server" />
    <div class="row">
        <div class="col-md-4">
            <label class="texto1 titulo1"><b>EXÁMEN</b></label>
            <table>
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
                                #ACC:  &nbsp;
                            </label>
                            <asp:Label runat="server" ID="lblAcc" CssClass="lbl"></asp:Label></b>
                    </td>
                    <td style="width: 30%">
                        <b>
                            <label class="texto1">
                                SEXO:
                            </label>
                        </b>
                        <b>
                            <asp:Label runat="server" ID="lblSexo" CssClass="lbl"></asp:Label></b>
                    </td>
                    <td style="width: 30%">
                        <b>
                            <label class="texto1">
                                EDAD:
                            </label>
                        </b>
                        <b>
                            <asp:Label runat="server" ID="lblEdad" CssClass="lbl"></asp:Label></b>
                    </td>
                </tr>
               <tr>
                   <td>
                       <b><label class="texto1">IMÁGENES DEL ESTUDIO:</label></b>
                   </td>
                   <td><asp:Label runat="server" ID="lblVisores"></asp:Label></td>
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
                    <div class="col-md-12" style="padding-left: 0px;">
                        <div id="divEstudiosRelacionados"></div>
                    </div>
                </div>

            <div class="row">
                 
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

                <div class="col-md-12">
                    
                </div>
            </div>
        </div>
        <div class="col-md-8" style="margin-top:50px;">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <b>
                        <label>INTERPRETACIÓN RADIOLOGIA</label></b>
                </div>
                <div class="col-md-4"></div>
                <%--DENTRO DE CADA SEPARADOR, LA SUMA DE LOS COL-MD DEBE SER DE 12--%>
                <%--SEPARADOR--%>

                <div class="col-md-6">
                    <b>
                        <label class="lblInformeOIT">NOMBRE PACIENTE</label></b>
                    <asp:TextBox runat="server" ID="txtNombrePaciente" Width="95%" CssClass="campos-texto" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <b>
                        <label class="lblInformeOIT">NÚMERO IDENTIFICADOR</label></b>
                    <asp:TextBox runat="server" ID="txtIdentificador" Width="95%" CssClass="campos-texto" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <b>
                        <label class="lblInformeOIT">FECHA RADIOGRAFIA</label></b>
                    <asp:TextBox runat="server" ID="txtFechaRadiografia" Width="95%" CssClass="campos-texto" Enabled="false"></asp:TextBox>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-2">
                    <label class="lblInformeOIT">N° RADIOGRAFIA</label>
                    <asp:TextBox runat="server" ID="txtNumeroRadiografia" Width="95%" CssClass="campos-texto"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label class="lblInformeOIT">RAD.DIGITAL</label>
                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_radiografia_digital" CssClass="lblInformeOIT">
                        <asp:ListItem runat="server" id="siRadiografiaDigital" Value="SI">SI&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem runat="server" id="noRadiografiaDigital" Value="NO">NO</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-md-3">
                    <label class="lblInformeOIT">MÉDICO</label>
                    <asp:TextBox runat="server" ID="txtMedico" Width="95%" CssClass="campos-texto" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="lblInformeOIT">TECNÓLOGO</label>
                    <asp:TextBox runat="server" ID="txtTencologo" Width="95%" CssClass="campos-texto" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label class="lblInformeOIT">LECTURA EN NEGATOSCOPIO</label>
                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_lectura_Negatoscopio" CssClass="lblInformeOIT">
                        <asp:ListItem runat="server" id="siLecturaEnNegatoscopio" Value="SI">SI&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem runat="server" id="noLecturaEnNegatoscopio" Value="NO">NO</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador">
                    <hr />
                </div>
                <div class="col-md-12 div-espaciador">
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-6">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">CALIDAD:&nbsp;</label>
                            </th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_tecnica_Quialidaden" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="aTecnicaQuilidaden" Value="1">1&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="bTecnicaQuilidaden" Value="2">2&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="cTecnicaQuilidaden" Value="3">3&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="dTecnicaQuilidaden" Value="4">4&nbsp;&nbsp;</asp:ListItem>
                                </asp:RadioButtonList>
                            </th>
                        </tr>
                    </table>
                </div>
                <div class="col-md-6">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">RADIOGRAFIA NORMAL:&nbsp;&nbsp;</label>
                            </th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_radiografia_Normal" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="siRadiografiaNormal" Value="SI">SI&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="noRadiografiaNormal" Value="NO">NO&nbsp;&nbsp;</asp:ListItem>
                                </asp:RadioButtonList>
                            </th>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-6">
                    <label class="lblInformeOIT">COMENTARIO:&nbsp;</label>
                    <asp:TextBox runat="server" ID="txtComentario" Width="95%" CssClass="campos-texto"></asp:TextBox>
                </div>
                <div class="col-md-6"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador">
                    <hr />
                </div>
                <div class="col-md-12 div-espaciador">
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <label class="lblInformeOIT">ALGUNA ANORMALIDAD PARENQUIMATOSA CONSISTENTE CON NEUMOCONIOSIS:&nbsp;</label>
                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_anormalidad_Parenquimatosa" CssClass="lblInformeOIT">
                        <asp:ListItem runat="server" id="siAnormalidadPerenquimatosa" Value="SI">SI (Completar 2B y 2C)&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem runat="server" id="noAnormalidadPerequimatosa" Value="NO">NO (pasar por sección 3)</asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <label class="lblInformeOIT">OPACIDADES PEQUEÑAS</label>
                </div>

                 <%--SEPARADOR--%>

                <div class="col-md-3">
                    
                    <label class="lblInformeOIT">a) Forma / Tamaño</label>
                    <table class="lblInformeOIT">
                        <tr>
                            <th>Primaria</th>
                            <th>Secundaria</th>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_primaria1">
                                    <asp:ListItem runat="server" id="pPrimaria1" Value="p">p</asp:ListItem>
                                    <asp:ListItem runat="server" id="sPrimaria1" Value="s">s</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_secundaria1">
                                    <asp:ListItem runat="server" id="pSecundaria1" Value="p">p</asp:ListItem>
                                    <asp:ListItem runat="server" id="sSecundaria1" Value="s">s</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_primaria2">
                                    <asp:ListItem runat="server" id="qPrimaria2" Value="q">q</asp:ListItem>
                                    <asp:ListItem runat="server" id="tPrimaria2" Value="t">t</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_secundaria2">
                                    <asp:ListItem runat="server" id="qSecundaria2" Value="q">q</asp:ListItem>
                                    <asp:ListItem runat="server" id="tSecundaria2" Value="t">t</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_primaria3">
                                    <asp:ListItem runat="server" id="rPrimaria3" Value="r">r</asp:ListItem>
                                    <asp:ListItem runat="server" id="uPrimaria3" Value="u">u</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_secundaria3">
                                    <asp:ListItem runat="server" id="rSecundaria3" Value="r">r</asp:ListItem>
                                    <asp:ListItem runat="server" id="uSecundaria3" Value="u">u</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3">
                    <label class="lblInformeOIT">b) Zonas</label>
                    <table class="lblInformeOIT">
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" ID="rb_zonas" RepeatDirection="Horizontal">
                                    <asp:ListItem runat="server" id="dZonas" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iZonas" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle"></td>
                            <td class="tdStyle"></td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3">
                    <label class="lblInformeOIT">b) Profusión</label>
                    <table class="lblInformeOIT">
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" ID="rb_profusion1" RepeatDirection="Horizontal">
                                    <asp:ListItem runat="server" id="arb_profusion1" Value="0/0">0/0</asp:ListItem> 
                                    <asp:ListItem runat="server" id="brb_profusion1" Value="0/1">0/1</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" ID="rb_profusion2" RepeatDirection="Horizontal">
                                    <asp:ListItem runat="server" id="arb_profusion2" Value="1/0">1/0</asp:ListItem>
                                    <asp:ListItem runat="server" id="brb_profusion2" Value="1/1">1/1</asp:ListItem>
                                    <asp:ListItem runat="server" id="crb_profusion2" Value="1/2">1/2</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" ID="rb_profusion3" RepeatDirection="Horizontal">
                                    <asp:ListItem runat="server" id="arb_profusion3" Value="2/1">2/1</asp:ListItem>
                                    <asp:ListItem runat="server" id="brb_profusion3" Value="2/2">2/2</asp:ListItem>
                                    <asp:ListItem runat="server" id="crb_profusion3" Value="2/3">2/3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" ID="rb_profusion4" RepeatDirection="Horizontal">
                                    <asp:ListItem runat="server" id="aProfusion4" Value="3/2">3/2</asp:ListItem>
                                    <asp:ListItem runat="server" id="bprofusion4" Value="3/3">3/3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-3">
                    <label class="lblInformeOIT">OPACIDADES GRANDES: </label>
                    <table class="lblInformeOIT">
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_opacidades_Pequenas">
                                    <asp:ListItem runat="server" id="oOpacidadesPequeñas" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="aOpacidadesPequeñas" Value="A">A</asp:ListItem>
                                    <asp:ListItem runat="server" id="cOpacidadesPequeñas" Value="C">C</asp:ListItem>
                                    <asp:ListItem runat="server" id="bOpacidadesPequeñas" Value="B">B</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador">
                    <hr />
                </div>
                <div class="col-md-12 div-espaciador">
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">ALGUNA ANORMALIDAD PLEURAL CONSISTENTE CON NEUMOCONIOSIS&nbsp;</label>
                            </th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_anormalidad_Pleural" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="siAnormalidadPleural" Value="SI">SI (Completar 3B, 3C, y 3D)&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="noAnormalidadPleural" Value="NO">NO (pasar por sección 4)</asp:ListItem>
                                </asp:RadioButtonList>
                            </th>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">PLACAS PLEURALES: &nbsp;</label></th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales">
                                    <asp:ListItem runat="server" id="siPlacasPleurales" Value="SI">SI&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="noPlacasPleurales" Value="NO">NO</asp:ListItem>
                                </asp:RadioButtonList></th>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-6">
                    <table class="lblInformeOIT">
                        <tr>
                            <th></th>
                            <th>SITIO</th>
                            <th>CALCIFICACIÓN</th>
                        </tr>
                        <tr>
                            <td>Perfil</td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_sitio_perfil">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesSitioPerfil" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesSitioPerfil" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesSitioPerfil" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_calcificacion_perfil">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesCalcificacionPerfil" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesCalcificacionPerfil" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesCalcificacionPerfil" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>Frente</td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_sitio_frente">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesSitioFrente" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesSitioFrente" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesSitioFrente" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_calcificacion_frente">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesCalcificacionFrente" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesCalcificacionFrente" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesCalcificacionFrente" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>Diagrama</td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_sitio_diagrama">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesSitioDiagrama" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesSitioDiagrama" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesSitioDiagrama" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_calcificacion_diagrama">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesCalcificacionDiagrama" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesCalcificacionDiagrama" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesCalcificacionDiagrama" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>Otro Sitio</td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_sitio_otro">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesSitioOtro" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesSitioOtro" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesSitioOtro" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_calcificacion_otro">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesCalcificacionOtro" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesCalcificacionOtro" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesCalcificacionOtro" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>

                    </table>
                </div>

                <div class="col-md-3">
                    <label class="lblInformeOIT">EXTENSIÓN: PARED (Combinado de Perfil y Frente)</label>

                    <table class="lblInformeOIT">
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_extencion_pared1">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesExtenconPared1" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesExtenconPared1" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="cPlacasPleuralesExtenconPared1" Value="1">1</asp:ListItem>
                                    <asp:ListItem runat="server" id="gPlacasPleuralesExtenconPared1" Value="2">2</asp:ListItem>
                                    <asp:ListItem runat="server" id="yPlacasPleuralesExtenconPared1" Value="3">3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_pleurales_extencion_pared2">
                                    <asp:ListItem runat="server" id="oPlacasPleuralesExtencionPared2" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="iPlacasPleuralesExtencionPared2" Value="I">I</asp:ListItem>
                                    <asp:ListItem runat="server" id="cPlacasPleuralesExtencionPared2" Value="1">1</asp:ListItem>
                                    <asp:ListItem runat="server" id="dPlacasPleuralesExtencionPared2" Value="2">2</asp:ListItem>
                                    <asp:ListItem runat="server" id="ePlacasPleuralesExtencionPared2" Value="3">3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>

                    <p class="lblInformeOIT">
                        Para 1/4 de la pared lateral = 1<br />
                        1/4 a 1/2 de pared lateral = 2<br />
                        > 1/2 de pared lateral = 3
                    </p>
                </div>

                <div class="col-md-3">
                    <label class="lblInformeOIT">ANCHO (OPCIONAL) (solo en perfil, 3mm grosor minimo)</label>

                    <table>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_plurales_ancho1" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="dPlacasPleuralesAncho1" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="aPlacasPleuralesAncho1" Value="a">a</asp:ListItem>
                                    <asp:ListItem runat="server" id="bPlacasPleuralesAncho1" Value="b">b</asp:ListItem>
                                    <asp:ListItem runat="server" id="cPlacasPleuralesAncho1" Value="c">c</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_placas_plurales_ancho2" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="iPlacasPleuralesAncho2" Value="I">I</asp:ListItem>
                                    <asp:ListItem runat="server" id="aPlacasPleuralesAncho2" Value="a">a</asp:ListItem>
                                    <asp:ListItem runat="server" id="bPlacasPleuralesAncho2" Value="b">b</asp:ListItem>
                                    <asp:ListItem runat="server" id="cPlacasPleuralesAncho2" Value="c">c</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>

                    <p class="lblInformeOIT">
                        1 a 5mm = a<br />
                        3 a 10mm = b<br />
                        > 10mm = c<br />
                    </p>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">OBLITERACIÓN ANGULO COSTOFRENICO&nbsp;&nbsp;</label>
                            </th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_obliteracion_angulo_costofrenico">
                                    <asp:ListItem runat="server" id="oObliteracionAnguloCostofrenico" Value="O">O&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="dObliteracionAnguloCostofrenico" Value="D">D&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="iObliteracionAnguloCostofrenico" Value="I">I&nbsp;&nbsp;</asp:ListItem>
                                </asp:RadioButtonList>
                            </th>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">ENGROSAMIENTO PLEURAL DIFUSO&nbsp;&nbsp;</label></th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso">
                                    <asp:ListItem runat="server" id="siEngrosamientoPleuralDifuso" Value="SI">SI&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="noEngrosamientoPleuralDifuso" Value="NO">NO&nbsp;&nbsp;</asp:ListItem>
                                </asp:RadioButtonList></th>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-4">
                    <table class="lblInformeOIT">
                        <tr>
                            <th></th>
                            <th>SITIO</th>
                            <th>CALCIFICACIÓN</th>
                        </tr>
                        <tr>
                            <td>Perfil</td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_sitio_perfil">
                                    <asp:ListItem runat="server" id="oEngrosamientoPleuralDifusoSitioPerfil" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dEngrosamientoPleuralDifusoSitioPerfil" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iEngrosamientoPleuralDifusoSitioPerfil" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_calcificacion_perfil">
                                    <asp:ListItem runat="server" id="oEngrosamientoPleuralDifusoCalcificacionPerfil" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dEngrosamientoPleuralDifusoCalcificacionPerfil" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iEngrosamientoPleuralDifusoCalcificacionPerfil" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>Frente</td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_sitio_frente">
                                    <asp:ListItem runat="server" id="oEngrosamientoPleuralDifusoSitioFrente" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dEngrosamientoPleuralDifusoSitioFrente" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iEngrosamientoPleuralDifusoSitioFrente" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_calcificacion_frente">
                                    <asp:ListItem runat="server" id="oEngrosamientoPleuralDifusoCalcificacionFrente" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dEngrosamientoPleuralDifusoCalcificacionFrente" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="iEngrosamientoPleuralDifusoCalcificacionFrente" Value="I">I</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="col-md-4">
                    <label class="lblInformeOIT">EXTENSIÓN: PARED</label>
                    <p class="lblInformeOIT">(Combinado de Perfil y Frente)</p>

                    <table class="lblInformeOIT">
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_extencion_pared1">
                                    <asp:ListItem runat="server" id="oEngrosamientoPleuralDifusoExtencionPared1" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="dEngrosamientoPleuralDifusoExtencionPared1" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="gEngrosamientoPleuralDifusoExtencionPared1" Value="1">1</asp:ListItem>
                                    <asp:ListItem runat="server" id="hEngrosamientoPleuralDifusoExtencionPared1" Value="2">2</asp:ListItem>
                                    <asp:ListItem runat="server" id="jEngrosamientoPleuralDifusoExtencionPared1" Value="3">3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_extencion_pared2">
                                    <asp:ListItem runat="server" id="oEngrosamientoPleuralDifusoExtencionPared2" Value="O">O</asp:ListItem>
                                    <asp:ListItem runat="server" id="iEngrosamientoPleuralDifusoExtencionPared2" Value="I">I</asp:ListItem>
                                    <asp:ListItem runat="server" id="gEngrosamientoPleuralDifusoExtencionPared2" Value="1">1</asp:ListItem>
                                    <asp:ListItem runat="server" id="hEngrosamientoPleuralDifusoExtencionPared2" Value="2">2</asp:ListItem>
                                    <asp:ListItem runat="server" id="jEngrosamientoPleuralDifusoExtencionPared2" Value="3">3</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>

                    <p class="lblInformeOIT">
                        Para 1/4 de la pared lateral = 1<br />
                        1/4 a 1/2 de pared lateral = 2<br />
                        > 1/2 de pared lateral = 3<br />
                    </p>
                </div>

                <div class="col-md-4">
                    <label class="lblInformeOIT">ANCHO (OPCIONAL)</label>
                    <p class="lblInformeOIT">(Solo en perfil, 3mm grosor minimo)</p>

                    <table>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_ancho1" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="dEngrosamientoPleuralDifusoAncho1" Value="D">D</asp:ListItem>
                                    <asp:ListItem runat="server" id="aEngrosamientoPleuralDifusoAncho1" Value="A">a</asp:ListItem>
                                    <asp:ListItem runat="server" id="bEngrosamientoPleuralDifusoAncho1" Value="B">b</asp:ListItem>
                                    <asp:ListItem runat="server" id="cEngrosamientoPleuralDifusoAncho1" Value="C">c</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdStyle">
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_engrosamiento_pleural_difuso_ancho2" CssClass="lblInformeOIT">
                                    <asp:ListItem runat="server" id="iEngrosamientoPleuralDifusoAncho2" Value="I">I</asp:ListItem>
                                    <asp:ListItem runat="server" id="aEngrosamientoPleuralDifusoAncho2" Value="a">a</asp:ListItem>
                                    <asp:ListItem runat="server" id="bEngrosamientoPleuralDifusoAncho2" Value="b">b</asp:ListItem>
                                    <asp:ListItem runat="server" id="cEngrosamientoPleuralDifusoAncho2" Value="c">c</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>

                    <p class="lblInformeOIT">
                        3 a 5 mm = a<br />
                        5 a 10 mm = b
                        <br />
                        > 10 mm = c
                    </p>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador">
                    <hr />
                </div>
                <div class="col-md-12 div-espaciador">
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <table>
                        <tr>
                            <th>
                                <label class="lblInformeOIT">OTRAS ANORMALIDADES&nbsp;&nbsp;</label>
                            </th>
                            <th>
                                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rb_otras_anormalidades">
                                    <asp:ListItem runat="server" id="siOtrasAnormalidades" Value="SI">SI&nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem runat="server" id="noOtrasAnormalidades" Value="NO">NO</asp:ListItem>
                                </asp:RadioButtonList>
                            </th>
                        </tr>
                    </table>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <label class="lblInformeOIT">SÍMBOLOS: </label>
                    <table style="text-align: center;">
                        <tr>
                            <th style="width:2%">
                                <label>aa</label>
                            </th>
                            <th style="width:2%">
                                <label>at</label>
                            </th>
                             <th style="width:2%">
                                <label>ax</label>
                            </th>
                            <th style="width:2%">
                                <label>bu</label>
                            </th>
                            <th style="width:2%">
                                <label>ca</label>
                            </th>
                            <th style="width:2%">
                                <label>cg</label>
                            </th>
                            <th style="width:2%">
                                <label>cn</label>
                            </th>
                            <th style="width:2%">
                                <label>co</label>
                            </th>
                            <th style="width:2%">
                                <label>cp</label>
                            </th>
                            <th style="width:2%">
                                <label>cv</label>
                            </th>
                            <th style="width:2%">
                                <label>di</label>
                            </th>
                            <th style="width:2%">
                                <label>ef</label>
                            </th>
                            <th style="width:2%">
                                <label>em</label>
                            </th>
                            <th style="width:2%">
                                <label>es</label>
                            </th>
                            <th style="width:2%">
                                <label>fr</label>
                            </th>
                            <th style="width:2%">
                                <label>hi</label>
                            </th>
                            <th style="width:2%">
                                <label>ho</label>
                            </th>
                            <th style="width:2%">
                                <label>id</label>
                            </th>
                            <th style="width:2%">
                                <label>ih</label>
                            </th>
                            <th style="width:2%">
                                <label>kl</label>
                            </th>
                            <th style="width:2%">
                                <label>me</label>
                            </th>
                            <th style="width:2%">
                                <label>pa</label>
                            </th>
                            <th style="width:2%">
                                <label>pb</label>
                            </th>
                            <th style="width:2%">
                                <label>pi</label>
                            </th>
                            <th style="width:2%">
                                <label>px</label>
                            </th>
                            <th style="width:2%">
                                <label>ra</label>
                            </th>
                            <th style="width:2%">
                                <label>rp</label>
                            </th>
                            <th style="width:2%">
                                <label>tb</label>
                            </th>
                            <th style="width:2%">
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

                <%--SEPARADOR--%>

                <div class="col-md-12 div-espaciador"></div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <label class="lblInformeOIT">COMENTARIO: </label>
                    <br />
                    <asp:TextBox runat="server" ID="txt_comentario_general" TextMode="MultiLine" Width="80%" Height="100px" CssClass="campos-texto"></asp:TextBox>
                    <br />
                    <label class="lblInformeOIT">FECHA DE LECTURA: </label>
                    <br />
                    <asp:TextBox runat="server" ID="txtFechaLectura" Width="200px" CssClass="campos-texto" onkeypress="return fecha(event)" Enabled="false"></asp:TextBox>
                </div>

                <%--SEPARADOR--%>

                <div class="col-md-12">
                    <br />
                     <div class="col-md-1" style="float:right;">
                        <br />
                        <asp:Button runat="server" ID="btnValidar" Text="Validar" OnClick="btnValidar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn bs-popover-filter" Width="60px" />       
                    </div>

                    <br />
                    <br />  
                        <asp:Button runat="server" ID="btnGuardar1" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn btn-filter" Width="66px" />
                        <asp:Button runat="server" ID="btnRegresar" Text="Regresar" OnClick="btnRegresar_Click" OnClientClick="CargaDatosActivo();" CssClass="btn btn-filter" Width="66px" />
                    <br />
                    <br />
                </div>

                <%--SEPARADOR--%>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalVerDocumento">
        <div class="modal-dialog modal-lg" style="background-color: #333">
            <div class="modal-content" style="background-color: #333">
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <img src="#" style="width: 100%;" id="imgDocumento" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <a href="#" class="btn btn-primary" style="width: 130px;" data-dismiss="modal">
                        <img src="../icon/cancelar.png" style="width: 25px; margin-left: -17px;" />
                        <label style="margin-left: 10px; cursor:pointer" class="lblbtn">Cerrar</label></a>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalVerInforme" style="height: 100% !important;">
        <div class="modal-dialog modal-xl" style="background-color: #333; height: 90% !important;">
            <div class="modal-content" style="background-color: #333; height: 100%">
                <div class="modal-body" style="height: 90% !important; float: left;">
                    <div class="row" style="height: 100% !important;">
                        <div class="col-md-3" style="text-align: center; height: 100% !important;">
                            <label class="texto1 titulo1" style="margin-left: -17px !important"><b>INFORMES ANTERIORES RELACIONADOS</b></label>
                            <br />
                            <div id="tablaInformesPrevios"></div>
                        </div>
                        <div class="col-md-9" style="height: 100% !important;">
                            <iframe style="width: 100%; height: 100%; visibility: visible" frameborder="0" id="iframeInforme" src="../Control/Vacio.html"></iframe>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="height: 10% !important; float: left;">
                    <a href="#" class="btn btn-primary" style="width: 130px;" data-dismiss="modal">
                        <img src="../icon/cancelar.png" style="width: 25px; margin-left: -17px;" />
                        <label style="margin-left: 10px; cursor:pointer" class="lblbtn">Cerrar</label></a>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            actualizarBloqueoExamen();
        });
    </script>
</asp:Content>
