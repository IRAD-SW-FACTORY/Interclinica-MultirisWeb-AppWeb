<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="VisorErrorLog.aspx.cs" Inherits="MultiRisWeb.Web.Configuracion.VisorErrorLog" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/Master.css" rel="stylesheet" />
    <link href="../css/Informar.css" rel="stylesheet" />
             <link href="../css/ListaExamen.css" rel="stylesheet" />
    <link href="../Complementos/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery-ui.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.css" rel="stylesheet" />
    <link href="../css/multiselect/jquery.multiselect.filter.css" rel="stylesheet" />
    <link href="../css/Pagination.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />


    <script type="text/javascript" src="../js/Usuarios.js"></script>
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <style type="text/css">
        .form-control {
            height: 30px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
            </div>
        </div>
    </div>
    <section class="main full" >
        <div id="datosBuscar" style="width:100%">
            <br />
            <br />
            <br />
            <h2 style="position:absolute; margin-left:1%;" id="tituloDocumentosLegales">Visor de Errores</h2> 

             <article style="text-align:left; float:right; margin-left:10px; margin-right:10px;">
                <label id="lblFechaTermino"> Fecha Final: </label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control fecha" ID="txtFechaTermino"></asp:TextBox>
                                                        <script type="text/javascript">
                                                            $(function () {
                                                                var fecha = new Date();
                                                                $("#txtFechaTermino").datepicker({
                                                                    autoclose: true,
                                                                    format: 'dd/mm/yyyy',
                                                                    firstDay: 1
                                                                });
                                                            });
                                                        </script>
            </article>

            <article style="text-align:left; float:right;">
                <label id="lblFechaInicio"> Fecha Inicio:</label>
                &nbsp;
                    <div class="input-group date">
                                            <b>
                                                <asp:TextBox runat="server" ID="txtFechaInicio"  TextMode="Date" CssClass="form-control fecha" ></asp:TextBox>
                                            </b>
                                        </div>
                                               <script type="text/javascript">
                                                   $(function () {
                                                       var fecha = new Date();
                                                       $("#txtFechaInicio").datepicker({
                                                           autoclose: true,
                                                           format: 'dd/mm/yyyy',
                                                           firstDay: 1
                                                       });
                                                   });
                                               </script>


            </article>





            <article style="text-align:left; float:right;">
                    <label id="lblTipoSistema">Tipo de Sistema: </label>
                <br />
   
                    <asp:DropDownList runat="server" ID="lstTipoSistema" SelectionMode="Multiple" Width="180px" CssClass="form-control-ddl" DataTextField="Descripcion" DataValueField="id_TipoSistema" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true"></asp:DropDownList>
            </article>
            
            <article style="text-align:left; float:right;">  
                <label id="lblTipoError">Tipo de Error: </label>
                                <br />
                <asp:DropDownList runat="server" ID="lstTipoError" SelectionMode="Multiple"  Width="180px" CssClass="form-control-ddl" DataTextField="Descripcion" DataValueField="id" AppendDataBoundItems="true" Font-Size="14px" Font-Bold="true"></asp:DropDownList>     
            </article>

                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
            <article>
                <%--<asp:Button runat="server" CssClass="btn btn-clear" ID="btnCrearPrestacion" OnClick="btnCrearPrestacion_Click" data-target="#modalCrearPrestacion" Text="Crear Prestacion" style="float:left; margin-left:1%;"/>--%>
                <%--<a href="#" id="btnAsignar" class="btn btn-clear" style="float:left; margin-left:1%;" onclick="EstudiosAsignados();" data-toggle="modal" data-target="#modalAgregarInstitucion" title="Asignar">Crear Institución </a>--%>

                <asp:Button runat="server" CssClass="btn btn-filter" ID="btnFiltrar" OnClick="btnFiltrar_Click" OnClientClick="CargaDatosActivo();" Text="BUSCAR" style="float:right; margin-right:10px;"/>
            </article>
            <br />
            <br />
        </div>

       <article style="margin: 1% 1% 1% 1%; /* 10px arriba, 3px derecha, 30px abajo, 5px izquierda ">
            <asp:GridView runat="server" Width="100%" ID="gvDatos" AutoGenerateColumns="false" CssClass="table table-striped table-dark table-hover"
                EmptyDataText="Sin Resultados" AllowPaging="true" AllowSorting="true" OnSorting="gvDatos_Sorting" PageSize="10"
                OnPageIndexChanging="gvDatos_PageIndexChanging">
                <HeaderStyle Height="5px"/>
                <Columns>
<%--                    <asp:BoundField DataField="Numero" HeaderText="Numero Error" SortExpression="Numero" ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:BoundField DataField="tipoErrorDescripcion" HeaderText="Tipo Error " SortExpression="tipoErrorDescripcion" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" ItemStyle-HorizontalAlign="Left"/>
                    <asp:BoundField DataField="tipoSistemaDescripcion" HeaderText="Tipo Sistema" SortExpression="tipoSistemaDescripcion" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Evento" HeaderText="Evento" SortExpression="Evento" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha Creación" SortExpression="fecha" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" ItemStyle-HorizontalAlign="Center" />
                </Columns>
                <PagerStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" CssClass="pagination-ys" />
                <HeaderStyle BackColor="#352D5C" ForeColor="White" HorizontalAlign="Center" Height="5px" />
            </asp:GridView>
        </article>
    </section>


<%--    <script src="../js/Prestaciones.js"></script>
    <script src="../js/evitarReenvio.js"></script>--%>

    <script>
        $(document).ready(function () {

            function CargaDatosInactivo() {
                $('#modalCargando').modal('hide');
            }

            function CargaDatosActivo() {
                $('#modalCargando').modal('show');
            }
        //    $('[data-toggle="tooltip"]').tooltip();

        //    $(function () {
        //        $("table tr").dblclick(function () {
        //            var id_institucion = $(this).find("td:eq(0)").text();

        //            $('#modalAgregarInstitucion').modal('show');

        //            cargarInstitucion(id_institucion);
        //        });
        //    });
        });
    </script>
</asp:Content>
