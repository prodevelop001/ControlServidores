<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="ControlServidores.Web.Catalogos.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">5</div>
    <div class="ttlPrincipal">
        <h1>Marcas</h1>
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
                    <asp:HiddenField ID="lblIdMarca" runat="server" />
                    <div class="grpInput">
                        <label>Nombre de la Marca</label>
                        <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtMarca" ForeColor="Red" ValidationGroup="Marcas"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="SistemasOperativos"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlMarca" runat="server">
                <asp:GridView ID="gdvMarcas" runat="server" CssClass="miTabla5" AutoGenerateColumns="False" OnRowDataBound="gdvMarcas_RowDataBound" OnRowDeleting="gdvMarcas_RowDeleting" OnSelectedIndexChanged="gdvMarcas_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdMarca" HeaderText="IdMarca">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreMarca" HeaderText="Nombre de la Marca" />
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
