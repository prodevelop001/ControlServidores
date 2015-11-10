<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="errorAcceso.aspx.cs" Inherits="ControlServidores.Web.errorAcceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <div class="principal">
        <div class="errorAcceso">
            <asp:Label ID="lblInfo" runat="server" Text="No tienes los privilegios para accesar a la pagina solicitada."></asp:Label>
            <asp:HyperLink ID="hlkRedirLogin" NavigateUrl="~/Login.aspx"  Text="Ir a Login" Visible="false" runat="server"></asp:HyperLink>
        </div>
    </div>
</asp:Content>
