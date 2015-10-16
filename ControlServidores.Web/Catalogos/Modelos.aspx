<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Modelos.aspx.cs" Inherits="ControlServidores.Web.Catalogos.Modelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">6</div>
    <div class="ttlPrincipal">
        <h1>Modelos</h1>
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
                    <asp:HiddenField ID="lblIdModelo" runat="server" />
                    <div class="grpInput">
                        <label>Marca</label>
                        <asp:TextBox ID="txtMarca" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="grpInput">
                        <label>Nombre de Modelo</label>
                        <asp:TextBox ID="txtNombreModelo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombreModelo" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtNombreModelo" ForeColor="Red" ValidationGroup="NombresModelos"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="NombresModelos"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlNombreModelo" runat="server">
                <div class="formCampos">
                    <div class="grpInput">
                        <label>Marca</label>
                        <asp:DropDownList ID="ddlMarca" runat="server" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                <asp:GridView ID="gdvNombreModelo" runat="server" CssClass="miTabla6" AutoGenerateColumns="False" OnRowDataBound="gdvNombreModelo_RowDataBound" OnRowDeleting="gdvNombreModelo_RowDeleting" OnSelectedIndexChanged="gdvNombreModelo_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdModelo" HeaderText="IdModelo">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdMarca" HeaderText="IdMarca">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreModelo" HeaderText="Nombre del Modelo" />
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
