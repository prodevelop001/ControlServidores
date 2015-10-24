<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StorageC.ascx.cs" Inherits="ControlServidores.Web.Controles.StorageC" %>
<div>
    <div class="agregarNuevo">
        <asp:Button ID="btnAdd" runat="server" Text="Add" />
    </div>
    <asp:Panel ID="pnlForm" runat="server">
        <div class="formCampos">
            <label>Tipo Storage: </label>
            <asp:DropDownList ID="ddlTipoStorageForm" runat="server"></asp:DropDownList>
        </div>
        <div class="formCampos">
            <label>Capacidad Asignada: </label>
            <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
        </div>
        <div class="formBotones">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlStorage" runat="server">
        <div class="formCampos">
            <div class="grpInput">
                <label>Tipo Storage: </label>
                <asp:DropDownList ID="ddlTipoStorage" runat="server"></asp:DropDownList>
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
                <asp:BoundField DataField="IdServidor" HeaderText="IdServidor">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="IdTipoStorage" HeaderText="IdTipoStorage">
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
</div>