<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="TiposArreglos.aspx.cs" Inherits="ControlServidores.Web.Catalogos.TiposArreglos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">6</div>
    <div class="ttlPrincipal">
        <h1>Tipos de Arreglos de Discos</h1>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="addNuevo">
                <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                <asp:Button ID="btnNuevo" CssClass="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>
            </div>
            <asp:Panel ID="pnlFormulario" CssClass="miFormulario" runat="server">
                <div class="formCampos">
                    <asp:HiddenField ID="lblIdTipoArreglo" runat="server" />
                    <div class="grpInput">
                        <label>Tipo de Arreglo</label>
                        <asp:TextBox ID="txtTipoArreglo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoArreglo" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtTipoArreglo" ForeColor="Red" ValidationGroup="TiposArreglos"></asp:RequiredFieldValidator>
                    </div>
                    <div class="grpInput">
                        <label>Descripción</label>
                        <asp:TextBox ID="txtTipoArregloDesc" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="TiposArreglos"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlTipoArreglo" runat="server">
                <asp:GridView ID="gdvTiposArreglos" runat="server" CssClass="miTabla6" AutoGenerateColumns="False" OnRowDataBound="gdvTiposArreglos_RowDataBound" OnRowDeleting="gdvTiposArreglos_RowDeleting" OnSelectedIndexChanged="gdvTiposArreglos_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdTipoArreglo" HeaderText="IdTipoArreglo">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo de Arreglo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
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
</div> <%--Fin de Div Principal--%>
</asp:Content>

