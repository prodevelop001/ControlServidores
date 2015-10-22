<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Estatus.aspx.cs" Inherits="ControlServidores.Web.Catalogos.Estatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">6</div>
    <div class="ttlPrincipal">
        <h1>Estatus</h1>
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
                    <asp:HiddenField ID="lblIdEstatus" runat="server" />
                    <div class="grpInput">
                        <div class="grpInput">
                        <label>Concepto Estatus</label>
                        <asp:DropDownList ID="ddlConceptoEstatusForm" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    </div>
                    <div class="grpInput">
                        <label>Nombre del Estatus</label>
                        <asp:TextBox ID="txtNombreEstatus" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombreEstatus" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtNombreEstatus" ForeColor="Red" ValidationGroup="NombresEstatus"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="NombresEstatus"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlNombreEstatus" runat="server">
                <div class="formCampos">
                    <div class="grpInput">
                        <label>Concepto Estatus</label>
                        <asp:DropDownList ID="ddlConceptoEstatus" runat="server" OnSelectedIndexChanged="ddlConceptoEstatus_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                <asp:GridView ID="gdvNombreEstatus" runat="server" CssClass="miTabla6" AutoGenerateColumns="False" OnRowDataBound="gdvNombreEstatus_RowDataBound" OnRowDeleting="gdvNombreEstatus_RowDeleting" OnSelectedIndexChanged="gdvNombreEstatus_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdEstatus" HeaderText="IdEstatus">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdConceptoEstatus" HeaderText="IdConceptoEstatus">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="_Estatus" HeaderText="Nombre del Estatus" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                        <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div> <%--Fin de Div Principal--%>
</asp:Content>
