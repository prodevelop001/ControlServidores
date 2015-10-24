﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemasOperativosC.ascx.cs" Inherits="ControlServidores.Web.Controles.SistemasOperativosC" %>
<div>
    <div class="agregarNuevo">
        <asp:Button ID="btnAdd" runat="server" Text="Add" />
    </div>
    <asp:Panel ID="pnlForm" runat="server">
        <label>Sistema Operativo</label>
        <div>
            <asp:DropDownList ID="ddlSO" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlSO" runat="server">
        <asp:GridView ID="gdvSO" runat="server" CssClass="miTabla6" AutoGenerateColumns="False" EmptyDataText="Sin SOs registrados.">
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
                <%--<asp:BoundField DataField="Estatus._Estatus" HeaderText="Estado" />--%>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</div>
