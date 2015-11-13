<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BitacoraC.ascx.cs" Inherits="ControlServidores.Web.Controles.BitacoraC" %>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
     function InIEvent() 
        {
            $('#<%= txtFechaProc.ClientID%>').datepicker({
                        changeMonth: true,
                        changeYear: true
            });
        };
        $(document).ready(InIEvent);
</script>
<div>
    <div>
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdBitacora" runat="server" />
        <asp:HiddenField ID="hdfEstado" runat="server" />
        <div class="agregarNuevo">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </div>
    <asp:Panel ID="pnlForm" CssClass="miFormulario" Visible ="false" runat="server">
        <div class="formCampos">
            <label>Fecha de procedimiento :</label>
            <asp:TextBox ID="txtFechaProc" runat="server"></asp:TextBox>
        </div>
        <div class="formCampos">
            <label>Descripción :</label>
            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Rows="5" runat="server" placeholder="Ej: Se convirtió a máquina virtual"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Campo requerido." ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="Bitacora"></asp:RequiredFieldValidator>
        </div>
        <div class="formCampos">
            <label>Observaciones :</label>
            <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Rows="5" runat="server" placeholder="Ej: No tiene IP asignada"></asp:TextBox>
        </div>
        <div class="formBotones">
            <asp:Button ID="btnRegistrar" CssClass="btnGuardar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="Bitacora" />
            <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBitacora" runat="server">
        <asp:GridView ID="gdvBitacora" runat="server" CssClass="miTabla" AutoGenerateColumns="false" OnSelectedIndexChanged="gdvBitacora_SelectedIndexChanged">
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
                <asp:BoundField DataField="Bitacora.DescripcionMantenimiento" HeaderText="Descripción" />
                <asp:BoundField DataField="Bitacora.Observaciones" HeaderText="Observaciones" />
                <asp:CommandField ControlStyle-CssClass="icon-pencil" SelectText=" Seleccionar" ShowSelectButton="True" />
                <asp:CommandField ControlStyle-CssClass="icon-cross" DeleteText=" Eliminar" ShowDeleteButton="False" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>
