<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlmacenamientoC.ascx.cs" Inherits="ControlServidores.Web.Controles.AlmacenamientoC" %>
<div>
    <div>
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdAlmacenamiento" runat="server" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
        <asp:Panel ID="pnlForm" runat="server">

        </asp:Panel>
        <asp:Panel ID="pnlAlmacenamiento" runat="server">
            <asp:GridView ID="gdvAlmacenamiento" runat="server">

            </asp:GridView>
        </asp:Panel>
    </div>
</div>