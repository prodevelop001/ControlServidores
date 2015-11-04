<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="ControlServidores.Web.Contactos" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="ControlServidores.Web.Contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">

    <div class="ttlPrincipal">
        <h1>Directorio</h1>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="formBusqueda">
                <div class="busquedaGrp">
                    <label>Nombre: </label>
                    <asp:TextBox ID="txtPorNombre" runat="server"></asp:TextBox>
                </div>
                <div class="busquedaGrp">
                    <label>Extensión: </label>
                    <asp:TextBox ID="txtPorExt" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="busquedaGrp">
                    <label>Puesto: </label>
                    <asp:TextBox ID="txtPorPuesto" runat="server"></asp:TextBox>
                </div>
                <div class="busquedaBoton">
                    <span>&nbsp;</span>
                    <asp:Button ID="btnBuscar" CssClass="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
                <asp:GridView ID="gdvPersonas" CssClass="miTabla" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                        <asp:BoundField DataField="Extension" HeaderText="Extensión" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    </Columns>
                </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div> <%--Fin de Div Principal--%>
</asp:Content>
