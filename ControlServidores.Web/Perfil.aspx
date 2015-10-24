<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ControlServidores.Web.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
<div class="ttlPrincipal">
    <h1>Perfil</h1>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlFormulario" runat="server">
                <div class="formCampos">
                    <asp:Label ID="lblIdUsuario" runat="server" CssClass="hide" Text="Label"></asp:Label>
                    <div class="grpInput">
                        <label>Nombre de usuario</label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="*Nombre de usuario requerido." ControlToValidate="txtNombreUsuario" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Puesto</label>
                        <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPuesto" runat="server" ErrorMessage="*Puesto requerido." ControlToValidate="txtPuesto" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Extensión</label>
                        <asp:TextBox ID="txtExtension" runat="server" TextMode="Number" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvExtension" runat="server" ErrorMessage="*Extensión requerida." ControlToValidate="txtExtension" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Correo</label>
                        <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="*Correo requerido." ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>
                    <%--<div class="grpInput">
                        <label>Contraseña</label>
                        <asp:TextBox ID="txtPass1" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPass1" runat="server" ErrorMessage="*Contraseña requerida." ControlToValidate="txtPass1" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Confirmar contraseña</label>
                        <asp:TextBox ID="txtPass2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPass2" runat="server" ErrorMessage="*Confirmacion requerida." ControlToValidate="txtPass2" ForeColor="Red" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                    </div>--%>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btnGuardar" Text="Actualizar" ValidationGroup="Perfil" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlInfo" runat="server">
                <div class="perfilInfo">
                    <div class="elementoInfo">
                        <label>Usuario: </label>
                        <asp:Label ID="lblUsrName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="elementoInfo">
                        <label>Rol: </label>
                        <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="elementoInfo">
                        <label>Nombre: </label>
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="elementoInfo">
                        <label>Extensión: </label>
                        <asp:Label ID="lblExtension" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="elementoInfo">
                        <label>Puesto: </label>
                        <asp:Label ID="lblPuesto" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="elementoInfo">
                        <label>Correo: </label>
                        <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label>
                    </div>

                </div>
                <div class="actualizarInfo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnActualizar" runat="server" CssClass="btnActualizar" Text="Actualizar" OnClick="btnActualizar_Click"></asp:Button>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
