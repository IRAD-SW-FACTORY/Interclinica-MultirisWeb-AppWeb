<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateClaveAcceso.aspx.cs" Inherits="MultiRisWeb.Web.Control.UpdateClaveAcceso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiRisWeb</title>
    <link rel="icon" href="../../Web/img/logo-amis.png" type="image/x-icon" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js" integrity="sha512-v2CJ7UaYy4JwqLDIrZUI/4hqeoQieOmAZNXBeQyjo21dadnwR+8ZaIJVT8EE2iyI61OV8e6M8PP2/4hpQINQ/g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <link href="../../Web/css/TemplateClear.css" rel="stylesheet" />
</head>
<body>
    <section class="vh-100" style="background-color: #404848">
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
                                    <img src="../../Web/img/certificacion.jpg" alt="login" class="img-fluid" style="border-radius: 1rem 0 0 1rem; max-width: 100px !important" />
                                </div>
                            </div>
                            <div class="col-md-3 col-lg-3 d-flex align-items-center">
                                <div class="card-body p-4 p-lg-5 text-black">
                                    <form id="form1" runat="server">
                                        <div class="row pb-1">
                                            <div class="col-12 text-center">
                                                <label style="font-size: 25px" class="m-0">Sistema de Informaci&oacute;n</label>
                                                <label style="font-size: 35px" class="m-0"><strong>TELERADIOLOG&Iacute;A</strong></label>
                                            </div>
                                        </div>
                                        <div class="form-outline mb-4 text-center">
                                            <p>
                                                Hola! <strong>
                                                    <asp:Label runat="server" ID="lblUsuario"></asp:Label></strong>, a continuaci&oacute;n favor ingresar clave de acceso actual y nueva clave de 
                                                acceso para su actualizaci&oacute;n
                                            </p>
                                        </div>
                                        <div class="pt-1 mb-4">                                            
                                            <div class="row pb-4">                                                
                                                 <div class="col-12">
                                                     <label class="col-12"><b>Ingrese Clave Actual</b></label>
                                                     <asp:TextBox runat="server" ID="txtPassActual" TextMode="Password" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                </div>
                                            </div>      
                                             <div class="row">                                                
                                                 <div class="col-12">
                                                     <label class="col-12"><b>Ingrese Nueva Clave</b></label>
                                                     <asp:TextBox runat="server" ID="txtPassNueva" TextMode="Password" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                </div>
                                            </div>      
                                             <div class="row">                                                
                                                 <div class="col-12">
                                                     <label class="col-12"><b>Reingrese Nueva Clave</b></label>
                                                     <asp:TextBox runat="server" ID="txtPassNueva2" TextMode="Password" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                </div>                                                
                                            </div>      
                                        </div>
                                        <div class="pt-1 mb-4 text-center">
                                            <asp:Button runat="server" Text="Modificar Clave de Acceso" ID="btnValidar" CssClass="btn btn-primary" OnClick="btnValidar_Click" />
                                        </div>
                                        <div class="pt-1 mb-4 text-center">
                                            <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-12 text-center">
                                                <a href="../../Default.aspx" target="_blank">Regresar Control de Acceso</a>
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