<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="ListarPlantilla.aspx.cs" Inherits="MultiRisWeb.Web.Plantilla.ListarPlantilla" ClientIDMode="Static"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Master.css" rel="stylesheet" />

    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
<%--    <link href="../css/MasterMenu.css" rel="stylesheet" />--%>

   <%-- <link href="../css/Plantillas.css" rel="stylesheet" />--%>
    <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />





    <style>
        .nav-plantillas {
            background-color: #F39555 !important;
        }

        .btn-filter {
            /*width: 60px !important;*/
            border-radius: 4px 4px 4px 4px !important;
            font-weight: bold;
            padding-top: 1px;
            font-size: 10px;
            color: white;
            background-color: #F39555;
            height: 28px !important;
            float:left;
        }

        .btn-filter:hover {
            color: white !important;
            background-color: #FF8C3F;
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
    <div class="row">
         <br />
        <h8 style="margin-left:9px; color:#F39555;">Plantillas>Plantillas</h8>
        <br />
        <div class="col-md-12">
            <table>
                <tr>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlmodalidad" Width="100%" CssClass="form-control-ddl" DataTextField="nombre" DataValueField="nombre" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true">
                            <asp:ListItem Selected="True" Value="0">MODALIDAD</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton runat="server" CssClass="filtrar" ImageUrl="../icon/lupa.png" Width="23px" OnClick="btnBuscar_Click" title="Filtrar" />
                    </td>
                    <td>
                        <a href="EditarPlantilla.aspx" class="" style="width: 20px !important; background-color: #404848 !important;" title="Crear Nueva plantilla">
                            <img src="../img/mas.png" style="width: 20px; cursor: pointer;" /></a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-md-12">
            <asp:GridView runat="server" CssClass="table table-striped table-dark table-hover" AutoGenerateColumns="false" ID="gvDatos" AllowSorting="true" OnSorting="gvDatos_Sorting" >
                <Columns>
                    <asp:BoundField DataField="id_plantilla" HeaderText="IDENTIFICADOR" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" SortExpression="id_plantilla" />
                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE PLANTILLA" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" SortExpression="nombre" />
                    <asp:BoundField DataField="modalidad" HeaderText="MODALIDAD" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" SortExpression="modalidad" ItemStyle-HorizontalAlign="Center" />
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <%# String.Format("<a data-toggle='tooltip' title='Editar Plantilla' data-placement='top' href='EditarPlantilla.aspx?id={0}'><img src='../img/editar.png' style='width: 15px;' /></a>", Eval("id_plantilla"))%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
                <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                            <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
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

    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();

            $(function () {
                $("table tr").dblclick(function () {
                    var id_filtro = $(this).find("td:eq(0)").text();
                    
                    document.location.href = "EditarPlantilla.aspx?id=" + id_filtro;
                });
            });
        });
    </script>
</asp:Content>
