<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebas.aspx.cs" Inherits="ControlServidores.Web.pruebas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="./Styles/Site.css">
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gdvPrueba" runat="server"></asp:GridView>
            <asp:Button ID="btnPrueba" runat="server" Text="Prueba" OnClick="btnPrueba_Click" />
        </div>
        <div id="btnSubmit">
            <asp:LinkButton ID="submitText" runat="server">Iniciar Sesión</asp:LinkButton>
		</div>
    </form>
</body>
</html>
