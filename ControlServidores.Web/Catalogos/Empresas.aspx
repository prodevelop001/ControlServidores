<%--<%@ Page Title="" Language="C#" MasterPageFile="~/prueba.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="ControlServidores.Web.Empresas" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="ControlServidores.Web.Empresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <div  class="principal">
        <div id="numCols" class="hide">7</div>
        <div class="ttlPrincipal">
            <h1>Empresas</h1>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnNuevo" CssClass="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>
                </div>
                <asp:Panel ID="pnlFormulario" CssClass="miFormulario" runat="server">
                    <div class="formCampos">
                        <asp:HiddenField ID="lblIdNombreEmpresa" runat="server" />
                        <div class="grpInput">
                            <label>Empresa</label>
                            <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmpresa" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtEmpresa" ForeColor="Red" ValidationGroup="Empresas"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmpresaTel" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtTelefono" ForeColor="Red" ValidationGroup="Empresas"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Dirección</label>
                            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="formBotones">
                        <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Empresas"></asp:Button>
                        <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEmpresa" runat="server">
                    <asp:GridView ID="gdvEmpresas" runat="server" CssClass="miTabla7" AutoGenerateColumns="False" EmptyDataText="No Hay Datos" OnSelectedIndexChanged="gdvEmpresas_SelectedIndexChanged" OnRowDataBound="gdvEmpresas_RowDataBound" OnRowDeleting="gdvConceptos_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DisplayIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdEmpresa" HeaderText="IdEmpresa">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <div>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
