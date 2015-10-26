<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlmacenamientoC.ascx.cs" Inherits="ControlServidores.Web.Controles.AlmacenamientoC" %>
<div>
    <div>
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdAlmacenamiento" runat="server" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    </div>
    <asp:Panel ID="pnlForm" Visible="false" runat="server">

        <label>Nombre de Unidad</label>
        <div>
            <asp:TextBox ID="txtUnidad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUnidad" runat="server" ErrorMessage="*Nombre de unidad requerida." ControlToValidate="txtUnidad" ForeColor="Red" ValidationGroup="Almacenamiento"></asp:RequiredFieldValidator>
        </div>
        <label>Tipo de almacenamiento</label>
        <div>
            <asp:DropDownList ID="ddlTipoAlmacenamiento" runat="server"></asp:DropDownList>
        </div>
        <label>Capacidad</label>
        <div>
            <asp:TextBox ID="txtCapacidad" TextMode="Number" runat="server"></asp:TextBox>
            &nbsp;
                <asp:DropDownList ID="ddlCapacidad" runat="server">
                    <asp:ListItem Text="-- Seleccionar --" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="MB" Value="MB"></asp:ListItem>
                    <asp:ListItem Text="GB" Value="GB"></asp:ListItem>
                    <asp:ListItem Text="TB" Value="TB"></asp:ListItem>
                </asp:DropDownList>
            <br />
            <asp:RequiredFieldValidator ID="rfvCapacidad" runat="server" ErrorMessage="*Capacidad requerida." ControlToValidate="txtCapacidad" ForeColor="Red" ValidationGroup="Almacenamiento"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Almacenamiento" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlAlmacenamiento" runat="server">
        <asp:GridView ID="gdvAlmacenamiento" runat="server" AutoGenerateColumns="False" OnRowDataBound="gdvAlmacenamiento_RowDataBound" OnRowDeleting="gdvAlmacenamiento_RowDeleting" OnSelectedIndexChanged="gdvAlmacenamiento_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IdAlmacenamiento" HeaderText="IdAlmacenamiento">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                <asp:BoundField DataField="TipoMemoria.IdTipoMemoria" HeaderText="IdTipoMemoria">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="TipoMemoria.Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>
