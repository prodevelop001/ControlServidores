﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BitacoraC.ascx.cs" Inherits="ControlServidores.Web.Controles.BitacoraC" %>
<div>
    <div>
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdBitacora" runat="server" />
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    </div>
    <asp:Panel ID="pnlForm" Visible ="false" runat="server">
        <label>Fecha de procedimiento</label>
        <div>
            <asp:TextBox ID="txtFechaProc" runat="server"></asp:TextBox>
        </div>
        <label>Descripción</label>
        <div>
            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Campo requerido." ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="Bitacora"></asp:RequiredFieldValidator>
        </div>
        <label>Observaciones</label>
        <div>
            <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="Bitacora" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBitacora" runat="server">
        <asp:GridView ID="gdvBitacora" runat="server" CssClass="miTabla9" AutoGenerateColumns="false" OnSelectedIndexChanged="gdvBitacora_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Bitacora.IdBitacora" HeaderText="IdBitacora">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="Personas.IdPersona" HeaderText="IdPersona">
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                </asp:BoundField>
                <asp:BoundField DataField="Personas.Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Bitacora.FechaCaptura" HeaderText="Fecha de Captura" />
                <asp:BoundField DataField="Bitacora.FechaMantenimiento" HeaderText="Fecha de procedimiento" />
                <asp:BoundField DataField="Bitacora.DescripcionMantenimiento" HeaderText="Descripcion" />
                <asp:BoundField DataField="Bitacora.Observaciones" HeaderText="Observaciones" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>