<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="errorAcceso.aspx.cs" Inherits="ControlServidores.Web.errorAcceso" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="errorAcceso.aspx.cs" Inherits="ControlServidores.Web.errorAcceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <div>
        <p>
            No tienes los privilegios para accesar a la pagina solicitada.
        </p>
    </div>
</asp:Content>
