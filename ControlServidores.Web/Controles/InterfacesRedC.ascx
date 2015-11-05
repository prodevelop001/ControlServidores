<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InterfacesRedC.ascx.cs" Inherits="ControlServidores.Web.Controles.InterfacesRedC" %>
<div>
    <div class="agregarNuevo">
        <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="btnAdd_Click" />
    </div>
    <asp:Panel ID="pnlFormIntRed" CssClass="miFormulario" Visible="false" runat="server">
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdConfRed" runat="server" />
        <div class="formCampos">
            <label>Nombre de la interfaz</label>
            <asp:TextBox ID="txtInterfazRed" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombreInterfaz" runat="server" ErrorMessage="*Campo requerido." ControlToValidate="txtInterfazRed" ForeColor="Red" ValidationGroup="InterfazRed"></asp:RequiredFieldValidator>
        </div>
        <div class="formCampos">
            <label>Dirección MAC</label>
            <asp:TextBox ID="txtDirMAC" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revDirMac" runat="server" ErrorMessage="*MAC no valida." ControlToValidate="txtDirMAC" ForeColor="Red" ValidationExpression="^([0-9A-F]{2}[:-]){5}([0-9A-F]{2})$" ValidationGroup="InterfazRed"></asp:RegularExpressionValidator>
        </div>
        <div class="formCampos">
            <label>Dirección IP</label>
            <asp:TextBox ID="txtDirIP" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDirIp" runat="server" ErrorMessage="*IP requerida" ControlToValidate="txtDirIP" ForeColor="Red" ValidationGroup="InterfazRed"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="revDirIP" runat="server" ErrorMessage="*IP no valida." ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="InterfazRed" ControlToValidate="txtDirIP" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
        <div class="formCampos">
            <label>Masca Sub Red</label>
            <asp:TextBox ID="txtMascaraSubRed" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSubNet" runat="server" ErrorMessage="*Sub Red requerida." ControlToValidate="txtMascaraSubRed" ForeColor="Red" ValidationGroup="InterfazRed"></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="revSubNet" runat="server" ErrorMessage="*IP no valida." ControlToValidate="txtMascaraSubRed" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="InterfazRed" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
        <div class="formCampos">
            <label>Gateway</label>
            <asp:TextBox ID="txtGateway" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revGateway" runat="server" ErrorMessage="*IP no valida." ControlToValidate="txtGateway" ForeColor="Red" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="InterfazRed"></asp:RegularExpressionValidator>
        </div>
        <div class="formCampos">
            <label>DNS</label>
            <asp:TextBox ID="txtDNS" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revDNS" runat="server" ErrorMessage="*IP no valida." ControlToValidate="txtDNS" ForeColor="Red" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="InterfazRed"></asp:RegularExpressionValidator>
        </div>
        <div class="formCampos">
            <label>VLAN</label>
            <asp:TextBox ID="txtVlan" runat="server"></asp:TextBox>
        </div>
        <div class="formCampos">
            <label>Estatus</label>
            <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
        </div>
        <div class="formBotones">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btnGuardar" Text="Guardar" ValidationGroup="InterfazRed" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </asp:Panel>
    <asp:GridView ID="gdvInterfacesRed" runat="server" CssClass="miTabla" AutoGenerateColumns="False" EmptyDataText="Sin Interfaces registradas." OnSelectedIndexChanged="gdvInterfacesRed_SelectedIndexChanged" OnRowDataBound="gdvInterfacesRed_RowDataBound" OnRowDeleting="gdvInterfacesRed_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IdConfRed" HeaderText="IdConfRed">
                <HeaderStyle CssClass="hide" />
                <ItemStyle CssClass="hide" />
            </asp:BoundField>
            <asp:BoundField DataField="InterfazRed" HeaderText="Interfaz" />
            <asp:BoundField DataField="DirIp" HeaderText="Dirección IP" />
            <asp:BoundField DataField="MascaraSubRed" HeaderText="SubNet" />
            <asp:BoundField DataField="Estatus.IdEstatus" HeaderText="IdEstatus" >
            <HeaderStyle CssClass="hide" />
            <ItemStyle CssClass="hide" />
            </asp:BoundField>
            <asp:BoundField DataField="Estatus._Estatus" HeaderText="Estado" />
            <asp:CommandField ControlStyle-CssClass="icon-pencil" SelectText=" Seleccionar" ShowSelectButton="True" />
            <asp:CommandField ControlStyle-CssClass="icon-cross" DeleteText=" Eliminar" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>
