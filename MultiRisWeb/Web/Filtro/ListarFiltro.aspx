<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="ListarFiltro.aspx.cs" Inherits="MultiRisWeb.Web.Filtro.ListarFiltro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:GridView runat="server" ID="gvDatos">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE" SortExpression="nombre" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# String.Format("<a data-toggle='modal' title='Ver Datos del Examen' data-target='#modalOpciones' href='#' onClick='opciones({0}, {1}); return false;'><img src='../icon/informarA.png' style='width: 23px' /></a>", Eval("id_ris_examen"), Eval("numeroacceso"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>