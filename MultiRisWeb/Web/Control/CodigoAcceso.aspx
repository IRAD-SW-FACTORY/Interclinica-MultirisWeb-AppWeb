<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodigoAcceso.aspx.cs" Inherits="MultiRisWeb.Web.Control.CodigoAcceso" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-cl">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" type="image/png" href="Web/Icon/favicon.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Control de Acceso | Codigo de Acceso</title>
    <link href="../../Web/Complementos/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Web/Complementos/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <link href="../../Web/css/TemplateClear.css" rel="stylesheet" /> 
    <script src="../../Web/Complementos/Jquery/jquery-ui.js"></script>
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
                                    <img src="../../Web/img/logo_amis.jpg" alt="login" class="img-fluid pt-5" style="border-radius: 1rem 0 0 1rem;" />
                                </div>
                                  <div class="col-12 text-center">
                                    <img src="../../Web/img/certificacion.jpg" alt="login" class="img-fluid" style="border-radius: 1rem 0 0 1rem; max-width:100px !important" />
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
                                       <div class="row pb-4">
                                        <div class="col-12 text-justify">
                                           <label style="font-size:18px" class="m-0">Bienvenido, favor ingresa codigo de acceso que se envio a tu numero de celular regsitrado en nuestro sistema.</label> 
                                        </div>                                        
                                    </div>
                                    <div class="form-outline mb-4">
                                        <asp:Label class="form-label" runat="server" ID="lblCodigoAcceso" Text="Codigo de Acceso"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCodigoAcceso" class="form-control" placeholder="codigo acceso" MaxLength="15" AutoComplete="off"></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-outline mb-4">
                                        <asp:Label runat="server" ID="lblMensaje" ForeColor="Red" Visible="false"></asp:Label>
                                    </div>
                                    <div class="pt-1 mb-4 text-center">
                                        <asp:Button runat="server" ID="btnLogin" class="btn btn-primary" Text="INGRESAR" Style="min-width: 100px !important" OnClick="btnLogin_Click" />
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
<script src="../../Web/js/master.js"></script>
