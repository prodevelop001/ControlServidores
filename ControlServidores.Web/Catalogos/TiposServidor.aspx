<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="TiposServidor.aspx.cs" Inherits="ControlServidores.Web.Catalogos.TiposServidor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">6</div>
    <div class="ttlPrincipal">
        <h1>Tipos de Servidor</h1>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <div class="addNuevo">
                <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                <asp:Button ID="btnNuevo" CssClass="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>
            </div>
            <asp:Panel ID="pnlFormulario" CssClass="miFormulario" runat="server">
                <div class="formCampos">
                    <asp:HiddenField ID="lblIdTipoServidor" runat="server" />
                    <div class="grpInput">
                        <label>Tipo de Servidor :</label>
                        <asp:TextBox ID="txtTipoServidor" runat="server" placeholder="Ej: VM"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoServidor" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtTipoServidor" ForeColor="Red" ValidationGroup="TiposServidores"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Descripción :</label>
                        <asp:TextBox ID="txtTipoServidorDesc" runat="server" placeholder="Ej: Equipo Virtual"></asp:TextBox>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="TiposServidores"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlTipoServidor" runat="server">
                <asp:GridView ID="gdvTiposServidores" runat="server" CssClass="miTabla" AutoGenerateColumns="False" OnRowDataBound="gdvTiposServidores_RowDataBound" OnRowDeleting="gdvTiposServidores_RowDeleting" OnSelectedIndexChanged="gdvTiposServidores_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdTipoServidor" HeaderText="IdTipoServidor">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo de Arreglo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:CommandField ControlStyle-CssClass="icon-pencil" SelectText=" Seleccionar" ShowSelectButton="True" />
                        <asp:CommandField ControlStyle-CssClass="icon-cross" DeleteText=" Eliminar" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div> <%--Fin de Div Principal--%>
</asp:Content>
