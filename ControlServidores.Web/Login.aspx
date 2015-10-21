<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControlServidores.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesión</title>
    <link rel="stylesheet" href="./Styles/general.css" type="text/css" />
    <link rel="stylesheet" href="./Styles/iconos.css" type="text/css" />
    <link rel="stylesheet" href="./Styles/login.css" type="text/css" />
    <link rel="icon" type="image/png" href="./Images/favicon.png" />
</head>
<body id="fondo_login">
    <div class="cuerpo">
        <div id="login_cab" class="login_center text_center">
            <h1>Sistema de</h1>
            <h3>Inventario de Servidores</h3>
        </div>
        <form id="form1" runat="server">
            <div id="login_form" class="login_center">
                <p class="text_center">Bienvenido</p>
                <span id="usrIcon" class="icon-user text_center"></span>
                <%--<input type="text" name="usrName" id="usrName" placeholder="Usuario" maxlength="23"/>--%>
                <asp:TextBox type="text" name="txtUsrName" ID="txtUsrName" placeholder="Usuario" MaxLength="23" runat="server" onkeypress="javascript:return EventoEnter(event);"></asp:TextBox>
                <span id="passIcon" class="icon-key text_center"></span>
                <%--<input type="password" name="usrPass" id="usrPass" placeholder="Contraseña" maxlength="23"/>--%>
                <asp:TextBox type="password" name="txtUsrPass" ID="txtUsrPass" placeholder="Contraseña" MaxLength="23" runat="server" onkeypress="Enter(event);"></asp:TextBox>
                <asp:Label ID="lblLogin" runat="server" Text="Etiqueta"></asp:Label>
                <div class="limpiar"></div>
                <div id="btnSubmit">
                    <asp:LinkButton ID="lnkBtnSubmit" runat="server" OnClick="lnkBtnSubmit_Click">
			        <div id="submitText">Iniciar Sesión</div>
			        <span id="submitIcon" class="icon-enter"></span>
                    </asp:LinkButton>
                </div>
            </div>
        </form>

    </div>
    <script type="text/javascript">
        function Enter(event) {
            var x = event.which || event.keyCode;
            if (x === 13) {
                //alert("Has presionado ENTER");
                var obj = document.getElementById("<%=lnkBtnSubmit.ClientID%>");
                obj.click();
            }

        }
    </script>
</body>
</html>
