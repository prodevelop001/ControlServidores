<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StorageC.ascx.cs" Inherits="ControlServidores.Web.Controles.StorageC" %>
<div>
    <div class="agregarNuevo">
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfStorage" runat="server" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    </div>
    <asp:Panel ID="pnlForm" Visible="false" runat="server">
        <div class="formCampos">
            <label>Tipo Storage: </label>
            <asp:DropDownList ID="ddlTipoStorageForm" runat="server"></asp:DropDownList>
        </div>
        <div class="formCampos">
            <label>Capacidad Asignada: </label>
            <asp:TextBox ID="txtCapacidad" runat="server" TextMode="Number"></asp:TextBox>&nbsp;
            <asp:DropDownList ID="ddlCapacidad" runat="server">
                <asp:ListItem Text="-- Seleccionar --" Value ="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="MB" Value="MB"></asp:ListItem>
                <asp:ListItem Text="GB" Value="GB"></asp:ListItem>
                <asp:ListItem Text="TB" Value ="TB"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:RequiredFieldValidator ID="rfvCapacidadAsignada" runat="server" ErrorMessage="*Asignacion de memoria requerida." ControlToValidate="txtCapacidad" ForeColor="Red" ValidationGroup="Storage"></asp:RequiredFieldValidator>
        </div>
        <div class="formBotones">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Storage" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlStorage" runat="server">
        <div class="formCampos">
            <div class="grpInput">
                <label>Tipo Storage: </label>
                <asp:DropDownList ID="ddlTipoStorage" runat="server" OnSelectedIndexChanged="ddlTipoStorage_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>
        <asp:GridView ID="gdvStorage" runat="server" CssClass="miTabla7" AutoGenerateColumns="False" EmptyDataText="Sin Storage Asignado">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IdStorage" HeaderText="IdStorage">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="TipoStorage.Tipo" HeaderText="Tipo"/>
                <asp:BoundField DataField="TipoStorage.IdTipoStorage" HeaderText="IdTipoStorage">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="CapacidadAsignada" HeaderText="Capacidad Asignada" />
                <%--<asp:BoundField DataField="Estatus._Estatus" HeaderText="Estado" />--%>
                <asp:CommandField SelectText=" Seleccionar" ShowSelectButton="True" />
                <asp:CommandField DeleteText=" Eliminar" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>