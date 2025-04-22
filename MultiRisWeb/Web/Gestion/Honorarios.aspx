<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Honorarios.aspx.cs" Inherits="MultiRisWeb.Web.Gestion.Honorarios" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    
<%--    <script src="../js/jquery-1.12.4.js"></script>
    <script src="../js/jquery-ui.js"></script>--%>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .css-color {
            color: white !important;
        }

        .form-control-ddl:hover, .form-control:hover, .btn-day:hover {
            cursor: pointer;
            background-color: #ebba98 !important;
            border-color: #352D5C !important;
        }
    </style>

    <div class="row" style="margin-top: 0px; height: 150px; width: 100%; background-color: #404848">
        <div style="width: 99%; margin-left: 1%; margin-top: 60px; height: 1px; background-color: #404848;"></div>

        <div class="col-md-12" style="background-color: #404848">
            <div style="width: 100%;">
                <h8 style="margin-left: 9px; color: #F39555;">Gestión>Producción</h8><br />
                <link href="../css/Master.css" rel="stylesheet" />

                <div class="css-div-filtros" style="min-height: 80px; padding-top: 20px">
                    <table class="css-table-filtros css-table-filtros-sup css-table-out">
                        <tr>
                            <td style="width: 150px;">
                                <p style="margin-bottom: 0px; padding-left: 5px;">FECHA INICIO</p>
                            </td>
                            <td style="width: 150px;">
                                <p style="margin-bottom: 0px; padding-left: 5px;">FECHA FINAL</p>
                            </td>
                            <td style="width: 50px;"></td>
                            <td style="width: 80px;"></td>
                            <td style="width: 80px;"></td>
                            <td style="width: 200px;"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control fecha css-color" ID="txtFechaInicio" Width="130px"></asp:TextBox></td>
                            <td>
                                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control fecha css-color" ID="txtFechaTermino" Width="130px"></asp:TextBox></td>
                            <td></td>
                            <td>
                                <asp:Button runat="server" CssClass="btn btn-filter" OnClick="btnFiltrarFecha_Click" Text="BUSCAR" Style="float: right; margin-right: 10px;" OnClientClick="CargaDatosActivo();" />
                            </td>
                            <td>
                                <asp:Button runat="server" CssClass="btn btn-clear" Width="60px" OnClick="btnLimpiar_Click" Text="LIMPIAR" Style="float: right; margin-right: 10px;" />
                            </td>
                            <td>
                                <asp:Button runat="server" CssClass="btn btn-clear" ID="btnDescargarInforme" Width="150px" OnClick="btnDescargarInforme_Click" Text="DESCARGAR INFORME" Style="padding-left: 5px;padding-right: 5px;" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div class="row" style="margin-top: 20px; width: 100%; margin-left: 5px">
        <div class="col-sm-12" style="padding: 0 5px 0 5px">
            <div class="css-div-filtros" style="min-height: 40px; padding-top: 15px">
                <table class="css-table-filtros css-table-filtros-sup css-table-out">
                    <tr>
                        <td style="width:100px">
                            <p style="margin-bottom: 0px; padding-left: 5px;">
                                Pagina: &nbsp;
                                    <asp:Label ID="lblNumeroPagina" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td style="width: 180px;">
                            <p style="margin-bottom: 0px; padding-left: 5px;">
                                Cantidad De Registros: &nbsp;
                                    <asp:Label ID="lblCantidadRegistros" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p style="margin-bottom: 0px; padding-left: 5px;">
                                De &nbsp;
                                    <asp:Label ID="lblTotalRegistros" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td style="width: 70%;">
                            <p style="margin-bottom: 0px; padding-left: 5px;">&nbsp;</p>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="btnSiguiente" OnClick="btnSiguiente_Click" cssClass="btn btn-filter"><i class="fa"></i>Siguiente</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnAtras" OnClick="btnAtras_Click" cssClass="btn btn-filter"><i class="fa"></i>Atras</asp:LinkButton>
                        </td>
                        <td style="width: 80px;"></td>
                        
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div class="row full" style="margin-top: 10px; width: 100%; margin-left: 5px">
        <div class="col-md-12">
            <asp:GridView runat="server" Width="100%" ID="gvDatos" AutoGenerateColumns="false" CssClass="table table-striped table-dark table-hover" EmptyDataText="Sin Resultados" AllowPaging="false" AllowSorting="true" PageSize="22">
                <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
                <Columns>
                    <asp:BoundField DataField="USER NAME RADIOLOGO" HeaderText="Radiologo" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="RADIOLOGO INFORME" HeaderText="Informador"  ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="TIPO RADIOLOGO" HeaderText="Perfil" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="INSTITUCION" HeaderText="Institución" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="MODALIDAD" HeaderText="Modalidad" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:TemplateField HeaderText="Atención" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" >
                        <ItemTemplate>
                            <%# String.Format(Eval("TIPO ATENCION").ToString() == "Urgencia" ? "<span style='color: red'>{0}</span>" : "<span>{0}</span>", Eval("TIPO ATENCION")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CODIGO FONASA" HeaderText="Código Fonasa" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="PRESTACION INFORME" HeaderText="Prestación Informe" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="FECHA EXAMEN" HeaderText="Fecha Examen" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-Width="9%" />
                    <asp:BoundField DataField="FECHA ASIGNACION" HeaderText="Fecha Asignacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-Width="9%" />
                    <asp:BoundField DataField="FECHA VALIDACION INFORME" HeaderText="Fecha Validacion" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-Width="9%" />
                    <asp:BoundField DataField="ID PACIENTE" HeaderText="Paciente" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="NOMBRE PACIENTE" HeaderText="Nombre Paciente" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="Silver" />
                    <asp:BoundField DataField="TIEMPO INFORME" HeaderText="Tiempo Informe" ItemStyle-HorizontalAlign="center" ItemStyle-ForeColor="Silver" HeaderStyle-Width="7%" />
                </Columns>
                <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
            </asp:GridView>
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

    <script type="text/javascript">
        $(document).ready(function () {
            //$('#eDownload').on('click', function () {
            //    var fechaInicio = $("#txtFechaInicio").val();
            //    var fechaFinal = $("#txtFechaTermino").val();

            //    $.ajax({
            //        type: "POST",
            //        url: "Honorarios.aspx/DescargarExcelHonorarios",
            //        data: JSON.stringify({ fechaInicio: fechaInicio, fechaFinal: fechaFinal }),
            //        contentType: "application/json; charset=utf-8",
            //        dataType: "json",
            //        success: function (response) {
            //            alert(response.d);
            //        },
            //        error: function (xhr, status, error) {
            //            alert("Error: " + error);
            //        }
            //    });
            //});
        });


        function CargaDatosInactivo() {
            $('#modalCargando').modal('hide');
        }

        function CargaDatosActivo() {
            //alert('aqui');
            $('#modalCargando').modal('show');
        }
    </script>
</asp:Content>
