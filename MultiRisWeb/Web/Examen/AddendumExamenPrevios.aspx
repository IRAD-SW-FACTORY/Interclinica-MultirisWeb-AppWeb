<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddendumExamenPrevios.aspx.cs" Inherits="MultiRisWeb.Web.Examen.AddendumExamenPrevios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiRisWeb</title>
    <link href="../Complementos/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <link href="../font/Avenir-Roman/style.css" rel="stylesheet" />
    <link href="../css/Master.css" rel="stylesheet" />
    <script src="../js/Validaciones.js"></script>
    <link rel="icon" href="../img/logo-amis.png" type="image/x-icon" />
    <link href="../css/Addendum.css" rel="stylesheet" />
    <link href="../css/Master.css" rel="stylesheet" />
    <link href="../css/MasterMenu.css" rel="stylesheet" />
    <style>
        .btn-verde {
            border-radius: 5px !important;
            background-color: #148F77 !important;
            border-color: #148F77 !important;
            color: #ffffff !important;
            border: 1px solid transparent;
            height: 30px !important;
            letter-spacing: 0px !important;
            font-family: 'Avenir' !important;
            vertical-align: middle !important;
        }

            .btn-verde:hover {
                background-color: #116756 !important;
            }
    </style>
</head>
<body>
    <form runat="server" id="formAddendumExamenPrevio">
        <asp:HiddenField runat="server" ID="hddIdPaciente" Value="" />
        <asp:HiddenField runat="server" ID="hddIdInstitucion" Value="" />
        <asp:HiddenField runat="server" ID="hddCodExamen" Value="" />


        <div class="row pt-5" style="height: 100% !important;">
            <div class="col-md-3" style=" height: 100% !important;">
                <fieldset>
                    <legend>Informes del Paciente</legend>
                    <div id="tablaInformesPrevios"></div>
                </fieldset>
            </div>
            <div class="col-md-9" style="height: 100% !important;">
                <fieldset>
                    <legend>Visualizacion Informe</legend>
                    <iframe style="width: 100%; height: 800px !important; visibility: visible" frameborder="0" id="iframeInforme" src="../Control/Vacio.html"></iframe>
                </fieldset>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="../js/master.js"></script>
    <link href="../css/Master.css" rel="stylesheet" />
    <script src="../js/AddendumExamenPrevio.js"></script>
</body>
</html>
