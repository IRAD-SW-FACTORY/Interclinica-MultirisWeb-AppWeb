<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="MultiRisWeb.Web.Error.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MultiRisWeb</title>
    <link href="../Complementos/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>--%>

<%--    <link href="../font/Avenir-Roman/style.css" rel="stylesheet" />--%>
<%--    <link href="../css/Master.css" rel="stylesheet" />--%>
    <script src="../js/jquery-1.12.4.js"></script>
</head>


<body>
<form id="form1" runat="server">
            <div class="row" style="text-align: center">
                                      <asp:Image ID="Image2" runat="server" ImageUrl="../img/logo_transparente.png" Height="161px" Width="457px"  />
                </div>
        <div style="width:900px; margin:0 auto;">

                      <asp:Image ID="Image1" runat="server" Height="524px" ImageUrl="../img/Error.gif"  />
    <br />
                      <br />
    <asp:Label ID="Label1" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Larger" ForeColor="Red" Text="Label" Font-Strikeout="False" Font-Underline="False"></asp:Label>
    <br /><br /><br />
            <asp:Button runat="server"  Text="Regresar a Control Acceso" BackColor="#FF6600" ForeColor="White" PostBackUrl="~/Default.aspx" />

    </div>
</form>
</body>
</html>
