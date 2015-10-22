<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="TipoStorage.aspx.cs" Inherits="ControlServidores.Web.Catalogos.TipoStorage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">5</div>
    <div class="ttlPrincipal">
        <h1>Tipo de Storage</h1>
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
                    <asp:HiddenField ID="lblIdTipoStorage" runat="server" />
                    <div class="grpInput">
                        <label>Tipo de Storage</label>
                        <asp:TextBox ID="txtTipoStorage" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoStorage" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtTipoStorage" ForeColor="Red" ValidationGroup="TiposStorage"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="TiposStorage"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlTipoStorage" runat="server">
                <asp:GridView ID="gdvTiposStorage" runat="server" CssClass="miTabla5" AutoGenerateColumns="False" OnRowDataBound="gdvTiposStorage_RowDataBound" OnRowDeleting="gdvTiposStorage_RowDeleting" OnSelectedIndexChanged="gdvTiposStorage_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdTipoStorage" HeaderText="IdTipoStorage">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo de Storage" />
                        <asp:CommandField SelectText=" Seleccionar" ShowSelectButton="True" />
                        <asp:CommandField DeleteText=" Eliminar" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div> <%--Fin de Div Principal--%>
</asp:Content>
