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
            <asp:Panel ID="Panel1" runat="server">
                <div class="perfilInfo">
                    <div class="">
                        <span>Usuario: </span>
                        <asp:Label ID="lblUsrName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="">
                        <span>Rol: </span>
                        <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="">
                        <span>Nombre: </span>
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="">
                        <span>Extensión: </span>
                        <asp:Label ID="lblExtension" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="">
                        <span>Puesto: </span>
                        <asp:Label ID="lblPuesto" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="">
                        <span>Correo: </span>
                        <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
