<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="EditarPlantilla.aspx.cs" Inherits="MultiRisWeb.Web.Plantilla.EditarPlantilla" ClientIDMode="Static"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Master.css" rel="stylesheet" />
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />

    <%-- VOCALI INICIO--%>
    <script type="text/javascript" src="../js/invoxmd_editor/js/ckeditor/ckeditor.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/rangyinputs-jquery.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/swfobject.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/invoxmd.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/control.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/toastr.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/js/toastr.config.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../js/invoxmd_editor/invoxmdeditor.min.js" charset="UTF-8"></script>
    <%-- VOCALI TERMINO--%>

    <script src="../js/EditarPlantilla.js"></script>
    <style>
        .btn {
            padding-left: 10px;
            padding-right: 10px;
            padding-top: 2px;
        }

        .btn2 {
            margin-top: -4px !important;
        }

        .nav-plantillas {
            background-color: #F39555 !important;
        }

        .btn-filter {
            /*width: 60px !important;*/
            border-radius: 4px 4px 4px 4px !important;
            font-weight: bold;
            padding-top: 1px;
            font-size: 11px;
            color: white;
            background-color: #F39555;
            height: 28px !important;
            float: left;
        }

            .btn-filter:hover {
                color: white !important;
                background-color: #FF8C3F;
            }

        .btn-clear {
            /*width: 60px !important;*/
            border-radius: 4px 4px 4px 4px !important;
            font-weight: bold;
            padding-top: 1px;
            font-size: 11px;
            color: white;
            background-color: #676C6F;
            height: 28px !important;
            float: left;
            margin-left: 20px;
        }

        .btn-danger {
            /*width: 60px !important;*/
            border-radius: 4px 4px 4px 4px !important;
            font-weight: bold;
            padding-top: 1px;
            font-size: 11px;
            color: white;
            background-color: red;
            height: 28px !important;
            float: left;
            margin-left: 20px;
        }

        .btn-filter:hover {
            color: white !important;
            background-color: #FF8C3F;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="idactual" type="hidden" runat="server" />
    <div class="row" style="margin-top: 50px;">
        <div class="col-md-4">
            <b>
                <label>Nombre Plantilla</label></b>
            <asp:TextBox runat="server" CssClass="form-control border" ID="txtNombre"></asp:TextBox>
            <b>
                <label style="margin-top: 10px;">Titulo Impreso</label></b>
            <asp:TextBox runat="server" name="titulo" CssClass="form-control border" ID="txtTitulo" TextMode="MultiLine" Height="200px"></asp:TextBox>

            <div class="row" style="padding-right: 0; padding-left: 0;">
                <div class="col-md-6" style="padding-right: 0; padding-left: 0;">
                    <b>
                        <label style="margin-top: 10px;">Modalidad</label></b>
                    <asp:DropDownList runat="server" ID="ddlModalidad" DataTextField="nombre" DataValueField="id_modalidad" Width="100%">
                        <asp:ListItem Selected="True" Value="0">--Seleccione--</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6" style="padding-right: 0; padding-left: 0;">
                    <div style="width: 100%; margin-top: 25px;">
                        <asp:Button runat="server" ID="btnAsignarModalidad" CssClass="btn btn-filter" OnClick="btnAsignarModalidad_Click" ToolTip="Asignar Modalidad" Text="Asignar" />
                    </div>
                </div>
                <div class="col-md-12" style="padding-right: 0; padding-left: 0;">
                    <asp:GridView runat="server" ID="gvModalidades" AutoGenerateColumns="false" EmptyDataText="Sin registros" CssClass="table" OnRowCommand="gvModalidades_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("id_plantilla_modalidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Silver" HeaderStyle-ForeColor="Silver" />
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar" ID="btnActualizar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
            <br />
            <div runat="server" id="divMensaje" visible="false" class="alert alert-warning">
                <strong>Alerta!</strong>
                <asp:Label runat="server" ID="lblAlertWarning"></asp:Label>
                <br />
                <asp:Button runat="server" ID="btnEliminarCancelar" Text="Cancelar" OnClick="btnEliminarCancelar_Click" CssClass="btn btn-clear" />
                <asp:Button runat="server" ID="btnEliminarSeguro" Text="Eliminar" OnClick="btnEliminarSeguro_Click" CssClass="btn btn-danger" />
                <br />
            </div>
            <br />
            <asp:Button runat="server" ID="btnGuardar" Width="90px" OnClick="btnGuardar_Click" Text="Guardar" CssClass="btn btn-filter" />

            <asp:Button runat="server" ID="btnVolver" Width="90px" OnClick="btnVolver_Click" Text="Regresar" CssClass="btn btn-clear" />

            <asp:Button runat="server" ID="btnEliminar" Width="90px" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="btn btn-danger" />
        </div>
        <div class="col-md-8">
            <b>
                <label>Técnica</label></b>
            <asp:TextBox runat="server" CssClass="form-control border" ID="txtTecnica" TextMode="MultiLine" Height="200px"></asp:TextBox>
            <b>
                <label style="margin-top: 10px;">Hallazgos</label></b>
            <asp:TextBox runat="server" CssClass="form-control border" spellcheck="true" ID="txtHallazgos" TextMode="MultiLine" Height="200px"></asp:TextBox>
            <b>
                <label style="margin-top: 10px;">Impresión</label></b>
            <asp:TextBox runat="server" CssClass="form-control border" ID="txtImpresion" TextMode="MultiLine" Height="200px"></asp:TextBox>
        </div>
    </div>
    <br />

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
</asp:Content>
