<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MultiRisWeb.Default" ClientIDMode="Static" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-cl">
<head runat="server">
    <title>Control de Acceso</title>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="Web/img/logo-amis.png" type="image/x-icon" />
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js" integrity="sha512-v2CJ7UaYy4JwqLDIrZUI/4hqeoQieOmAZNXBeQyjo21dadnwR+8ZaIJVT8EE2iyI61OV8e6M8PP2/4hpQINQ/g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="Web/js/jquery-ui.js"></script>
    
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
    
    <link href="Web/css/TemplateClear.css" rel="stylesheet" /> 
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
</head>
<body>
      <section class="vh-100" style="background-color:#404848">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <div class="col-md-6 col-lg-6 d-none d-md-block p-1 align-middle">                               
                                <div class="col-12">
                                    <img src="Web/img/logo3.png" alt="login" class="img-fluid pt-5" style="border-radius: 1rem 0 0 1rem; min-width:450px !important" />
                                </div>                               
                            </div>
                        <div class="col-md-3 col-lg-3 d-flex align-items-center">
                            <div class="card-body p-4 p-lg-5 text-black">
                                <form id="form1" runat="server">
                                    <div class="row pb-4">
                                        <div class="col-12 text-center">
                                           <label style="font-size:25px" class="m-0">Sistema de Informaci&oacute;n</label>
                                            <label style="font-size:35px" class="m-0"><strong>TELERADIOLOG&Iacute;A</strong></label>
                                        </div>                                        
                                    </div>
                                    <div class="form-outline mb-4">
                                        <asp:Label class="form-label" runat="server" ID="lblUsername" Text="Nombre de Usuario"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUsername" class="form-control" placeholder="username" MaxLength="250" AutoComplete="off"></asp:TextBox>
                                    </div>
                                    <div class="form-outline mb-4">
                                        <asp:Label runat="server" class="form-label" ID="lblPassword" Text="Contraseña"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtPassword" class="form-control" placeholder="******" TextMode="Password" MaxLength="250" AutoComplete="off"></asp:TextBox>
                                    </div>
                                    <div class="form-outline mb-4">
                                        <asp:Label runat="server" ID="lblMensaje" ForeColor="Red" Visible="false">Credenciales Incorrectas</asp:Label>
                                    </div>
                                    <div class="pt-1 mb-4 text-center">
                                        <asp:Button runat="server" ID="btnLogin" class="btn btn-primary" Text="INGRESAR" Style="min-width: 100px !important" OnClick="btnIngresar_Click" />
                                    </div>

                                    <div class="row">
                                        <div class="col-12 text-center">
                                            <label style="font-size: 16px;">Sistema Compatible con Google Chrome v75+</label>
                                        </div>
                                        <div class="col-12 text-center">
                                            <a href="https://www.youtube.com/watch?v=zj8WYaewpq4" target="_blank">Videos de Apoyo</a>
                                        </div>
                                    </div>

                                    <%--MODAL POPUP--%>
                                    <div runat="server" class="modal fade" id="modalInicioPopUpHabil">
                                        <div class="modal-dialog modal-lg" style="background-color: #404848">
                                            <button type="button" class="close" data-dismiss="modal" style="color: #fd7e14;">&times;&nbsp;</button>
                                            <div class="modal-content" style="background-color: #404848">
                                                <div class="modal-body">
                                                    <div class="row">
                                                        <img src="Web/img/habil.png" />
                                                    </div>
                                                </div>
                                                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--MODAL POPUP--%>
                                    <div runat="server" class="modal fade" id="modalInicioPopUpNoHabil">
                                        <div class="modal-dialog modal-lg" style="background-color: #404848">
                                            <button type="button" class="close" data-dismiss="modal" style="color: #fd7e14;">&times;&nbsp;</button>
                                            <div class="modal-content" style="background-color: #404848">
                                                <div class="modal-body">
                                                    <div class="row">
                                                        <img src="Web/img/noHabil.png" />
                                                    </div>
                                                </div>
                                                <div style="background-color: #352D5C; height: 20px; width: 100%;"></div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="modal fade" id="modalCargando" role="dialog" data-keyboard="false" data-backdrop="static">
                                        <div class="modal-dialog modal-lg">
                                            <%# String.Format(Eval("nombre_tipo_urgencia").ToString() == "Urgencia" ? "<span style='color: red'>{0}</span>" : "<span>{0}</span>", Eval("nombre_tipo_urgencia")) %>
                                            <div class="modal-content1" style="background: url('../img/logo_fondo.png'); background-size: cover; background-blend-mode: overlay;">
                                                <div class="row">
                                                    <br />
                                                    <br />
                                                    <div class="col-md-12" style="text-align: center;">
                                                        <br />
                                                        <label class="label-title" style="font-size: 20px; color: white;">Cargando registros y comentarios desde los centros</label>
                                                        <br />
                                                        <label class="label-title" style="font-size: 20px; color: white;">Espere un momento por favor.</label>
                                                        <br />
                                                    </div>
                                                </div>
                                                <div class="row" style="text-align: center;">
                                                    <div class="col-md-12"></div>
                                                    <div class="col-md-12">
                                                        <img src="Web/img/preloader.gif" class="imgLoader" style="width: 150px; height: 150px;" />
                                                        <br />
                                                        <br />
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </form>

                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</body>
</html>
<script src="Web/js/master.js"></script>
