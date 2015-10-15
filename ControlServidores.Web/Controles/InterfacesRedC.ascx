<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InterfacesRedC.ascx.cs" Inherits="ControlServidores.Web.Controles.InterfacesRedC" %>
<asp:Panel ID="pnlFormIntRed" runat="server">
    <asp:HiddenField ID="hdfEstado" runat="server" />
    <asp:HiddenField ID="hdfIdConfRed" runat="server" />
    <label>Nombre de la interfaz</label>
    <div>
        <asp:TextBox ID="txtInterfazRed" runat="server"></asp:TextBox>
    </div>
    <label>Dirección MAC</label>
    <div>
        <asp:TextBox ID="txtDirMAC" runat="server"></asp:TextBox>
    </div>
    <label>Dirección IP</label>
    <div>
        <asp:TextBox ID="txtDirIP" runat="server"></asp:TextBox>
    </div>
    <label>Masca Sub Red</label>
    <div>
        <asp:TextBox ID="txtMascaraSubRed" runat="server"></asp:TextBox>
    </div>
    <label>Gateway</label>
    <div>
        <asp:TextBox ID="txtGateway" runat="server"></asp:TextBox>
    </div>
    <label>DNS</label>
    <div>
        <asp:TextBox ID="DNS" runat="server"></asp:TextBox>
    </div>
    <label>VLAN</label>
    <div>
        <asp:TextBox ID="txtVlan" runat="server"></asp:TextBox>
    </div>
     <label>Estatus</label>
    <div>
        <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </div>
</asp:Panel>
