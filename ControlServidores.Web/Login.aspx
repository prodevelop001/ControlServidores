﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControlServidores.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <link rel="stylesheet" href="./Styles/general.css">
	<link rel="stylesheet" href="./Styles/iconos.css">
	<link rel="stylesheet" href="./Styles/login.css">
</head>
<body>
<div class="cuerpo">
	<div id="login_cab" class="login_center text_center">
		<h1>Control de Servidores</h1>
		<h4>Sistema de Inventario de Servidores</h4>
	</div>
    <form id="form1" runat="server">
    <div id="login_form" class="login_center">
		<p class="text_center">Bienvenido</p>
		<span id="usrIcon" class="icon-user text_center"></span>
        <asp:TextBox name="txtUsrName" ID="txtUsrName" placeholder="Usuario" maxlength="23" runat="server"></asp:TextBox>
		<%--<input type="text" runat="server"  name="usrName" ID="txtUsrName" placeholder="Usuario" maxlength="23">--%>
		<span id="passIcon" class="icon-key text_center"></span>
		<input type="password" name="usrPass" id="usrPass" placeholder="Contraseña" maxlength="23">
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
</body>
</html>
