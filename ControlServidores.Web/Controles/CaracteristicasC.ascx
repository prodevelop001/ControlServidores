<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaracteristicasC.ascx.cs" Inherits="ControlServidores.Web.Controles.CaracteristicasC" %>
<div>
    <div>
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdModelo" runat="server" />
        <asp:HiddenField ID="hdfIdEspecificacion" runat="server" />
        <asp:HiddenField ID="hdfIdTipoServidor" runat="server" />
        <asp:HiddenField ID="hdfEstatus" runat="server" />
        <asp:Button ID="btnEditar" runat="server" Text="Editar" />
    </div>
    <asp:Panel ID="pnlForm" runat="server">
    </asp:Panel>
    <asp:Panel ID="pnlCaracteristicas" runat="server">

        
            <label>Server name:</label>
            <div>
                <asp:Label ID="lblAliasServidor" runat="server" Text=""></asp:Label>
            </div>
            <label>Descripción:</label>
            <div>
                <asp:Label ID="lblDescripcionUso" runat="server" Text=""></asp:Label>
            </div>
            <label>Tipo de servidor:</label>
            <div>
                <asp:Label ID="lblTipoServidor" runat="server" Text=""></asp:Label>
            </div>
            <label>Modelo:</label>
            <div>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="lblModelo" runat="server" Text=""></asp:Label>
            </div>
            <label>Procesador:</label>
            <div>
                <asp:Label ID="lblProcesador" runat="server" Text=""></asp:Label>
            </div>
            <label>Número de procesadores:</label>
            <div>
                <asp:Label ID="lblNumProcesadores" runat="server" Text=""></asp:Label>
            </div>
            <label>Capacidad de RAM:</label>
            <div>
                <asp:Label ID="lblCapacidadRam" runat="server" Text=""></asp:Label>
            </div>
            <label>Arreglo de discos:</label>
            <div>
                <asp:Label ID="lblArregloDiscos" runat="server" Text=""></asp:Label>
            </div>
            <label>Soporte:</label>
            <div>
                <asp:Label ID="lblSoporte" runat="server" Text="Sin Soporte"></asp:Label>
            </div>

    </asp:Panel>
</div>
