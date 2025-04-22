<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="MultiRisWeb.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-cl">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" type="image/png" href="Web/Icon/favicon.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultirisWeb</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js" integrity="sha512-v2CJ7UaYy4JwqLDIrZUI/4hqeoQieOmAZNXBeQyjo21dadnwR+8ZaIJVT8EE2iyI61OV8e6M8PP2/4hpQINQ/g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <link href="Web/css/TemplateClear.css" rel="stylesheet" />
    <script src="Web/Complementos/Jquery/jquery-ui.js"></script>
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
                                    <img src="Web/img/errorServer.png" alt="Catalogacion" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 d-flex align-items-center">
                                <div class="card-body p-4 p-lg-5 text-black">
                                    <div class="row">
                                        <div class="col-12 text-center">
                                            <img src="Web/img/logo_amis.jpg" alt="login" class="img-fluid" style="border-radius: 1rem 0 0 1rem; max-width: 180px !important" />
                                        </div>
                                        <div class="col-12 text-justify pt-3">
                                            <h6>
                                                <asp:Label runat="server" ID="lblId"></asp:Label></h6>
                                        </div>
                                        <div class="col-12 text-justify pt-4 text-center">
                                            <a href="https://multiris.irad.cl/multirisweb">Regresar a control de acceso</a>
                                        </div>
                                    </div>
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
