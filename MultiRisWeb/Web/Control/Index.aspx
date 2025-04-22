<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MultiRisWeb.Web.Control.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .lbl {
            margin-top: 20px;
            font-size: 35px;
            color: black !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-md-4" style="cursor: pointer;">
            <a href="../Examen/ListaExamen.aspx?urgencia=U">
                <div style="width: 30%; height: 100px; float: left; background-color: white; text-align: center;">
                    <img src="../img/urgente.jpg" style="width: 100px;" />
                </div>
                <div style="width: 70%; height: 100px; float: left; background-color: white; text-align: center;">
                    <label style="margin-top: 10px; font-size: 24px; cursor: pointer;">URGENTES</label>
                    <br />
                    <asp:Label runat="server" CssClass="lbl" ID="lblUrgentes" ForeColor="Red"></asp:Label>
                </div>
            </a>
        </div>
        <div class="col-md-4" style="cursor: pointer;">
            <a href="../Examen/ListaExamen.aspx?urgencia=H">
                <div style="width: 30%; height: 100px; float: left; background-color: white; text-align: center;">
                    <img src="../img/Hospitalizado.jpg" style="width: 100px;"  />
                </div>
                <div style="width: 70%; height: 100px; float: left; background-color: white; text-align: center;">
                    <label style="margin-top: 10px; font-size: 24px; cursor: pointer;">HOSPITALIZADOS</label>
                    <br />
                    <asp:Label runat="server" CssClass="lbl" ID="lblHospitalizados" ForeColor="green"></asp:Label>
                </div>
            </a>
        </div>
        <div class="col-md-4" style="cursor: pointer;">
            <a href="../Examen/ListaExamen.aspx?urgencia=A">
                <div style="width: 30%; height: 100px; float: left; background-color: white; text-align: center;">
                    <img src="../img/Ambulatorio.jpg" style="width: 100px;"  />
                </div>
                <div style="width: 70%; height: 100px; float: left; background-color: white; text-align: center;">
                    <label style="margin-top: 10px; font-size: 24px; cursor: pointer;">AMBULATORIOS</label>
                    <br />
                    <asp:Label runat="server" CssClass="lbl" ID="lblAmbulatorios" ForeColor="Blue"></asp:Label>
                </div>
            </a>
        </div>
        <div class="col-md-3"></div>
    </div>
</asp:Content>
