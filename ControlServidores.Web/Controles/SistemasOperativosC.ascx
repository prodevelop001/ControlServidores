<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemasOperativosC.ascx.cs" Inherits="ControlServidores.Web.Controles.SistemasOperativosC" %>
<div>
    <div class="agregarNuevo">
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdSoServidor" runat="server" />
        <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="btnAdd_Click" />
    </div>
    <asp:Panel ID="pnlForm" runat="server" Visible ="false">
        <div class="formCampos">
            <label>Sistema Operativo</label>
            <asp:DropDownList ID="ddlSO" runat="server"></asp:DropDownList>
        </div>
        <div class="formBotones">
            <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlSO" runat="server">
        <asp:GridView ID="gdvSO" runat="server" CssClass="miTabla9" AutoGenerateColumns="False" EmptyDataText="Sin SOs registrados." OnRowDataBound="gdvSO_RowDataBound" OnSelectedIndexChanged="gdvSO_SelectedIndexChanged" OnRowDeleting="gdvSO_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IdSOxServidor" HeaderText="IdSOxServidor">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="SO.NombreSO" HeaderText="Sistema" />
                <asp:BoundField DataField="SO.IdSO" HeaderText="IdSO">
                <HeaderStyle CssClass="hide" />
                <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="hide" HeaderText="#" ItemStyle-CssClass="hide">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="hide" HeaderText="#" ItemStyle-CssClass="hide">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="hide" HeaderText="#" ItemStyle-CssClass="hide">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>
