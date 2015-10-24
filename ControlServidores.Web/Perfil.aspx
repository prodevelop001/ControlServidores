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
                    <h4>Usuario: </h4>
                    <asp:Label ID="lblUsrName" runat="server" Text=""></asp:Label>
                    <h4>Nombre: </h4>
                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    <h4>Rol: </h4>
                    <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
